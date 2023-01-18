Jobsity .NET Backend Challenge

## Assignment
The goal of this exercise is to create a simple browser-based chat application using .NET.
This application should allow several users to talk in a chatroom and also to get stock quotes
from an API using a specific command.


Authenticated users (.NET Identity) are able to chat in the chatroom.
The chat will load the last 50 messages.
Market Quotes can be requested to Chat-Bot using the following command format: /stock=aapl.us
The chatbot will call an external API to retrieve the information and will send a message back to the chatroom with the quote.

ls@Author Aldo Bento

Generate Database from Package Manager Console in Visual Studio

## Installation
* Download the repo and open the Chat.sln file.

Update-Database -Context IdentityDbContext -StartupProject Jobsity.Chat.UI -Project Jobsity.Chat.DataContext Update-Database -Context ChatDbContext -StartupProject Jobsity.Chat.UI -Project Jobsity.Chat.DataContext Install and run RabbitMq with Docker
Running local instance of RabbitMq using Docker

docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management
Confirm RabbitMq is running going to your browser and opening http://127.0.0.1:15672/