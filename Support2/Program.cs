using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Support2.Areas.Identity.Data;
using Support2.Data;
using Support2.DBContext;
using System;
using System.Configuration;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();

        // Połączenie do bazy danych "YourConnectionString"
        builder.Services.AddDbContext<KontaktZglosznenieData>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Połączenie do bazy danych "DefaultConnection"
        builder.Services.AddDbContext<supportdata>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Podłączenie Logowania/Rejestrownia
        builder.Services.AddDbContext<Support2Context>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


        builder.Services.AddDefaultIdentity<Support2User>(options =>
        {
            options.SignIn.RequireConfirmedAccount = true;
        })
            .AddEntityFrameworkStores<Support2Context>();

        var app = builder.Build();

        // The rest of your code remains unchanged

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication(); // Add this line to enable authentication
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
