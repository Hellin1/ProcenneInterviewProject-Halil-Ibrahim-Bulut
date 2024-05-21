using Application;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Context;
using Persistance.Repositories;
using Persistance.Services;
using Persistance.Uow;

namespace Persistance;

public static class ServiceRegistration
{
    public static void AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<LibraryContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("Local"));
        });

        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IIdentityService, IdentityService>();
        services.AddScoped<ITransactionManager, TransactionManager>();


    }
}
