using Application.Features.Brands.Rules;
using Application.Features.Cars.Rules;
using Application.Features.Color.Rules;
using Application.Features.Damages.Rules;
using Application.Features.IndividualCustomer.Rules;
using Application.Features.Invoices.Rules;
using Application.Features.Models.Rules;
using Application.Features.Transmission.Rules;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Rents.Rules;
using Application.Features.FindexScores.Rules;
using Application.Features.Users.Rules;
using Core.Security.Jwt;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddScoped<BrandBusinessRules>();
            services.AddScoped<ModelBusinessRules>();
            services.AddScoped<FuelBusinessRules>();
            services.AddScoped<ColorBusinessRules>();
            services.AddScoped<TransmissionBusinessRules>();
            services.AddScoped<CarBusinessRules>();
            services.AddScoped<IndividualCustomerBusinessRules>();
            services.AddScoped<InvoiceBusinessRules>();
            services.AddScoped<RentBusinessRules>();
            services.AddScoped<FindexScoreBusinessRules>();
            services.AddScoped<DamageBusinessRules>();
            services.AddScoped<UserBusinessRules>();

            services.AddTransient(typeof(IPipelineBehavior<,>),typeof(RequestValidationBehavior<,>));
            
            return services;
        }
    }
}
