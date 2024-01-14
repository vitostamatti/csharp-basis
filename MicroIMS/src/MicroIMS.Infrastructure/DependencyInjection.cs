using MicroIMS.Application.Repositories;
using MicroIMS.Application.Services;
using MicroIMS.Domain.Repositories;
using MicroIMS.Infrastructure.Repositories;
using MicroIMS.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MicroIMS.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddPersistence();
        services.AddServices();
        return services;
    }
    private static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite("Data Source = db.sqlite"));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUsersRepository, UsersRepository>();
        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IEmailService, EmailService>();
        return services;
    }
}



