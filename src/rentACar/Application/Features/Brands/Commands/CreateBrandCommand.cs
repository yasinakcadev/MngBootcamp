﻿using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Mailing;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands;

public class CreateBrandCommand : IRequest<Brand>
{
    public string Name { get; set; }

    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, Brand>
    {
        IBrandRepository _brandRepository;
        IMapper _mapper;
        BrandBusinessRules _brandBusinessRules;
        IMailService _mailService;

        public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper,
            BrandBusinessRules brandBusinessRules, IMailService mailService)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
            _brandBusinessRules = brandBusinessRules;
            _mailService = mailService;
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
            _mailService.sendMail(mail);
            return createdBrand;
        }
    }
}