using Application.Features.Cars.Rules;
using Application.Services.CredibilityServices;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Cars.Dtos;
using Application.Features.Invoices.Commands;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Cars.Commands
{
    public class RentalCarCommand : IRequest<CarDto>
    {
        public int Id { get; set; }
        public int TakingCityId { get; set; }
        public int GivingCityId { get; set; }
        public int UserId { get; set; }
        public int TotalRentDay { get; set; }

        public List<int> AdditionalServices { get; set; }

        public class RentalCarCommandHandler : IRequestHandler<RentalCarCommand, CarDto>
        {
            private CarBusinessRules _carBusinessRule;
            private ICarRepository _carRepository;
            private IMediator _mediator;
            private IMapper _mapper;
            private IRentRepository _rentRepository;
            private IAdditionalServiceRepository _additionalServiceRepository;

            public RentalCarCommandHandler(IAdditionalServiceRepository additionalServiceRepository,
                CarBusinessRules carBusinessRule, ICarRepository carRepository, IMapper mapper, IMediator mediator,
                IRentRepository rentRepository)
            {
                _additionalServiceRepository = additionalServiceRepository;
                _carBusinessRule = carBusinessRule;
                _carRepository = carRepository;
                _mapper = mapper;
                _mediator = mediator;
                _rentRepository = rentRepository;
            }

            public async Task<CarDto> Handle(RentalCarCommand request, CancellationToken cancellationToken)
            {
                await _carBusinessRule.IsExist(request.Id);
                await _carBusinessRule.IsCarCityExist(request.TakingCityId);
                await _carBusinessRule.IsCarCityExist(request.GivingCityId);
                await _carBusinessRule.CarCanNotBeRentWhenIsInMaintenanceOrRented(request.Id);

                //var car = await _carRepository.GetAsync(c => c.Id == request.Id);

                var cars = await _carRepository.GetListAsync(include: x => x.Include(x => x.Model),
                    predicate: c => c.Id == request.Id);

                var car = cars.Items.FirstOrDefault();
                if (car == null)
                    throw new BusinessException("Car cannot find");

                car.CarState = Domain.Enums.CarState.Rented;
                await _carRepository.UpdateAsync(car);

                double additionalServicesTotalAmount = 0;
                List<AdditionalService> additionalServices = default;

                if (request.AdditionalServices != null)
                {
                    var additionalServicesList =
                        await _additionalServiceRepository.GetListAsync(x => request.AdditionalServices.Contains(x.Id));

                    additionalServices = additionalServicesList.Items.ToList();

                    foreach (var additionalService in additionalServicesList.Items)
                    {
                        additionalServicesTotalAmount += additionalService.DailyPrice * request.TotalRentDay;
                    }
                }

                int cityExtentPrice = request.TakingCityId == request.GivingCityId ? 0 : 500;

                Random rnd = new Random();
                var command = new CreateInvoiceCommand()
                {
                    InvoiceNo = rnd.Next(100000),
                    CreationDate = DateTime.Now,
                    RentStartDate = DateTime.Now,
                    RentEndDate = DateTime.Now.AddDays(request.TotalRentDay),
                    TotalRentDay = request.TotalRentDay,
                    TotalRentAmount = (car.Model.DailyPrice * request.TotalRentDay) + cityExtentPrice,
                    AdditionalRentAmount = additionalServicesTotalAmount,
                    UserId = request.UserId,
                };

                var invoice = await _mediator.Send(command);

                var rent = new Domain.Entities.Rent(request.Id, request.UserId,
                    DateTime.Now.AddDays(request.TotalRentDay),
                    request.GivingCityId, invoice.Id, DateTime.Now, request.TakingCityId,
                    car.CurrentIndicatorValueAsKilometer);

                rent.AdditionalServices = additionalServices;

                await _rentRepository.AddAsync(rent);

                var dto = _mapper.Map<CarDto>(car);

                return dto;
            }
        }
    }
}