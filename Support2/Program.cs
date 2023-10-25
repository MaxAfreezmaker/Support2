using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Support2.DBContext;
using Support2.Models.DBentities;
using Microsoft.AspNetCore.Authorization;

public class Program
{
    public static void Main(string[] args)
    {
        // Add services to the container.
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();
        //DI
        builder.Services.AddDbContext<supportdata>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
        );

        var app = builder.Build();

        // Inicjalizacja us³ug DbContext i sprawdzenie po³¹czenia
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var dbContext = services.GetRequiredService<supportdata>();
                dbContext.Database.OpenConnection(); // Sprawdzenie po³¹czenia z baz¹ danych

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

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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

    //Autoryzacje
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAuthorization();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }
}
