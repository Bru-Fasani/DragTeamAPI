using DragTeamAPI.Data;
using DragTeamAPI.Repository;
using DragTeamAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");

Console.WriteLine(connectionString);

// Database configuration
builder.Services.AddDbContext<DragTeamDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection")));

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler =
            System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

// Dependency Injection
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<ITeamService, TeamService>();

// CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();


    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.Run();
