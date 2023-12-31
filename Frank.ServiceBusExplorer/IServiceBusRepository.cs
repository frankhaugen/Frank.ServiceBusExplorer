using Azure.Messaging.ServiceBus;

using Frank.ServiceBusExplorer.Models;

namespace Frank.ServiceBusExplorer;

public interface IServiceBusRepository
{
    IEnumerable<ServiceBusEntity> GetServiceBuses();
    Task<IEnumerable<TopicEntity>> GetTopicsAsync(string serviceBusName, CancellationToken cancellationToken);
    Task<IEnumerable<SubscriptionEntity>> GetSubscriptionsAsync(string serviceBusName, string topicName, CancellationToken cancellationToken);
    Task<IEnumerable<ServiceBusReceivedMessage>> GetMessagesAsync(string serviceBusName, string topicName, string subscriptionName, SubQueue subQueue, CancellationToken cancellationToken);
    Task CompleteMessageAsync(ServiceBusReceivedMessage message, ServiceBusEntity serviceBusEntity, TopicEntity topicEntity, SubscriptionEntity subscriptionEntity);
    Task DeadLetterMessageAsync(ServiceBusReceivedMessage message, ServiceBusEntity serviceBusEntity, TopicEntity topicEntity, SubscriptionEntity subscriptionEntity);
}