using ClientManagement.API.Data;

using Microsoft.EntityFrameworkCore;


using System.Text;
using Microsoft.AspNetCore.Identity;

using Microsoft.Extensions.FileProviders;
using ClientManagement.API.Repositories;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ClientsDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ClientsConnectionString")));

builder.Services.AddScoped<IHelpServiceRepository, SQLHelpServiceRepository>();
builder.Services.AddScoped<IClientRepository, SQLClientRepository>();
// builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
builder.Services.AddAutoMapper(typeof(Program).Assembly);


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

app.Run();
