using APIsprint.Data;
using APIsprint.Models;
using APIsprint.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIsprint.Services
{
    public class CardService : ICardService
    {
        private readonly AppDbContext _context;

        public CardService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Card>> GetAllAsync()
        {
            return await _context.Cards
                .Include(c => c.Account)
                .ToListAsync();
        }

        public async Task<Card> GetByIdAsync(int id)
        {
            return await _context.Cards
                .FirstOrDefaultAsync(c => c.card_id == id);
        }

        public async Task<Card> CreateAsync(Card card)
        {
            _context.Cards.Add(card);

            await _context.SaveChangesAsync();

            return card;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var card = await _context.Cards
                .FirstOrDefaultAsync(c => c.card_id == id);

            if (card == null)
                return false;

            _context.Cards.Remove(card);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}