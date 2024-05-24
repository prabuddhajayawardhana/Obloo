using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Obloo.Application.Common.Interfaces.Authentication;
using Obloo.Application.Common.Interfaces.Persistence;
using Obloo.Infrastructure.Services.Authentication;
using Microsoft.EntityFrameworkCore;
using Obloo.Infrastructure.Persistence.Data;
using Obloo.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Obloo.Domain.Entities;
using Obloo.Domain.Interfaces;
using Obloo.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Obloo.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddDbContext<SqlDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("TransactionConnectionString"), options => options.EnableRetryOnFailure()));

        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IOblooServiceProvider, OblooServiceProvider>();
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

        return services;
    }
}
