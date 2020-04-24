using KokaarWebApi.DataAccess.Data;
using KokaarWebApi.DataAccess.Repository.Abstract;
using KokaarWebApi.DataAccess.Repository.Concrete;
using KokaarWepApi.Service.Abstract;
using KokaarWepApi.Service.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KokaarWebApi.Utility.Infrastructure
{
    public class CustomeDependencyResolver
    {
        public CustomeDependencyResolver()
        {
            
        }

        public static void InjectDependencies(IServiceCollection services, string connectionString)
        {            
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICustomerService, CustomerService>();
        }

    }
}
