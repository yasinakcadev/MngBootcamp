using Application.Services.Repositories;
using Core.Application.Response;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;

namespace Application.Features.Color.Commands
{
    public class DeleteColorCommand : IRequest<NoContent>
    {
        public int Id { get; set; }

        public class DeleteColorCommandHandler : IRequestHandler<DeleteColorCommand, NoContent>
        {
            private IColorRepository _colorRepository;

            public DeleteColorCommandHandler(IColorRepository colorRepository)
            {
                _colorRepository = colorRepository;
            }

            public async Task<NoContent> Handle(DeleteColorCommand request, CancellationToken cancellationToken)
            {
                var color = await _colorRepository.GetAsync(c => c.Id == request.Id);
                if (color == null)
                    throw new BusinessException("Color not found");
                await _colorRepository.DeleteAsync(color);
                return new NoContent();
            }
        }
    }
}
