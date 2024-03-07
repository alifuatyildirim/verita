using AdminLTE.Data;
using AdminLTE.Middlewares;
using AdminLTE.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System.IO;
using Verita.Application.Extensions;
using Verita.Contract.Models;
using Verita.Data;
using Verita.Repository.Mssql;
using Verita.Repository.Mssql.GenericRepository;

namespace AdminLTE
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("ApplicationDbContext");
            services.AddGenericRepository<ApplicationDbContext>();
            services.AddQueryRepository<ApplicationDbContext>();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            services.AddIdentity<ApplicationUser, IdentityRole>()
               .AddEntityFrameworkStores<ApplicationDbContext>()
               .AddDefaultTokenProviders();
            //services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            //{
            //    options.Password.RequireDigit = true;
            //    options.Lockout.MaxFailedAccessAttempts = 3;
            //    //... Diğer Identity ayarları
            //})
            //.AddEntityFrameworkStores<ApplicationDbContext>()
            //.AddDefaultTokenProviders();
            services.AddApplicationServices();
            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, AppClaimsPrincipalFactory>();
            services.AddScoped<SignInManager<ApplicationUser>, AuditableSignInManager<ApplicationUser>>();

            var mvcBuilder = services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();

                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.Configure<CookieAuthenticationOptions>(options =>
            {
                options.LoginPath = new PathString("/Account/Login");
            });

            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStatusCodePagesWithRedirects("~/Home/Error/{0}");

            app.UseStaticFiles();
            try
            {
                string sharedFilesPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "SharedFiles");
                ErrorHandlingMiddlewareExtensions.LogError(sharedFilesPath);

                app.UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(sharedFilesPath),
                    RequestPath = "/SharedFiles"
                });
            }
            catch (System.Exception ex)
            {

                ErrorHandlingMiddlewareExtensions.LogError(ex.Message);
            }
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseGlobalExceptionHandler();
            app.UseMiddleware<RequestLoggingMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            try
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    DataSeed.Seed(scope.ServiceProvider).Wait();
                }
            }
            catch (System.Exception ex)
            {

                ErrorHandlingMiddlewareExtensions.LogError(ex.Message);
            }
        }
    }
}
