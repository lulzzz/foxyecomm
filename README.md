# foxyecomm
 It is an e-commerce infrastructure developed with microservice architecture.It mainly includes DDD / CQRS implementation.
 
 
Includes the following services 

<ul>
<li>Inventory Service</li>
<li>Brand Service</li>
<li>Category Service</li>
<li>Basket Service</li>
<li>Order Service</li>
<li>Transaction Service</li>
<li>Notification Service</li>
<li>Image Service</li>
<li>Slider Service</li>
</ul>

<h2>Architecture</h2>

Rabbitmq is used For lightweight message queue.RabbitMQ manage commands and events as message brokers.On the other hand MongoDb is used for CQRS Event Store


<h2>Prerequisites</h2>

<ul>
<li>PostgreSql</li>
<li>MongoDb</li>
<li>RabbitMQ</li>
<li>Redis(to be added for caching)</li>
<li>Elastic Search(to be added for searching)</li>
</ul>

<b>Note</b>
I am using docker containers for all products(postgresql,mongodb etc) , so you may need to change the configurations.
