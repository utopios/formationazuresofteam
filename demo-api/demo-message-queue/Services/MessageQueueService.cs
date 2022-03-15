using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;

namespace demo_message_queue.Services;

public class MessageQueueService
{
    private static string connectionString = @"DefaultEndpointsProtocol=https;AccountName=utopiosstorage;AccountKey=krVM/IOwW0SIpHKyCaLuD3QLqpiPawpW2/WIfCRsyl2XsH1T3KPvipZwNd5u0ZL48kQm0ArGsyAL+AStwOI7DQ==;EndpointSuffix=core.windows.net";
    private QueueClient queueClient;
    public bool CreationQueue(string name)
    {
        queueClient = new QueueClient(connectionString, name);
        queueClient.CreateIfNotExists();
        return queueClient.Exists();
    }

    public bool SendMessage(string name, string message)
    {
        queueClient = new QueueClient(connectionString, name);
        if (queueClient.Exists())
        {
            queueClient.SendMessage(message);
            return true;
        }

        return false;
    }

    public string GetLastMessage(string name)
    {
        queueClient = new QueueClient(connectionString, name);
        QueueMessage[] messages = queueClient.ReceiveMessages();
        string content = messages[0].MessageText;
        queueClient.DeleteMessage(messages[0].MessageId, messages[0].PopReceipt);
        return content;
    }
}