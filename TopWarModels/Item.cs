namespace TopWarModels
{
    public class Item
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string ImageUrl { get; set; }
        public required ICollection<ItemAttribute> Attributes { get; set; }
    }
}