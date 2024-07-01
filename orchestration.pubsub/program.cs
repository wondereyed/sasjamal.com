using System;
using System.Threading.Tasks;
using System.Threading.Channels;
using ms.common.sharedtypes;

namespace orchestration.pubsub
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var channel = Channel.CreateUnbounded<object>();

            var publisher = new Publisher<object>(channel);
            var subscriber = new Subscriber<object>(channel);

            var subscriberTask = subscriber.StartAsync();

            var message = new MyMessage { Id = 1, Content = "Hello, World!" };
            var command = new MyCommand { CommandName = "Create", Payload = message };
            var @event = new MyEvent { EventName = "Created", Payload = message };

            await publisher.PublishAsync(command);
            await publisher.PublishAsync(@event);

            // Give the subscriber some time to process messages
            await Task.Delay(1000);

            channel.Writer.Complete();

            await subscriberTask;
        }
    }
}