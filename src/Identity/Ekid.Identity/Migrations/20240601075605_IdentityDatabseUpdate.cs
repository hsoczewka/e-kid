using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ekid.Identity.Migrations
{
    /// <inheritdoc />
    public partial class IdentityDatabseUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Version",
                schema: "identity",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tenants",
                schema: "identity",
                columns: table => new
                {
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tenants", x => x.TenantId);
                });

            migrationBuilder.CreateTable(
                name: "user_accounts",
                schema: "identity",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "character varying(320)", maxLength: 320, nullable: false),
                    FirstName = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    LastName = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    Tenants = table.Column<ISet<Guid>>(type: "jsonb", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_accounts", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "user_credentials",
                schema: "identity",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Login = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "character varying(320)", maxLength: 320, nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_credentials", x => x.UserId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tenants",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "user_accounts",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "user_credentials",
                schema: "identity");

            migrationBuilder.DropColumn(
                name: "Version",
                schema: "identity",
                table: "users");
        }
    }
}
