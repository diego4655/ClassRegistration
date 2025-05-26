using ClassRegistration.Server.Domain.Models;
using ClassRegistration.Server.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClassRegistration.Server.Application.Courses.Commands.DeleteStudentCourse;

public class DeleteStudentCourseCommandHandler : IRequestHandler<DeleteStudentCourseCommand, bool>
{
    private readonly ApplicationDbContext _context;

    public DeleteStudentCourseCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteStudentCourseCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var studentCourse = await _context.StudentCourses
                .FirstOrDefaultAsync(sc => sc.StudentId == request.StudentId && sc.CourseId == request.CourseId);

            if (studentCourse == null)
            {
                throw new ArgumentException("No se encontró la matrícula del curso");
            }

            var course = await _context.Courses.FindAsync(request.CourseId);
            var student = await _context.Students.FindAsync(request.StudentId);

            if (course == null || student == null)
            {
                throw new ArgumentException("No se encontró el curso o el estudiante");
            }

            // Return credits to student
            student.Credits += course.Credits;

            _context.StudentCourses.Remove(studentCourse);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
} 