using RabbitMQ.Client;
using System.Text;

namespace RabbitMQ
{
    class Program
    {
        static void Main(string[] args)
        {
            string UserName = "guest";
            string Password = "guest";
            string HostName = "localhost";

            var connectionFactory = new ConnectionFactory()
            {
                UserName = UserName,
                Password = Password,
                HostName = HostName
            };
            var connection = connectionFactory.CreateConnection();
            var model = connection.CreateModel();

            // Create Exchange
            //model.ExchangeDeclare("demoExchange", ExchangeType.Direct);
            //Console.WriteLine("Creating Exchange");

            // Create Queue
            //model.QueueDeclare("demoqueue", true, false, false, null);
            //Console.WriteLine("Creating Queue");

            // Bind Queue to Exchange
            //model.QueueBind("test", "test-exchange", "testkey");
            //Console.WriteLine("Creating Binding");

            var properties = model.CreateBasicProperties();
            properties.Persistent = false;

            byte[] messagebuffer = Encoding.Default.GetBytes("Test Message");
            model.BasicPublish("test-exchange","testkey", properties, messagebuffer);
            Console.WriteLine("Message Sent");
        }
    }
}