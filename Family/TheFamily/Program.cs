using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TheFamily.Data;
using TheFamily.Interfaces;
using TheFamily.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddDbContext<FamilyDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("FamilyContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<FamilyDbContext>();
    context.Database.EnsureCreated();
    DataSeeding.seedData(context);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
