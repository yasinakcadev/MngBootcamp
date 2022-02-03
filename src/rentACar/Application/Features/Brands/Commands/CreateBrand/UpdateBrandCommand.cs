using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands;

public class UpdateBrandCommand : IRequest<BrandDto>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public class UpdateBrandHandler : IRequestHandler<UpdateBrandCommand, BrandDto>
    {
        private IBrandRepository _brandRepository;
        private IMapper _mapper;
        private BrandBusinessRules _brandBusinessRules;

        public UpdateBrandHandler(BrandBusinessRules brandBusinessRules, IBrandRepository brandRepository, IMapper mapper)
        {
            _brandBusinessRules = brandBusinessRules;
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<BrandDto> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetAsync(x => x.Id == request.Id);

            if (brand == null)
                throw new BusinessException("Brand cannot found");

            await _brandBusinessRules.BrandNameCanNotBeDuplicatedWhenInsertedAndUpdated(request.Name);

            _mapper.Map(request, brand);

            await _brandRepository.UpdateAsync(brand);

            var dto = _mapper.Map<BrandDto>(brand);

            return dto;
        }
    }

}