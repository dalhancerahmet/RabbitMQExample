using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        ConnectionFactory factory = new ConnectionFactory();
        factory.Uri = new Uri("amqps://wfnfeekq:N7I76Tsz7TViCmlw2HocY5v1F0ZrJSQl@cow.rmq2.cloudamqp.com/wfnfeekq");

        using (IConnection connection = factory.CreateConnection())
        using (IModel channel = connection.CreateModel())
        {
            channel.QueueDeclare("mesajkuyrugu", false, false, false);
            EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
            channel.BasicConsume("mesajkuyrugu", false, consumer);
            consumer.Received += (sender, e) =>
            {
                //e.Body : Kuyruktaki mesajı verir.
                Console.WriteLine(Encoding.UTF8.GetString(e.Body));
            };
        }
        Console.Read();
    }
}