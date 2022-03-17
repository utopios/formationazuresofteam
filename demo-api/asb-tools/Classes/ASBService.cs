using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;

namespace asb_tools.Classes;

public class ASBService
{
    private static string connectionString = @"Endpoint=sb://formation-softeam.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=Y/eeLeZpAlJ2lSOTiurFoLGH9Jwb7/N7FjEiV1UBjtM=";
    private static string queueName = "notification";

    private static ServiceBusSender _serviceBusSender;
    private static ServiceBusClient _serviceBusClient;

    public async void SendStringMessage(string message)
    {
        _serviceBusClient = new ServiceBusClient(connectionString);
        _serviceBusSender = _serviceBusClient.CreateSender(queueName);
        await _serviceBusSender.SendMessageAsync(new ServiceBusMessage(message));
    }

    public ServiceBusProcessor CreateProcessor()
    {
        _serviceBusClient = new ServiceBusClient(connectionString);
        return _serviceBusClient.CreateProcessor(queueName);
    }

    public async void CreateTopic(string topicName)
    {
        ServiceBusAdministrationClient serviceBusAdministrationClient = new ServiceBusAdministrationClient(connectionString);
        await serviceBusAdministrationClient.CreateTopicAsync(topicName);
    }

    public async void CreateSubscrption(string topicName, string subscriptionName)
    {
        ServiceBusAdministrationClient serviceBusAdministrationClient = new ServiceBusAdministrationClient(connectionString);
        serviceBusAdministrationClient.CreateSubscriptionAsync(
            new CreateSubscriptionOptions(topicName, subscriptionName));
    }

    public async Task ReceiveMessageAsync(string subscriptionName, string topicName)
    {
        _serviceBusClient = new ServiceBusClient(connectionString);
        ServiceBusReceiver receiver = _serviceBusClient.CreateReceiver(topicName, subscriptionName);
        while (true)
        {
            ServiceBusReceivedMessage messageReceived =await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(5));
            //Récupération du message
        }
    }
}