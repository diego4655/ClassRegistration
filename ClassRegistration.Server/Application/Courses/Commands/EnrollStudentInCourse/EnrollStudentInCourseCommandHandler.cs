using Azure.Core;
using ClassRegistration.Server.Domain.Models;
using ClassRegistration.Server.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClassRegistration.Server.Application.Courses.Commands.EnrollStudentInCourse;

public class EnrollStudentInCourseCommandHandler : IRequestHandler<EnrollStudentInCourseCommand, bool>
{
    private readonly ApplicationDbContext _context;
    public EnrollStudentInCourseCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }


    private async Task<StudentCourse> CheckIsAbleToCreate(Student student,Guid courseId, List<Course> courses)
    {
        List<StudentCourse> registerStudentCourse = await _context.StudentCourses.Where(sc => sc.StudentId == student.Id).ToListAsync();


        if (registerStudentCourse.Any() && registerStudentCourse.Exists(data => data.CourseId == courseId))
        {
            throw new ArgumentException("El curso seleccionado ya se encuentra escrito para el estudiante seleccionado");
        }

        foreach (var item in registerStudentCourse)
        {
            var newTeacher = courses?.FirstOrDefault(c => c.Id == courseId)?.TeacherId ?? throw new ArgumentNullException("No se encontro profesor para el curso");
            if (courses != null && courses.FirstOrDefault(c => c.Id == item.CourseId)?.TeacherId == newTeacher)
            {
                throw new ArgumentException("No puede tomar la clase porque ya toma una con el mismo profesor");
            }
        }
        
        return new StudentCourse() { StudentId = student.Id , CourseId = courseId};
    } 


    private async Task UpdateStudentCredits(Student student, int creditsToSubstract)
    {
        try
        {
            if (student.Credits > creditsToSubstract)
            {
                student.Credits = student.Credits - creditsToSubstract;
                await _context.SaveChangesAsync();
                return;
            }
            throw new ArgumentException("No hay suficientes creditos para inscribir otra materia");
        }
        catch (Exception ex)
        {

            throw new ArgumentException(ex.Message);
        }
        
    }

    public async Task<bool> Handle(EnrollStudentInCourseCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var student = await _context.Students.FindAsync(request.StudentId);
            var courses = await _context.Courses.ToListAsync();

            if (student == null ||  courses.FirstOrDefault(data=> data.Id == request.CourseId) == null)
            {
                throw new ArgumentException("Estudiante o curso no encontrado");
            }

            var studentCourse = await CheckIsAbleToCreate(student, request.CourseId, courses);
            await UpdateStudentCredits(student, courses?.FirstOrDefault(c => c.Id == request.CourseId)?.Credits ?? 0);
            
            _context.StudentCourses.Add(studentCourse);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
}
