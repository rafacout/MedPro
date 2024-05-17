using MediatR;
using MedPro.Application.Commands.Patient.CreatePatient;
using MedPro.Application.Commands.Patient.DeletePatient;
using MedPro.Application.Commands.Patient.UpdatePatient;
using MedPro.Application.Queries.Patient.GetAllPatients;
using MedPro.Application.Queries.Patient.GetPatientById;
using Microsoft.AspNetCore.Mvc;

namespace MedPro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var patientByIdQuery = new GetPatientByIdQuery(id);
            
            var patientViewModel = await _mediator.Send(patientByIdQuery);

            return Ok(patientViewModel);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllPatientsQuery queryRequest)
        {
            var list = await _mediator.Send(queryRequest);
            
            return Ok(list);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePatientCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(Post), new { id = id });
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdatePatientCommand command)
        {
            await _mediator.Send(command);
            
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeletePatientCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
