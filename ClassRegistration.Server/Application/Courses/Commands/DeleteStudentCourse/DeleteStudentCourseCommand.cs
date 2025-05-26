using MediatR;

namespace ClassRegistration.Server.Application.Courses.Commands.DeleteStudentCourse;

public class DeleteStudentCourseCommand : IRequest<bool>
{
    public Guid CourseId { get; set; }
    public Guid StudentId { get; set; }
} 