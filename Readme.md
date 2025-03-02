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






