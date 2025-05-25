using ClassRegistration.Server.Domain.Models;
using MediatR;

namespace ClassRegistration.Server.Application.Courses.Queries.GetAllStudent;

public class GetAllStudentQuery:IRequest<List<Student>>
{    
}



