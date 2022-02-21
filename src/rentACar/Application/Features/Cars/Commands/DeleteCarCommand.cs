using Application.Services.Repositories;
using Core.Application.Response;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Commands
{
    public class DeleteCarCommand: IRequest<NoContent>
    {
        public int Id { get; set; }

        public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, NoContent>
        {
            ICarRepository _carRepository;

            public DeleteCarCommandHandler(ICarRepository carRepository)
            {
                _carRepository = carRepository;
            }

            public async Task<NoContent> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
            {
                var car = await _carRepository.GetAsync(c => c.Id == request.Id);
                if (car == null) throw new BusinessException("Car does not exists");
                await _carRepository.DeleteAsync(car);
                return new NoContent();
            }
        }
    }
}
