using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using SymptomsProject.Data;
using SymptomsProject.Services;

namespace SymptomsProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<SymptomsContext>( options =>
            {
                options.UseMySql(
                    builder
                        .Configuration
                        .GetConnectionString("SymptomsContext"),
                    ServerVersion
                    .AutoDetect(
                            builder
                            .Configuration
                            .GetConnectionString("SymptomsContext")
                        )
                    );
            }
            );

            builder.Services.AddScoped<PatientService>();
            builder.Services.AddScoped<SymptomService>();
            builder.Services.AddScoped<SeedingService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            else
            {
                app.Services.CreateScope().ServiceProvider.GetRequiredService<SeedingService>().Seed();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
