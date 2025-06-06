using Application.Activities.Queries;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Application.Core;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        ///////////////////////////////////////////////
        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
        });
        builder.Services.AddCors();
        builder.Services.AddMediatR(x =>
            x.RegisterServicesFromAssemblyContaining<GetActivityList.Handler>());
        builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);

        ///////////////////////////////////////////////
        // Configure the HTTP request pipeline.
        var app = builder.Build();
        app.UseCors(x =>
            x.AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins("http://localhost:3000", "https://localhost:3000")
            );

        app.MapControllers();

        // Need to use Service Locator pattern to get the DbContext
        using var scope = app.Services.CreateScope();

        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<AppDbContext>();
            await context.Database.MigrateAsync();
            // Seed the database with initial data 
            await DbInitualizer.SeedEmptyDb(context);
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred during migration");
        }

        app.Run();
    }
}