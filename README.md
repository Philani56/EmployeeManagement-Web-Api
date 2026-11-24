# Employee Management Web API

A RESTful Web API built with ASP.NET Core for managing employee records, departments, and organizational data.

## Features

- **Employee CRUD Operations:** Create, read, update, and delete employee profiles.
- **RESTful Architecture:** Standard HTTP methods and status codes.
- **Database Integration:** Configured with Entity Framework Core (update with your specific DB, e.g., SQL Server / SQLite / PostgreSQL).
- **API Documentation:** Interactive Swagger / OpenAPI UI for testing endpoints.

## Tech Stack

- **Framework:** .NET / ASP.NET Core Web API
- **Language:** C#
- **ORM:** Entity Framework Core
- **Tools:** Visual Studio / .NET CLI

## Getting Started

### Prerequisites

- [.NET SDK](https://microsoft.com) (e.g., .NET 8.0 or later)
- SQL Server (or your configured database provider)

### Installation & Setup

1. **Clone the repository:**
   ```bash
   git clone git@github.com:Philani56/EmployeeManagement-Web-Api.git
   cd EmployeeManagement-Web-Api
   ```

2. **Configure the database connection:**
   Update the `ConnectionStrings` section in `EmployeeManagement/appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER;Database=EmployeeManagementDb;Trusted_Connection=True;TrustServerCertificate=True;"
   }
   ```

3. **Apply database migrations:**
   ```bash
   dotnet ef database update --project EmployeeManagement
   ```

4. **Run the application:**
   ```bash
   dotnet run --project EmployeeManagement
   ```

5. **Explore the API:**
   Once running, open your browser and navigate to `https://localhost:<port>/swagger` (or `/scalar`) to view and test the endpoints.

## API Endpoints

| Method | Endpoint | Description |
| :--- | :--- | :--- |
| `GET` | `/api/employees` | Retrieve a list of all employees |
| `GET` | `/api/employees/{id}` | Retrieve a specific employee by ID |
| `POST` | `/api/employees` | Add a new employee |
| `PUT` | `/api/employees/{id}` | Update an existing employee |
| `DELETE` | `/api/employees/{id}` | Delete an employee |

*(Update the routes above to match your exact controller endpoints.)*

## Author

- **Philani Khumalo** – [@Philani56](https://github.com)
