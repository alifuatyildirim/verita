var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

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
        name: "Urunlerimiz",
        pattern: "urunlerimiz/{id?}", 
         defaults: new { controller = "Home", action = "Urunlerimiz" });

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
         defaults: new { controller = "Home", action = "BunlariBiliyorMusunuz" });

    endpoints.MapControllerRoute(
        name: "Iletisim",
        pattern: "bize-ulasin/{id?}",
         defaults: new { controller = "Home", action = "Iletisim" });

    endpoints.MapControllerRoute(
        name: "BasindaBiz",
        pattern: "basinda-biz/{id?}",
         defaults: new { controller = "Home", action = "BasindaBiz" });

    endpoints.MapControllerRoute(
        name: "Hakkimizda",
        pattern: "hakkimizda/{id?}",
         defaults: new { controller = "Home", action = "Hakkimizda" });


    endpoints.MapControllerRoute(
        name: "EgzotikMeyveler",
        pattern: "egzotik-meyveler/{id?}",
         defaults: new { controller = "Home", action = "EgzotikMeyveler" });

    endpoints.MapControllerRoute(
        name: "VeritaGurmeKivi", 
        pattern: "verita-gurme-kivi/{id?}",
         defaults: new { controller = "Home", action = "VeritaGurmeKivi" });

    endpoints.MapControllerRoute(
        name: "OrganizasyonYapisi",
        pattern: "organizasyon-yapisi/{id?}",
         defaults: new { controller = "Home", action = "OrganizasyonYapisi" });

    endpoints.MapControllerRoute(
        name: "Default",
        pattern: "{controller}/{action}/{id}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});
app.Run();
