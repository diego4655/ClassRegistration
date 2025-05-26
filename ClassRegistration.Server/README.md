# Servidor - Sistema de Registro de Clases

## Requisitos Previos
- .NET 8 SDK
- SQL Server (2019 o superior)
- Visual Studio 2022 o Visual Studio Code

## Configuración de la Base de Datos

1. Configurar la cadena de conexión en `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=ClassRegistration;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

## Migraciones

1. Instalar las herramientas de Entity Framework Core:
```bash
dotnet tool install --global dotnet-ef
```

2. Crear la migración inicial:
```bash
dotnet ef migrations add InitialCreate
```

3. Aplicar la migración a la base de datos:
```bash
dotnet ef database update
```

## Estructura del Proyecto
```
ClassRegistration.Server/
├── Controllers/
│   ├── StudentController.cs
│   ├── CourseController.cs
│   └── StudentCourseController.cs
├── Models/
│   ├── Student.cs
│   ├── Course.cs
│   └── StudentCourse.cs
├── Data/
│   └── ApplicationDbContext.cs
├── Commands/
│   └── EnrollStudentInCourse/
├── Queries/
│   └── GetAllCoursesByStudent/
└── Program.cs
```

## Patrones y Arquitectura
- Clean Architecture
- CQRS (Command Query Responsibility Segregation)
- Repository Pattern
- Entity Framework Core como ORM

## Endpoints API

### Estudiantes
- GET `/api/student` - Obtener todos los estudiantes
- POST `/api/student` - Crear nuevo estudiante

### Cursos
- GET `/api/course` - Obtener todos los cursos
- POST `/api/course` - Crear nuevo curso

### Matrículas
- POST `/api/studentCourses` - Registrar estudiante en curso
- GET `/api/studentCourses/CourseByStudent` - Obtener cursos por estudiante
- GET `/api/studentCourses/AllStudentparnes` - Obtener todos los cursos y estudiantes por curso
- DELETE `/api/studentCourses` - Eliminar cursos asignados a un estudiante
 

## Ejecución del Proyecto

1. Desarrollo:
correr directamente desde el visual studio

## Características Implementadas
- API RESTful
- Validación de datos
- Manejo de errores
- Transacciones de base de datos
- Swagger para documentación de API

## Consideraciones de Seguridad
- Validación de entrada
- Manejo de excepciones
- CORS configurado