using Hangfire;
using hangfire_practice.Data;
using hangfire_practice.Job;
using hangfire_practice.Service;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<HangfireDbContext>(options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("HangFireConnString")));

// Hangfire
builder.Services.AddHangfire(config =>
{
    config.UseSqlServerStorage(
        builder.Configuration.GetConnectionString("HangFireConnString")
    );
});

// Hangfire Server
builder.Services.AddHangfireServer();
builder.Services.AddTransient<DatabaseBackupService>();
builder.Services.AddTransient<DatabaseBackupJob>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var jobService = scope.ServiceProvider
        .GetRequiredService<DatabaseBackupJob>();

    jobService.ExecuteJob();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.UseHttpsRedirection();

app.UseAuthorization();

// Hangfire Dashboard
app.UseHangfireDashboard("/hangfire");

app.MapControllers();

app.Run();
