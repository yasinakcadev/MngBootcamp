﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CredibilityServices
{
    public interface IFindexCreditService
    {
        short GetFindexScore(int Id);
    }
}
