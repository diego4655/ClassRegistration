using MediatR;

namespace ClassRegistration.Server.Application.Courses.Commands.CreateStudent;

public class StudentCommand:IRequest<bool>
{
    public string Name { get; set; }

}

