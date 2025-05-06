using TopWarModels;

namespace TopWarDatabase.Tests
{
    public class ItemTests
    {
        [Fact]
        public void Item_WithAttributes_ShouldContainExpectedValues()
        {
            var attributes = new List<ItemAttribute>
            {
                new ItemAttribute {
                    AttributeType = "Attack",
                    AttributeValue = "10",
                    Item = new Item { Id = 99, Name = "Dummy", ImageUrl = "url", Attributes = new List<ItemAttribute>() }
                },
                new ItemAttribute {
                    AttributeType = "Defense",
                    AttributeValue = "5",
                    Item = new Item { Id = 99, Name = "Dummy", ImageUrl = "url", Attributes = new List<ItemAttribute>() }
                }
            };

            var item = new Item
            {
                Id = 3,
                Name = "Shield Generator",
                ImageUrl = "https://example.com/shield.png",
                Attributes = attributes
            };

            Assert.Collection(item.Attributes,
                attr =>
                {
                    Assert.Equal("Attack", attr.AttributeType);
                    Assert.Equal("10", attr.AttributeValue);
                },
                attr =>
                {
                    Assert.Equal("Defense", attr.AttributeType);
                    Assert.Equal("5", attr.AttributeValue);
                });
        }

    }
}
