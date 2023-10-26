using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Support2.DBContext;
using System;
using System.Configuration;

public class Program
{
    public static void Main(string[] args)
    {
         var builder = WebApplication.CreateBuilder(args);

          builder.Services.AddControllersWithViews();

        builder.Services.AddDbContext<KontaktZglosznenieData>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("YourConnectionString")));


        // Konfiguracja bazy danych
        builder.Services.AddDbContext<supportdata>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
        );

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var dbContext = services.GetRequiredService<supportdata>();
                dbContext.Database.EnsureCreated(); // Tworzenie bazy danych (jeœli nie istnieje)

                if (dbContext.Database.CanConnect())
                {
                    Console.WriteLine("Po³¹czenie z baz¹ danych nawi¹zane pomyœlnie.");
                }
                else
                {
                    Console.WriteLine("Nie uda³o siê nawi¹zaæ po³¹czenia z baz¹ danych.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wyst¹pi³ b³¹d podczas próby nawi¹zania po³¹czenia z baz¹ danych:");
                Console.WriteLine(ex.Message);
            }
        }

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
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
