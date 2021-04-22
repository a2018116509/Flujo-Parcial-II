namespace ApiProductor.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;
    using Azure.Messaging.ServiceBus;
    using ApiProductor.Models;
    using Newtonsoft.Json;
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        [HttpPost]
        public async Task<bool> EnviarAsync([FromBody] Data data)
        {
            string connectionString = "Endpoint=sb://queueraspberryparcial2.servicebus.windows.net/;SharedAccessKeyName=enviar;SharedAccessKey=5ByTvkmxIKC0nh/qc5RsmDv0jK8DV4pQPngfqtIh4yk=;EntityPath=colaparcial2";
            string queueName = "colaparcial2";
            String mensaje = JsonConvert.SerializeObject(data);
            await using (ServiceBusClient client = new ServiceBusClient(connectionString))
            {
                // create a sender for the queue 
                ServiceBusSender sender = client.CreateSender(queueName);

                // create a message that we can send
                ServiceBusMessage message = new ServiceBusMessage(mensaje);

                // send the message
                await sender.SendMessageAsync(message);
                Console.WriteLine($"Sent a single message to the queue: {queueName}");
            }

            return true;
        }
    }
}
