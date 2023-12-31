﻿using System.Globalization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using WebProgramlamaProje.Extensions;
using WebProgramlamaProje.Models.Domain;
using WebProgramlamaProje.Repository.Abstract;
using WebProgramlamaProje.Repository.Implementation;

namespace WebProgramlamaProje;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var connectionString = builder.Configuration.GetConnectionString("conn");
        builder.Services.AddDbContext<ApplicationDbContext>(options => { options.UseSqlServer(connectionString); });
        builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
        builder.Services.ConfigureApplicationCookie(options => options.LoginPath = "/UserAuthentication/Login");
        builder.Services.AddTransient<IUserAuthenticationService, UserAuthenticationService>();
        builder.Services.AddTransient<IFlightService, FlightService>();
        builder.Services.AddTransient<ITicketService, TicketService>();
        builder.Services.AddTransient<ITicketTypeService, TicketTypeService>();
        builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
        builder.Services.AddHttpContextAccessor();
        builder.Services.Configure<RequestLocalizationOptions>(options =>
        {
            options.DefaultRequestCulture = new("tr-TR");
            CultureInfo[] cultures = new CultureInfo[] { new("tr-TR"), new("en-US") };
            options.SupportedCultures = cultures;
            options.SupportedUICultures = cultures;
        });
        builder.Services.AddScoped<RequestLocalizationCookiesMiddleware>();



        builder.Services.AddControllersWithViews()
            .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
            .AddDataAnnotationsLocalization();

        var app = builder.Build();

        


        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();

        app.UseAuthorization();
        app.UseRequestLocalization();
        app.UseMiddleware<RequestLocalizationCookiesMiddleware>();

        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            SeedData.Initialize(services).Wait();
        }
        

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=UserAuthentication}/{action=Login}/{id?}");

        app.Run();
    }
}
