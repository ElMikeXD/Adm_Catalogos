using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EGobX.NTemplate.Infraestructure.EFCore.SqlServer.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "catalog");

            migrationBuilder.CreateTable(
                name: "Template",
                schema: "catalog",
                columns: table => new
                {
                    TemplateId = table.Column<Guid>(nullable: false),
                    Folio = table.Column<int>(nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Template_TemplateId", x => x.TemplateId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Template",
                schema: "catalog");
        }
    }
}
