﻿using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Caching;
using Core.Mailing;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands;

public class CreateBrandCommand : IRequest<Brand>,ILoggableRequest
{
    public string Name { get; set; }

    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, Brand>
    {
        IBrandRepository _brandRepository;
        IMapper _mapper;
        BrandBusinessRules _brandBusinessRules;
        IMailService _mailService;
        ICacheService _cacheService;


        public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper,
            BrandBusinessRules brandBusinessRules, IMailService mailService, ICacheService cacheService)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
            _brandBusinessRules = brandBusinessRules;
            _mailService = mailService;
            _cacheService= cacheService;
        }

        public async Task<Brand> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            await _brandBusinessRules.BrandNameCanNotBeDuplicatedWhenInsertedAndUpdated(request.Name);

            var mappedBrand = _mapper.Map<Brand>(request);

            var createdBrand = await _brandRepository.AddAsync(mappedBrand);
            var mail = new Mail { 
                ToFullName = "system admins",
                ToEmail = "admins@mng.com.tr",
                Subject = "New Brand Added",
                HtmlBody = "Hey, check the system!"
            };
            // _mailService.sendMail(mail);
            _cacheService.Remove("brands-list");
            return createdBrand;
        }
    }
}