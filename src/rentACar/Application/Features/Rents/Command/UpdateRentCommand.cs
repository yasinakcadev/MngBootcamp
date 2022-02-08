using Application.Features.Rents.Rules;
using Application.Services.Repositories;
using Core.Application.Response;
using Domain.Entities;
using MediatR;

namespace Application.Features.Rents.Command;

public class UpdateRentCommand : IRequest<NoContent>
{
    public Rent Rent { get; set; }

    public class UpdateRentCommandHandler : IRequestHandler<UpdateRentCommand, NoContent>
    {
        private RentBusinessRules _rentBusinessRules;
        private IRentRepository _rentRepository;


        public UpdateRentCommandHandler(RentBusinessRules rentBusinessRules, IRentRepository rentRepository)
        {
            _rentBusinessRules = rentBusinessRules;
            _rentRepository = rentRepository;
        }

        public async Task<NoContent> Handle(UpdateRentCommand request, CancellationToken cancellationToken)
        {
            await _rentRepository.UpdateAsync(request.Rent);

            return new NoContent();
        }
    }
}