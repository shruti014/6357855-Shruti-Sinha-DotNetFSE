using Confluent.Kafka;
using System.Text.Json;

public class KafkaConsumerService : IConsumerService
{
    private readonly string _topic = "chat-topic";
    private readonly IConsumer<Ignore, string> _consumer;

    public KafkaConsumerService()
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = "localhost:9092",
            GroupId = "chat-consumer-group",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };
        _consumer = new ConsumerBuilder<Ignore, string>(config).Build();
        _consumer.Subscribe(_topic);
    }

    public void StartConsuming(CancellationToken token)
    {
        Task.Run(() =>
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    var consumeResult = _consumer.Consume(token);
                    var message = JsonSerializer.Deserialize<ChatMessage>(consumeResult.Message.Value);
                    Console.WriteLine($"[{message.Timestamp}] {message.User}: {message.Message}");
                }
            }
            catch (OperationCanceledException)
            {
                _consumer.Close();
            }
        });
    }
}