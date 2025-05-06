using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using TopWarModels;

#nullable disable

namespace TopWarDatabase.Migrations
{
    /// <inheritdoc />
    public partial class TestData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                        table: "Items",
                        columns: new[] { "Name", "Description", "ImageUrl" },
                        values: new object[,]
                        {
                { "Item1", "Description for Item1", "http://example.com/image1.png" },
                { "Item2", "Description for Item2", "http://example.com/image2.png" },
                { "Item3", "Description for Item3", "http://example.com/image3.png" }
                        });

            migrationBuilder.InsertData(
                table: "ItemAttributes",
                columns: new[] { "AttributeType", "AttributeValue", "ItemId" },
                values: new object[,]
                {
                { "Army DMG plus", "10", 1 },
                { "Navy DMG plus", "20", 1 },
                { "Air DMG plus", "15", 2 },
                { "Army HP plus", "5", 2 },
                { "Navy HP plus", "8", 3 },
                { "Air HP plus", "12", 3 }
                });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
