using ClassRegistration.Server.Domain.Models;
using ClassRegistration.Server.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClassRegistration.Server.Application.Courses.Queries.GetAllCoursesByStudent
{
    public class GetAllCourseByStudentQueryHandler : IRequestHandler<GetAllCourseByStudentQuery, GetAllCourseByStudentQuery>
    {
        private readonly ApplicationDbContext _context;
        public GetAllCourseByStudentQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }


        private async Task<StudentDto> GetStudentInformation(StudentDto student)
        {            
            var studentInfo = await _context.Students
                .Where(s => s.Id == student.Id)
                .Select(s => new StudentDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Credits = s.Credits
                })
                .FirstOrDefaultAsync();

            return studentInfo ?? new StudentDto();
        }

        private async Task<List<CourseDto>> GetCoursesByStudent(Guid studentId)
        {
            try
            {
                return await _context.StudentCourses
                    .Where(sc => sc.StudentId == studentId)
                    .Select(sc => new CourseDto
                    {
                        Id = sc.Course.Id,
                        Name = sc.Course.Name,
                        Description = sc.Course.Description,
                        Credits = sc.Course.Credits,
                        TeacherName = sc.Course.Teacher.Name
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<GetAllCourseByStudentQuery> Handle(GetAllCourseByStudentQuery request, CancellationToken cancellationToken)
        {
            try
            {

                StudentDto student = await GetStudentInformation(request.Student);
                List<CourseDto> courses = await GetCoursesByStudent(request.Student.Id);
                return new GetAllCourseByStudentQuery {Student = student,Courses = courses};
            }
            catch(ArgumentNullException ane)
            {
                throw new ArgumentException(ane.Message);
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
            
        }
    }
}
