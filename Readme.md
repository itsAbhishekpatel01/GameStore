## Version 1.0.0 Task List
- Initial version of the project
- Created the project structure
- Added the Game model
- Added the GameDto
- Added the InMemoryGameRepository
- Added the GameService
- Added the GameController
- Added the GET, POST, PUT, DELETE endpoints
- Added the REST Client file

ASP.NET Core Web API

Install .NET SDK from https://dotnet.microsoft.com/en-us/download
Install VS Code
Install vs code extensions c# dev tools, sqlite and rest client

There are  couple of ways to create a ASP.NET project
Command dotnet new 
cmd+shift+p -> .NET: New Project
dotnet new web empty project

VS Code Solution Explorer
It help to manage dependencies, add new files, folders, etc.

We will be using builder object to introduce various services in the project

What is request pipeline?
It is a series of middleware components that are executed in the order they are added to the pipeline. Each middleware component can choose to pass the request to the next component in the pipeline or short-circuit the pipeline and not call the next component.

# What is the purpose of the Program.cs file?
It is the entry point of the application.
It contains the Main method which is the first method that is called when the application starts.
It is responsible for creating the host for the application.

# What does .csproj file contain?
It contains the list of files that are part of the project, the project's dependencies, and other information that is used to build the project.

# What is the purpose of the appsettings.json?
It is used to store configuration settings for the application so that we dont have to give hard coded values in the code.

# What is the purpose of the appsettings.Development.json?
It is used to store configuration settings that are specific to the development environment.
It is not used in production. In production, the appsettings.json file is used.

# What is the purpose of the launchSettings.json?
It is used to configure the application's debug settings.
We have the option to configure the environment variables, the application URL, and the launch browser.
We can change url using launchSettings.json file.

# What is the purpose of the obj folder?
It contains the output of the build process.
It contains the intermediate files that are generated during the build process.

# What is the purpose of the bin folder?
It contains the output of the build process.
It contains the final output of the build process, which is the compiled application.

# What is the purpose of the .sln file?
It is the solution file for the project.
It contains information about the projects that are part of the solution.

# How to build the project?
1. Build using Solution Explorer
    - Right click on the project and select Build
2. Build using dotnet build command
    - Open the terminal and run the command dotnet build
3. Build using Visual Studio Code
    - Press cmd+shift+b

# How to run the project?
1. Run using Solution Explorer
    - Right click on the project and select Run
    - Debugger will be attached
2. Run using dotnet run command
    - Open the terminal and run the command dotnet run
    - No debugger will be attached
3. Run using Visual Studio Code
    - Press F5
    - Select c#
    - Select the configuration which is configured in launchSettings.json file
    - Select the environment which is configured in launchSettings.json file
    - Select the default one
    - Debugger will start and the application will run

# What is the purpose of the games.http file?
It is used to test the API endpoints using the REST Client extension in Visual Studio Code.
It contains the HTTP requests that are sent to the API endpoints.

# What is the purpose of the DTO?
It is used to transfer data between the API and the client.
It is used to define the structure of the data that is sent between the API and the client. 
Dtos are contracts between client and server which defines what data will be sent and received.

# Why use record type in DTO?
Record type is immutable and it is a good practice to use immutable types in DTOs.
It makes the code more readable and maintainable.

# Why are we using in memory database in the initial phase?
It is easy to set up and use.
To test the API endpoints without setting up a real database.

# Why are we using Minimal APIs?
It is a new feature in ASP.NET Core that allows us to create APIs with minimal code.
It is a lightweight way to create APIs without the need for controllers and actions.

# Why do we use .WithName() method at the end of apis?
It is used to give a name to the API endpoint.
It is used to identify the API endpoint in the HTTP request.

# Why do we need to make a new Dto for each API endpoint?
Because each API endpoint has different data requirements.
Like creating a new game requires different data than updating a game.

# What happens in the productions when multiple users are trying to access the same resource?
The requests are processed concurrently.
The requests are processed in parallel.
The requests are processed in a thread-safe manner. 

# What is meaning of "GameDto?" ?
It a null level object i.e. it can have GameDto object or null value.

## Version 1.1.0 Completed Task List
- Added the Extension methods
- Added the GameMapper
- Added the GameValidator
- Added the Data Annotations
- Added the MinimalApis.Extensions package
- Added the Validation middleware

# Why do we use Extension methods?
To extend the functionality of a class without modifying the class itself.
To add new methods to a class without changing the class itself.
To make the code more readable and maintainable.


# We do write "/games" most of the time in the apis, why not to make it a constant?
We can use MapGroup() method to group the APIs together.
All of the APIs that are part of the same group start with the same URL segment.
To make this work replace app to group and also return the group object.
Also change WebApplication to RouteGroupBuilder.

# How to validate the data received in the request?
We can check manually if the data is valid or not but it is not a good practice.
We are using Data Annotations to validate the data received in the request.
We give data annotations with [] above the property.
We will use a external dependency called MinimalApis.Extensions to validate the data received in the request.

# What is Nuget ?
NuGet is a package manager for .NET that is used to install, update, and remove packages in a .NET project.
It is used to manage the dependencies of a .NET project.

