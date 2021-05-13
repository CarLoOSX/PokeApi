using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;
using Users.Users.Domain.Shared;

namespace Users.Users.Persistence.Shared
{
    public class RabbitMqEventPublisher : EventPublisher
    {
        public void Publish(DomainEvent dEvent)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "guest",
                Password = "guest",
                VirtualHost = "pokemons"
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.BasicPublish(string.Empty,
                    routingKey: "notify_pokemons_on_user_add_favorite",
                    basicProperties: null,
                    body: Encoding.UTF8.GetBytes(dEvent.Message));
            }
        }

        public void Publish(IList<DomainEvent> dEvents)
        {
            foreach (var dEvent in dEvents)
            {
                Publish(dEvent);
            }
        }
    }
}