using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Verita.Application.BasindaBizService;
using Verita.Application.BunlariBiliyorMusunuzService;
using Verita.Application.HakkimizdaService;
using Verita.Application.HakkimizdaTimeLineService;
using Verita.Application.HomePageSliderService;
using Verita.Application.Image;
using Verita.Application.MeyveliRehberService;
using Verita.Application.NedenVeritaService;
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

        services.AddScoped<IProductOrderItemRepository, ProductOrderItemRepository>();
        services.AddScoped<IProductOrderItemService, ProductOrderItemService>();

        services.AddScoped<IPageImageRepository, PageImageRepository>();
        services.AddScoped<IPageImageService, PageImageService>();

        services.AddScoped<IPageRepository, PageRepository>();
        services.AddScoped<IPageService, PageService>();

        services.AddScoped<IBasindaBizRepository, BasindaBizRepository>();
        services.AddScoped<IBasindaBizService, BasindaBizService.BasindaBizService>();

        services.AddScoped<IHomePageSliderRepository, HomePageSliderRepository>();
        services.AddScoped<IHomePageSliderService, HomePageSliderService.HomePageSliderService>();
        
        services.AddScoped<IHomePageContentRepository, HomePageContentRepository>();
        services.AddScoped<IHomePageContentService, HomePageContentService.HomePageContentService>();

        services.AddScoped<INedenVeritaRepository, NedenVeritaRepository>();
        services.AddScoped<INedenVeritaService, NedenVeritaService.NedenVeritaService>();

        services.AddScoped<IReferanslarRepository, ReferanslarRepository>();
        services.AddScoped<IReferanslarService, ReferanslarService.ReferanslarService>();

        services.AddScoped<IBunlariBiliyorMusunuzRepository, BunlariBiliyorMusunuzRepository>();
        services.AddScoped<IBunlariBiliyorMusunuzService, BunlariBiliyorMusunuzService.BunlariBiliyorMusunuzService>();

        services.AddScoped<IHakkimizdaRepository, HakkimizdaRepository>();
        services.AddScoped<IHakkimizdaService, HakkimizdaService.HakkimizdaService>();

        services.AddScoped<IHakkimizdaTimeLineRepository, HakkimizdaTimeLineRepository>();
        services.AddScoped<IHakkimizdaTimeLineService, HakkimizdaTimeLineService.HakkimizdaTimeLineService>();


        services.AddScoped<IMeyveliRehberRepository, MeyveliRehberRepository>();
        services.AddScoped<IMeyveliRehberService, MeyveliRehberService.MeyveliRehberService>();

        services.AddScoped<IImageService, ImageService>();
        return services;
    }


}