using ClassRegistration.Server.Application.Courses.Commands.CreateStudent;
using ClassRegistration.Server.Application.Courses.Queries.GetAllStudent;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassRegistration.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class StudentController: ControllerBase
    {
        private readonly IMediator _mediator;
        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(StudentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            GetAllStudentQuery getAllStudent = new GetAllStudentQuery();
            var result = await _mediator.Send(getAllStudent);
            return Ok(result);
        }
    }
}
