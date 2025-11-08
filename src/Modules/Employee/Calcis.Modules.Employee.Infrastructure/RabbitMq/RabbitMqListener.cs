using Calcis.Shared.Infrastructure.Logging;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Employee.Infrastructure.RabbitMq
{
    public class RabbitMqListener : BackgroundService
    {
        private readonly Task<IConnection> _connectionTask;
        private Logger<RabbitMqListener> _logger;

        public RabbitMqListener(Task<IConnection> connectionTask, Logger<RabbitMqListener> logger)
        {
            _connectionTask = connectionTask;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var queueName = "keycloak.events.queue";
            var exchangeName = "keycloak.events";

            try
            {
                var connection = await _connectionTask;
                var channel = await connection.CreateChannelAsync();

                await channel.ExchangeDeclareAsync(exchange: exchangeName, type: ExchangeType.Topic, durable: true);
                await channel.QueueDeclareAsync(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

                await channel.QueueBindAsync(queue: queueName, exchange: exchangeName, routingKey: "#");

                var consumer = new AsyncEventingBasicConsumer(channel);
                consumer.ReceivedAsync += async (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);

                    // Tu możesz dodać logikę (np. zapis do read model)
                    await Task.Yield(); // żeby handler był async
                };

                await channel.BasicConsumeAsync(queue: queueName, autoAck: true, consumer: consumer);

                await Task.Delay(Timeout.Infinite, stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Błąd podczas nasłuchiwania RabbitMQ");
            }
        }
    }
}
