using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Exceptions;
using WebApi.HomeTask.Bll.Extensions;
using WebApi.HomeTask.Dal;
using WebApi.HomeTask.Shared.Extensions;
using WebApi.HomeTask.Shared.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Setup serilog
builder.Host.UseSerilog((ctx, lc) => lc
        // For dev envs+ compact json formatter should be used.
#if DEBUG
    .WriteTo.Console()
#else
    .WriteTo.Console(new Serilog.Formatting.Compact.RenderedCompactJsonFormatter())
#endif
    .Enrich.FromLogContext()
    .Enrich.WithExceptionDetails());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        // Make sure that database is up to date and seed base data.
        var context = services.GetRequiredService<RestaurantDbContext>();
        await context.Database.MigrateAsync();
        await ApplicationDbContextSeed.SeedBaseData(context, loggerFactory);
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "Migration failed");
    }
}

// global cors policy
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// global error handler
app.UseMiddleware<ErrorHandlerMiddleware>();

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