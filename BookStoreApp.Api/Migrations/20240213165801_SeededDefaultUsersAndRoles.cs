using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreApp.Api.Migrations
{
    public partial class SeededDefaultUsersAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2193e614-a340-4538-8963-e547f9d4d71b", "ca99c8cd-2673-4954-8694-70e20173693f", "Administrator", "ADMINISTRATOR" },
                    { "3cb9691c-6cd9-48b8-95d2-7453b28e0966", "32210025-1b97-44ec-8cba-06fca4dae35d", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2353ed45-0f07-4744-89b2-8b66508fb603", 0, "c4702bfd-d1e5-4699-a415-30aa0c572f92", "user@bookstore.com", false, "System", "User", false, null, "USER@BOOKSTORE.COM", "USER@BOOKSTORE.COM", "AQAAAAEAACcQAAAAEKDfe2ug1MM4jlshbdAi/TuUynAb/Jt9JbxZK50z9VAJ6dU2FnQEdmVTX5pDfw4CRA==", null, false, "16958bc2-7a19-4519-86a4-4ccfe9d40e40", false, "user@bookstore.com" },
                    { "892a2d96-b408-4ec7-b1dd-a37762b0a930", 0, "44514a5d-6f0d-4b3b-8145-731dc3027d6c", "admin@bookstore.com", false, "System", "Admin", false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAEAACcQAAAAEJNyxDhjU52RaDkZ43TNnBB1QOu4FgmSpSBzaohBWNIxLK1eC6ovh+1sI3LLqTBKnA==", null, false, "90029d76-1afb-468f-b9b4-fafc06c54c6f", false, "admin@bookstore.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3cb9691c-6cd9-48b8-95d2-7453b28e0966", "2353ed45-0f07-4744-89b2-8b66508fb603" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2193e614-a340-4538-8963-e547f9d4d71b", "892a2d96-b408-4ec7-b1dd-a37762b0a930" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3cb9691c-6cd9-48b8-95d2-7453b28e0966", "2353ed45-0f07-4744-89b2-8b66508fb603" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2193e614-a340-4538-8963-e547f9d4d71b", "892a2d96-b408-4ec7-b1dd-a37762b0a930" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2193e614-a340-4538-8963-e547f9d4d71b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3cb9691c-6cd9-48b8-95d2-7453b28e0966");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2353ed45-0f07-4744-89b2-8b66508fb603");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "892a2d96-b408-4ec7-b1dd-a37762b0a930");
        }
    }
}
