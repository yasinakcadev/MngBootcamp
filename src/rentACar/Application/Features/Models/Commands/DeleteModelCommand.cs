using Application.Services.Repositories;
using Core.Application.Response;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Commands
{
    public class DeleteModelCommand: IRequest<NoContent>
    {
        public int Id { get; set; }

        public class DeleteModelCommandHandler : IRequestHandler<DeleteModelCommand, NoContent>
        {
            IModelRepository _modelRepository;

            public DeleteModelCommandHandler(IModelRepository modelRepository)
            {
                _modelRepository = modelRepository;
            }

            public async Task<NoContent> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
            {
                var model = await _modelRepository.GetAsync(m => m.Id == request.Id);
                if (model == null)
                    throw new BusinessException("Model cannot found");
                await _modelRepository.DeleteAsync(model);
                return new NoContent();
            }
        }


    }
}
