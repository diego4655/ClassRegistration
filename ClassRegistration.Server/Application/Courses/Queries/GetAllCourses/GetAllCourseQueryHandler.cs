using ClassRegistration.Server.Application.Courses.Queries.GetAllCourses;
using ClassRegistration.Server.Features.Courses.Queries.GetCourse;
using ClassRegistration.Server.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClassRegistration.Server.Features.Courses.Queries.GetAllCourses
{
    public class GetAllCourseQueryHandler : IRequestHandler<GetAllCourseQuery, IEnumerable<GetCourseResponse>>
    {
        private readonly ApplicationDbContext _context;
        public GetAllCourseQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetCourseResponse>> Handle(GetAllCourseQuery request, CancellationToken cancellationToken)
        {
            var courseList = await _context.Courses
                .Include(c => c.Teacher)
                .ToListAsync(cancellationToken);
            return courseList.Select(course => new GetCourseResponse
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                Credits = course.Credits,
                TeacherName = course.Teacher.Name
            }).ToList();
        }
    }
}


    
