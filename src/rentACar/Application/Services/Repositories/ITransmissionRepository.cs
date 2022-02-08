using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Repositories
{
    public interface ITransmissionRepository: IAsyncRepository<Domain.Entities.Transmission>
    {
    }
}
