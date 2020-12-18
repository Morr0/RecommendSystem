using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecommendSystem.Models;
using RecommendSystem.Repositories;

namespace RecommendSystem.Services
{
    public class ItemService : IItemService
    {
        private DataContext _context;

        public ItemService(DataContext context)
        {
            _context = context;
        }
        
        public Task<Item> GetItem(string Id)
        {
            return _context.Item.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task AddItem(Item item)
        {
            await _context.Item.AddAsync(item).ConfigureAwait(false);
            await _context.SaveChangesAsync();
        }
    }
}