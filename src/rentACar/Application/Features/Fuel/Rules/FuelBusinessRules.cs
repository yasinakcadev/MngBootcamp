using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;

namespace Application.Features.Brands.Rules;

public class FuelBusinessRules
{
    private IFuelRepository _fuelRepository;

    public FuelBusinessRules(IFuelRepository fuelRepository)
    {
        _fuelRepository = fuelRepository;
    }

    public async Task FuelNameCanNotBeDuplicatedWhenInsertedAndUpdated(string name)
    {
        var fuels = await _fuelRepository.GetListAsync(x => x.Name == name);
        if (fuels.Items.Any())
        {
            throw new BusinessException("Fuel Name Dublicated");
        }
    }
}