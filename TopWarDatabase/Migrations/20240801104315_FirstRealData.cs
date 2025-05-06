using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TopWarDatabase.Migrations
{
    /// <inheritdoc />
    public partial class FirstRealData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemAttributes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ItemAttributes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ItemAttributes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ItemAttributes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ItemAttributes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ItemAttributes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                        table: "Items",
                        columns: new[] {"Id", "Name", "Description", "ImageUrl" },
                        values: new object[,]
                        {
                {1, "AnpuAltarStatue", "", "http://michalciernia.pl/AnpuAltarStatue.png" },
                {2, "AsianArchway", "A most persistent sound which reverbates through all of history", "http://michalciernia.pl/AsianArchway.png" },
                {3, "BringThatFire", "Bring that fire and keep it up", "http://michalciernia.pl/BringThatFire.png" },
                {4, "CheersMate", "Best wishes to you", "http://michalciernia.pl/CheersMateCheersMateCheersMateCheersMateCheersMateCheersMateCheersMateCheersMateCheersMateCheersMate.png" },
                {5, "GoldenTank", "The Golden Tank will appear in battle!", "http://michalciernia.pl/GoldenTank.png" },
                {6, "GoldenWarhsip", "The Golden Battleship will appear in battle!", "http://michalciernia.pl/GoldenWarhsip.png" },
                {7, "PrettyChill", "", "http://michalciernia.pl/PrettyChill.png" },
                {8, "RoyalDragonBoat", "Keep sailing!", "http://michalciernia.pl/RoyalDragonBoat.png" }
                        });

            migrationBuilder.InsertData(
                table: "ItemAttributes",
                columns: new[] { "AttributeType", "AttributeValue", "ItemId" },
                values: new object[,]
                {
                { "All heroes war increase", "+500", 1 },
                { "March size", "+1", 1 },
                { "March size", "+1", 2 },
                { "All heroes DEF increase", "+500", 3 },
                { "March size", "+1", 4 },
                { "Single army slot HP bonus", "+50%", 5 },
                { "Single navy slot HP bonus", "+50%", 6 },
                { "March size", "+1", 7 },
                { "All units attack", "+1%", 7 },
                { "March size", "+1", 8 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Name", "Description", "ImageUrl" },
                values: new object[,]
                {
                { 1, "Item1", "Description for Item1", "http://example.com/image1.png" },
                { 2, "Item2", "Description for Item2", "http://example.com/image2.png" },
                { 3, "Item3", "Description for Item3", "http://example.com/image3.png" }
                });

            migrationBuilder.InsertData(
                table: "ItemAttributes",
                columns: new[] { "Id", "AttributeType", "AttributeValue", "ItemId" },
                values: new object[,]
                {
                { 1, "Army DMG plus", "10", 1 },
                { 2, "Navy DMG plus", "20", 1 },
                { 3, "Air DMG plus", "15", 2 },
                { 4, "Army HP plus", "5", 2 },
                { 5, "Navy HP plus", "8", 3 },
                { 6, "Air HP plus", "12", 3 }
                });
        }
    }
}
