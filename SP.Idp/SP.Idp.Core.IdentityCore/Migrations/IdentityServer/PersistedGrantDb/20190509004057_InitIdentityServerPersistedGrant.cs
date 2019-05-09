using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SP.Idp.Core.IdentityCore.Migrations.IdentityServer.PersistedGrantDb
{
    public partial class InitIdentityServerPersistedGrant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Idp_DeviceFlowCodes",
                columns: table => new
                {
                    UserCode = table.Column<string>(maxLength: 200, nullable: false),
                    DeviceCode = table.Column<string>(maxLength: 200, nullable: false),
                    SubjectId = table.Column<string>(maxLength: 200, nullable: true),
                    ClientId = table.Column<string>(maxLength: 200, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Expiration = table.Column<DateTime>(nullable: false),
                    Data = table.Column<string>(maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idp_DeviceFlowCodes", x => x.UserCode);
                });

            migrationBuilder.CreateTable(
                name: "Idp_PersistedGrants",
                columns: table => new
                {
                    Key = table.Column<string>(maxLength: 200, nullable: false),
                    Type = table.Column<string>(maxLength: 50, nullable: false),
                    SubjectId = table.Column<string>(maxLength: 200, nullable: true),
                    ClientId = table.Column<string>(maxLength: 200, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Expiration = table.Column<DateTime>(nullable: true),
                    Data = table.Column<string>(maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idp_PersistedGrants", x => x.Key);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Idp_DeviceFlowCodes_DeviceCode",
                table: "Idp_DeviceFlowCodes",
                column: "DeviceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Idp_PersistedGrants_SubjectId_ClientId_Type",
                table: "Idp_PersistedGrants",
                columns: new[] { "SubjectId", "ClientId", "Type" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Idp_DeviceFlowCodes");

            migrationBuilder.DropTable(
                name: "Idp_PersistedGrants");
        }
    }
}
