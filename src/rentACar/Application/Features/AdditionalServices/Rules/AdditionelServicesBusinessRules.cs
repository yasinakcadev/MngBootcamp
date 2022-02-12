using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;

namespace Application.Features.AdditionalServices.Rules;

public class AdditionelServicesBusinessRules
{
    private IAdditionalServiceRepository _additionalServiceRepository;

    public AdditionelServicesBusinessRules(IAdditionalServiceRepository additionalServiceRepository)
    {
        _additionalServiceRepository = additionalServiceRepository;
    }

    public async Task AdditionalServiceNameCannotDublicatedWhenInsertedOrUpdated(string name)
    {
        var additionalServices = await _additionalServiceRepository.GetListAsync(predicate: a => a.Name == name);
        if (additionalServices.Items.Any())
            throw new BusinessException("Additional Service Name Cannot Dublicated");
    }


}