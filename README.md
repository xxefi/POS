# POS System

This is a comprehensive POS (Point of Sale) system that allows businesses to manage their inventory, process orders, handle payments, and generate reports. The system is designed for flexibility and scalability, making it suitable for both small businesses and large enterprises.

## Table of Contents

- [Features](#features)
- [Tech Stack](#tech-stack)
- [Project Structure](#project-structure)
- [Installation](#installation)
- [Configuration](#configuration)
- [Usage](#usage)
- [API Documentation](#api-documentation)
- [Contributing](#contributing)
- [License](#license)

## Features

- **Inventory Management**: Manage products, categories, ingredients, and menu items.
- **Sales**: Handle orders, payments, and returns.
- **Reporting**: Track sales, generate reports, and view statistics.
- **User Management**: Manage employees, roles, and permissions.
- **Marketing**: Manage customer groups and feedback.
- **Terminal Management**: Configure POS terminals and their settings.

## Tech Stack

- **Backend**: ASP.NET Core, C#
- **Database**: PostgreSQL (Npgsql)
- **Frontend**: React, TypeScript, Tailwind CSS
- **Authentication**: JWT (JSON Web Token)
- **Validation**: FluentValidation
- **APIs**: RESTful API with Swagger documentation

## Project Structure

The project is structured using a multi-layered architecture to separate concerns and ensure maintainability.


### Key Components

- **Entities**: Defines the core business objects such as `CategoryEntity`, `ProductEntity`, `OrderEntity`, etc.
- **Repositories**: Interfaces and classes for data access, located in the `Application` layer.
- **Services**: Business logic encapsulated in services for modularity and reusability.
- **Controllers**: RESTful API endpoints to interact with the system, located in the `WebAPI` layer.

## Installation

### Prerequisites

- .NET 6 SDK
- PostgreSQL
- Node.js (for frontend)
- NPM or Yarn

### Backend

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/pos-system.git
   cd pos-system/POSAdmin.WebAPI
   ```

2. Install backend dependencies:
   ```bash
   dotnet restore
   ```

3.Set up the database:
  Ensure PostgreSQL is installed and running.
  Configure the database connection string in appsettings.json.

4. Apply migrations and seed data:
   ```bash
   dotnet ef database update
   ```

5. Run the backend:
   ```bash
   dotnet run
   ```

Frontend

1. Navigate to the frontend directory:
   ```bash
   cd pos-system/frontend
   ```

2. Install frontend dependencies:
   ```bash
   npm install
   ```

3. Start the frontend:
   ```bash
   npm start
   ```

Configuration
  Backend configuration settings (e.g., database, JWT) can be found in appsettings.json and appsettings.Development.json.
  
  Database: PostgreSQL connection string.
  JWT: Authentication and token settings.
  Swagger: API documentation is enabled by default at /swagger.

Usage
Admin Panel
The admin panel is used to manage the inventory, view sales reports, configure terminal settings, and handle user permissions. You can access it through the frontend at:
  ```bash
http://localhost:3000/admin
  ```

API
  The backend provides a set of RESTful APIs to interact with the POS system. These APIs handle all core business logic, including:
  
  Products: CRUD operations for products.
  Orders: Place and manage orders.
  Users: Handle employee accounts and roles.
  Reports: Generate sales and inventory reports.

API Documentation
  Swagger is integrated for API documentation. You can access the Swagger UI for exploring and testing the APIs:
  ```bash
http://localhost:5000/swagger
```

