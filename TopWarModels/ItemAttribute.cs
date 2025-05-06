using System.Text.Json.Serialization;

namespace TopWarModels
{
    public class ItemAttribute
    {
        public int Id { get; set; }
        public required string AttributeType { get; set; }
        public required string AttributeValue { get; set; }
        public int ItemId { get; set; }

        [JsonIgnore]
        public required Item Item { get; set; }
    }
}
