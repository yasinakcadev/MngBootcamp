using Application.Services.CredibilityServices;
using Application.Services.CredibilityServices.MyFindexScoreImplementation;
using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.CredibilityServices;
using Core.Security.Jwt;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("rentACarConnectionString")));
            
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IAdditionalServiceRepository, AdditionalServiceRepository>();
            services.AddScoped<IModelRepository, ModelRepository>();
            services.AddScoped<IFuelRepository, FuelRepository>();
            services.AddScoped<IColorRepository, ColorRepository>();
            services.AddScoped<IFindexScoreRepository, FindexScoreRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ITransmissionRepository, TransmissionRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IRentRepository, RentRepository>();
            services.AddScoped<IIndividualCustomerRepository, IndividualCustomerRepository>();
            services.AddScoped<ICorporateCustomerRepository, CorporateCustomerRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IFindexCreditService, MyFindexScore>();
            services.AddScoped<IDamageRepository, DamageRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITokenHelper,JwtHelper>();

            return services;
        }
    }
}
