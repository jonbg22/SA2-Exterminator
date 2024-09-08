using Exterminator.Services.Interfaces;
using Exterminator.Services.Implementations;
using Exterminator.Repositories.Interfaces;
using Exterminator.Repositories.Data;
using Exterminator.Repositories.Implementations;
using Microsoft.AspNetCore.Diagnostics;
using Exterminator.WebApi.ExceptionHandlerExtensions;

var builder = WebApplication.CreateBuilder(args);

// TODO: Register all dependencies.
builder.Services.AddTransient<ILogService, LogService>();
builder.Services.AddTransient<IGhostbusterService, GhostbusterService>();
builder.Services.AddTransient<ILogRepository, LogRepository>();
builder.Services.AddTransient<IGhostbusterRepository, GhostbusterRepository>();
builder.Services.AddSingleton<IGhostbusterDbContext, GhostbusterDbContext>();



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

// Registering custom exception handler here
app.UseGlobalExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
