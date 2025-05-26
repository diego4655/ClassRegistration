using ClassRegistration.Server.Domain.Models;
using MediatR;

namespace ClassRegistration.Server.Application.Courses.Queries.GetAllCoursesByStudent
{
    public class GetAllCourseByStudentQuery: IRequest<GetAllCourseByStudentQuery>
    {
        public StudentDto Student { get; set; }
        public List<CourseDto> Courses { get; set; }
    }

    public class StudentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Credits { get; set; }
    }

    public class CourseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Credits { get; set; }
        public string TeacherName { get; set; } = string.Empty;
    }
}
