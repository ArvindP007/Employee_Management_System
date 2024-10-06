# Employee Management API

This project uses .NET version 8

## Setup Instructions

1. **Install .NET 8**  
   Ensure you have .NET 8 installed on your machine. You can download it from [dotnet.microsoft.com].
   (https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-8.0.401-windows-x86-installer)

2. **Clone the Repository**
    
    Once Git is installed, clone this repository to your local machine:
    ```
    git clone 
    ```

5. **Open the Project in Your IDE**
    
    Open the cloned repository in your favorite IDE (e.g., Visual Studio).

6. **Install Dependencies**

    Open the command terminal from the repository folder and run:
    ```
    dotnet restore
    ```
## Run the Application

1. **Run the Development Server**

    Run the following command to start the development server:
    ```
    donet run 
    ```
    Navigate to [Swagger Documentation](https://localhost:7130/swagger/index.html) in your browser

## Project Structure
```
- EmployeeManagementSystem.API
  -----------------------------
  This contains Models, Data and Controllers. 
  Models or Data Transfer Objects (DTOs) used for handling requests and responses. 
  Data manages interactions with the database. 
  The controllers contains main business logic of the application. It contains services that implement the core functionalities and processes. The services interacts with data repositories to interact with database.
  
 ```
### Backend Scalability

1. **Database:**
    - Currently the backend API is using SQL Server database that is good for development purpose as well as for production.
	
2. **API**
    - Currently, the API is returning all the records available in the database.
