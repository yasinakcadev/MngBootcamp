using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;

namespace Application.Features.Brands.Rules;

public class BrandBusinessRules
{
    IBrandRepository _brandRepository;

    public BrandBusinessRules(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task BrandNameCanNotBeDuplicatedWhenInsertedAndUpdated(string name)
    {
        var result = await _brandRepository.GetListAsync(b => b.Name == name);
        if (result.Items.Any())
        {
            throw new BusinessException("Brand name exists");
        }
    }
}