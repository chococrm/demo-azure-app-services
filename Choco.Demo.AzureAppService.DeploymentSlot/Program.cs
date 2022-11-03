using Choco.Demo.AzureAppService.DeploymentSlot;

var builder = WebApplication.CreateBuilder(args);

// apply configuration
var configuration = builder.Configuration;
configuration["Version"] = "1";
configuration[ConfigKey.AppSlot] = Environment.GetEnvironmentVariable("APP_SLOT") ?? string.Empty;
configuration[ConfigKey.AppMode] = Environment.GetEnvironmentVariable("APP_MODE") ?? string.Empty;

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// throw new Exception("You shall not pass!");

app.Run();