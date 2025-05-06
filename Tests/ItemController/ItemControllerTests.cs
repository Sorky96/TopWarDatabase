using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using TopWarModels;

namespace TopWarDatabase.Tests
{
    public class ItemsControllerTests
    {
        private DbContextOptions<GameItemsContext> CreateNewContextOptions()
        {
            return new DbContextOptionsBuilder<GameItemsContext>()
                .UseInMemoryDatabase(databaseName: System.Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public async Task GetItems_ReturnsAllItems()
        {
            var options = CreateNewContextOptions();
            using var context = new GameItemsContext(options);
            context.Items.Add(new Item
            {
                Name = "Laser Gun",
                ImageUrl = "url",
                Attributes = new List<ItemAttribute>()
            });
            await context.SaveChangesAsync();

            var controller = new ItemsController(context);
            var result = await controller.GetItems();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var items = Assert.IsAssignableFrom<IEnumerable<Item>>(okResult.Value);
            Assert.Single(items);
        }

        [Fact]
        public async Task GetItem_ReturnsCorrectItem()
        {
            var options = CreateNewContextOptions();
            using var context = new GameItemsContext(options);
            var item = new Item
            {
                Name = "Tank",
                ImageUrl = "url",
                Attributes = new List<ItemAttribute>()
            };
            context.Items.Add(item);
            await context.SaveChangesAsync();

            var controller = new ItemsController(context);
            var result = await controller.GetItem(item.Id);

            var returnedItem = Assert.IsType<Item>(result.Value);
            Assert.Equal("Tank", returnedItem.Name);
        }

        [Fact]
        public async Task CreateItem_AddsNewItem()
        {
            var options = CreateNewContextOptions();
            using var context = new GameItemsContext(options);
            var controller = new ItemsController(context);

            var newItem = new Item
            {
                Name = "Drone",
                ImageUrl = "url",
                Attributes = new List<ItemAttribute>()
            };

            var result = await controller.CreateItem(newItem);
            var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var item = Assert.IsType<Item>(createdResult.Value);
            Assert.Equal("Drone", item.Name);
        }

        [Fact]
        public async Task DeleteItem_RemovesItem()
        {
            var options = CreateNewContextOptions();
            using var context = new GameItemsContext(options);
            var item = new Item
            {
                Name = "Mech",
                ImageUrl = "url",
                Attributes = new List<ItemAttribute>()
            };
            context.Items.Add(item);
            await context.SaveChangesAsync();

            var controller = new ItemsController(context);
            var result = await controller.DeleteItem(item.Id);

            Assert.IsType<NoContentResult>(result);
            Assert.False(context.Items.Any(i => i.Id == item.Id));
        }
    }
}
