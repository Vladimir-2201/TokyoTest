using Microsoft.EntityFrameworkCore;
using TokyoTestServer.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TokyoTestServerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TokyoTestServerContext") ?? throw new InvalidOperationException("Connection string 'TokyoTestServerContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
};

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
