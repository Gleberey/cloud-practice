using ListingService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<QueueSenderService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/", () => "ListingService is running");

app.MapPost("/send-listing-message", async (QueueSenderService queueSenderService) =>
{
    var text = $"Listing created at {DateTime.Now}";
    await queueSenderService.SendMessageAsync(text);
    return Results.Ok("Message sent to queue");
});

app.Run();