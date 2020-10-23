using VendingMachine.InternalBusMessages;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Configuration;
using System.Text;

namespace VendingMachine.Snacks
{
    public static class RabbitMQPublisher
    {
        public static void PublishMessage(BaseMessage message)
        {
            string userName = ConfigurationManager.AppSettings["RabbitMQUserName"];
            string password = ConfigurationManager.AppSettings["RabbitMQPassword"];
            string hostName = ConfigurationManager.AppSettings["RabbitMQHost"];
            string port = ConfigurationManager.AppSettings["RabbitMQPort"];
            string virtualHost = ConfigurationManager.AppSettings["RabbitMQVirtualHost"];

            var connectionFactory = new ConnectionFactory()
            {
                UserName = userName,
                Password = password,
                HostName = hostName,
                Port = int.Parse(port),
                VirtualHost = virtualHost
            };
            var connection = connectionFactory.CreateConnection();
            var model = connection.CreateModel();
            var properties = model.CreateBasicProperties();
            model.QueueDeclare(queue: "CardSlotsMessage", durable: false, exclusive: false, autoDelete: false, arguments: null);
            properties.Persistent = false;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(message, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All });
            byte[] messagebuffer = Encoding.Default.GetBytes(json);
            model.BasicPublish("", "CardSlotsMessage", properties, messagebuffer);
        }
    }
}