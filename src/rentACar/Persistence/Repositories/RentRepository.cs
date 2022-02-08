using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;

namespace Persistence.Repositories;

public class RentRepository : EfRepositoryBase<Rent, BaseDbContext>,IRentRepository
{
    public RentRepository(BaseDbContext context) : base(context)
    {
    }
}