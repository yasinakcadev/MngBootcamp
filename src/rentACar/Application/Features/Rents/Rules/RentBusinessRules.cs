using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;

namespace Application.Features.Rents.Rules;

public class RentBusinessRules
{
    private IRentRepository _rentRepository;

    public RentBusinessRules(IRentRepository rentRepository)
    {
        _rentRepository = rentRepository;
    }

    public Task MustNotBeNull(DateTime startDate,DateTime endDate)
    {
        if(startDate == default || endDate == default)
            throw new BusinessException("Must Not Be Null");
        return Task.CompletedTask;
    }
    public Task MustBeEndDateGreaterThanStartDate(DateTime startDate, DateTime endDate)
    {
        if (!(endDate > startDate))
            throw new BusinessException("Must Be EndDate Greater Than Start Date");
        return Task.CompletedTask;
    }
}