﻿using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transmission.Rules
{
    public class TransmissionBusinessRules
    {
        ITransmissionRepository _transmissionRepository;

        public TransmissionBusinessRules(ITransmissionRepository transmissionRepository)
        {
            _transmissionRepository = transmissionRepository;
        }

        public async Task TransmissionNameCanNotBeDuplicatedWhenInsertedAndUpdated(string name)
        {
            var result = await _transmissionRepository.GetListAsync(t => t.Name == name);
            if (result.Items.Any())
                throw new BusinessException("Transmission name exists");
        }
    }
}
