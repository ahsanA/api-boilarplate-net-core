using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIBoilerplate.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cows",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisplayNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    InitialWeight = table.Column<double>(type: "float", nullable: false),
                    InitialPrice = table.Column<double>(type: "float", nullable: false),
                    OnBoardingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FarmId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cows", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cows");
        }
    }
}
