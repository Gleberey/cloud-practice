using DisputeService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<QueueReceiverBackgroundService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/", () => "DisputeService is running");

app.Run();