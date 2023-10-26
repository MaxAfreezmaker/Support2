using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Support2.DBContext;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();

        // Po��czenie do bazy danych "YourConnectionString"
        builder.Services.AddDbContext<KontaktZglosznenieData>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Po��czenie do bazy danych "DefaultConnection"
        builder.Services.AddDbContext<supportdata>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var dbContext = services.GetRequiredService<supportdata>();
                dbContext.Database.EnsureCreated(); // Tworzenie bazy danych (je�li nie istnieje)

                if (dbContext.Database.CanConnect())
                {
                    Console.WriteLine("Po��czenie z baz� danych 'supportdata' nawi�zane pomy�lnie.");
                }
                else
                {
                    Console.WriteLine("Nie uda�o si� nawi�za� po��czenia z baz� danych 'supportdata'.");
                }

                var kontaktDbContext = services.GetRequiredService<KontaktZglosznenieData>();
                kontaktDbContext.Database.EnsureCreated();

                if (kontaktDbContext.Database.CanConnect())
                {
                    Console.WriteLine("Po��czenie z baz� danych 'KontaktZglosznenieData' nawi�zane pomy�lnie.");
                }
                else
                {
                    Console.WriteLine("Nie uda�o si� nawi�za� po��czenia z baz� danych 'KontaktZglosznenieData'.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wyst�pi� b��d podczas pr�by nawi�zania po��czenia z baz� danych:");
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
