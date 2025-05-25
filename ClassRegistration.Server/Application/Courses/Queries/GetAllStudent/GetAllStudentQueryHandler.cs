using ClassRegistration.Server.Domain.Models;
using ClassRegistration.Server.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClassRegistration.Server.Application.Courses.Queries.GetAllStudent;

public class GetAllStudentQueryHandler:IRequestHandler<GetAllStudentQuery,List<Student>>
{
    private readonly ApplicationDbContext _context;
    public GetAllStudentQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<Student>> Handle(GetAllStudentQuery request, CancellationToken cancellationToken)
    {
        var students = await _context.Students.ToListAsync(cancellationToken);
        return students;
    }
}

