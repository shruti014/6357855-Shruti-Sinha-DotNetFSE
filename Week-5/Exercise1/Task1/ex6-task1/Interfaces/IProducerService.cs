public interface IProducerService
{
    Task SendMessageAsync(ChatMessage message);
}