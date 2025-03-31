using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nuevo_Proyecto.Interface;
using Nuevo_Proyecto.Model;

namespace Nuevo_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetCustomerById(int id)
        {
            var person = await _personRepository.GetPersonByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPerson()
        {
            var person = await _personRepository.GetPersonAsync();
            return Ok(person);
        }
        [HttpPost]
        public async Task<ActionResult<Person>> CreatePerson(Person person)
        {
            var createdPerson = await _personRepository.CreatePersonAsync(person);
            return CreatedAtAction(nameof(GetPerson), new { id = createdPerson.BusinessEntityID }, createdPerson);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePersonAsync(int id, [FromBody] Person person)
        {
            try
            {
                if (id != person.BusinessEntityID)
                    return BadRequest("ID en URL no coincide con el cuerpo.");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _personRepository.UpdatePersonAsync(person);
                return result ? NoContent() : NotFound();
            }
            catch (DbUpdateException ex)
            {
                // Registra el error (usa ILogger en producción)
                return StatusCode(500, $"Error al actualizar: {ex.InnerException?.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error inesperado: {ex.Message}");
            }
        
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var result = await _personRepository.DeletePersonByIdAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
