using Application.Services.Repositories;
using Core.Application.Response;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Fuel.Commands
{
    public class DeleteFuelCommand: IRequest<NoContent>
    {
        public int Id { get; set; }

        public class DeleteFuelHandler : IRequestHandler<DeleteFuelCommand, NoContent>
        {
            private IFuelRepository _fuelRepository;

            public DeleteFuelHandler(IFuelRepository fuelRepository)
            {
                _fuelRepository = fuelRepository;
            }

            public async Task<NoContent> Handle(DeleteFuelCommand request, CancellationToken cancellationToken)
            {
                var fuel = await _fuelRepository.GetAsync(f => f.Id == request.Id);
                if (fuel == null)
                    throw new BusinessException("Fuel cannot found");

                await _fuelRepository.DeleteAsync(fuel);
                return new NoContent();
            }
        }
    }
}
