using MediatR;
using MedPro.Application.Commands.CreateSpeciality;
using MedPro.Application.Commands.DeleteSpeciality;
using MedPro.Application.Commands.UpdateSpeciality;
using MedPro.Application.Queries.Speciality.GetAllSpecialities;
using MedPro.Application.Queries.Speciality.GetSpecialityById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedPro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "admin, receptionist, doctor")]
    public class SpecialityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SpecialityController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var specialityByIdQuery = new GetSpecialityByIdQuery(id);
            
            var speciality = await _mediator.Send(specialityByIdQuery);

            return Ok(speciality);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllSpecialitiesQuery queryRequest)
        {
            var list = await _mediator.Send(queryRequest);
            
            return Ok(list);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSpecialityCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(Post), new { id = id });
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateSpecialityCommand command)
        {
            await _mediator.Send(command);
            
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteSpecialityCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
