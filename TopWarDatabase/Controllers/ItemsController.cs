using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TopWarModels;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    private readonly GameItemsContext _context;

    public ItemsController(GameItemsContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Item>>> GetItems([FromQuery] string? search = null, [FromQuery] string? attributeFilter = null, [FromQuery] bool sortByValue = false, [FromQuery] int limit = 20)
    {
        var query = _context.Items.Include(i => i.Attributes).AsQueryable();

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(i => i.Name.Contains(search) || i.Description.Contains(search));
        }

        if (!string.IsNullOrEmpty(attributeFilter))
        {
            query = query.Where(i => i.Attributes.Any(a => a.AttributeType.Contains(attributeFilter)));
            if (sortByValue)
            {
                query = query.OrderByDescending(i => i.Attributes.FirstOrDefault(a => a.AttributeType.Contains(attributeFilter)).AttributeValue);
            }
        }

        var items = await query.ToListAsync();

        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Item>> GetItem(int id)
    {
        var item = await _context.Items.Include(i => i.Attributes)
                                        .FirstOrDefaultAsync(i => i.Id == id);
        if (item == null)
        {
            return NotFound();
        }
        return item;
    }

    [HttpPost]
    public async Task<ActionResult<Item>> CreateItem(Item item)
    {
        _context.Items.Add(item);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateItem(int id, Item item)
    {
        if (id != item.Id)
        {
            return BadRequest();
        }

        _context.Entry(item).State = EntityState.Modified;

        foreach (var attribute in item.Attributes)
        {
            if (attribute.Id == 0)
            {
                _context.ItemAttributes.Add(attribute);
            }
            else
            {
                _context.Entry(attribute).State = EntityState.Modified;
            }
        }

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ItemExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        var item = await _context.Items.Include(i => i.Attributes)
                                        .FirstOrDefaultAsync(i => i.Id == id);
        if (item == null)
        {
            return NotFound();
        }

        _context.Items.Remove(item);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ItemExists(int id)
    {
        return _context.Items.Any(e => e.Id == id);
    }
}