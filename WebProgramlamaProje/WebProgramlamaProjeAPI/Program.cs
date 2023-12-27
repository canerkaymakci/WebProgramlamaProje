namespace WebProgramlamaProjeAPI;

using Microsoft.EntityFrameworkCore;
using WebProgramlamaProjeAPI.Domain;
using WebProgramlamaProjeAPI.Repositories;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        var connectionString = builder.Configuration.GetConnectionString("conn");
        builder.Services.AddDbContext<ApplicationDbContext>(options => { options.UseSqlServer(connectionString); });
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddTransient<ITicketService, TicketService>();
        builder.Services.AddCors(options => options.AddPolicy("AllowAnyOriginPolicy", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));


        var app = builder.Build();

        app.UseCors("AllowAnyOriginPolicy");

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}

