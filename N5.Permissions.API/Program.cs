using MediatR;
using Microsoft.EntityFrameworkCore;
using N5.Permissions.Infrastructure;
using N5.Permissions.Application.Commands;
using N5.Permissions.Application.Queries;
using N5.Permissions.Infrastructure.Repositories;
using Serilog;
using Nest;
using N5.Permissions.Domain.Models;
using N5.Permissions.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var settings = new ConnectionSettings()
    .DefaultMappingFor<Permission>(x => x.IndexName("permission"));
builder.Services.AddSingleton<IElasticClient>(new ElasticClient(settings));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IElasticsearchRepository, ElasticsearchRepository>();
builder.Services.AddDbContext<PermissionContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);



builder.Services.AddMediatR(new Type[]
{
  typeof(RequestPermissionCommand),
  typeof(ModifyPermissionCommand),
  typeof(GetAllPermissionQuery)
});

builder.Host.UseSerilog();
var app = builder.Build();

using (var scope = app.Services.CreateScope()) 
{
    var context = scope.ServiceProvider.GetRequiredService<PermissionContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseErrorHandlerMiddleware();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
