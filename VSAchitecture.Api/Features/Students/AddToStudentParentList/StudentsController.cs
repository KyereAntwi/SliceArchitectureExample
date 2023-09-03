using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VSAchitecture.Api.Features.Students.AddToStudentParentList;

[Route("api/students")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("{studentId}/parents/{parentId}")]
    public async Task<ActionResult> AddToParentsList([FromRoute] Guid parentId, [FromRoute] Guid studentId)
    {
        await _mediator.Send(new AddToStudentParentListCommand(parentId, studentId));

        return NoContent();
    }
}