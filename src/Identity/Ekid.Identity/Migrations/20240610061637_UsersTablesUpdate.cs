using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ekid.Identity.Migrations
{
    /// <inheritdoc />
    public partial class UsersTablesUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Login",
                schema: "identity",
                table: "user_credentials",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "identity",
                table: "user_credentials",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(320)",
                oldMaxLength: 320);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "identity",
                table: "user_accounts",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(320)",
                oldMaxLength: 320);

            migrationBuilder.CreateIndex(
                name: "IX_user_credentials_Email",
                schema: "identity",
                table: "user_credentials",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_credentials_Login",
                schema: "identity",
                table: "user_credentials",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_accounts_Email",
                schema: "identity",
                table: "user_accounts",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_user_credentials_Email",
                schema: "identity",
                table: "user_credentials");

            migrationBuilder.DropIndex(
                name: "IX_user_credentials_Login",
                schema: "identity",
                table: "user_credentials");

            migrationBuilder.DropIndex(
                name: "IX_user_accounts_Email",
                schema: "identity",
                table: "user_accounts");

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                schema: "identity",
                table: "user_credentials",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "identity",
                table: "user_credentials",
                type: "character varying(320)",
                maxLength: 320,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "identity",
                table: "user_accounts",
                type: "character varying(320)",
                maxLength: 320,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);
        }
    }
}
