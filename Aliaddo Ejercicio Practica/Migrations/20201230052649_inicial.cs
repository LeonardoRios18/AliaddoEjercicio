using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliaddo_Ejercicio_Practica.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Padre",
                columns: table => new
                {
                    PadreID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    LName = table.Column<string>(nullable: false),
                    NDocument = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PhoneN = table.Column<string>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Children = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Padre", x => x.PadreID);
                });

            migrationBuilder.CreateTable(
                name: "Hijo",
                columns: table => new
                {
                    HijoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PadreID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    LName = table.Column<string>(nullable: false),
                    NDocument = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PhoneN = table.Column<string>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hijo", x => x.HijoID);
                    table.ForeignKey(
                        name: "FK_Hijo_Padre_PadreID",
                        column: x => x.PadreID,
                        principalTable: "Padre",
                        principalColumn: "PadreID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hijo_PadreID",
                table: "Hijo",
                column: "PadreID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hijo");

            migrationBuilder.DropTable(
                name: "Padre");
        }
    }
}
