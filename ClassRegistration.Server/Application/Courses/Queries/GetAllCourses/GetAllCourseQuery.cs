using ClassRegistration.Server.Features.Courses.Queries.GetCourse;
using MediatR;

namespace ClassRegistration.Server.Application.Courses.Queries.GetAllCourses
{
    public class GetAllCourseQuery:IRequest<IEnumerable<GetCourseResponse>>
    {
    }
}
