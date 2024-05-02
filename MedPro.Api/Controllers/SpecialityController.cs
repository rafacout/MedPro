using MedPro.Application.InputModels;
using MedPro.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedPro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialityController : ControllerBase
    {
        private readonly ISpecialityService _specialityService;

        public SpecialityController(ISpecialityService specialityService)
        {
            _specialityService = specialityService;
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var speciality = _specialityService.GetById(id);
            
            if (speciality == null)
            {
                return NotFound();
            }
            
            return Ok(speciality);
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var specialities = _specialityService.GetAll();
            
            return Ok(specialities);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] SpecialityInputModel inputModel)
        {
            var id = _specialityService.Create(inputModel);

            return CreatedAtAction(nameof(Post), new { id = id }, inputModel);
        }
        
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] SpecialityInputModel inputModel)
        {
            _specialityService.Update(id, inputModel);
            
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _specialityService.Delete(id);
            return NoContent();
        }
    }
}
