using ClassRegistration.Server.Domain.Models;
using MediatR;

namespace ClassRegistration.Server.Application.Courses.Commands.EnrollStudentInCourse;

public class EnrollStudentInCourseCommand : IRequest<bool>
{
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
}