using APIsprint.Models;
using APIsprint.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIsprint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Card>>> GetCards()
        {
            var cards = await _cardService.GetAllAsync();

            return Ok(cards);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Card>> GetCard(int id)
        {
            var card = await _cardService.GetByIdAsync(id);

            if (card == null)
            {
                return NotFound(new
                {
                    message = "Cartão não encontrado"
                });
            }

            return Ok(card);
        }

        [HttpPost]
        public async Task<ActionResult<Card>> CreateCard(Card card)
        {
            var createdCard = await _cardService.CreateAsync(card);

            return CreatedAtAction(
                nameof(GetCard),
                new { id = createdCard.card_id },
                createdCard
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCard(int id)
        {
            var deleted = await _cardService.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound(new
                {
                    message = "Cartão não encontrado"
                });
            }

            return Ok(new
            {
                message = "Cartão removido com sucesso"
            });
        }
    }
}