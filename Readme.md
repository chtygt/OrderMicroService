# Sipariş Mikroservis Uygulaması

## Servisler
    -Customer
    -Product
    -Order
    -Report

Veritabanı olarak Postgresql, ORM olarak Entity framework, message queue olarak RabbitMQ kullandım. Bu versiyonda CQRS Pattern iplemantasyonunu yetiştiremedim.
Siparişlerin tarih aralığına göre raporlanabilmesi için RabbitMQ üzerinden kuyruk oluşmaktadır.

## Kurulum
Bilgisayarınızda docker ve docker-compose kurulu ise docker-compose.yml dosyası ile servisleri çalıştırabilirsiniz.
Docker Desktop ve Visual studio 2022 kurulu ise doğrudan VS 2022 içerisinden docker-compose projesini çalıştırabilirsiniz. 
Veritabanları development ortamında otomatik migrate edilmektedir.  

Aşağıdaki adresler ile servislere erişebilirsiniz.
 

customer-service

	http://localhost:5033

customer-service-db

	customer-service-db:3510
		

product-service
	
	http://localhost:5033

product-service-db
	
	product-service-db:3520

order-service
	
	http://localhost:5033

order-service-db
	
	order-service-db:3530


report-service
	
	http://localhost:5033

report-service-db
	
	report-service-db:3540
	

Rabbitmq
	
	http://localhost:5672
	


Sonarqube raporu

![alt text](https://github.com/chtygt/OrderMicroService/blob/master/Sonarqube.jpg?raw=true)

