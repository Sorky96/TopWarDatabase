using Microsoft.EntityFrameworkCore;
using TopWarModels;

public class GameItemsContext : DbContext
{
    public GameItemsContext(DbContextOptions<GameItemsContext> options) : base(options) { }

    public DbSet<Item> Items { get; set; }
    public DbSet<ItemAttribute> ItemAttributes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ItemAttribute>()
            .HasKey(ia => ia.Id);

        modelBuilder.Entity<Item>()
            .HasMany(i => i.Attributes)
            .WithOne(ia => ia.Item)
            .HasForeignKey(ia => ia.ItemId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}