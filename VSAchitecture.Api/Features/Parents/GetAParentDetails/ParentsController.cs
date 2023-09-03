using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VSAchitecture.Api.Features.Parents.GetAParentDetails;

[Route("api/parents")]
[ApiController]
public class ParentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ParentsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{Id}")]
    public async Task<ActionResult<GetAParentDetailsResponse>> GetDetials([FromRoute] Guid Id)
    {
        var response = await _mediator.Send(new GetAParentDetailsQuery(Id));
        return Ok(response);
    }
}