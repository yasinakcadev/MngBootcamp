using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Response;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;

namespace Application.Features.Transmissions.Commands
{
    public class DeleteTransmissionCommand : IRequest<NoContent>
    {
        public int Id { get; set; }

        public class DeleteTransmissionCommandHandler : IRequestHandler<DeleteTransmissionCommand, NoContent>
        {
            private IMapper _mapper;
            private ITransmissionRepository _transmissionRepository;

            public DeleteTransmissionCommandHandler(IMapper mapper, ITransmissionRepository transmissionRepository)
            {
                _mapper = mapper;
                _transmissionRepository = transmissionRepository;
            }

            public async Task<NoContent> Handle(DeleteTransmissionCommand request, CancellationToken cancellationToken)
            {
                var transmission = await _transmissionRepository.GetAsync(t => t.Id == request.Id);
                if (transmission == null) throw new BusinessException("Transmission cannot found");
                await _transmissionRepository.DeleteAsync(transmission);
                return new NoContent();
            }
        }
    }
}
