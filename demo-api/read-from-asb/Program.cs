// See https://aka.ms/new-console-template for more information

using asb_tools.Classes;
using Azure.Messaging.ServiceBus;

static async void Main()
{
    ASBService asbService = new ASBService();
    ServiceBusProcessor processor = asbService.CreateProcessor();
    processor.ProcessMessageAsync += HandleMessage;
    await processor.StartProcessingAsync();

}

static async Task HandleMessage(ProcessMessageEventArgs eventArgs)
{
    Console.WriteLine($"{eventArgs.Message.Body.ToString()}");
    await eventArgs.CompleteMessageAsync(eventArgs.Message);
}

Main();