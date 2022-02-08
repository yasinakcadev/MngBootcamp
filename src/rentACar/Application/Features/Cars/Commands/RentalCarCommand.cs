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
        public int CustomerId { get; set; }
        public int TotalRentDay { get; set; }


        public class RentalCarCommandHandler : IRequestHandler<RentalCarCommand, CarDto>
        {
            private CarBusinessRules _carBusinessRule;
            private ICarRepository _carRepository;
            IFindexScoreRepository _findexScoreRepository;
            IFindexCreditService _findexCreditService;
            private IMediator _mediator;
            private IMapper _mapper;
            private IRentRepository _rentRepository;



            public RentalCarCommandHandler(CarBusinessRules carBusinessRule, ICarRepository carRepository, IFindexCreditService findexCreditService, IFindexScoreRepository findexScoreRepository)
            {
                _carBusinessRule = carBusinessRule;
                _carRepository = carRepository;
                _findexScoreRepository = findexScoreRepository;
                _findexCreditService = findexCreditService;
                _mapper = mapper;
                _mediator = mediator;
                _rentRepository = rentRepository;
            }

            public async Task<CarDto> Handle(RentalCarCommand request, CancellationToken cancellationToken)
            {
                await _carBusinessRule.IsExist(request.Id);
                await _carBusinessRule.IsCarCityExist(request.TakingCityId);
                await _carBusinessRule.IsCarCityExist(request.GivingCityId);
                await _carBusinessRule.CarCanNotBeRentWhenIsInMaintenance(request.Id);

                //var car = await _carRepository.GetAsync(c => c.Id == request.Id);

                var cars = await _carRepository.GetListAsync(include: x => x.Include(x => x.Model),
                    predicate: c => c.Id == request.Id);
                var car = cars.Items.FirstOrDefault();
                if (car == null)
                    throw new BusinessException("Car cannot find");

                car.CarState = Domain.Enums.CarState.Rented;
                await _carRepository.UpdateAsync(car);

                Random rnd = new Random();
                var command = new CreateInvoiceCommand()
                {
                    InvoiceNo = rnd.Next(100000),
                    CreationDate = DateTime.Now,
                    RentStartDate = DateTime.Now,
                    RentEndDate = DateTime.Now.AddDays(request.TotalRentDay),
                    TotalRentDay = request.TotalRentDay,
                    TotalRentAmount = car.Model.DailyPrice * request.TotalRentDay,
                    CustomerId = request.CustomerId,
                };

                var invoice = await _mediator.Send(command);

                var rent = new Domain.Entities.Rent(request.Id, request.CustomerId,
                    DateTime.Now.AddDays(request.TotalRentDay),
                    request.GivingCityId, invoice.Id, DateTime.Now, request.TakingCityId,
                    car.CurrentIndicatorValueAsKilometer);

                await _rentRepository.AddAsync(rent);

                var dto = _mapper.Map<CarDto>(car);

                return dto;
            }
        }
    }
}