# RabbitMQExample
RabbitMQExample

Yapılan işlem basit düzeyde RabbitMQ kullanımı ile ilgili ve bir eğitim içeriği olarak hazırlanmıştır.

1. Adım ConnectionFactory sınıfından nesne türetmek
2. Adım türetilen bu nesnenin Uri'sini vermek
3. Adım factory nesnesinden connection oluşturmak
4. Adım oluşturulan connectiondan bir model(channel) oluşturmak

Bundan sonraki adımlar en son oluşturduğumuz channel nesnesi üzerinden devam edecektir.
5. Adım channel.QueueDeclare ile kuyruk oluşturup gerekli konfigurasyonlarını yapmak
6. Adım göndermek istediğimiz string türündeki değeri byte arrayine çevirmek
7. Adım ve son adım olarak  channel.BasicPublish ile body ile byte arrayine dönüştürülen metinsel değeri göndermek.

Buraya kadar BasicPublish işlemini yaptık.
Bundan sonra BasicConsume yani RabbitMQ'ya gönderilen mesajı alan tarafı yazacağız.

Yukarıdaki 5. Adıma kadar olan herşey burada da geçerli

1. Adım EventingBasicConsumer sınıfından consumer(alıcı/tüketici) nesnesini türetmek
2. Adım BasicConsume ile gerekli configuration işlemlerini yapmak
3. Adım consumer.Received ile kuyruktaki mesajları tek tek dolaşıp, buna göre işlem yapmak.
4. Adım gelen mesaj byte array türünden olduğu için, okumak adına bunu tekrar string ifadeye dönüştürmek gereklidir.

Encoding.UTF8.GetString(body) ile string değere dönüştürüyoruz.

Bitti :)
