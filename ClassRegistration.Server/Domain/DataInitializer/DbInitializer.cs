using ClassRegistration.Server.Domain.Models;
using ClassRegistration.Server.Infrastructure;

namespace ClassRegistration.Server.Domain.Data;

public static class DbInitializer
{
    public static void Initialize(ApplicationDbContext context)
    {        
        context.Database.EnsureCreated();
       
        if (context.Teachers.Any())
        {
            return; 
        }

        
        var teachers = new Teacher[]
        {
            new Teacher 
            { 
                Name = "Jorge Pacheco",
                Email = "jorge.pacheco@gmail.com",
                Phone = "3123456789"
            },
            new Teacher 
            { 
                Name = "Juan Perez",
                Email = "juan.perez@gmail.com",
                Phone = "3123456790"
            },
            new Teacher 
            { 
                Name = "Maria Lopez",
                Email = "maria.lopez@gmail.com",
                Phone = "3123456791"
            },
            new Teacher 
            { 
                Name = "Pedro Ramirez",
                Email = "pedro.ramirez@gmail.com",
                Phone = "3123456792"
            },
            new Teacher 
            { 
                Name = "Roberto Gonzalez",
                Email = "roberto.gonzalez@gmail.com",
                Phone = "3123456793"
            }
        };

        context.Teachers.AddRange(teachers);
        context.SaveChanges();
        
        var courses = new Course[]
        {
            
            new Course 
            { 
                Name = "Matematicas",
                Description = "Conceptos basicos de algebra y calculo",
                TeacherId = teachers[0].Id
            },
            new Course 
            { 
                Name = "Algebra",
                Description = "Temas avanzados en calculo y algebra lineal",
                TeacherId = teachers[0].Id
            },

            
            new Course 
            { 
                Name = "Fisica",
                Description = "Principios basicos de mecanica y termodinamica",
                TeacherId = teachers[1].Id
            },
            new Course 
            { 
                Name = "Fisica Electrica",
                Description = "Principios de fisica electica",
                TeacherId = teachers[1].Id
            },

            
            new Course 
            { 
                Name = "Programacion Basica",
                Description = "Introduccion a la programacion y algoritmos",
                TeacherId = teachers[2].Id
            },
            new Course 
            { 
                Name = "Estructuras de Datos",
                Description = "Estudio de las estructuras de datos fundamentales y algoritmos",
                TeacherId = teachers[2].Id
            },

            
            new Course 
            { 
                Name = "Ingles",
                Description = "Estudio de la gramatica y vocabulario en ingles",
                TeacherId = teachers[3].Id
            },
            new Course 
            { 
                Name = "Español",
                Description = "Estudio de la gramatica y vocabulario en español",
                TeacherId = teachers[3].Id
            },

            
            new Course 
            { 
                Name = "Quimica",
                Description = "Estudio de la quimica y sus aplicaciones",
                TeacherId = teachers[4].Id
            },
            new Course 
            { 
                Name = "Biologia",
                Description = "Estudio de la biologia y sus aplicaciones",
                TeacherId = teachers[4].Id
            }
        };

        context.Courses.AddRange(courses);
        context.SaveChanges();
        
        var students = new Student[]
        {
            new Student { Name = "Ana Garcia" },
            new Student { Name = "Carlos Lopez" },
            new Student { Name = "Daniel Ramirez" },
            new Student { Name = "Eva Martinez" },
            new Student { Name = "Fernando Torres" }
        };

        context.Students.AddRange(students);
        context.SaveChanges();


        var enrollments = new StudentCourse[]
        {
            
            new StudentCourse 
            { 
                StudentId = students[0].Id,
                CourseId = courses[0].Id 
            },
            new StudentCourse 
            { 
                StudentId = students[0].Id,
                CourseId = courses[2].Id 
            },
            new StudentCourse 
            { 
                StudentId = students[0].Id,
                CourseId = courses[4].Id 
            },

            new StudentCourse 
            { 
                StudentId = students[1].Id,
                CourseId = courses[6].Id 
            },
            new StudentCourse 
            { 
                StudentId = students[1].Id,
                CourseId = courses[8].Id 
            }
        };

        context.StudentCourses.AddRange(enrollments);
        context.SaveChanges();
    }
} 