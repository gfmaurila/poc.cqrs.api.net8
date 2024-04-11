using Microsoft.EntityFrameworkCore.Migrations;
using poc.core.api.net8.Enumerado;
using poc.core.api.net8.Extensions;
using poc.core.api.net8.User;
using System.Text.Json;

#nullable disable

namespace Poc.SQLServer.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Gender = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    Notification = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "DATE", nullable: false),
                    Email = table.Column<string>(type: "varchar(254)", unicode: false, maxLength: 254, nullable: false),
                    Phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    RoleUserAuth = table.Column<string>(type: "varchar(2048)", unicode: false, maxLength: 2048, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            // Inserir dados falsos
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "FirstName", "LastName", "Gender", "DateOfBirth", "Email", "Password", "RoleUserAuth", "Notification", "Phone" },
                values: new object[]
                {
                    Guid.NewGuid(), "Guilherme", "Figueiras Maurila", EGender.Male.ToString(), new DateTime(1986, 03, 18), "gfmaurila@gmail.com", Password.ComputeSha256Hash("@C23l10a1985"),
                    JsonSerializer.Serialize(new List<string>
                    {
                        ERoleUserAuth.USER.ToString(),
                        ERoleUserAuth.CREATE_USER.ToString(),
                        ERoleUserAuth.UPDATE_USER.ToString(),
                        ERoleUserAuth.DELETE_USER.ToString(),
                        ERoleUserAuth.GET_USER.ToString(),
                        ERoleUserAuth.GET_BY_ID_USER.ToString(),

                        ERoleUserAuth.NOTIFICATION.ToString(),
                        ERoleUserAuth.CREATE_NOTIFICATION.ToString(),
                        ERoleUserAuth.DELETE_NOTIFICATION.ToString(),
                        ERoleUserAuth.GET_NOTIFICATION.ToString(),

                        ERoleUserAuth.REGION.ToString(),
                        ERoleUserAuth.COUNTRI.ToString(),
                        ERoleUserAuth.DEPARTMENT.ToString(),
                        ERoleUserAuth.EMPLOYEE.ToString(),
                        ERoleUserAuth.JOB.ToString(),
                        ERoleUserAuth.JOB_HISTORY.ToString(),
                        ERoleUserAuth.LOCATION.ToString(),

                        ERoleUserAuth.MKT_POST.ToString(),
                    }, (JsonSerializerOptions)null),
                    "WhatsApp",
                    "51985623312"
                }
            );

            // Inserir dados falsos
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "FirstName", "LastName", "Gender", "DateOfBirth", "Email", "Password", "RoleUserAuth", "Notification", "Phone" },
                values: new object[]
                {
                    Guid.NewGuid(), "Patrik", "Mandes", EGender.Male.ToString(), new DateTime(2006, 03, 18), "patrik.mendes@gmail.com", Password.ComputeSha256Hash("@C23l10a1985"),
                    JsonSerializer.Serialize(new List<string>
                    {
                        ERoleUserAuth.USER.ToString(),
                        ERoleUserAuth.CREATE_USER.ToString(),
                        ERoleUserAuth.UPDATE_USER.ToString(),
                        ERoleUserAuth.DELETE_USER.ToString(),
                        ERoleUserAuth.GET_USER.ToString(),
                        ERoleUserAuth.GET_BY_ID_USER.ToString(),

                        ERoleUserAuth.NOTIFICATION.ToString(),
                        ERoleUserAuth.CREATE_NOTIFICATION.ToString(),
                        ERoleUserAuth.DELETE_NOTIFICATION.ToString(),
                        ERoleUserAuth.GET_NOTIFICATION.ToString(),

                        ERoleUserAuth.REGION.ToString(),
                        ERoleUserAuth.COUNTRI.ToString(),
                        ERoleUserAuth.DEPARTMENT.ToString(),
                        ERoleUserAuth.EMPLOYEE.ToString(),
                        ERoleUserAuth.JOB.ToString(),
                        ERoleUserAuth.JOB_HISTORY.ToString(),
                        ERoleUserAuth.LOCATION.ToString(),

                        ERoleUserAuth.MKT_POST.ToString(),
                    }, (JsonSerializerOptions)null),
                    "WhatsApp",
                    "51985623312"
                }
            );

            // Inserir dados falsos
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "FirstName", "LastName", "Gender", "DateOfBirth", "Email", "Password", "RoleUserAuth", "Notification", "Phone" },
                values: new object[]
                {
                    Guid.NewGuid(), "Guilherme", "Figueiras Maurila - 2", EGender.Male.ToString(), new DateTime(1986, 03, 18), "gfmaurila@hotmail.com", Password.ComputeSha256Hash("@C23l10a1985"),
                    JsonSerializer.Serialize(new List<string>
                    {
                        ERoleUserAuth.USER.ToString(),
                        ERoleUserAuth.NOTIFICATION.ToString(),
                    }, (JsonSerializerOptions)null),
                    "SMS",
                    "51985623355"
                }
            );

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "FirstName", "LastName", "Gender", "DateOfBirth", "Email", "Password", "RoleUserAuth", "Notification", "Phone" },
                values: new object[]
                {
                    Guid.NewGuid(), "Clarisse", "Maurila", EGender.Female.ToString(), new DateTime(1973, 08, 05), "clarisse.maurila@gmail.com", Password.ComputeSha256Hash("@C23l10a1985"),
                    JsonSerializer.Serialize(new List<string>
                    {
                        ERoleUserAuth.GET_USER.ToString(),
                        ERoleUserAuth.GET_NOTIFICATION.ToString(),
                    }, (JsonSerializerOptions)null),
                    "Email",
                    "51985623300"
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
