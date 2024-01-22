using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Verita.Application;
using Verita.Application.ProductService;
using Verita.Data.Abstracts;
using Verita.Data.Concrete;

namespace AdminLTE.Extensions;

public static class ApplicationServicesExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<IUserClaimService, UserClaimService>();


        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductService, ProductService>();
        return services;
    }


}