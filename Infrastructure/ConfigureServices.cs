

using BlazorAndFluxorCrud.Model;

using Domain.Common;
using Infrastructure.Persistence.Repository;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite("Data Source=items.db"));

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        return services;
    }
}
