# foxyecomm
This project contains basic concepts of ecommerce and this project demonstrates the implementation of domain driven development and cqrs.On the other hand i have been used  microservice architectural patterns.I will continue to develop this application in my spare time.
 

<h2>Prerequisites</h2>

<ul>
<li>PostgreSql</li>
<li>MongoDb</li>
<li>RabbitMQ</li>
<li>Concul for service discovery</li>
<li>Redis(to be added for caching)</li>
<li>Elastic Search(to be added for searching)</li>
</ul>
 
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

<h2>Notes</h2>
I used rabbitmq as message broker for manage commands and events.Also I used mongodb as  CQRS Event Store.And all products using docker containers , so you may need to change the configurations.

Cheers!
