using BookBond.Core.Interfaces;
using BookBond.Infra.Data;
using BookBond.Infra.Models;
using BookBond.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookBond.Infra;

public static class ServiceExtensions
{
    public static void ConfigurePersistenceApp(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(connectionString));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
    }
}