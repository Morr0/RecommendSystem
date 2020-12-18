using System.Threading.Tasks;
using RecommendSystem.Models;

namespace RecommendSystem.Services
{
    public interface IItemService
    {
        Task<Item> GetItem(string Id);
        Task AddItem(Item item);
    }
}