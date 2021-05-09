using Microsoft.EntityFrameworkCore.Migrations;

namespace EastviewRestAPI.Migrations
{
    public partial class AddingCitizenTasksAndData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    CitizenId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Citizens_CitizenId",
                        column: x => x.CitizenId,
                        principalTable: "Citizens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Citizens",
                columns: new[] { "Id", "Address", "FirstName", "Job", "LastName" },
                values: new object[] { 1, "1512 Doe St", "John", "Constructor", "Doe" });

            migrationBuilder.InsertData(
                table: "Citizens",
                columns: new[] { "Id", "Address", "FirstName", "Job", "LastName" },
                values: new object[] { 2, "1512 Doe St", "Jane", "Actress", "Doe" });

            migrationBuilder.InsertData(
                table: "Citizens",
                columns: new[] { "Id", "Address", "FirstName", "Job", "LastName" },
                values: new object[] { 3, "302 Peachtree St", "Steve", "Student", "Smith" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CitizenId", "Day", "Description" },
                values: new object[] { 1, 1, 1, "Finish house kitchen" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CitizenId", "Day", "Description" },
                values: new object[] { 2, 2, 1, "Film TV Serie chapter" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CitizenId", "Day", "Description" },
                values: new object[] { 3, 3, 1, "Assist to English class" });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CitizenId",
                table: "Tasks",
                column: "CitizenId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DeleteData(
                table: "Citizens",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Citizens",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Citizens",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
