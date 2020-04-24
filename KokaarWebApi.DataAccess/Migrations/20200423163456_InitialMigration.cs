using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KokaarWebApi.DataAccess.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUser = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "City", "Country", "CreationDate", "CreationUser", "DateOfBirth", "Email", "Name", "PhoneNumber", "UpdateDate", "UpdateUser" },
                values: new object[,]
                {
                    { 1, "Berry", "Mali", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1650, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "armand@gmail.com", "Griffin Beak Eldritch", "+15149969897", null, null },
                    { 2, "Nancy", "Cameroun", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1668, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "armand@gmail.com", "Swashbuckler Rye", "+15149969897", null, null },
                    { 3, "Eli", "Canada", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1701, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "armand@gmail.com", "Ivory Bones Sweet", "+15149969897", null, null },
                    { 4, "Arnold", "Canada", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1702, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "armand@gmail.com", "The Unseen Stafford", "+15149969897", null, null },
                    { 5, "Seabury", "Maps", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1690, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "armand@gmail.com", "Toxic Reyson", "+15149969897", null, null },
                    { 6, "Rutherford", "France", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1723, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "armand@gmail.com", "Fearless Cloven", "+15149969897", null, null },
                    { 7, "Atherton", "Cameroun", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1721, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "armand@gmail.com", "Crow Ridley", "+15149969897", null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
