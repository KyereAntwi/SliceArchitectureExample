using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VSAchitecture.Api.Features.Students.GetAStudentDetails;

[Route("api/students")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{Id}")]
    public async Task<ActionResult<GetAStudentDetailsQuery>> GetDetials([FromRoute] Guid Id)
    {
        var response = await _mediator.Send(new GetAStudentDetailsQuery(Id));
        return Ok(response);
    }
}