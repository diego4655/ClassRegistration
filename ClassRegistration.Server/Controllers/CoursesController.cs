using ClassRegistration.Server.Application.Courses.Queries.GetAllCourses;
using ClassRegistration.Server.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassRegistration.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CoursesController(IMediator mediator)
    {
        _mediator = mediator;
    }

  

 
    [HttpGet]    
    public async Task<ActionResult<List<Course>>> GetAllCourses()
    {
        GetAllCourseQuery query = new GetAllCourseQuery();
        var result = await _mediator.Send(query);
        if(result.Count() == 0)
        {
            return NoContent();
        }

        return Ok(result);
    } 

} 