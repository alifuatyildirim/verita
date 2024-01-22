using System;
using System.Collections.Concurrent;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection; 

namespace Verita.Repository.Mssql
{
    public static class ServiceCollectionExtensions
    {
       private static readonly ConcurrentDictionary<IServiceCollection, IConfiguration> Configurations = new ConcurrentDictionary<IServiceCollection, IConfiguration>();

    /// <summary>
    /// Sets the default <see cref="IConfiguration"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to set default configuration.</param>
    /// <param name="configuration">The <see cref="IConfiguration"/> to set.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection SetDefaultConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        Configurations[services] = configuration;
        return services;
    }

    /// <summary>
    /// Returns the default <see cref="IConfiguration"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to get default configuration.</param>
    /// <returns>The default <see cref="IConfiguration"/>.</returns>
    /// <exception cref="InvalidOperationException">The default configuration is not set with <seealso cref="SetDefaultConfiguration"/> before.</exception>
    public static IConfiguration GetDefaultConfiguration(this IServiceCollection services)
    {
        if (Configurations.TryGetValue(services, out IConfiguration? configuration))
        {
            return configuration;
        }

        throw new InvalidOperationException($"{nameof(SetDefaultConfiguration)} is not called!");
    }
        
    /// <summary>
    /// Registers a configuration instance which TOptions will bind against.
    /// The name of the options instance will be the name of the TOptions class.
    /// The configuration being bound will be the configuration set in <see cref="SetDefaultConfiguration"/> method.
    /// </summary>
    /// <typeparam name="TOptions">The type of options being configured.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection ConfigureWithOptionName<TOptions>(this IServiceCollection services) 
        where TOptions : class
    {
        return services.Configure<TOptions>(services.GetDefaultConfiguration().GetSection(typeof(TOptions).Name));
    }

    /// <summary>
    /// Registers a configuration instance which TOptions will bind against.
    /// The name of the options instance will be the name of the TOptions class.
    /// The configuration being bound will be the configuration set in <see cref="SetDefaultConfiguration"/> method.
    /// Also attempts to bind the configuration instance to a new instance of type TOptions and returns it.
    /// </summary>
    /// <typeparam name="TOptions">The type of options being configured.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <param name="options">The new instance of TOptions if found, default(TOptions) otherwise.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection ConfigureAndGetWithOptionName<TOptions>(this IServiceCollection services, out TOptions options) 
        where TOptions : class
    {
        IConfigurationSection configurationSection = services.GetDefaultConfiguration().GetSection(typeof(TOptions).Name);
        options = configurationSection.Get<TOptions>();

        return services.Configure<TOptions>(configurationSection);
    }
        
    /// <summary>
    /// Attempts to bind the configuration instance to a new instance of type T.
    /// If this configuration section has a value, that will be used.
    /// Otherwise binding by matching property names against configuration keys recursively.
    /// The configuration being bound will be the configuration set in <see cref="SetDefaultConfiguration"/> method.
    /// </summary>
    /// <typeparam name="TOptions">The type of options being configured.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <returns>The new instance of TOptions if successful, default(TOptions) otherwise.</returns>
    public static TOptions GetOptionWithName<TOptions>(this IServiceCollection services) 
        where TOptions : class
    {
        IConfigurationSection configurationSection = services.GetDefaultConfiguration().GetSection(typeof(TOptions).Name);
        return configurationSection.Get<TOptions>();
    }
     
        public static IServiceCollection AddQueryRepository<TDbContext>(
            this IServiceCollection services,
            ServiceLifetime lifetime = ServiceLifetime.Scoped)
            where TDbContext : DbContext
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.Add(new ServiceDescriptor(
                typeof(IQueryRepository),
                serviceProvider =>
                {
                    TDbContext dbContext = ActivatorUtilities.CreateInstance<TDbContext>(serviceProvider);
                    dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                    return new QueryRepository<TDbContext>(dbContext);
                },
                lifetime));

            services.Add(new ServiceDescriptor(
                typeof(IQueryRepository<TDbContext>),
                serviceProvider =>
                {
                    TDbContext dbContext = ActivatorUtilities.CreateInstance<TDbContext>(serviceProvider);
                    dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                    return new QueryRepository<TDbContext>(dbContext);
                },
                lifetime));

            return services;
        }
    }
}