# Version 1.2.0  Task List
- Added the Entity Framework Core
- Added the SQLite database provider
- Added the DbContext
- Added the Genre model
- Added the GenreDto
- Added dependency injection
- Added GameMapper
- REST API built with Entity Framework Core


# What is Entity Framework Core?
Entity Framework Core is an object-relational mapping (ORM) framework that is used to interact with databases in .NET applications.
It is used to map database tables to .NET objects and vice versa.
It is used to perform CRUD operations on the database.  

# Why if we dont use Entity Framework Core?
We have to write the SQL queries manually.
Need to learn new language.
Error prone.
Need to mannually keep C# models and SQL tables in sync.

# What is benefit of using Entity Framework Core?
No need to learn a new language.
Minimal data-access code(LINQ)
Tooling to keep C# models and SQL tables in sync.
Change tracking
Multiple database support.

# WHAT IS LINQ?
Language Integrated Query (LINQ) is a feature in C# that is used to query data from different data sources.
It is used to query data from collections, databases, XML, and other data sources.
It is used to write queries in C# that are similar to SQL queries.

# What is the purpose of the DbContext class?
It is used to interact with the database.
It is used to define the database schema.
It is used to define the database tables and relationships.

# We have to use Provider Microsoft.EntityFrameworkCore.Sqlite why?
Because we are using SQLite as the database provider.
SQLite is a lightweight database that is used for testing and development purposes.
To use any other database , we need to install the provider from corresponding NuGet package.

# What is DbContext?
DbContext is a object that represents a session with the database.
It is used to query and save data to the database.

# What are DbContext options?
Options containts how to connect to the database.
It contains the connection string, the database provider, and other options that are used to connect to the database.

# What is DbSet?
DbSet is a collection of entities that are used to query and save data to the database.

# Discuss about ASP.NEt Core Configuration System
There are multiple places where we can store configuration settings in an ASP.NET Core application.
- appsettings.json file
- Command line arguments
- Environment variables
- User secrets
- Azure Key Vault
There is an Interface IConfiguration which is used to access the configuration settings in the application.
The good thing is IConfiguration does not care where the configuration settings are stored.

For sqlite, we dont need credential, so we can use appsettings.json file.
But for other databases, we need to use environment variables or user secrets.
Never store sensitive information in the appsettings.json file.

# What is Database Migrations?
-Database migrations are used to update the database schema to match the changes in the application.
-It is used to create, update, and delete database tables and columns.
-It is used to keep the database schema in sync with the application.
We need two packages for migrations
- dotnet ef
- Microsoft.EntityFrameworkCore.Design

# Which command is used to add a migration?
dotnet ef migrations add InitialCreate --output-dir Data/Migrations
You can use any other name instead of InitialCreate.

# How to apply the migration to the database?
dotnet ef database update

# How to make sure that the database is created when the application starts?
We are making a method migrateDb() in the DataExtrensions class.
We are calling this method in the Program.cs file.

# What is OnModelCreating method?
This method will run as soon as the migrations are applied to the database.
We can use this to populate some data in the database.
For example here, we adding some genre data in the database.

# We using another migration to SeedGenres, why?
To seed the genres data in the database as soon as the database is created using this command
dotnet ef migrations add SeedGenres --output-dir Data/Migrations

-- Now We have changes in API to taake advantage of the database.

# What is dependency injection?
Dependency injection is a design pattern that is used to inject dependencies into a class.
It is used to decouple the dependencies from the class.
It is used to make the code more testable and maintainable.

# What are problems if we dont use dependency injection?
We define the custom constructor in the class according to the dependencies.
If any changes in the dependencies, we need to change the constructor in the class.
It is difficult to test the class because the dependencies are tightly coupled with the class.

# What happens in the background when we use dependency injection?
When we use dependency injection, the dependencies are recived as parameters in the constructor.
In this way, the depencencies are not constructed in the class, they are injected from outside.

# Who constructs the dependencies when we use dependency injection?
IServiceProvider constructs the dependencies when we use dependency injection.
Now when the http request comes, the service provider constructs the dependencies and injects them into the controller.

# What is dependency inversion principle?
Dependency inversion principle is a design principle that states that high-level modules should not depend on low-level modules.

# What does IServiceProvider do when a request comes?
IServiceProvider resolve, constructs the dependencies and injects them into the controller when a request comes.

# When another request comes, does IServiceProvider construct the dependencies again?
It depends on the scope of the dependencies.
If the dependencies are scoped, they are constructed again.
If the dependencies are singleton, they are constructed only once.

# Why do we need to change the CreateGameDto?
Because now, Genre is not a string anymore, it is an object.
We need to change the CreateGameDto to reflect this change.

# What means this game.Genre!.Name, why we use ! operator?
It is used to tell the compiler that the value is not null and it can be used safely.

# It is always necessary to respect the dto contract?
Yes, it is always necessary to respect the dto contract.
The dto contract defines the structure of the data that is sent between the client and the server.
If the dto contract is not respected, the data will not be sent correctly between the client and the server.

# What is the purpose of the GameMapper?
Since we were doing a lot of stuffs in the controller, we moved that to the GameMapper.
It is used to map the GameDto to the Game and vice versa.
It is used to map the CreateGameDto to the Game and vice versa.


