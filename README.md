# 🎓 ASP.NET University Management System

A **full-stack ASP.NET Core MVC & Web API application** for managing a university system including **students, teachers, courses, and rooms** with **authentication, role-based authorization, and REST API support**.

This project demonstrates modern backend architecture and best practices such as **Repository Pattern, DTOs, pagination, and Identity authentication**.

---

# 🚀 Features

## 👨‍🎓 Student Management

- Add new students
- Edit student information
- Upload student photos
- Activate / deactivate students
- Delete students
- Register students in courses
- View student course enrollments

---

## 📚 Course Management

- Create courses
- Assign teachers to courses
- Define course capacity
- Track student enrollments

---

## 👨‍🏫 Teacher Management

- Add teachers
- Manage teacher information
- Assign teachers to courses

---

## 🏫 Room Management

- Manage university rooms
- Assign rooms to courses

---

## 🔐 Authentication & Authorization

- ASP.NET Identity authentication
- Login & registration system
- Role-based authorization
- Admin-only features (such as deleting students)

---

## 📡 Web API

REST API endpoints for **student management**:


GET /api/students
GET /api/students/{id}
POST /api/students
PUT /api/students/{id}
DELETE /api/students/{id}


---

## 📄 Pagination

API and MVC pagination supported.

### API Example


GET /api/students?pageNumber=1&pageSize=5


### MVC Example


/Student/Index?pageNumber=1&pageSize=5


Pagination improves **performance when dealing with large datasets**.

---

## 🖼️ Student Photo Upload

Students can upload profile photos stored in:


wwwroot/StudentPictures


---

# 🏗️ Architecture

The project follows a **clean layered architecture**.


Controllers
│
├── MVC Controllers
├── API Controllers
│
Models
│
Repository Layer
│
DbContext (Entity Framework)
│
ViewModels
│
Views (Razor)


---

## 📦 Layers

### Controllers

Handle HTTP requests and return:

- Razor Views (MVC)
- JSON responses (API)

---

### Repository Layer

Implements the **Repository Pattern** to separate data access logic.

Example:


IStudentRepository
StudentRepository


---

### Models

Entity classes mapped to the database.

Examples:

- Student
- Teacher
- Course
- Room
- StudentCourse

---

### ViewModels

Used for UI operations such as:

- Login
- Register
- Role management
- Course registration

---

### DbContext

Handles database connection and entity mapping.


MyDbContext : DbContext


---

# 🗄️ Database

The project uses **Entity Framework Core with Code First Migrations**.

### Main tables include

- Students
- Teachers
- Courses
- Rooms
- StudentCourses
- AspNetUsers
- AspNetRoles

---

### Many-to-Many Relationship


Student <-> Course


via:


StudentCourse


---

# 🔐 Authentication & Roles

Implemented using **ASP.NET Identity**.

### Features

- User registration
- Login system
- Role creation
- Admin role assignment
- Authorization checks

# 📡 API Example

## Get Students


GET /api/students?pageNumber=1&pageSize=5


### Response

```json
{
  "pageNumber": 1,
  "pageSize": 5,
  "totalCount": 20,
  "totalPages": 4,
  "data": [
    {
      "studentId": 1,
      "studentName": "Ali Hassan",
      "studentAge": 20,
      "isActive": true
    }
  ]
}
```
# 📁 Project Structure

```
demoEFapp
│
├── Controllers
│   ├── StudentController
│   ├── CourseController
│   ├── TeacherController
│   ├── RoomController
│   ├── AdminController
│   └── AccountController
│
├── Models
│   ├── Student
│   ├── Teacher
│   ├── Course
│   ├── Room
│   └── StudentCourse
│
├── Repository
│   ├── IStudentRepository
│   ├── StudentRepository
│   ├── ITeacherRepository
│   ├── TeacherRepository
│   ├── ICourseRepository
│   └── CourseRepository
│
├── Context
│   └── MyDbContext
│
├── ViewModels
│   ├── LoginVM
│   ├── RegisterVM
│   ├── CreateRoleVM
│   └── StudentCourseVM
│
├── Views
│
└── Migrations
```
## ⚙️ Technologies Used

- ASP.NET Core MVC
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server / PostgreSQL
- ASP.NET Identity
- Razor Views
- Bootstrap UI
- LINQ
- Repository Pattern
- DTO Pattern

## 🧠 Concepts Demonstrated

This project demonstrates important backend concepts:

- MVC Architecture
- REST API Design
- Entity Framework Core
- Repository Pattern
- Authentication & Authorization
- Pagination
- DTO usage
- File Upload Handling
- Role-based security
- LINQ querying
- Clean project structure

## 🛠️ How to Run the Project

### 1️⃣ Clone the repository

```bash
git clone https://github.com/ziyad-alboghdady/ASP.NET-University-Management-System.git
```

### 2️⃣ Open the solution in Visual Studio

Open the `.sln` file.

### 3️⃣ Restore packages

```bash
dotnet restore
```

### 4️⃣ Update the database

```powershell
Update-Database
```

or

```bash
dotnet ef database update
```

### 5️⃣ Run the project

```bash
dotnet run
```

## 👨‍💻 Author

**Ziyad Alboghdady**

Software Engineering Student  
Backend Developer (ASP.NET Core)

### 🔗 GitHub

[ziyad-alboghdady](https://github.com/ziyad-alboghdady)

### 🔗 LinkedIn

[Ziyad Alboghdady](https://www.linkedin.com/in/ziyad-alboghdady-a50ab8247)

## 📌 Future Improvements

Planned enhancements:

- Search + Pagination
- SignalR real-time notifications
- Swagger API documentation
- Advanced filtering & sorting
- API authentication with JWT
- Unit testing
