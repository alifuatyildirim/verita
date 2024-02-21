using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Verita.Application.ProductService;
using Verita.Data.Abstracts;
using Verita.Data.Concrete;

namespace Verita.Application.Extensions;

public static class ApplicationServicesExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<IUserClaimService, UserClaimService>();


        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductService, ProductService.ProductService>();

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICategoryService, CategoryService>();

        services.AddScoped<IProductCardRepository, ProductCardRepository>();
        services.AddScoped<IProductCardService, ProductCardService>();

        services.AddScoped<IPageImageRepository, PageImageRepository>();
        services.AddScoped<IPageImageService, PageImageService>();

        services.AddScoped<IPageRepository, PageRepository>();
        services.AddScoped<IPageService, PageService>();
        return services;
    }


}