using Azure.Messaging.ServiceBus;

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
}