using APIsprint.Models;

namespace APIsprint.Services.Interfaces
{
    public interface ICardService
    {
        Task<IEnumerable<Card>> GetAllAsync();

        Task<Card> GetByIdAsync(int id);

        Task<Card> CreateAsync(Card card);

        Task<bool> DeleteAsync(int id);
    }
}