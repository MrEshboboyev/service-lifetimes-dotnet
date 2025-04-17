using ServiceLifetimes.Api.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddTransient<IOperation, Operation>();
builder.Services.AddScoped<IOperation, Operation>();
builder.Services.AddSingleton<IOperation, Operation>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
