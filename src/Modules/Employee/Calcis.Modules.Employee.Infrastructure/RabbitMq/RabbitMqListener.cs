using Calcis.Modules.Employee.Application.Commands;
using Calcis.Modules.Employee.Application.Commands.Models;
using Calcis.Shared.Infrastructure.Logging;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
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
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public RabbitMqListener(Task<IConnection> connectionTask, Logger<RabbitMqListener> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _connectionTask = connectionTask;
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
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

                    _logger.LogInformation(new Exception("Otrzymano wiadomość z RabbitMQ: "), message);

                    var keycloakEvent = JsonConvert.DeserializeObject<KeycloakEvent>(message);

                    if (keycloakEvent?.ResourceType == "USER")
                    {
                        // TODO::Add handling for user events: CREATE, UPDATE, DELETE
                        var createUser = JsonConvert.DeserializeObject<CreateUserKeycloakCommand>(message);
                        if (createUser is not null && createUser.OperationType == "CREATE")
                        {
                            using var scope = _serviceScopeFactory.CreateScope();
                            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                            await mediator.Send(createUser);
                        }
                    }
                    else if (keycloakEvent?.ResourceType == "GROUP_MEMBERSHIP")
                    {
                        // TODO::Add handling for group membership events
                    }
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
