using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Configuration;
using Verita.Application.Extensions;
using Verita.Contract.Models;
using Verita.Data;
using Verita.Repository.Mssql;
using Verita.Repository.Mssql.GenericRepository;
using Verita7.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContext");
builder.Services.AddGenericRepository<ApplicationDbContext>();
builder.Services.AddQueryRepository<ApplicationDbContext>();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
   .AddEntityFrameworkStores<ApplicationDbContext>()
   .AddDefaultTokenProviders();
builder.Services.AddApplicationServices();

var app = builder.Build();
app.UseStaticFiles(); // Statik dosyalarý sunmak için UseStaticFiles yöntemini kullan
try
{


    // SharedFile klasörünün yolunu al
    string sharedFilesPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "SharedFiles");

    // SharedFile klasörünü sunmak için bir URL rotasý tanýmla
    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(sharedFilesPath),
        RequestPath = "/SharedFiles"
    });
}
catch (Exception ex)
{
    ErrorHandlingMiddlewareExtensions.LogError(ex.Message);
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "MerakEttikleriniz",
        pattern: "merak-ettikleriniz/{id?}",
         defaults: new { controller = "Home", action = "MerakEttikleriniz" });

    endpoints.MapControllerRoute(
        name: "Verita",
        pattern: "verita/{id?}",
         defaults: new { controller = "Home", action = "Verita" });

    endpoints.MapControllerRoute(
        name: "B2bUrun",
        pattern: "B2bUrun/{id?}",
         defaults: new { controller = "Home", action = "B2bUrun" });

    endpoints.MapControllerRoute(
        name: "B2bUrunler",
        pattern: "b2b-urunler/{f?}",
         defaults: new { controller = "Home", action = "B2bUrunler" });

    endpoints.MapControllerRoute(
        name: "GidaGuvenligi",
        pattern: "gida-guvenligi/{id?}",
         defaults: new { controller = "Home", action = "GidaGuvenligi" });

    endpoints.MapControllerRoute(
      name: "BunlariBiliyorMusunuz",
      pattern: "bunlari-biliyor-musunuz/{id?}",
         defaults: new { controller = "BunlariBiliyorMusunuz", action = "Index" });

    endpoints.MapControllerRoute(
        name: "Iletisim",
        pattern: "bize-ulasin/{id?}",
         defaults: new { controller = "Home", action = "Iletisim" });

    endpoints.MapControllerRoute(
        name: "BasindaBiz",
        pattern: "basinda-biz/{id?}",
         defaults: new { controller = "BasindaBiz", action = "Index" });

    endpoints.MapControllerRoute(
        name: "MeyveliRehber",
        pattern: "meyveli-rehber/{id?}",
         defaults: new { controller = "MeyveliRehber", action = "Index" });

    endpoints.MapControllerRoute(
        name: "Hakkimizda",
        pattern: "hakkimizda/{id?}",
         defaults: new { controller = "Hakkimizda", action = "Index" });
    endpoints.MapControllerRoute(
        name: "Hakkimizda2",
        pattern: "hakkimizda2/{id?}",
         defaults: new { controller = "Home", action = "Hakkimizda" });
    endpoints.MapControllerRoute(
        name: "EgzotikMeyveler",
        pattern: "egzotik-meyveler/{id?}",
         defaults: new { controller = "Home", action = "EgzotikMeyveler" });

    endpoints.MapControllerRoute(
        name: "VeritaGurmeKivi",
        pattern: "verita-gurme-kivi/{id?}",
         defaults: new { controller = "Product", action = "Index" },
        constraints: new { id = @"\d+" });

    endpoints.MapControllerRoute(
       name: "Urunler",
       pattern: "urunler/{id?}",
        defaults: new { controller = "Product", action = "Index" },
       constraints: new { id = @"\d+" });

    endpoints.MapControllerRoute(
      name: "Urunlerimiz",
      pattern: "urunlerimiz/{id?}",
       defaults: new { controller = "Urunlerimiz", action = "Index" },
      constraints: new { id = @"\d+" });

    endpoints.MapControllerRoute(
        name: "OrganizasyonYapisi",
        pattern: "organizasyon-yapisi/{id?}",
         defaults: new { controller = "Home", action = "OrganizasyonYapisi" });

    endpoints.MapControllerRoute(
    name: "Hedeflerimiz",
    pattern: "hedeflerimiz/{id?}",
     defaults: new { controller = "Home", action = "Hedeflerimiz" });

    endpoints.MapControllerRoute(
   name: "Page",
   pattern: "page/{id?}",
    defaults: new { controller = "Page", action = "Index" });


    endpoints.MapControllerRoute(
   name: "DalindanSofraya",
   pattern: "dalindan-sofraya/{id?}",
    defaults: new { controller = "Home", action = "DalindanSofraya" });

    endpoints.MapControllerRoute(
name: "GuvenliAmbalaj",
pattern: "guvenli-ambalaj/{id?}",
defaults: new { controller = "Home", action = "GuvenliAmbalaj" });

    endpoints.MapControllerRoute(
  name: "NedenVerita",
  pattern: "neden-verita/{id?}",
   defaults: new { controller = "Home", action = "NedenVerita" });

    endpoints.MapControllerRoute(
name: "SogukZincir",
pattern: "soguk-zincir/{id?}",
defaults: new { controller = "Home", action = "SogukZincir" });


    endpoints.MapControllerRoute(
name: "KaliteGarantisi",
pattern: "kalite-garantisi/{id?}",
 defaults: new { controller = "Home", action = "KaliteGarantisi" });

    endpoints.MapControllerRoute(
          name: "OrganizasyonYapisi2",
          pattern: "organizasyon-yapisi2/{id?}",
           defaults: new { controller = "Home", action = "OrganizasyonYapisi2" });

    endpoints.MapControllerRoute(
        name: "Default",
        pattern: "{controller}/{action}/{id}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

});
app.Run();
