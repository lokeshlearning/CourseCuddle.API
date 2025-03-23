using CourseCuddle.Application;
using CourseCuddle.Application.Interfaces;
using CourseCuddle.Application.Services;
using CourseCuddle.Core.Entities;
using CourseCuddle.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Azure.Identity;
using Azure.Monitor.OpenTelemetry.AspNetCore;
var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContextPool<OnlineCourseDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection"),
    options=> options.EnableRetryOnFailure()
    ).EnableSensitiveDataLogging());
builder.Services.AddScoped<ICourseCategoryRepository,CourseCategoryRepository>();
builder.Services.AddScoped<ICourseCategoryService, CourseCategoryService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin() // Replace with your Angular URL
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddOpenTelemetry().UseAzureMonitor(options => {
    options.ConnectionString = "InstrumentationKey=f5360c8e-8e07-41af-b0b7-6cf353a3ac6a;IngestionEndpoint=https://canadacentral-1.in.applicationinsights.azure.com/;LiveEndpoint=https://canadacentral.livediagnostics.monitor.azure.com/;ApplicationId=f80b36cf-2fbe-4ebc-955f-fe172a34a3fe";
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
app.UseCors(MyAllowSpecificOrigins);
app.Run();
