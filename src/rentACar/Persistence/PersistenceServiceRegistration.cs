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

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("rentACarConnectionString")));
            services.AddScoped<IBrandRepository, BrandRepository>();
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
            return services;
        }
    }
}
