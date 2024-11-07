using API_Showcase.Services;
using APIWeaver;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(options =>
{
    // Adds the server URL dynamically using the HttpContext.
    options.AddServerFromRequest();
});

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<ITelegrafService, TelegrafService>();
builder.Services.AddSingleton<EmqxService>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(corsOptions =>
    {
        corsOptions
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
    });
});

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapControllers();

app.Run();