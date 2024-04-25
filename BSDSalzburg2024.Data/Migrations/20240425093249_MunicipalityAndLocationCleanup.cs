using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSDSalzburg2024.Data.Migrations
{
    /// <inheritdoc />
    public partial class MunicipalityAndLocationCleanup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrtLand",
                table: "tblOrt");

            migrationBuilder.AlterColumn<string>(
                name: "OrtStrasse",
                table: "tblOrt",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OrtPlz",
                table: "tblOrt",
                type: "varchar(5)",
                unicode: false,
                maxLength: 5,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(5)",
                oldUnicode: false,
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OrtName",
                table: "tblOrt",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GemeindeID",
                table: "tblOrt",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GemeindePLZ",
                table: "tblGemeinde",
                type: "varchar(5)",
                unicode: false,
                maxLength: 5,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(5)",
                oldUnicode: false,
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GemeindeName",
                table: "tblGemeinde",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GemeindeLand",
                table: "tblGemeinde",
                type: "varchar(3)",
                unicode: false,
                maxLength: 3,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(3)",
                oldUnicode: false,
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblOrt_GemeindeID",
                table: "tblOrt",
                column: "GemeindeID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblOrt_tblGemeinde_GemeindeID",
                table: "tblOrt",
                column: "GemeindeID",
                principalTable: "tblGemeinde",
                principalColumn: "GemeindeID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblOrt_tblGemeinde_GemeindeID",
                table: "tblOrt");

            migrationBuilder.DropIndex(
                name: "IX_tblOrt_GemeindeID",
                table: "tblOrt");

            migrationBuilder.AlterColumn<string>(
                name: "OrtStrasse",
                table: "tblOrt",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "OrtPlz",
                table: "tblOrt",
                type: "varchar(5)",
                unicode: false,
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5)",
                oldUnicode: false,
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "OrtName",
                table: "tblOrt",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<int>(
                name: "GemeindeID",
                table: "tblOrt",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "OrtLand",
                table: "tblOrt",
                type: "varchar(3)",
                unicode: false,
                maxLength: 3,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GemeindePLZ",
                table: "tblGemeinde",
                type: "varchar(5)",
                unicode: false,
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5)",
                oldUnicode: false,
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "GemeindeName",
                table: "tblGemeinde",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "GemeindeLand",
                table: "tblGemeinde",
                type: "varchar(3)",
                unicode: false,
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(3)",
                oldUnicode: false,
                oldMaxLength: 3);
        }
    }
}
