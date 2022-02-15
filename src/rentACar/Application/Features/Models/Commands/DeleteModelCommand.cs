using Application.Services.Repositories;
using Core.Application.Response;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;

namespace Application.Features.Models.Commands;

public class DeleteModelCommand : IRequest<NoContent>
{
    public int Id { get; set; }

    public class DeleteModelHandler : IRequestHandler<DeleteModelCommand, NoContent>
    {
        private IModelRepository _modelRepository;

        public DeleteModelHandler(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }

        public async Task<NoContent> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
        {
            var model = await _modelRepository.GetAsync(x => x.Id == request.Id);

            if (model == null) throw new BusinessException("Model cannot found");

            await _modelRepository.DeleteAsync(model);

            return new NoContent();
        }
    }
}