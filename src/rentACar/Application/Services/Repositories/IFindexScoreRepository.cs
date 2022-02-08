using Core.Persistence.Repositories;
using Domain.Entities;
using Domain.FindexScore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Repositories
{
    public interface IFindexScoreRepository : IAsyncRepository<FindexScore>
    {
    }
}
