using Azure.Storage.Queues;

namespace demo_message_queue.Services;

public class MessageQueueService
{
    private static string connectionString = @"DefaultEndpointsProtocol=https;AccountName=utopiosstorage;AccountKey=krVM/IOwW0SIpHKyCaLuD3QLqpiPawpW2/WIfCRsyl2XsH1T3KPvipZwNd5u0ZL48kQm0ArGsyAL+AStwOI7DQ==;EndpointSuffix=core.windows.net";

    public bool CreationQueue(string name)
    {
        QueueClient queueClient = new QueueClient(connectionString, name);
        queueClient.CreateIfNotExists();
        return queueClient.Exists();
    }

    public bool SendMessage(string name, string message)
    {
        QueueClient queueClient = new QueueClient(connectionString, name);
        if (queueClient.Exists())
        {
            queueClient.SendMessage(message);
            return true;
        }

        return false;
    }
}