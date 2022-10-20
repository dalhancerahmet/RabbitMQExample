using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        ConnectionFactory factory = new ConnectionFactory();
        factory.Uri = new Uri("amqps://wfnfeekq:N7I76Tsz7TViCmlw2HocY5v1F0ZrJSQl@cow.rmq2.cloudamqp.com/wfnfeekq");
        IConnection connection = factory.CreateConnection();
        IModel channel = connection.CreateModel();

        channel.QueueDeclare("mesajkuyrugu", false, false, false);
        EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
        channel.BasicConsume("mesajkuyrugu", false, consumer);
        consumer.Received += (sender, e) =>
        {
            var body = e.Body.ToArray();
            Console.WriteLine(Encoding.UTF8.GetString(body));

        };
        Console.ReadLine();
    }
}