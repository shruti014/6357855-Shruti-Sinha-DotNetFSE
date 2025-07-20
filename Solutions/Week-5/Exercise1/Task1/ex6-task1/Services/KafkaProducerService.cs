using Confluent.Kafka;
using System.Text.Json;

public class KafkaProducerService : IProducerService
{
    private readonly string _topic = "chat-topic";
    private readonly IProducer<Null, string> _producer;

    public KafkaProducerService()
    {
        var config = new ProducerConfig { BootstrapServers = "localhost:9092" };
        _producer = new ProducerBuilder<Null, string>(config).Build();
    }

    public async Task SendMessageAsync(ChatMessage message)
    {
        string json = JsonSerializer.Serialize(message);
        await _producer.ProduceAsync(_topic, new Message<Null, string> { Value = json });
    }
}