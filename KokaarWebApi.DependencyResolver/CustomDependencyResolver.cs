using AutoMapper;
using KokaarWebApi.DataAccess.Data;
using KokaarWebApi.DataAccess.Repository.Contracts;
using KokaarWebApi.DataAccess.Repository.Implementations;
using KokaarWepApi.Service.Contracts;
using KokaarWepApi.Service.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace KokaarWebApi.DependencyResolver
{
    public class CustomDependencyResolver
    {
        public CustomDependencyResolver()
        {

        }

        public static void InjectDependencies(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<ICustomerService, CustomerService>();
        }

    }
}