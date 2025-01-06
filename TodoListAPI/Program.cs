using Microsoft.EntityFrameworkCore;
using TodoListAPI.Models;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configure Kestrel to listen on port 5267
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(5267); // Listen on port 5267
});

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TodoListAPI", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline
// Make Swagger available in both development and staging environments
if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        // Ensure the Swagger UI is accessible via the correct endpoint
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoListAPI v1");
        c.RoutePrefix = string.Empty; // Serve the Swagger UI at the root (http://localhost:5267)
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
