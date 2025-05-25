using MediatR;


namespace ClassRegistration.Server.Features.Courses.Queries.GetCourse;

public class GetCourseResponse:IRequest<GetCourseResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Credits { get; set; }
    public string TeacherName { get; set; }
} 