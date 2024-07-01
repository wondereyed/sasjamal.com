using System;
using System.Threading.Tasks;
using System.Threading.Channels;

namespace orchestration.pubsub
{
    public class Publisher<T>
    {
        private readonly Channel<T> _channel;

        public Publisher(Channel<T> channel)
        {
            _channel = channel;
        }

        public async Task PublishAsync(T message)
        {
            await _channel.Writer.WriteAsync(message);
        }
    }
}
