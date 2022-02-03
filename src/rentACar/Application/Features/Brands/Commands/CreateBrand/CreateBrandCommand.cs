using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands;

public class CreateBrandCommand : IRequest<Brand>
{
    public string Name { get; set; }

    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, Brand>
    {
        IBrandRepository _brandRepository;
        IMapper _mapper;
        BrandBusinessRules _brandBusinessRules;

        public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper,
            BrandBusinessRules brandBusinessRules)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
            _brandBusinessRules = brandBusinessRules;
        }

        public async Task<Brand> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            await _brandBusinessRules.BrandNameCanNotBeDuplicatedWhenInsertedAndUpdated(request.Name);

            var mappedBrand = _mapper.Map<Brand>(request);

            var createdBrand = await _brandRepository.AddAsync(mappedBrand);
            return createdBrand;
        }
    }
}