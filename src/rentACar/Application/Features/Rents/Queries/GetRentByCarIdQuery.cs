using Application.Features.Cars.Models;
using Application.Features.Cars.Queries;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Rents.Queries;

public class GetRentByCarIdQuery : IRequest<Rent>
{
    public int CarId { get; set; }

    public class GetRentByCarIdQueryHandler : IRequestHandler<GetRentByCarIdQuery, Rent>
    {
        private IRentRepository _rentRepository;

        public GetRentByCarIdQueryHandler(IRentRepository rentRepository)
        {
            _rentRepository = rentRepository;
        }

        public async Task<Rent> Handle(GetRentByCarIdQuery request, CancellationToken cancellationToken)
        {
            var rents = await _rentRepository.GetListAsync(predicate:x => x.CarId == request.CarId && !x.IsCompleted,orderBy:x => x.OrderByDescending(x => x.EndDate));
            return rents.Items.FirstOrDefault();
        }
    }
}
