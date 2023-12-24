using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        //SeedData.Initialize(connectionString);

        var app = builder.Build();

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

        app.UseAuthentication();

        app.UseAuthorization();

        using(var scope = app.Services.CreateScope())
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
