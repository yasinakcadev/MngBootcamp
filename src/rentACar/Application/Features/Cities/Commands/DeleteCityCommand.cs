using Application.Services.Repositories;
using Core.Application.Response;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cities.Commands
{
    public class DeleteCityCommand : IRequest<NoContent>
    {
        public int Id { get; set; }

        public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, NoContent>
        {
            private ICityRepository _cityRepository;

            public DeleteCityCommandHandler(ICityRepository cityRepository)
            {
                _cityRepository = cityRepository;
            }

            public async Task<NoContent> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
            {
                var city = await _cityRepository.GetAsync(c => c.Id == request.Id);
                if (city == null)
                    throw new BusinessException("City not found");
                await _cityRepository.DeleteAsync(city);
                return new NoContent();
            }
        }
    }
}
