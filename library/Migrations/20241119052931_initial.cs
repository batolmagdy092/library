using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace library.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NationalId",
                table: "Authors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NationatiltyId",
                table: "Authors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Nationals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationals", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_NationalId",
                table: "Authors",
                column: "NationalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Nationals_NationalId",
                table: "Authors",
                column: "NationalId",
                principalTable: "Nationals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Nationals_NationalId",
                table: "Authors");

            migrationBuilder.DropTable(
                name: "Nationals");

            migrationBuilder.DropIndex(
                name: "IX_Authors_NationalId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "NationalId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "NationatiltyId",
                table: "Authors");
        }
    }
}
