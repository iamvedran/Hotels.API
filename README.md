# Hotels.API

This is a demo project showcasing a web API for hotel management. The API allows you to perform various operations related to hotels, such as retrieving hotel information, adding new hotels, updating hotel details, and deleting hotels. It is built using .NET Core 6, a powerful and cross-platform framework for building modern web applications.

## Features

- Retrieve a list of hotels
- Get detailed information about a specific hotel
- Add a new hotel to the system
- Update existing hotel details
- Delete a hotel from the system
- JWT Security: The application uses JWT (JSON Web Tokens) to secure the API and handle user authentication and authorization.
- AutoMapper for object mapping
- Serilog for structured logging capabilities
- Swagger API Documentation: Swagger is integrated into the project for generating API documentation, making it easier to explore and understand the available endpoints.
- Unit Testing with nUnit: The project includes simple token a unit test written using nUnit framework to ensure the correctness of individual components and functionalities.

## Technologies Used

- .NET Core 6: A free and open-source web framework for building modern web applications using C#.
- C#: A powerful, statically-typed programming language for building a wide range of applications.
- Entity Framework Core: An Object-Relational Mapping (ORM) framework that simplifies database operations and management.
- ASP.NET Core: A framework for building web APIs and web applications.
- RESTful API: The API follows the principles of Representational State Transfer (REST) architecture.
- JSON: The API uses JSON (JavaScript Object Notation) as the data interchange format.

## Getting Started

To get a local copy of this project up and running, follow these steps:

1. Clone this repository to your local machine.
2. Open the solution file (`Hotels.sln`) in your preferred development environment.
3. Build the solution to restore the NuGet packages and compile the project.
4. Set up the database connection string in the `appsettings.json` file.
5. Run the database migrations to create the required tables using Entity Framework Core.
6. Start the application and make requests to the API endpoints.
