using MediatR;
using Microsoft.AspNetCore.Mvc;
using VSAchitecture.Api.Features.Students.RemoveParentFromList;

namespace VSAchitecture.Api.Features.Students.RemoveParentFromList;

[Route("api/students")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpDelete("{studentId}/parents/{parentId}")]
    public async Task<ActionResult> RemoveParentFromList([FromRoute] Guid parentId, [FromRoute] Guid studentId)
    {
        await _mediator.Send(new RemoveParentFromListCommand(parentId, studentId));

        return Accepted();
    }
}