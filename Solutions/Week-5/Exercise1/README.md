# Kafka Integration with C#

## Overview
This repository demonstrates Kafka integration with C# using two separate tasks organized into respective sub-directories:
- **Task 1:** Chat application using ASP.NET Core Web API + Kafka
- **Task 2:** Chat application using Windows Forms (.NET) + Kafka
---
## Prerequisites

- [.NET 6+ SDK](https://dotnet.microsoft.com/download)
- [Apache Kafka](https://kafka.apache.org/downloads) installed locally
- [Zookeeper](https://zookeeper.apache.org/) (comes with Kafka)
---
## Kafka & Zookeeper Setup (Windows CLI)

1. Open CMD in Kafka directory  
2. Start Zookeeper:
   ```bash
   .\bin\windows\zookeeper-server-start.bat .\config\zookeeper.properties
   ```
3. Open new CMD => Start Kafka Broker:
    ```bash
    .\bin\windows\kafka-server-start.bat .\config\server.properties
    ```
4. Create a topic:
    ```bash
    .\bin\windows\kafka-topics.bat --create --topic chat-topic --bootstrap-server localhost:9092 --partitions 1 --replication-factor 1
    ```
---
## Project Structure
```graphsql
Kafka-CSharp-Chat/
│
├── Task1_WebAPI_Kafka/
│   └── README.md   # Web API + Kafka console output
│
├── Task2_WinForms_Kafka/
│   └── README.md   # WinForms GUI app using Kafka
├── outputs.png     # Outputs
└── README.md       # Global setup & summary
```
---
## How to Run
### Task 1: ASP.NET Core Web API + Kafka
- Run ASP.NET Core Web API
- Send messages via Swagger or Postman
- Console prints consumed Kafka messages
### Task 2: Windows Forms Chat App
- Run multiple WinForms clients
- Send/receive messages in real-time
- Chat view updates via Kafka consumer