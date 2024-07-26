using MassTransit;

namespace Application.QueueConsumer;

public interface IMessageConsumer<T> : IConsumer<T> where T : class 
{
}