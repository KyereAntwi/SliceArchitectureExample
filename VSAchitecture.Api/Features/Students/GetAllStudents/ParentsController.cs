using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VSAchitecture.Api.Features.Students.GetAllStudents;

[Route("api/students")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<StudentDto>))]
    public async Task<ActionResult> Get()
    {
        var vm = await _mediator.Send(new GetAllStudentsQuery());
        return Ok(vm);
    }
}