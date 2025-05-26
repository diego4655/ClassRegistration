using ClassRegistration.Server.Domain.Models;
using ClassRegistration.Server.Infrastructure;
using MediatR;

namespace ClassRegistration.Server.Application.Courses.Commands.CreateStudent;

public class StudentCommandHandler : IRequestHandler<StudentCommand, bool>
{
    private readonly ApplicationDbContext _context;
    public StudentCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<bool> Handle(StudentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var student = new Student
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Credits = 10
            };
            _context.Students.Add(student);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
}
