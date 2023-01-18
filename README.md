## Jobsity .NET Backend Challenge

## Assignment
The goal of this exercise is to create a simple browser-based chat application using .NET.
This application should allow several users to talk in a chatroom and also to get stock quotes
from an API using a specific command.

## Functionalities
Authenticated users (.NET Identity) are able to chat in the chatroom.
The chat will load the last 50 messages.
Market Quotes can be requested to Chat-Bot using the following command format: /stock=aapl.us
The chat bot will call an external API to retrieve the information and will send a message back to the chatroom with the quote.

@Author Aldo Bento

Generate Database from Package Manager Console in Visual Studio

## Installation
* Download the repo and open the Chat.sln file.
* Install Sql Server locally
* Run the command `dotnet ef database update` to create database tables.
* Run the Chat.UI project and StockBot.Api project