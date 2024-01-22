using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Verita.Repository.Mssql.GenericRepository
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGenericRepository<TDbContext>(
            this IServiceCollection services,
            ServiceLifetime lifetime = ServiceLifetime.Scoped)
            where TDbContext : DbContext
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }


            services.Add(new ServiceDescriptor(
                typeof(IGenericRepository),
                serviceProvider =>
                {
                    TDbContext dbContext = ActivatorUtilities.CreateInstance<TDbContext>(serviceProvider);
                    return new GenericRepository<TDbContext>(dbContext);
                },
                lifetime));

            services.Add(new ServiceDescriptor(
                typeof(IGenericRepository<TDbContext>),
                serviceProvider =>
                {
                    TDbContext dbContext = ActivatorUtilities.CreateInstance<TDbContext>(serviceProvider);
                    return new GenericRepository<TDbContext>(dbContext);
                },
                lifetime));

            return services;
        }
    }
}