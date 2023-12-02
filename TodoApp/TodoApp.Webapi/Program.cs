using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using TodoApp.Webapi.DataAccess;
using TodoApp.Webapi.Health_Checks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TodoDbContext>();

builder.Services.AddHealthChecks()
    .AddCheck<DatabaseHealthCheck>("Database");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("health", new HealthCheckOptions 
{  
    ResponseWriter = HealthCheckResponse.WriteResponse
});


app.Run();
