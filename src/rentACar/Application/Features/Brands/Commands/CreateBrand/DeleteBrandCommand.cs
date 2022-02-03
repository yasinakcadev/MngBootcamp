using Application.Services.Repositories;
using Core.Application.Response;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;

namespace Application.Features.Brands.Commands;

public class DeleteBrandCommand : IRequest<NoContent>
{
    public int Id { get; set; }

    public class DeleteBrandHandler : IRequestHandler<DeleteBrandCommand, NoContent>
    {
        private IBrandRepository _brandRepository;

        public DeleteBrandHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<NoContent> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetAsync(x => x.Id == request.Id);

            if (brand == null) throw new BusinessException("Brand cannot found");

            await _brandRepository.DeleteAsync(brand);

            return new NoContent();
        }
    }
}