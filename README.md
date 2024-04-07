# Project Summary 

Imagine a revolutionary software project that combines cutting-edge technologies and industry best practices to create a truly exceptional application. Built on the powerful foundation of .NET Core 8, this project embodies the principles of SOLID design, ensuring a codebase that is robust, flexible, and maintainable.

At the heart of this project lies the Clean Architecture, which provides a clear separation of concerns and promotes testability and scalability. Domain-Driven Design (DDD) shapes the architecture, ensuring that the software closely models the real-world problem domain, resulting in a more intuitive and adaptable system.

For the frontend, the project utilizes React with Vite, offering a lightning-fast development experience. The use of Tailwind CSS further enhances the frontend development process, providing a utility-first approach to styling that allows for rapid prototyping and easy customization.

To manage communication between different parts of the system, the project employs the Mediator pattern. This pattern simplifies the interaction between components, reducing dependencies and making the system more maintainable.

For data access and persistence, the project leverages the Repository pattern and Unit of Work. These patterns provide a clean and consistent way to interact with the database, improving code maintainability and testability.

To ensure portability and scalability, the project is containerized using Docker. Docker containers encapsulate each component, making it easy to deploy and scale the application across different environments.

In summary, this project represents the pinnacle of modern software development, combining .NET Core 8, React with Vite, Tailwind CSS, SOLID principles, Clean Architecture, DDD, Mediator pattern, Repository pattern, Unit of Work, and Docker to deliver a high-performance, scalable, and maintainable solution.

--------------------------------------------------------------------------------------------------------------------------------------------------------------------

**MSSQL Setup**

`docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Admin@123" -v mssqlvol:/var/opt/mssql -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:latest`

`Data Source=localhost;Initial Catalog=Obloo;User ID=sa;Trust Server Certificate=True`

**Mongo Setup**

`docker run -v mongodbvol:/var/opt/mongodbvol -p 8081:8081 --name mongo -d mongo:latest`

`docker exec -it mongo bin/bash`

`docker run -d -p 3000:3000 -v mongodbvol:/var/opt/mongodbvol mongoclient/mongoclient`

Add-Migration InitialCreate

`Update-Database`

`docker compose -f docker-compose.yml -f docker-compose.override.yml up -d`

`docker-compose run Obloo/src/Obloo.Infrastructure dotnet ef migrations add InitialCreate`

`docker-compose run Obloo dotnet ef database update`

`docker exec -it obloo.api bash`

# docker managment doc 
https://learn.microsoft.com/en-us/aspnet/core/security/docker-compose-https?view=aspnetcore-8.0
