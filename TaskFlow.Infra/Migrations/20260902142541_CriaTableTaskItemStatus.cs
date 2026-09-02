using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskFlow.Infra.Migrations
{
    /// <inheritdoc />
    public partial class CriaTableTaskItemStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "TaskItem",
                type: "int",
                nullable: false,
                defaultValue: 1); // Define um valor padrão para StatusId, garantindo que registros existentes recebam o status "TODO" (Id = 1)

            migrationBuilder.CreateTable(
                name: "TaskItemStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slug = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItemStatus", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TaskItemStatus",
                columns: new[] { "Id", "Color", "Name", "Slug" },
                values: new object[,]
                {
                    { 1, "#9AA0A6", "A Fazer", "TODO" },
                    { 2, "#4A90D9", "Em Andamento", "IN_PROGRESS" },
                    { 3, "#3DA35D", "Feito", "DONE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskItem_StatusId",
                table: "TaskItem",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItemStatus_Slug",
                table: "TaskItemStatus",
                column: "Slug",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItem_TaskItemStatus_StatusId",
                table: "TaskItem",
                column: "StatusId",
                principalTable: "TaskItemStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskItem_TaskItemStatus_StatusId",
                table: "TaskItem");

            migrationBuilder.DropTable(
                name: "TaskItemStatus");

            migrationBuilder.DropIndex(
                name: "IX_TaskItem_StatusId",
                table: "TaskItem");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "TaskItem");
        }
    }
}
