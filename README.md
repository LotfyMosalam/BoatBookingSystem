# Boat & Trip Booking System – Apps Square Task

## Overview

This project is a **Boat and Trip Booking System** developed.
It is built using **.NET 9** and follows **Clean Architecture**, **CQRS**, and modern backend best practices.

The system supports three user roles:

* **Admin** – manages users, boats, and reservations.
* **Owner** – registers boats, creates trips, and manages services.
* **Customer** – browses boats/trips and makes reservations.

---

## Technologies Used

* .NET 9
* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* MediatR (CQRS)
* JWT Authentication
* Serilog Logging
* FluentValidation
* Swagger (OpenAPI)

---

## Architecture

The project follows **Clean Architecture** with four main layers:

```
BoatBookingSystem
│
├── API
│   └── Controllers, Middleware, JWT, Swagger
│
├── Application
│   └── CQRS, DTOs, Interfaces, Validators, Behaviors
│
├── Infrastructure
│   └── EF Core, Repositories, Database, Logging
│
└── Domain
    └── Entities, Enums, Core Business Models
```

### Key Patterns Used

* **CQRS** using MediatR
* **Repository Pattern**
* **Dependency Injection**
* **Global Exception Handling**
* **Validation Pipeline**

---

## User Roles & Features

### Admin

* Approve or reject user registrations
* Approve or reject boats
* View all reservations

### Owner

* Register and await approval
* Add boats (pending admin approval)
* Create and manage trips
* Add additional services
* View reservations

### Customer

* Register and browse trips/boats
* Book trips with additional services
* Book boats
* Cancel reservations within allowed period

---

## Authentication & Authorization

* JWT-based authentication
* Role-based authorization:

  * `Admin`
  * `Owner`
  * `Customer`

All protected endpoints require a valid JWT token.

---

## Database

* SQL Server
* Entity Framework Core
* Code-first approach using migrations

Main entities:

* ApplicationUser
* Boat
* Trip
* Reservation
* AdditionalService
* ReservationService

---

## Getting Started

### 1. Clone the repository

```bash
git clone <repository-url>
cd BoatBookingSystem
```

---

### 2. Configure the database

Open:

```
BoatBookingSystem.API/appsettings.json
```

Update the connection string if needed:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=BoatBookingDb;Trusted_Connection=True;TrustServerCertificate=True"
}
```

---

### 3. Apply migrations

Open **Package Manager Console**:

* Set default project to:

```
BoatBookingSystem.Infrastructure
```

Run:

```powershell
Update-Database
```

---

### 4. Run the project

Set startup project:

```
BoatBookingSystem.API
```

Press:

```
F5 or Ctrl + F5
```

---

### 5. Open Swagger

Navigate to:

```
https://localhost:<port>/swagger
```

---

## Default Admin Account

The system seeds a default admin user:

```
Email: admin@system.com
Password: Admin123!
Role: Admin
```

Use this account to:

* Approve owners
* Approve boats
* Manage reservations

---

## API Authentication in Swagger

1. Login using `/api/auth/login`
2. Copy the returned JWT token
3. Click **Authorize** in Swagger
4. Paste the token
5. Call protected endpoints

---

## Logging

The system uses **Serilog**:

* Logs to console
* Logs to daily rolling files:

```
Logs/log-<date>.txt
```

---

## Validation

* Implemented using **FluentValidation**
* Automatically triggered via MediatR pipeline
* Returns structured validation errors

---

## Error Handling

* Global exception middleware
* Handles:

  * Server errors
  * Validation errors
* Returns consistent JSON responses

---

## Project Structure (Simplified)

```
BoatBookingSystem.API
BoatBookingSystem.Application
BoatBookingSystem.Infrastructure
BoatBookingSystem.Domain
```

---

## Sample API Flow

### Owner Registration

```
POST /api/auth/register
Role: Owner
```

### Admin Approval

```
POST /api/admin/approve-user/{userId}
```

### Owner Creates Boat

```
POST /api/owner/boats
```

### Customer Books Trip

```
POST /api/customer/book-trip
```

---

## Notes

* All write operations use **CQRS commands**
* All read operations use **CQRS queries**
* User IDs are extracted from JWT tokens (not request body)

---

## Author

**Lotfy Abdalla Mosalam**
Full Stack Developer (.NET & Angular)
