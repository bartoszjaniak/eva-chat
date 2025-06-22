using BackendApi.Data.Repositories;
using BackendApi.Interfaces;
using BackendApi.Services.Mocks;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Register controllers
builder.Services.AddControllers();

// Register MediatR
builder.Services.AddMediatR(typeof(Program));

// Register Entity Framework Core with SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Services
builder.Services.AddScoped<IChatService, FakeChatService>();
builder.Services.AddScoped<IChatRepository, ChatRepository>();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")  // adres frontendu
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();  // jeśli używasz ciasteczek lub auth
        });
});


var app = builder.Build();

// allow CORS globally
app.UseCors(MyAllowSpecificOrigins);

// Map controllers
app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();



app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
