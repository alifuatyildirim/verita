using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace AdminLTE.Middlewares
{
    public static class ErrorHandlingMiddlewareExtensions
    {
        public static void UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "text/plain";

                    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    var exception = exceptionHandlerPathFeature.Error;

                    // Hata mesajını dosyaya yaz
                    LogError(exception);

                    await context.Response.WriteAsync("Internal Server Error. Please try again later.");
                });
            });
        }

        private static void LogError(Exception ex)
        {
            try
            {
                string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorLog.txt");
                string errorMessage = $"[{DateTime.Now.ToString()}] {ex.Message}\n{ex.StackTrace}\n\n";

                // Hata mesajını dosyaya yaz
                File.AppendAllText(logFilePath, errorMessage);
            }
            catch (Exception e)
            {
                // Hata oluşursa konsola yazdır
                Console.WriteLine("Hata kaydedilirken bir sorun oluştu: " + e.Message);
            }
        }

        public static void LogError(string ex)
        {
            try
            {
                string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorLog.txt");
                string errorMessage = $"[{DateTime.Now.ToString()}] {ex}\n{ex}\n\n";

                // Hata mesajını dosyaya yaz
                File.AppendAllText(logFilePath, errorMessage);
            }
            catch (Exception e)
            {
                // Hata oluşursa konsola yazdır
                Console.WriteLine("Hata kaydedilirken bir sorun oluştu: " + e.Message);
            }
        }
    }
}