using Microsoft.EntityFrameworkCore;
using api.Data;

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
            policy.WithOrigins(
                    "https://calm-dune-08e4a6e10.2.azurestaticapps.net", // Your active frontend URL
                    "http://localhost:4200"
                  )
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

app.UseHttpsRedirection();

// 1. CORS MUST be placed early, before routing, static files, and controllers
app.UseCors(MyAllowSpecificOrigins);

// 2. Optional root redirect to Swagger
app.MapGet("/", () => Results.Redirect("/swagger"));

// 3. Authentication & Authorization
app.UseAuthorization();

// 4. Map API controllers last so they handle the /api/ routes properly
app.MapControllers();

app.Run();