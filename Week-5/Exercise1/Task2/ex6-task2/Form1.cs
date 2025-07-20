using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Confluent.Kafka;

namespace task2
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource _cts = new();

        public Form1()
        {
            InitializeComponent();
            StartConsumer();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            var chat = new ChatMessage
            {
                User = txtUser.Text,
                Message = txtMessage.Text
            };

            await SendMessageAsync(chat);
            txtMessage.Clear();
        }

        private async Task SendMessageAsync(ChatMessage chat)
        {
            var config = new ProducerConfig { BootstrapServers = "localhost:9092" };
            using var producer = new ProducerBuilder<Null, string>(config).Build();
            string json = JsonSerializer.Serialize(chat);
            await producer.ProduceAsync("chat-topic", new Message<Null, string> { Value = json });
        }

        private void StartConsumer()
        {
            Task.Run(() =>
            {
                var config = new ConsumerConfig
                {
                    BootstrapServers = "localhost:9092",
                    GroupId = Guid.NewGuid().ToString(),
                    AutoOffsetReset = AutoOffsetReset.Earliest
                };

                using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
                consumer.Subscribe("chat-topic");

                try
                {
                    while (!_cts.Token.IsCancellationRequested)
                    {
                        var result = consumer.Consume(_cts.Token);
                        var chat = JsonSerializer.Deserialize<ChatMessage>(result.Message.Value);

                        Invoke(new Action(() =>
                        {
                            lstMessages.Items.Add($"[{chat.Timestamp:T}] {chat.User}: {chat.Message}");
                        }));
                    }
                }
                catch (OperationCanceledException) { consumer.Close(); }
            });
        }
    }

    public class ChatMessage
    {
        public string User { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}