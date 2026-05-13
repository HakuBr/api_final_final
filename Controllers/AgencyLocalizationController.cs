using APIsprint.Data;
using APIsprint.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIsprint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgencyLocalizationController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AgencyLocalizationController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/AgencyLocalization
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgencyLocalization>>> GetAgencyLocalizations()
        {
            return await _context.AgencyLocalizations
                .Include(a => a.Agency)
                .ToListAsync();
        }

        // GET: api/AgencyLocalization/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AgencyLocalization>> GetAgencyLocalization(int id)
        {
            var localization = await _context.AgencyLocalizations
                .Include(a => a.Agency)
                .FirstOrDefaultAsync(a => a.agency_localization_id == id);

            if (localization == null)
            {
                return NotFound(new
                {
                    message = "Localização da agência não encontrada"
                });
            }

            return Ok(localization);
        }

        // POST: api/AgencyLocalization
        [HttpPost]
        public async Task<ActionResult<AgencyLocalization>> CreateAgencyLocalization(AgencyLocalization localization)
        {
            var agencyExists = await _context.Agencies
                .AnyAsync(a => a.agency_id == localization.agency_id);

            if (!agencyExists)
            {
                return BadRequest(new
                {
                    message = "Agência não encontrada"
                });
            }

            _context.AgencyLocalizations.Add(localization);

            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetAgencyLocalization),
                new { id = localization.agency_localization_id },
                localization
            );
        }

        // PUT: api/AgencyLocalization/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAgencyLocalization(
            int id,
            AgencyLocalization localization)
        {
            if (id != localization.agency_localization_id)
            {
                return BadRequest(new
                {
                    message = "ID inválido"
                });
            }

            var existingLocalization = await _context.AgencyLocalizations
                .FirstOrDefaultAsync(a => a.agency_localization_id == id);

            if (existingLocalization == null)
            {
                return NotFound(new
                {
                    message = "Localização não encontrada"
                });
            }

            existingLocalization.agency_number_identification =
                localization.agency_number_identification;

            existingLocalization.agency_city =
                localization.agency_city;

            existingLocalization.agency_neighbordhood =
                localization.agency_neighbordhood;

            existingLocalization.agency_road =
                localization.agency_road;

            existingLocalization.agency_number =
                localization.agency_number;

            existingLocalization.agency_id =
                localization.agency_id;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Localização atualizada com sucesso"
            });
        }

        // DELETE: api/AgencyLocalization/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgencyLocalization(int id)
        {
            var localization = await _context.AgencyLocalizations
                .FirstOrDefaultAsync(a => a.agency_localization_id == id);

            if (localization == null)
            {
                return NotFound(new
                {
                    message = "Localização não encontrada"
                });
            }

            _context.AgencyLocalizations.Remove(localization);

            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Localização removida com sucesso"
            });
        }
    }
}