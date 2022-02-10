using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;

namespace Application.Features.Rents.Rules;

public class RentBusinessRules
{
    private IRentRepository _rentRepository;
    IFindexScoreRepository _findexScoreRepository;
    ICarRepository _carRepository;

    public RentBusinessRules(IRentRepository rentRepository, IFindexScoreRepository findexScoreRepository,
    ICarRepository carRepository)
    {
        _rentRepository = rentRepository;
        _findexScoreRepository = findexScoreRepository;
        _carRepository = carRepository;
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
    public async Task<bool> CustomersFindexScoreMustBeGreaterOrEqualToCarsMinFindexScore(int customerId, int carId)
    {
        var findexScoreOfTheCustomer = await _findexScoreRepository.GetAsync(c => c.CustomerId == customerId);
        if (findexScoreOfTheCustomer == null) throw new BusinessException("Customer has to have a findex score to rent a car");
        var car = await _carRepository.GetAsync(c => c.Id == carId);
        var carMinFindexScore = car.MinFindexScore;
        var customerFindexScore = findexScoreOfTheCustomer.Score;


        if (customerFindexScore <= carMinFindexScore)
            throw new BusinessException("Customer's Findex Score Must Be GreaterOrEqual To Car's MinFindexScore");
        return true;
    }

}