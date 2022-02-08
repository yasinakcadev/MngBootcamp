using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Domain.FindexScore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class FindexScoreRepository : EfRepositoryBase<FindexScore, BaseDbContext>, IFindexScoreRepository
    {
        public FindexScoreRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
