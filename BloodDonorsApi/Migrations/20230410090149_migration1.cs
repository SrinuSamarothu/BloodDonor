using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodDonorsApi.Migrations
{
    /// <inheritdoc />
    public partial class migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "donor",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    phnumber = table.Column<long>(type: "bigint", nullable: false),
                    city = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    bloodGroup = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    profession = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    weight = table.Column<int>(type: "int", nullable: false),
                    height = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_ID", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "donor");
        }
    }
}
