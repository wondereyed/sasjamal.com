using System;
using System.Threading.Tasks;
using System.Threading.Channels;
using ms.common.sharedtypes;

namespace orchestration.pubsub
{
    public class Subscriber<T>
    {
        private readonly Channel<T> _channel;

        public Subscriber(Channel<T> channel)
        {
            _channel = channel;
        }

        public async Task StartAsync()
        {
            await foreach (var item in _channel.Reader.ReadAllAsync())
            {
                switch (item)
                {
                    case MyCommand command:
                        Console.WriteLine($"Received Command: {command.CommandName} with Message: {command.Payload.Content}");
                        break;
                    case MyEvent @event:
                        Console.WriteLine($"Received Event: {@event.EventName} with Message: {@event.Payload.Content}");
                        break;
                    default:
                        Console.WriteLine("Received unknown message type");
                        break;
                }
            }
        }
    }
}
