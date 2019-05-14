using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SP.Idp.Core.IdentityCore.Migrations.IdentityServer.ConfigurationDb
{
    public partial class InitIdentityServerConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Idp_ApiResources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Enabled = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    LastAccessed = table.Column<DateTime>(nullable: true),
                    NonEditable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idp_ApiResources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Idp_Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Enabled = table.Column<bool>(nullable: false),
                    ClientId = table.Column<string>(maxLength: 200, nullable: false),
                    ProtocolType = table.Column<string>(maxLength: 200, nullable: false),
                    RequireClientSecret = table.Column<bool>(nullable: false),
                    ClientName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    ClientUri = table.Column<string>(maxLength: 2000, nullable: true),
                    LogoUri = table.Column<string>(maxLength: 2000, nullable: true),
                    RequireConsent = table.Column<bool>(nullable: false),
                    AllowRememberConsent = table.Column<bool>(nullable: false),
                    AlwaysIncludeUserClaimsInIdToken = table.Column<bool>(nullable: false),
                    RequirePkce = table.Column<bool>(nullable: false),
                    AllowPlainTextPkce = table.Column<bool>(nullable: false),
                    AllowAccessTokensViaBrowser = table.Column<bool>(nullable: false),
                    FrontChannelLogoutUri = table.Column<string>(maxLength: 2000, nullable: true),
                    FrontChannelLogoutSessionRequired = table.Column<bool>(nullable: false),
                    BackChannelLogoutUri = table.Column<string>(maxLength: 2000, nullable: true),
                    BackChannelLogoutSessionRequired = table.Column<bool>(nullable: false),
                    AllowOfflineAccess = table.Column<bool>(nullable: false),
                    IdentityTokenLifetime = table.Column<int>(nullable: false),
                    AccessTokenLifetime = table.Column<int>(nullable: false),
                    AuthorizationCodeLifetime = table.Column<int>(nullable: false),
                    ConsentLifetime = table.Column<int>(nullable: true),
                    AbsoluteRefreshTokenLifetime = table.Column<int>(nullable: false),
                    SlidingRefreshTokenLifetime = table.Column<int>(nullable: false),
                    RefreshTokenUsage = table.Column<int>(nullable: false),
                    UpdateAccessTokenClaimsOnRefresh = table.Column<bool>(nullable: false),
                    RefreshTokenExpiration = table.Column<int>(nullable: false),
                    AccessTokenType = table.Column<int>(nullable: false),
                    EnableLocalLogin = table.Column<bool>(nullable: false),
                    IncludeJwtId = table.Column<bool>(nullable: false),
                    AlwaysSendClientClaims = table.Column<bool>(nullable: false),
                    ClientClaimsPrefix = table.Column<string>(maxLength: 200, nullable: true),
                    PairWiseSubjectSalt = table.Column<string>(maxLength: 200, nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    LastAccessed = table.Column<DateTime>(nullable: true),
                    UserSsoLifetime = table.Column<int>(nullable: true),
                    UserCodeType = table.Column<string>(maxLength: 100, nullable: true),
                    DeviceCodeLifetime = table.Column<int>(nullable: false),
                    NonEditable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idp_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Idp_IdentityResources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Enabled = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Required = table.Column<bool>(nullable: false),
                    Emphasize = table.Column<bool>(nullable: false),
                    ShowInDiscoveryDocument = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    NonEditable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idp_IdentityResources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Idp_ApiResourceClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(maxLength: 200, nullable: false),
                    ApiResourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idp_ApiResourceClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Idp_ApiResourceClaims_Idp_ApiResources_ApiResourceId",
                        column: x => x.ApiResourceId,
                        principalTable: "Idp_ApiResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Idp_ApiResourceProperties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(maxLength: 250, nullable: false),
                    Value = table.Column<string>(maxLength: 2000, nullable: false),
                    ApiResourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idp_ApiResourceProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Idp_ApiResourceProperties_Idp_ApiResources_ApiResourceId",
                        column: x => x.ApiResourceId,
                        principalTable: "Idp_ApiResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Idp_ApiScopes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Required = table.Column<bool>(nullable: false),
                    Emphasize = table.Column<bool>(nullable: false),
                    ShowInDiscoveryDocument = table.Column<bool>(nullable: false),
                    ApiResourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idp_ApiScopes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Idp_ApiScopes_Idp_ApiResources_ApiResourceId",
                        column: x => x.ApiResourceId,
                        principalTable: "Idp_ApiResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Idp_ApiSecrets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Value = table.Column<string>(maxLength: 4000, nullable: false),
                    Expiration = table.Column<DateTime>(nullable: true),
                    Type = table.Column<string>(maxLength: 250, nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    ApiResourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idp_ApiSecrets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Idp_ApiSecrets_Idp_ApiResources_ApiResourceId",
                        column: x => x.ApiResourceId,
                        principalTable: "Idp_ApiResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Idp_ClientClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(maxLength: 250, nullable: false),
                    Value = table.Column<string>(maxLength: 250, nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idp_ClientClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Idp_ClientClaims_Idp_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Idp_Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Idp_ClientCorsOrigins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Origin = table.Column<string>(maxLength: 150, nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idp_ClientCorsOrigins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Idp_ClientCorsOrigins_Idp_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Idp_Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Idp_ClientGrantTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GrantType = table.Column<string>(maxLength: 250, nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idp_ClientGrantTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Idp_ClientGrantTypes_Idp_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Idp_Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Idp_ClientIdPRestrictions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Provider = table.Column<string>(maxLength: 200, nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idp_ClientIdPRestrictions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Idp_ClientIdPRestrictions_Idp_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Idp_Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Idp_ClientPostLogoutRedirectUris",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PostLogoutRedirectUri = table.Column<string>(maxLength: 2000, nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idp_ClientPostLogoutRedirectUris", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Idp_ClientPostLogoutRedirectUris_Idp_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Idp_Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Idp_ClientProperties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(maxLength: 250, nullable: false),
                    Value = table.Column<string>(maxLength: 2000, nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idp_ClientProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Idp_ClientProperties_Idp_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Idp_Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Idp_ClientRedirectUris",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RedirectUri = table.Column<string>(maxLength: 2000, nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idp_ClientRedirectUris", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Idp_ClientRedirectUris_Idp_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Idp_Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Idp_ClientScopes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Scope = table.Column<string>(maxLength: 200, nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idp_ClientScopes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Idp_ClientScopes_Idp_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Idp_Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Idp_ClientSecrets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    Value = table.Column<string>(maxLength: 4000, nullable: false),
                    Expiration = table.Column<DateTime>(nullable: true),
                    Type = table.Column<string>(maxLength: 250, nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idp_ClientSecrets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Idp_ClientSecrets_Idp_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Idp_Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Idp_IdentityClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(maxLength: 200, nullable: false),
                    IdentityResourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idp_IdentityClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Idp_IdentityClaims_Idp_IdentityResources_IdentityResourceId",
                        column: x => x.IdentityResourceId,
                        principalTable: "Idp_IdentityResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Idp_IdentityResourceProperties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(maxLength: 250, nullable: false),
                    Value = table.Column<string>(maxLength: 2000, nullable: false),
                    IdentityResourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idp_IdentityResourceProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Idp_IdentityResourceProperties_Idp_IdentityResources_IdentityResourceId",
                        column: x => x.IdentityResourceId,
                        principalTable: "Idp_IdentityResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Idp_ApiScopeClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(maxLength: 200, nullable: false),
                    ApiScopeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idp_ApiScopeClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Idp_ApiScopeClaims_Idp_ApiScopes_ApiScopeId",
                        column: x => x.ApiScopeId,
                        principalTable: "Idp_ApiScopes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Idp_ApiResourceClaims_ApiResourceId",
                table: "Idp_ApiResourceClaims",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Idp_ApiResourceProperties_ApiResourceId",
                table: "Idp_ApiResourceProperties",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Idp_ApiResources_Name",
                table: "Idp_ApiResources",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Idp_ApiScopeClaims_ApiScopeId",
                table: "Idp_ApiScopeClaims",
                column: "ApiScopeId");

            migrationBuilder.CreateIndex(
                name: "IX_Idp_ApiScopes_ApiResourceId",
                table: "Idp_ApiScopes",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Idp_ApiScopes_Name",
                table: "Idp_ApiScopes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Idp_ApiSecrets_ApiResourceId",
                table: "Idp_ApiSecrets",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Idp_ClientClaims_ClientId",
                table: "Idp_ClientClaims",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Idp_ClientCorsOrigins_ClientId",
                table: "Idp_ClientCorsOrigins",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Idp_ClientGrantTypes_ClientId",
                table: "Idp_ClientGrantTypes",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Idp_ClientIdPRestrictions_ClientId",
                table: "Idp_ClientIdPRestrictions",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Idp_ClientPostLogoutRedirectUris_ClientId",
                table: "Idp_ClientPostLogoutRedirectUris",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Idp_ClientProperties_ClientId",
                table: "Idp_ClientProperties",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Idp_ClientRedirectUris_ClientId",
                table: "Idp_ClientRedirectUris",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Idp_Clients_ClientId",
                table: "Idp_Clients",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Idp_ClientScopes_ClientId",
                table: "Idp_ClientScopes",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Idp_ClientSecrets_ClientId",
                table: "Idp_ClientSecrets",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Idp_IdentityClaims_IdentityResourceId",
                table: "Idp_IdentityClaims",
                column: "IdentityResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Idp_IdentityResourceProperties_IdentityResourceId",
                table: "Idp_IdentityResourceProperties",
                column: "IdentityResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Idp_IdentityResources_Name",
                table: "Idp_IdentityResources",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Idp_ApiResourceClaims");

            migrationBuilder.DropTable(
                name: "Idp_ApiResourceProperties");

            migrationBuilder.DropTable(
                name: "Idp_ApiScopeClaims");

            migrationBuilder.DropTable(
                name: "Idp_ApiSecrets");

            migrationBuilder.DropTable(
                name: "Idp_ClientClaims");

            migrationBuilder.DropTable(
                name: "Idp_ClientCorsOrigins");

            migrationBuilder.DropTable(
                name: "Idp_ClientGrantTypes");

            migrationBuilder.DropTable(
                name: "Idp_ClientIdPRestrictions");

            migrationBuilder.DropTable(
                name: "Idp_ClientPostLogoutRedirectUris");

            migrationBuilder.DropTable(
                name: "Idp_ClientProperties");

            migrationBuilder.DropTable(
                name: "Idp_ClientRedirectUris");

            migrationBuilder.DropTable(
                name: "Idp_ClientScopes");

            migrationBuilder.DropTable(
                name: "Idp_ClientSecrets");

            migrationBuilder.DropTable(
                name: "Idp_IdentityClaims");

            migrationBuilder.DropTable(
                name: "Idp_IdentityResourceProperties");

            migrationBuilder.DropTable(
                name: "Idp_ApiScopes");

            migrationBuilder.DropTable(
                name: "Idp_Clients");

            migrationBuilder.DropTable(
                name: "Idp_IdentityResources");

            migrationBuilder.DropTable(
                name: "Idp_ApiResources");
        }
    }
}
