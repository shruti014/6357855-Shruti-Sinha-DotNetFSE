# Task 1 – Kafka + ASP.NET Core Web API Chat App

## Overview
This task demonstrates a chat message publisher (via Web API) and a consumer that prints the chat messages in the console.
---
## Features

- Publish messages via `POST /api/chat`
- Messages serialized to JSON and sent to Kafka
- Background Kafka consumer prints messages to terminal
- Uses `Confluent.Kafka`, DI, DTOs, and clean controller setup
---
## Tech Stack

- .NET 6 Web API
- Confluent.Kafka (NuGet)
- Swagger / Postman for testing
---
## Kafka Setup

```bash
# Zookeeper
.\bin\windows\zookeeper-server-start.bat .\config\zookeeper.properties

# Kafka
.\bin\windows\kafka-server-start.bat .\config\server.properties

# Create topic
.\bin\windows\kafka-topics.bat --create --topic chat-topic --bootstrap-server localhost:9092 --partitions 1 --replication-factor 1
```
---
## How to Run
- Open the solution in Visual Studio or CLI
- Run the Web API project
- Open Postman
- Test **POST** `/api/chat` with:
    ```json
        {
            "user": "John",
            "message": "Hello Mike!"
        }
    ```
- Terminal shows:
    ```bash
    [12:01:45] Alice: Hello Bob!
    ```