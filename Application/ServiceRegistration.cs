using Application.Behaivours;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;

namespace Application;
public static class ServiceRegistration
{
    public static void AddApplicationService(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        // fluent validation
        //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));


    }
}
