using Employee.Infrastructure;
using Employee.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Employee.Infrastructure.Extension;
using Employee.Api.Configure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(
    opions =>
    {
        opions.AddDefaultPolicy( policy =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:7263", "http://localhost:7263");
            policy.SetIsOriginAllowedToAllowWildcardSubdomains();
        });
    }
    );
// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureMediator();
builder.Services.ConfigureDatabase(builder.Configuration);


var app = builder.Build();

//run pending migration
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<EmployeeDb>();
    db.Database.Migrate();
}
// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

app.MapControllers();
app.Run();


