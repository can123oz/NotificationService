# Notification Service

Welcome to the Notification Service built by Can Ozdemir. I have been developing in Java for almost a year, and it was fun trying to build a great architecture with .NET, as I have experience with it. This service is developed using .NET 8 and provides a robust notification system. This README will guide you through setting up and running the project using Docker.

## Prerequisites

Before you begin, make sure you have the following installed on your machine:

- [Docker](https://www.docker.com/get-started)

## Setup and Run

To get started with the project, follow these steps:

### 1. Go To Project Directory and run the command

First, make sure you are in the root directory of your project. Then, use the following command to start the Docker containers:

```bash
docker-compose up -d
```

* The application will be accessible at http://localhost:8080/swagger/index.html

### Room for improvement 

* Figure out how to update database from the docker-compose
* Find a dynamic way for handling when a provider is down and switching it.
* Implement priority to your business logic.