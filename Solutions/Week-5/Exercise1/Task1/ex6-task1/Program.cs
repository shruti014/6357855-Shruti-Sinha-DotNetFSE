var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<IProducerService, KafkaProducerService>();
builder.Services.AddSingleton<IConsumerService, KafkaConsumerService>();

var app = builder.Build();
app.MapControllers();

var consumerService = app.Services.GetRequiredService<IConsumerService>();
CancellationTokenSource cts = new();
consumerService.StartConsuming(cts.Token);

app.Run();