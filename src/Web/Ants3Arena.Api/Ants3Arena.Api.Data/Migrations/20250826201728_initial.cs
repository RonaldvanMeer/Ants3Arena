using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ants3Arena.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AntColors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AntColors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Directions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DirectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VerticalVelocity = table.Column<int>(type: "int", nullable: false),
                    HorizontalVelocity = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ants_AntColors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "AntColors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ants_Directions_DirectionId",
                        column: x => x.DirectionId,
                        principalTable: "Directions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ants_ColorId",
                table: "Ants",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ants_DirectionId",
                table: "Ants",
                column: "DirectionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ants");

            migrationBuilder.DropTable(
                name: "AntColors");

            migrationBuilder.DropTable(
                name: "Directions");
        }
    }
}
