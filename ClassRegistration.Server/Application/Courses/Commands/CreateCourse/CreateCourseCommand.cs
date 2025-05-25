namespace ClassRegistration.Server.Features.Courses.Commands.CreateCourse;

public class CreateCourseResponse
{    
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Credits { get; set; }
    public Guid TeacherId { get; set; }
} 