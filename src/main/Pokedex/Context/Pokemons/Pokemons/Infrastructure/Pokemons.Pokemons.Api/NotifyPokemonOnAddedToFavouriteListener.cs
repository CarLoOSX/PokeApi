using System;
using System.Text;
using Pokemons.Pokemons.Application.UseCase;
using Pokemons.Pokemons.Domain.ValueObject;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Pokemons.Pokemons.Api
{
    public class NotifyPokemonOnAddedToFavouriteListener
    {
        private readonly PokemonAddedToFavouritesNotifier _pokemonAddedToFavouritesNotifier;
        private readonly ConnectionFactory _factory;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public NotifyPokemonOnAddedToFavouriteListener(
            PokemonAddedToFavouritesNotifier pokemonAddedToFavouritesNotifier)
        {
            _pokemonAddedToFavouritesNotifier = pokemonAddedToFavouritesNotifier;

            _factory = new ConnectionFactory
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "guest",
                Password = "guest",
                VirtualHost = "pokemons"
            };
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public void Register()
        {
            var consumer = new EventingBasicConsumer(_channel);


            consumer.Received += MessageReceived;

            _channel.BasicConsume(queue: "notify_pokemons_on_user_add_favorite",
                autoAck: true,
                consumer: consumer);
        }

        private void MessageReceived(object sender, BasicDeliverEventArgs e)
        {
            var body = e.Body.ToArray();

            var message = Encoding.UTF8.GetString(body);

            _pokemonAddedToFavouritesNotifier.Execute(new PokemonId(Convert.ToInt32(message)));
        }

        public void Deregister()
        {
            _connection.Close();
        }
    }
}