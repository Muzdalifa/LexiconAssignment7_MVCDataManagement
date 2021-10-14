using Microsoft.EntityFrameworkCore.Migrations;

namespace LexiconAssignment7_MVCDataManagement.Migrations
{
    public partial class ChangeIDNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonLanguages_Languages_LanguageID",
                table: "PersonLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonLanguages_People_PersonID",
                table: "PersonLanguages");

            migrationBuilder.RenameColumn(
                name: "PersonID",
                table: "PersonLanguages",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "LanguageID",
                table: "PersonLanguages",
                newName: "LanguageId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "PersonLanguages",
                newName: "PersonLanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonLanguages_PersonID",
                table: "PersonLanguages",
                newName: "IX_PersonLanguages_PersonId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "People",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Languages",
                newName: "LanguageId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Countries",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Cities",
                newName: "CityId");

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, "Tanzania" },
                    { 2, "Sweden" },
                    { 3, "Kenya" },
                    { 4, "Uganda" },
                    { 5, "Germany" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "LanguageId", "Name" },
                values: new object[,]
                {
                    { 1, "Swahili" },
                    { 2, "Swedish" },
                    { 3, "English" },
                    { 4, "Spanish" },
                    { 5, "Arabic" },
                    { 6, "Chinese" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Dar es salaam" },
                    { 2, 1, "Dodoma" },
                    { 3, 2, "Uppsala" },
                    { 4, 2, "Stockholm" },
                    { 5, 3, "Nairobi" },
                    { 6, 4, "Kampala" },
                    { 7, 5, "	Munich" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PersonLanguages_Languages_LanguageId",
                table: "PersonLanguages",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonLanguages_People_PersonId",
                table: "PersonLanguages",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonLanguages_Languages_LanguageId",
                table: "PersonLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonLanguages_People_PersonId",
                table: "PersonLanguages");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 5);

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "PersonLanguages",
                newName: "PersonID");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "PersonLanguages",
                newName: "LanguageID");

            migrationBuilder.RenameColumn(
                name: "PersonLanguageId",
                table: "PersonLanguages",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_PersonLanguages_PersonId",
                table: "PersonLanguages",
                newName: "IX_PersonLanguages_PersonID");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "People",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "Languages",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Countries",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Cities",
                newName: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonLanguages_Languages_LanguageID",
                table: "PersonLanguages",
                column: "LanguageID",
                principalTable: "Languages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonLanguages_People_PersonID",
                table: "PersonLanguages",
                column: "PersonID",
                principalTable: "People",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
