using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestAcesso.Infrastructure.Database.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountTransfer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AccountOrigin = table.Column<string>(nullable: true),
                    AccountDestination = table.Column<string>(nullable: true),
                    Value = table.Column<decimal>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    QtyAttempts = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTransfer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: false),
                    LogDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AccountNumber = table.Column<string>(nullable: true),
                    Value = table.Column<decimal>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    HasExecute = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountTransfer");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "Transaction");
        }
    }
}
