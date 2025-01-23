## YouBlog ##
Simple API for a blog with posts and comments.

### Architecture ###
Monolithic architecture with a single service, split in 4 layers.
 - **Api**: Contains the controllers and the logic relatable to the API.
 - **Application**: Contains the business logic and the application services.
 - **Infrastructure**: Contains the data access logic, the database context and general infrastructure logic.
 - **Models**: Contains the domain entities.

### Database ###
Currently, the application is using an in-memory database. 
The database starts empty every time the application is started.

### Executing the application ###
Make sure you have the .NET 9 SDK installed in your machine. You can download it [here](https://dotnet.microsoft.com/download).

To run the application, execute the following command in the root folder of the project:

```dotnet run --project ./YouBlog.Api/YouBlog.Api.csproj```

Open your favorite browser and navigate to the following URL to access the Swagger documentation:
http://localhost:5214/swagger

### Debugging the application ###
Make sure you have the .NET 9 SDK installed in your machine. You can download it [here](https://dotnet.microsoft.com/download).

To debug the application, open the project in your favorite IDE and run the project with the `YouBlog.Api` profile.
We recommend using Visual Studio or JetBrains Rider.

### Future Implementations ###
 - **Database**: Implement a database for the application.
 - **Authentication**: Implement JWT authentication for the API.
 - **Authorization**: Implement role-based authorization for the API.
 - **Logging**: Implement logging for the application.
 - **Exception Handling**: Implement exception handling for the application.
 - **SSL**: Implement SSL for the application.
 - **Unit Tests**: Implement unit tests for the application.
 - **Integration Tests**: Implement integration tests for the application.
 - **CI/CD**: Implement CI/CD pipelines for the application.
 - **Frontend**: Implement a frontend for the application.