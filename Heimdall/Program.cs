using FastEndpoints;
using FastEndpoints.Swagger;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Heimdall;
using Heimdall.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();
builder.Services.AddQueries();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseFastEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerGen();
    app.UseSwaggerUi3();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.Run();
