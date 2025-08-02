# Clean Architecture with Blazor and .NET 8

This repository is a sample web application built with .NET 8 and Blazor, demonstrating a full-stack solution using Clean Architecture principles. It includes features like user authentication, CRUD operations, and a containerized SQL Server database for development.

## Features

* **Full-Stack Application:** Frontend and backend are built within a single, unified Blazor Web App project.
* **Clean Architecture:** The solution is structured into four distinct layers (Core, Application, Infrastructure, Web) to ensure separation of concerns, maintainability, and testability.
* **Authentication & Authorization:** Uses ASP.NET Core Identity for secure user registration and login. Pages and API endpoints are protected.
* **CRUD Operations:** A complete example of Create, Read, Update, and Delete functionality for a "Product" entity.
* **Dockerized Database:** Uses Docker Compose to run a SQL Server instance, providing a consistent and isolated development environment.
* **Entity Framework Core:** Leverages EF Core with a repository pattern for data access and migrations for database schema management.

## Architecture

The project follows the principles of Clean Architecture, with dependencies pointing only inwards:

* **`Core`**: Contains the core business logic, including entities and repository interfaces. It has no dependencies on other layers.
* **`Application`**: Contains application-specific logic and use cases (Commands and Queries). It depends only on the `Core` layer.
* **`Infrastructure`**: Contains the implementation details for external concerns, such as the database context (`AppDbContext`), repositories, and other services. It depends on the `Application` layer.
* **`Web`**: The presentation layer. This is the Blazor Web App project containing UI components, API controllers, and the application's startup configuration. It depends on the `Application` and `Infrastructure` layers.

## Getting Started

### Prerequisites

* [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
* [Docker Desktop](https://www.docker.com/products/docker-desktop)
* A Git client

### Setup and Running the Project

1.  **Clone the Repository**
    ```bash
    git clone <YOUR_REPOSITORY_URL>
    cd CleanArchitectureBlazor
    ```

2.  **Configure the Database Password**
    * Open the `docker-compose.yml` file.
    * Change the `SA_PASSWORD` environment variable to your own strong password.

3.  **Start the Database Container**
    * Make sure Docker Desktop is running.
    * In your terminal, run the following command to start the SQL Server container in the background:
        ```bash
        docker-compose up -d
        ```

4.  **Update the Connection String**
    * Open the `Web/appsettings.json` file.
    * Update the `Password` in the `DefaultConnection` string to match the `SA_PASSWORD` you set in the `docker-compose.yml` file.

5.  **Apply Database Migrations**
    * This command will create the database and all the necessary tables (Products, Identity, etc.).
    * Run this from the root directory of the project:
        ```bash
        dotnet ef database update --startup-project Web
        ```

6.  **Run the Application**
    * Navigate to the `Web` project folder and run the application:
        ```bash
        cd Web
        dotnet watch
        ```
    * The application will be available at the URL shown in the terminal (e.g., `http://localhost:5112`).

You can now navigate to the application, register a new user, and access the Products CRUD page.