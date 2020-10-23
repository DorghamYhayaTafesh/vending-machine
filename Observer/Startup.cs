using RabbitMQ.Client;
using System;
using System.Configuration;

namespace VendingMachine.Observer
{
    class Startup
    {
        static void Main(string[] args)
        {
            string userName = ConfigurationManager.AppSettings["RabbitMQUserName"];
            string password = ConfigurationManager.AppSettings["RabbitMQPassword"];
            string hostName = ConfigurationManager.AppSettings["RabbitMQHost"];
            string port = ConfigurationManager.AppSettings["RabbitMQPort"];
            string virtualHost = ConfigurationManager.AppSettings["RabbitMQVirtualHost"];
            ConnectionFactory connectionFactory = new ConnectionFactory
            {
                UserName = userName,
                Password = password,
                HostName = hostName,
                Port = int.Parse(port),
                VirtualHost = virtualHost
            };
            var connection = connectionFactory.CreateConnection();
            var channel = connection.CreateModel();

            channel.BasicQos(0, 1, false);
            // the channel body will be deserialized.
            //BaseConsumer messageReceiver;
            //switch (typeof(body))
            //{
            //    case typeof(OpenCardSlotMessage):
            //        messageReceiver = new CardSlotConsumer(); break;

            //        and so on ....
            //}

            //channel.BasicConsume("CardSlotsMessage", false, messageReceiver);
            Console.ReadLine();

        }
    }
}
