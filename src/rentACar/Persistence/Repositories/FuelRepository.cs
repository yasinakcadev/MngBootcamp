﻿using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class FuelRepository : EfRepositoryBase<Fuel, BaseDbContext>, IFuelRepository
    {
        public FuelRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
