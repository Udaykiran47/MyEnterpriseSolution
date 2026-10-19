using Microsoft.EntityFrameworkCore;
using Api.Models;

var builder = WebApplication.CreateBuilder(args);

// ==========================================
// 1. SERVICES CONFIGURATION (Before Build)
// ==========================================

// Add controllers once
builder.Services.AddControllers();

// Configure MySQL database connection using EF Core
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("https://thankful-moss-02c74aa10.3.azurestaticapps.net") // Your frontend URL
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});


// Configure Swagger/OpenAPI documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Build the application container
var app = builder.Build();

// ==========================================
// 2. HTTP MIDDLEWARE PIPELINE (After Build)
// ==========================================

// Configure the HTTP request pipeline for development or production environments
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Make sure to use the policy before mapping controllers
app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.MapFallbackToFile("index.html"); // Routes client-side requests back to Angular


app.UseStaticFiles();
// UseCors MUST be placed after UseHttpsRedirection, but before UseAuthorization
app.UseCors("AllowAngularApp");

app.UseAuthorization();

app.MapControllers();
app.Run();