using ClassRegistration.Server.Infrastructure;
using MediatR;

namespace ClassRegistration.Server.Features.Courses.Queries.GetCourse;

public class GetCourseQueryHandler : IRequestHandler<GetCourseResponse, GetCourseResponse>
{
    private readonly ApplicationDbContext _context;
    public GetCourseQueryHandler( ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<GetCourseResponse> Handle(GetCourseResponse request, CancellationToken cancellationToken)
    {                
        var course = await _context.Courses.FindAsync(request.Id);
        return new GetCourseResponse()
        {
            Name = course.Name,
            Credits = course.Credits,
            TeacherName = course.Teacher.Name,
            Description = course.Description,
        };
    }
} 