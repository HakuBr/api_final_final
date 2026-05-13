using APIsprint.Models;
using APIsprint.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIsprint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {
            var persons = await _personService.GetAllAsync();

            return Ok(persons);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await _personService.GetByIdAsync(id);

            if (person == null)
            {
                return NotFound(new
                {
                    message = "Pessoa não encontrada"
                });
            }

            return Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult<Person>> CreatePerson(Person person)
        {
            try
            {
                var createdPerson = await _personService.CreateAsync(person);

                return CreatedAtAction(
                    nameof(GetPerson),
                    new { id = createdPerson.person_id },
                    createdPerson
                );
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(int id, Person person)
        {
            var updated = await _personService.UpdateAsync(id, person);

            if (!updated)
            {
                return NotFound(new
                {
                    message = "Pessoa não encontrada"
                });
            }

            return Ok(new
            {
                message = "Pessoa atualizada com sucesso"
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var deleted = await _personService.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound(new
                {
                    message = "Pessoa não encontrada"
                });
            }

            return Ok(new
            {
                message = "Pessoa removida com sucesso"
            });
        }
    }
}