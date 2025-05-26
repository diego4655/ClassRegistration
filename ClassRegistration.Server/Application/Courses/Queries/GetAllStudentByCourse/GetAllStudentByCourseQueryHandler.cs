using ClassRegistration.Server.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClassRegistration.Server.Application.Courses.Queries.GetAllStudentByCourse
{
    public class GetAllStudentByCourseQueryHandler : IRequestHandler<GetAllStudentByCourseQuery, GetAllStudentByCourseQuery>
    {
        private readonly ApplicationDbContext _context;
        public GetAllStudentByCourseQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<GetAllStudentByCourseQuery> Handle(GetAllStudentByCourseQuery request, CancellationToken cancellationToken)
        {
            var courses = await _context.StudentCourses
                 .Where(sc => sc.StudentId == request.StudentId)
                 .Select(sc => new CourseDtoSmall
                 {
                     Id = sc.CourseId,
                     Name = sc.Course.Name
                 }).ToListAsync();

            GetAllStudentByCourseQuery getAllStudentByCourseQuery = new GetAllStudentByCourseQuery() { StudentId = request.StudentId};
            getAllStudentByCourseQuery.Students = new();
            foreach (var course in courses)
            {
                List<StudentDtoSmall> studentList = new();
                studentList = await _context.StudentCourses
                                                  .Where(sc => sc.CourseId == course.Id)
                                                  .Select(sc => new StudentDtoSmall
                                                  {
                                                      Id = sc.StudentId,
                                                      Name = sc.Student.Name
                                                  }).ToListAsync();

                getAllStudentByCourseQuery.Students.Add(new StudentByClass() { CourseName = course.Name, StudentList = studentList }); 
            
            }

            return getAllStudentByCourseQuery;




        }
    }
}
