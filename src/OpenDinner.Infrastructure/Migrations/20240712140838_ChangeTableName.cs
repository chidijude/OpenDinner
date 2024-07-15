using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenDinner.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuDinnerIds_menus_MenuId",
                table: "MenuDinnerIds");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuReviewIds_menus_MenuId",
                table: "MenuReviewIds");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuSections_menus_MenuId",
                table: "MenuSections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_menus",
                table: "menus");

            migrationBuilder.RenameTable(
                name: "menus",
                newName: "Menus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menus",
                table: "Menus",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuDinnerIds_Menus_MenuId",
                table: "MenuDinnerIds",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuReviewIds_Menus_MenuId",
                table: "MenuReviewIds",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuSections_Menus_MenuId",
                table: "MenuSections",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuDinnerIds_Menus_MenuId",
                table: "MenuDinnerIds");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuReviewIds_Menus_MenuId",
                table: "MenuReviewIds");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuSections_Menus_MenuId",
                table: "MenuSections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menus",
                table: "Menus");

            migrationBuilder.RenameTable(
                name: "Menus",
                newName: "menus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_menus",
                table: "menus",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuDinnerIds_menus_MenuId",
                table: "MenuDinnerIds",
                column: "MenuId",
                principalTable: "menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuReviewIds_menus_MenuId",
                table: "MenuReviewIds",
                column: "MenuId",
                principalTable: "menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuSections_menus_MenuId",
                table: "MenuSections",
                column: "MenuId",
                principalTable: "menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
