using Microsoft.Extensions.Options;
using Portfolio.Application.DI;
using Portfolio.Common.DI;
using Portfolio.Extensions;
using Portfolio.Infrastructure;
using Portfolio.Infrastructure.DI;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddAppSettingSectionsService(builder.Configuration);

builder.Services.AddDataBaseContext(builder.Configuration);

builder.Services.AddIdentityServices();

builder.Services.AddAAuthenticationService(builder.Configuration);

builder.Services.AddLocalizationService();

builder.Services.AddApplicationStrapping();

builder.Services.AddCommonStrapping();

builder.Services.AddInfrastructureStrapping();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.EnableCORSServices();

builder.Services.AddSwaggerDocumentationService();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var service = builder.Services.BuildServiceProvider();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();

app.UseSwaggerUI();

app.UseStaticFiles();

app.UseCors();

app.UseRequestLocalization(service.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

app.UseHttpsRedirection();

app.UseExceptionHandler(_ => { });

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
