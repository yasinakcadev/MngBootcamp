using Application.Features.Cars.Commands;
using Application.Features.Cars.Queries;
using Application.Features.Cars.Rules;

using Application.Features.Rents.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Rents.Command;

public class CreateRentCommand : IRequest<Domain.Entities.Rent>
{
    public int CustomerId { get; set; }
    public int InvoiceId { get; set; }
    public int GivingCityId { get; set; }
    public int TakingCityId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<int> CarIds { get; set; }

    public class CreateRentCommandHandler : IRequestHandler<CreateRentCommand, Domain.Entities.Rent>
    {
        private RentBusinessRules _rentBusinessRules;
        private IRentRepository _rentRepository;
        private IMapper _mapper;
        private IMediator _mediator;



        public async Task<Domain.Entities.Rent> Handle(CreateRentCommand request, CancellationToken cancellationToken)
        {
            await _rentBusinessRules.MustNotBeNull(request.StartDate,request.EndDate);
            await _rentBusinessRules.MustBeEndDateGreaterThanStartDate(request.StartDate,request.EndDate);

            //var cars = await _mediator.Send(new GetCarListByIdsQuery(){CarIds = request.CarIds});

            var rent = _mapper.Map<Domain.Entities.Rent>(request);

            //var total = cars.Items.Sum(x => x.Model.DailyPrice * request.TotalRentDay);
            //rent.CarId = cars.Items;

            await _rentRepository.AddAsync(rent);

            return rent;
        }
    }
}