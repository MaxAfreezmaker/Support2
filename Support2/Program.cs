using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Support2.Areas.Identity.Data;
using Support2.Data;
using Support2.DBContext;
using Microsoft.AspNetCore.Builder;  // Dodane dla metody UseExceptionHandler
using Microsoft.Extensions.Hosting;  // Dodane dla metody UseExceptionHandler
using Microsoft.Extensions.DependencyInjection;  // Dodane dla metody AddRazorRuntimeCompilation
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

        // Połączenie do bazy danych "YourConnectionString"
        builder.Services.AddDbContext<KontaktZglosznenieData>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Połączenie do bazy danych "DefaultConnection"
        builder.Services.AddDbContext<supportdata>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Podłączenie Logowania/Rejestrowania
        builder.Services.AddDbContext<Support2Context>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddIdentity<Support2User, IdentityRole>(options =>
        {
            options.SignIn.RequireConfirmedAccount = true;
        })
        .AddEntityFrameworkStores<Support2Context>()
        .AddDefaultTokenProviders();

        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });
        });


        var app = builder.Build();

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
            name: "Identity",
            pattern: "{area=Identity}/{controller=Account}/{action=Login}/{id?}");


        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.MapControllers();

        app.Run();

    }
}
