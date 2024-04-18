# Project Name: Mini Portfolio Web API

## Introduction
This repository contains a .NET Web API project designed as a mini portfolio to showcase the implementation of clean code and a clean architecture approach. The project is structured into five layers, ensuring separation of concerns and scalability.

## Architecture Layers
- **Presentation Layer**: The user interface of the application. This layer is responsible for handling HTTP requests and responses.
- **Infrastructure Layer**: Manages data access and external resources like databases, file systems, and network services.
- **Application Layer**: Contains business logic and application services. It acts as a mediator between the presentation and domain layers.
- **Domain Layer**: The core layer where business models and entities are defined.
- **Common Layer**: Provides shared utilities and resources across the application.

## Design Patterns
- **Generic Repository**: Abstracts the data layer to provide a reusable interface for accessing data sources.
- **Specification Design Pattern (DP)**: Enables business rules to be encapsulated in a flexible way.
- **Unit of Work**: Maintains a list of domain actions and commits them as a single transaction.

## Features
- **Global Error Handling**: Ensures that all unhandled exceptions are caught and handled gracefully.
- **Localization**: Supports multiple languages and cultures, making the application globally accessible.

## Getting Started
To get started with this project, clone the repository and open it in your preferred .NET development environment.

## Prerequisites
- .NET SDK
- Any relational database (e.g., SQL Server, PostgreSQL)

## Build and Run
To build and run the project, use the following commands:
```bash
dotnet restore
dotnet build
dotnet run
