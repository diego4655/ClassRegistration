using MediatR;

namespace ClassRegistration.Server.Application.Courses.Queries.GetAllStudentByCourse
{
    public class GetAllStudentByCourseQuery : IRequest<GetAllStudentByCourseQuery>
    {
        public Guid StudentId { get; set; }
        public List<StudentByClass> Students { get; set; }

    }

    public class StudentDtoSmall
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class CourseDtoSmall
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class StudentByClass
    {
        public string CourseName { get; set; }
        public List<StudentDtoSmall> StudentList { get; set; }
    }
}
