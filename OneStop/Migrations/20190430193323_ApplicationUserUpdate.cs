using Microsoft.EntityFrameworkCore.Migrations;

namespace OneStop.Migrations
{
    public partial class ApplicationUserUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c67dcff0-d4e5-44f4-923d-456d169ee815");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserId", "UserName" },
                values: new object[] { "f5d27fa8-9a9e-4b0b-bdd1-4ddd039f5ed1", 0, "ba9903ae-57e9-49e2-9fcd-6e8865499007", null, true, "admin", "admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", null, "AQAAAAEAACcQAAAAEEUW+KJ08MRhQHmBZc6DZPCGRmzNHlG3+7yxqc9FMhjzxV3ri+3guytGy2THaH4OKg==", null, false, "63feb7ac-30d7-4944-adda-9305d2f2991d", false, 0, "admin@admin.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5d27fa8-9a9e-4b0b-bdd1-4ddd039f5ed1");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserId", "UserName" },
                values: new object[] { "c67dcff0-d4e5-44f4-923d-456d169ee815", 0, "b271a35d-9ff3-4a25-8bbf-5f183b010e99", null, true, "admin", "admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", null, "AQAAAAEAACcQAAAAECyYKfqoAUrurqNeSLBoj78UONnHFJiEgevv5g1w/mG5KA1EbeIXrJTHdny8LVJJLA==", null, false, "9987fb49-1f38-437b-ae20-19d3afe4b318", false, 0, "admin@admin.com" });
        }
    }
}
