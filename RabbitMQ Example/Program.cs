using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        /** Mesajın gönderilmesi, başlangıç **/
        ConnectionFactory factory = new ConnectionFactory();
        factory.Uri = new Uri("amqps://wfnfeekq:N7I76Tsz7TViCmlw2HocY5v1F0ZrJSQl@cow.rmq2.cloudamqp.com/wfnfeekq");
        //factory.HostName = "localhost";

        using (IConnection connection = factory.CreateConnection())
        using (IModel channel = connection.CreateModel())
        {
            channel.QueueDeclare("mesajkuyrugu", false, false,false);
            //queue: Oluşturulacak kuyruğun adını belirliyoruz.
            //durable: Normal şartlarda kuyruktaki mesajların hepsi bellek üzerinde dizilirler. Hal böyleyken RabbitMQ sunucuları bir sebepten dolayı restart atarlarsa tüm veriler kaybolabilir. durable parametresine true değerini verirsek eğer verilerimiz güvenli bir şekilde sağlamlaştırılacak yani fiziksel hale getirilecektir.
            //exclusive: Oluşturulacak bu kuyruğa birden fazla kanalın bağlanıp, bağlanmayacağını belirtir.
            //autoDelete: True değerine karşılık tüm mesajlar bitince kuyruğu otomatik imha eder.
            byte[] message = Encoding.UTF8.GetBytes("Bu bir rabbitMQ üzerinden gönderilen mesajdır.");
            channel.BasicPublish(exchange:"",routingKey:"mesajkuyrugu",body:message);
            //exchange: Eğer exchange kullanmıyorsanız boş bırakınız.Böylece default exchange devreye girecek ve kullanılmış olacaktır.
            //routingKey: Eğer ki default exchange kullanıyorsanız routingKey olarak oluşturduğunuz kuyruğa verdiğiniz ismin birebir aynısını veriniz.
            //body : Gönderilecek mesajın ta kendisidir.
        }
        /** Mesajın gönderilmesi, bitiş **/
    }
}