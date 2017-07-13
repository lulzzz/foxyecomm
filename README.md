# foxyecomm
 It is an e-commerce infrastructure developed with microservice architecture.It mainly includes DDD / CQRS implementation.
 
 
Includes the following services 

<ul>
<li>Inventory Service(in progress)</li>
<li>Brand Service(to be added)</li>
<li>Category Service(to be added)</li>
<li>Basket Service(to be added)</li>
<li>Order Service(to be added</li>
<li>Transaction Service(to be added</li>
<li>Notification Service(to be added</li>
<li>Image Service(to be added</li>
</ul>

<h2>Architecture</h2>

Rabbitmq is used For lightweight message queue.RabbitMQ manage commands and events as message brokers.On the other hand MongoDb is used for CQRS Event Store


<h2>Prerequisites</h2>

<ul>
<li>PostgreSql</li>
<li>MongoDb</li>
<li>RabbitMQ</li>
<li>Concul for service discovery</li>
<li>Redis(to be added for caching)</li>
<li>Elastic Search(to be added for searching)</li>
</ul>

<b>Note</b>
I am using docker containers for all products(postgresql,mongodb etc) , so you may need to change the configurations.
