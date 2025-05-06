using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using TopWarModels;

namespace TopWarDatabase.Services
{
    public class ItemService
    {
        private readonly GameItemsContext _context;
        private readonly IMemoryCache _cache;

        public ItemService(GameItemsContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<IEnumerable<Item>> GetItems()
        {
            if (!_cache.TryGetValue("items", out List<Item> items))
            {
                items = await _context.Items.Include(i => i.Attributes).ToListAsync();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(5));

                _cache.Set("items", items, cacheEntryOptions);
            }

            return items;
        }

        public async Task<Item> GetItem(int id)
        {
            return await _context.Items.Include(i => i.Attributes)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Item> CreateItem(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            _cache.Remove("items");

            return item;
        }
    }
}
