using Microsoft.EntityFrameworkCore.Migrations;

namespace SP.Idp.Core.IdentityCore.Migrations.IdentityServer.ConfigurationDb
{
    public partial class RenameConfigurationTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Idp_ApiResourceClaims_Idp_ApiResources_ApiResourceId",
                table: "Idp_ApiResourceClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_Idp_ApiResourceProperties_Idp_ApiResources_ApiResourceId",
                table: "Idp_ApiResourceProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_Idp_ApiScopeClaims_Idp_ApiScopes_ApiScopeId",
                table: "Idp_ApiScopeClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_Idp_ApiScopes_Idp_ApiResources_ApiResourceId",
                table: "Idp_ApiScopes");

            migrationBuilder.DropForeignKey(
                name: "FK_Idp_ApiSecrets_Idp_ApiResources_ApiResourceId",
                table: "Idp_ApiSecrets");

            migrationBuilder.DropForeignKey(
                name: "FK_Idp_ClientClaims_Idp_Clients_ClientId",
                table: "Idp_ClientClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_Idp_ClientCorsOrigins_Idp_Clients_ClientId",
                table: "Idp_ClientCorsOrigins");

            migrationBuilder.DropForeignKey(
                name: "FK_Idp_ClientGrantTypes_Idp_Clients_ClientId",
                table: "Idp_ClientGrantTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Idp_ClientIdPRestrictions_Idp_Clients_ClientId",
                table: "Idp_ClientIdPRestrictions");

            migrationBuilder.DropForeignKey(
                name: "FK_Idp_ClientPostLogoutRedirectUris_Idp_Clients_ClientId",
                table: "Idp_ClientPostLogoutRedirectUris");

            migrationBuilder.DropForeignKey(
                name: "FK_Idp_ClientProperties_Idp_Clients_ClientId",
                table: "Idp_ClientProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_Idp_ClientRedirectUris_Idp_Clients_ClientId",
                table: "Idp_ClientRedirectUris");

            migrationBuilder.DropForeignKey(
                name: "FK_Idp_ClientScopes_Idp_Clients_ClientId",
                table: "Idp_ClientScopes");

            migrationBuilder.DropForeignKey(
                name: "FK_Idp_ClientSecrets_Idp_Clients_ClientId",
                table: "Idp_ClientSecrets");

            migrationBuilder.DropForeignKey(
                name: "FK_Idp_IdentityClaims_Idp_IdentityResources_IdentityResourceId",
                table: "Idp_IdentityClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_Idp_IdentityResourceProperties_Idp_IdentityResources_IdentityResourceId",
                table: "Idp_IdentityResourceProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Idp_IdentityResources",
                table: "Idp_IdentityResources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Idp_IdentityResourceProperties",
                table: "Idp_IdentityResourceProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Idp_IdentityClaims",
                table: "Idp_IdentityClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Idp_ClientSecrets",
                table: "Idp_ClientSecrets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Idp_ClientScopes",
                table: "Idp_ClientScopes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Idp_Clients",
                table: "Idp_Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Idp_ClientRedirectUris",
                table: "Idp_ClientRedirectUris");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Idp_ClientProperties",
                table: "Idp_ClientProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Idp_ClientPostLogoutRedirectUris",
                table: "Idp_ClientPostLogoutRedirectUris");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Idp_ClientIdPRestrictions",
                table: "Idp_ClientIdPRestrictions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Idp_ClientGrantTypes",
                table: "Idp_ClientGrantTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Idp_ClientCorsOrigins",
                table: "Idp_ClientCorsOrigins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Idp_ClientClaims",
                table: "Idp_ClientClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Idp_ApiSecrets",
                table: "Idp_ApiSecrets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Idp_ApiScopes",
                table: "Idp_ApiScopes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Idp_ApiScopeClaims",
                table: "Idp_ApiScopeClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Idp_ApiResources",
                table: "Idp_ApiResources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Idp_ApiResourceProperties",
                table: "Idp_ApiResourceProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Idp_ApiResourceClaims",
                table: "Idp_ApiResourceClaims");

            migrationBuilder.RenameTable(
                name: "Idp_IdentityResources",
                newName: "IdpConfig_IdentityResources");

            migrationBuilder.RenameTable(
                name: "Idp_IdentityResourceProperties",
                newName: "IdpConfig_IdentityResourceProperties");

            migrationBuilder.RenameTable(
                name: "Idp_IdentityClaims",
                newName: "IdpConfig_IdentityClaims");

            migrationBuilder.RenameTable(
                name: "Idp_ClientSecrets",
                newName: "IdpConfig_ClientSecrets");

            migrationBuilder.RenameTable(
                name: "Idp_ClientScopes",
                newName: "IdpConfig_ClientScopes");

            migrationBuilder.RenameTable(
                name: "Idp_Clients",
                newName: "IdpConfig_Clients");

            migrationBuilder.RenameTable(
                name: "Idp_ClientRedirectUris",
                newName: "IdpConfig_ClientRedirectUris");

            migrationBuilder.RenameTable(
                name: "Idp_ClientProperties",
                newName: "IdpConfig_ClientProperties");

            migrationBuilder.RenameTable(
                name: "Idp_ClientPostLogoutRedirectUris",
                newName: "IdpConfig_ClientPostLogoutRedirectUris");

            migrationBuilder.RenameTable(
                name: "Idp_ClientIdPRestrictions",
                newName: "IdpConfig_ClientIdPRestrictions");

            migrationBuilder.RenameTable(
                name: "Idp_ClientGrantTypes",
                newName: "IdpConfig_ClientGrantTypes");

            migrationBuilder.RenameTable(
                name: "Idp_ClientCorsOrigins",
                newName: "IdpConfig_ClientCorsOrigins");

            migrationBuilder.RenameTable(
                name: "Idp_ClientClaims",
                newName: "IdpConfig_ClientClaims");

            migrationBuilder.RenameTable(
                name: "Idp_ApiSecrets",
                newName: "IdpConfig_ApiSecrets");

            migrationBuilder.RenameTable(
                name: "Idp_ApiScopes",
                newName: "IdpConfig_ApiScopes");

            migrationBuilder.RenameTable(
                name: "Idp_ApiScopeClaims",
                newName: "IdpConfig_ApiScopeClaims");

            migrationBuilder.RenameTable(
                name: "Idp_ApiResources",
                newName: "IdpConfig_ApiResources");

            migrationBuilder.RenameTable(
                name: "Idp_ApiResourceProperties",
                newName: "IdpConfig_ApiResourceProperties");

            migrationBuilder.RenameTable(
                name: "Idp_ApiResourceClaims",
                newName: "IdpConfig_ApiResourceClaims");

            migrationBuilder.RenameIndex(
                name: "IX_Idp_IdentityResources_Name",
                table: "IdpConfig_IdentityResources",
                newName: "IX_IdpConfig_IdentityResources_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Idp_IdentityResourceProperties_IdentityResourceId",
                table: "IdpConfig_IdentityResourceProperties",
                newName: "IX_IdpConfig_IdentityResourceProperties_IdentityResourceId");

            migrationBuilder.RenameIndex(
                name: "IX_Idp_IdentityClaims_IdentityResourceId",
                table: "IdpConfig_IdentityClaims",
                newName: "IX_IdpConfig_IdentityClaims_IdentityResourceId");

            migrationBuilder.RenameIndex(
                name: "IX_Idp_ClientSecrets_ClientId",
                table: "IdpConfig_ClientSecrets",
                newName: "IX_IdpConfig_ClientSecrets_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Idp_ClientScopes_ClientId",
                table: "IdpConfig_ClientScopes",
                newName: "IX_IdpConfig_ClientScopes_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Idp_Clients_ClientId",
                table: "IdpConfig_Clients",
                newName: "IX_IdpConfig_Clients_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Idp_ClientRedirectUris_ClientId",
                table: "IdpConfig_ClientRedirectUris",
                newName: "IX_IdpConfig_ClientRedirectUris_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Idp_ClientProperties_ClientId",
                table: "IdpConfig_ClientProperties",
                newName: "IX_IdpConfig_ClientProperties_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Idp_ClientPostLogoutRedirectUris_ClientId",
                table: "IdpConfig_ClientPostLogoutRedirectUris",
                newName: "IX_IdpConfig_ClientPostLogoutRedirectUris_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Idp_ClientIdPRestrictions_ClientId",
                table: "IdpConfig_ClientIdPRestrictions",
                newName: "IX_IdpConfig_ClientIdPRestrictions_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Idp_ClientGrantTypes_ClientId",
                table: "IdpConfig_ClientGrantTypes",
                newName: "IX_IdpConfig_ClientGrantTypes_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Idp_ClientCorsOrigins_ClientId",
                table: "IdpConfig_ClientCorsOrigins",
                newName: "IX_IdpConfig_ClientCorsOrigins_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Idp_ClientClaims_ClientId",
                table: "IdpConfig_ClientClaims",
                newName: "IX_IdpConfig_ClientClaims_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Idp_ApiSecrets_ApiResourceId",
                table: "IdpConfig_ApiSecrets",
                newName: "IX_IdpConfig_ApiSecrets_ApiResourceId");

            migrationBuilder.RenameIndex(
                name: "IX_Idp_ApiScopes_Name",
                table: "IdpConfig_ApiScopes",
                newName: "IX_IdpConfig_ApiScopes_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Idp_ApiScopes_ApiResourceId",
                table: "IdpConfig_ApiScopes",
                newName: "IX_IdpConfig_ApiScopes_ApiResourceId");

            migrationBuilder.RenameIndex(
                name: "IX_Idp_ApiScopeClaims_ApiScopeId",
                table: "IdpConfig_ApiScopeClaims",
                newName: "IX_IdpConfig_ApiScopeClaims_ApiScopeId");

            migrationBuilder.RenameIndex(
                name: "IX_Idp_ApiResources_Name",
                table: "IdpConfig_ApiResources",
                newName: "IX_IdpConfig_ApiResources_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Idp_ApiResourceProperties_ApiResourceId",
                table: "IdpConfig_ApiResourceProperties",
                newName: "IX_IdpConfig_ApiResourceProperties_ApiResourceId");

            migrationBuilder.RenameIndex(
                name: "IX_Idp_ApiResourceClaims_ApiResourceId",
                table: "IdpConfig_ApiResourceClaims",
                newName: "IX_IdpConfig_ApiResourceClaims_ApiResourceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdpConfig_IdentityResources",
                table: "IdpConfig_IdentityResources",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdpConfig_IdentityResourceProperties",
                table: "IdpConfig_IdentityResourceProperties",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdpConfig_IdentityClaims",
                table: "IdpConfig_IdentityClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdpConfig_ClientSecrets",
                table: "IdpConfig_ClientSecrets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdpConfig_ClientScopes",
                table: "IdpConfig_ClientScopes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdpConfig_Clients",
                table: "IdpConfig_Clients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdpConfig_ClientRedirectUris",
                table: "IdpConfig_ClientRedirectUris",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdpConfig_ClientProperties",
                table: "IdpConfig_ClientProperties",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdpConfig_ClientPostLogoutRedirectUris",
                table: "IdpConfig_ClientPostLogoutRedirectUris",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdpConfig_ClientIdPRestrictions",
                table: "IdpConfig_ClientIdPRestrictions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdpConfig_ClientGrantTypes",
                table: "IdpConfig_ClientGrantTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdpConfig_ClientCorsOrigins",
                table: "IdpConfig_ClientCorsOrigins",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdpConfig_ClientClaims",
                table: "IdpConfig_ClientClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdpConfig_ApiSecrets",
                table: "IdpConfig_ApiSecrets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdpConfig_ApiScopes",
                table: "IdpConfig_ApiScopes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdpConfig_ApiScopeClaims",
                table: "IdpConfig_ApiScopeClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdpConfig_ApiResources",
                table: "IdpConfig_ApiResources",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdpConfig_ApiResourceProperties",
                table: "IdpConfig_ApiResourceProperties",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdpConfig_ApiResourceClaims",
                table: "IdpConfig_ApiResourceClaims",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IdpConfig_ApiResourceClaims_IdpConfig_ApiResources_ApiResourceId",
                table: "IdpConfig_ApiResourceClaims",
                column: "ApiResourceId",
                principalTable: "IdpConfig_ApiResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdpConfig_ApiResourceProperties_IdpConfig_ApiResources_ApiResourceId",
                table: "IdpConfig_ApiResourceProperties",
                column: "ApiResourceId",
                principalTable: "IdpConfig_ApiResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdpConfig_ApiScopeClaims_IdpConfig_ApiScopes_ApiScopeId",
                table: "IdpConfig_ApiScopeClaims",
                column: "ApiScopeId",
                principalTable: "IdpConfig_ApiScopes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdpConfig_ApiScopes_IdpConfig_ApiResources_ApiResourceId",
                table: "IdpConfig_ApiScopes",
                column: "ApiResourceId",
                principalTable: "IdpConfig_ApiResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdpConfig_ApiSecrets_IdpConfig_ApiResources_ApiResourceId",
                table: "IdpConfig_ApiSecrets",
                column: "ApiResourceId",
                principalTable: "IdpConfig_ApiResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdpConfig_ClientClaims_IdpConfig_Clients_ClientId",
                table: "IdpConfig_ClientClaims",
                column: "ClientId",
                principalTable: "IdpConfig_Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdpConfig_ClientCorsOrigins_IdpConfig_Clients_ClientId",
                table: "IdpConfig_ClientCorsOrigins",
                column: "ClientId",
                principalTable: "IdpConfig_Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdpConfig_ClientGrantTypes_IdpConfig_Clients_ClientId",
                table: "IdpConfig_ClientGrantTypes",
                column: "ClientId",
                principalTable: "IdpConfig_Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdpConfig_ClientIdPRestrictions_IdpConfig_Clients_ClientId",
                table: "IdpConfig_ClientIdPRestrictions",
                column: "ClientId",
                principalTable: "IdpConfig_Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdpConfig_ClientPostLogoutRedirectUris_IdpConfig_Clients_ClientId",
                table: "IdpConfig_ClientPostLogoutRedirectUris",
                column: "ClientId",
                principalTable: "IdpConfig_Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdpConfig_ClientProperties_IdpConfig_Clients_ClientId",
                table: "IdpConfig_ClientProperties",
                column: "ClientId",
                principalTable: "IdpConfig_Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdpConfig_ClientRedirectUris_IdpConfig_Clients_ClientId",
                table: "IdpConfig_ClientRedirectUris",
                column: "ClientId",
                principalTable: "IdpConfig_Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdpConfig_ClientScopes_IdpConfig_Clients_ClientId",
                table: "IdpConfig_ClientScopes",
                column: "ClientId",
                principalTable: "IdpConfig_Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdpConfig_ClientSecrets_IdpConfig_Clients_ClientId",
                table: "IdpConfig_ClientSecrets",
                column: "ClientId",
                principalTable: "IdpConfig_Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdpConfig_IdentityClaims_IdpConfig_IdentityResources_IdentityResourceId",
                table: "IdpConfig_IdentityClaims",
                column: "IdentityResourceId",
                principalTable: "IdpConfig_IdentityResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdpConfig_IdentityResourceProperties_IdpConfig_IdentityResources_IdentityResourceId",
                table: "IdpConfig_IdentityResourceProperties",
                column: "IdentityResourceId",
                principalTable: "IdpConfig_IdentityResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdpConfig_ApiResourceClaims_IdpConfig_ApiResources_ApiResourceId",
                table: "IdpConfig_ApiResourceClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_IdpConfig_ApiResourceProperties_IdpConfig_ApiResources_ApiResourceId",
                table: "IdpConfig_ApiResourceProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_IdpConfig_ApiScopeClaims_IdpConfig_ApiScopes_ApiScopeId",
                table: "IdpConfig_ApiScopeClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_IdpConfig_ApiScopes_IdpConfig_ApiResources_ApiResourceId",
                table: "IdpConfig_ApiScopes");

            migrationBuilder.DropForeignKey(
                name: "FK_IdpConfig_ApiSecrets_IdpConfig_ApiResources_ApiResourceId",
                table: "IdpConfig_ApiSecrets");

            migrationBuilder.DropForeignKey(
                name: "FK_IdpConfig_ClientClaims_IdpConfig_Clients_ClientId",
                table: "IdpConfig_ClientClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_IdpConfig_ClientCorsOrigins_IdpConfig_Clients_ClientId",
                table: "IdpConfig_ClientCorsOrigins");

            migrationBuilder.DropForeignKey(
                name: "FK_IdpConfig_ClientGrantTypes_IdpConfig_Clients_ClientId",
                table: "IdpConfig_ClientGrantTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_IdpConfig_ClientIdPRestrictions_IdpConfig_Clients_ClientId",
                table: "IdpConfig_ClientIdPRestrictions");

            migrationBuilder.DropForeignKey(
                name: "FK_IdpConfig_ClientPostLogoutRedirectUris_IdpConfig_Clients_ClientId",
                table: "IdpConfig_ClientPostLogoutRedirectUris");

            migrationBuilder.DropForeignKey(
                name: "FK_IdpConfig_ClientProperties_IdpConfig_Clients_ClientId",
                table: "IdpConfig_ClientProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_IdpConfig_ClientRedirectUris_IdpConfig_Clients_ClientId",
                table: "IdpConfig_ClientRedirectUris");

            migrationBuilder.DropForeignKey(
                name: "FK_IdpConfig_ClientScopes_IdpConfig_Clients_ClientId",
                table: "IdpConfig_ClientScopes");

            migrationBuilder.DropForeignKey(
                name: "FK_IdpConfig_ClientSecrets_IdpConfig_Clients_ClientId",
                table: "IdpConfig_ClientSecrets");

            migrationBuilder.DropForeignKey(
                name: "FK_IdpConfig_IdentityClaims_IdpConfig_IdentityResources_IdentityResourceId",
                table: "IdpConfig_IdentityClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_IdpConfig_IdentityResourceProperties_IdpConfig_IdentityResources_IdentityResourceId",
                table: "IdpConfig_IdentityResourceProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdpConfig_IdentityResources",
                table: "IdpConfig_IdentityResources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdpConfig_IdentityResourceProperties",
                table: "IdpConfig_IdentityResourceProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdpConfig_IdentityClaims",
                table: "IdpConfig_IdentityClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdpConfig_ClientSecrets",
                table: "IdpConfig_ClientSecrets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdpConfig_ClientScopes",
                table: "IdpConfig_ClientScopes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdpConfig_Clients",
                table: "IdpConfig_Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdpConfig_ClientRedirectUris",
                table: "IdpConfig_ClientRedirectUris");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdpConfig_ClientProperties",
                table: "IdpConfig_ClientProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdpConfig_ClientPostLogoutRedirectUris",
                table: "IdpConfig_ClientPostLogoutRedirectUris");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdpConfig_ClientIdPRestrictions",
                table: "IdpConfig_ClientIdPRestrictions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdpConfig_ClientGrantTypes",
                table: "IdpConfig_ClientGrantTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdpConfig_ClientCorsOrigins",
                table: "IdpConfig_ClientCorsOrigins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdpConfig_ClientClaims",
                table: "IdpConfig_ClientClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdpConfig_ApiSecrets",
                table: "IdpConfig_ApiSecrets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdpConfig_ApiScopes",
                table: "IdpConfig_ApiScopes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdpConfig_ApiScopeClaims",
                table: "IdpConfig_ApiScopeClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdpConfig_ApiResources",
                table: "IdpConfig_ApiResources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdpConfig_ApiResourceProperties",
                table: "IdpConfig_ApiResourceProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdpConfig_ApiResourceClaims",
                table: "IdpConfig_ApiResourceClaims");

            migrationBuilder.RenameTable(
                name: "IdpConfig_IdentityResources",
                newName: "Idp_IdentityResources");

            migrationBuilder.RenameTable(
                name: "IdpConfig_IdentityResourceProperties",
                newName: "Idp_IdentityResourceProperties");

            migrationBuilder.RenameTable(
                name: "IdpConfig_IdentityClaims",
                newName: "Idp_IdentityClaims");

            migrationBuilder.RenameTable(
                name: "IdpConfig_ClientSecrets",
                newName: "Idp_ClientSecrets");

            migrationBuilder.RenameTable(
                name: "IdpConfig_ClientScopes",
                newName: "Idp_ClientScopes");

            migrationBuilder.RenameTable(
                name: "IdpConfig_Clients",
                newName: "Idp_Clients");

            migrationBuilder.RenameTable(
                name: "IdpConfig_ClientRedirectUris",
                newName: "Idp_ClientRedirectUris");

            migrationBuilder.RenameTable(
                name: "IdpConfig_ClientProperties",
                newName: "Idp_ClientProperties");

            migrationBuilder.RenameTable(
                name: "IdpConfig_ClientPostLogoutRedirectUris",
                newName: "Idp_ClientPostLogoutRedirectUris");

            migrationBuilder.RenameTable(
                name: "IdpConfig_ClientIdPRestrictions",
                newName: "Idp_ClientIdPRestrictions");

            migrationBuilder.RenameTable(
                name: "IdpConfig_ClientGrantTypes",
                newName: "Idp_ClientGrantTypes");

            migrationBuilder.RenameTable(
                name: "IdpConfig_ClientCorsOrigins",
                newName: "Idp_ClientCorsOrigins");

            migrationBuilder.RenameTable(
                name: "IdpConfig_ClientClaims",
                newName: "Idp_ClientClaims");

            migrationBuilder.RenameTable(
                name: "IdpConfig_ApiSecrets",
                newName: "Idp_ApiSecrets");

            migrationBuilder.RenameTable(
                name: "IdpConfig_ApiScopes",
                newName: "Idp_ApiScopes");

            migrationBuilder.RenameTable(
                name: "IdpConfig_ApiScopeClaims",
                newName: "Idp_ApiScopeClaims");

            migrationBuilder.RenameTable(
                name: "IdpConfig_ApiResources",
                newName: "Idp_ApiResources");

            migrationBuilder.RenameTable(
                name: "IdpConfig_ApiResourceProperties",
                newName: "Idp_ApiResourceProperties");

            migrationBuilder.RenameTable(
                name: "IdpConfig_ApiResourceClaims",
                newName: "Idp_ApiResourceClaims");

            migrationBuilder.RenameIndex(
                name: "IX_IdpConfig_IdentityResources_Name",
                table: "Idp_IdentityResources",
                newName: "IX_Idp_IdentityResources_Name");

            migrationBuilder.RenameIndex(
                name: "IX_IdpConfig_IdentityResourceProperties_IdentityResourceId",
                table: "Idp_IdentityResourceProperties",
                newName: "IX_Idp_IdentityResourceProperties_IdentityResourceId");

            migrationBuilder.RenameIndex(
                name: "IX_IdpConfig_IdentityClaims_IdentityResourceId",
                table: "Idp_IdentityClaims",
                newName: "IX_Idp_IdentityClaims_IdentityResourceId");

            migrationBuilder.RenameIndex(
                name: "IX_IdpConfig_ClientSecrets_ClientId",
                table: "Idp_ClientSecrets",
                newName: "IX_Idp_ClientSecrets_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_IdpConfig_ClientScopes_ClientId",
                table: "Idp_ClientScopes",
                newName: "IX_Idp_ClientScopes_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_IdpConfig_Clients_ClientId",
                table: "Idp_Clients",
                newName: "IX_Idp_Clients_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_IdpConfig_ClientRedirectUris_ClientId",
                table: "Idp_ClientRedirectUris",
                newName: "IX_Idp_ClientRedirectUris_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_IdpConfig_ClientProperties_ClientId",
                table: "Idp_ClientProperties",
                newName: "IX_Idp_ClientProperties_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_IdpConfig_ClientPostLogoutRedirectUris_ClientId",
                table: "Idp_ClientPostLogoutRedirectUris",
                newName: "IX_Idp_ClientPostLogoutRedirectUris_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_IdpConfig_ClientIdPRestrictions_ClientId",
                table: "Idp_ClientIdPRestrictions",
                newName: "IX_Idp_ClientIdPRestrictions_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_IdpConfig_ClientGrantTypes_ClientId",
                table: "Idp_ClientGrantTypes",
                newName: "IX_Idp_ClientGrantTypes_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_IdpConfig_ClientCorsOrigins_ClientId",
                table: "Idp_ClientCorsOrigins",
                newName: "IX_Idp_ClientCorsOrigins_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_IdpConfig_ClientClaims_ClientId",
                table: "Idp_ClientClaims",
                newName: "IX_Idp_ClientClaims_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_IdpConfig_ApiSecrets_ApiResourceId",
                table: "Idp_ApiSecrets",
                newName: "IX_Idp_ApiSecrets_ApiResourceId");

            migrationBuilder.RenameIndex(
                name: "IX_IdpConfig_ApiScopes_Name",
                table: "Idp_ApiScopes",
                newName: "IX_Idp_ApiScopes_Name");

            migrationBuilder.RenameIndex(
                name: "IX_IdpConfig_ApiScopes_ApiResourceId",
                table: "Idp_ApiScopes",
                newName: "IX_Idp_ApiScopes_ApiResourceId");

            migrationBuilder.RenameIndex(
                name: "IX_IdpConfig_ApiScopeClaims_ApiScopeId",
                table: "Idp_ApiScopeClaims",
                newName: "IX_Idp_ApiScopeClaims_ApiScopeId");

            migrationBuilder.RenameIndex(
                name: "IX_IdpConfig_ApiResources_Name",
                table: "Idp_ApiResources",
                newName: "IX_Idp_ApiResources_Name");

            migrationBuilder.RenameIndex(
                name: "IX_IdpConfig_ApiResourceProperties_ApiResourceId",
                table: "Idp_ApiResourceProperties",
                newName: "IX_Idp_ApiResourceProperties_ApiResourceId");

            migrationBuilder.RenameIndex(
                name: "IX_IdpConfig_ApiResourceClaims_ApiResourceId",
                table: "Idp_ApiResourceClaims",
                newName: "IX_Idp_ApiResourceClaims_ApiResourceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Idp_IdentityResources",
                table: "Idp_IdentityResources",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Idp_IdentityResourceProperties",
                table: "Idp_IdentityResourceProperties",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Idp_IdentityClaims",
                table: "Idp_IdentityClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Idp_ClientSecrets",
                table: "Idp_ClientSecrets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Idp_ClientScopes",
                table: "Idp_ClientScopes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Idp_Clients",
                table: "Idp_Clients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Idp_ClientRedirectUris",
                table: "Idp_ClientRedirectUris",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Idp_ClientProperties",
                table: "Idp_ClientProperties",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Idp_ClientPostLogoutRedirectUris",
                table: "Idp_ClientPostLogoutRedirectUris",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Idp_ClientIdPRestrictions",
                table: "Idp_ClientIdPRestrictions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Idp_ClientGrantTypes",
                table: "Idp_ClientGrantTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Idp_ClientCorsOrigins",
                table: "Idp_ClientCorsOrigins",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Idp_ClientClaims",
                table: "Idp_ClientClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Idp_ApiSecrets",
                table: "Idp_ApiSecrets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Idp_ApiScopes",
                table: "Idp_ApiScopes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Idp_ApiScopeClaims",
                table: "Idp_ApiScopeClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Idp_ApiResources",
                table: "Idp_ApiResources",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Idp_ApiResourceProperties",
                table: "Idp_ApiResourceProperties",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Idp_ApiResourceClaims",
                table: "Idp_ApiResourceClaims",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Idp_ApiResourceClaims_Idp_ApiResources_ApiResourceId",
                table: "Idp_ApiResourceClaims",
                column: "ApiResourceId",
                principalTable: "Idp_ApiResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Idp_ApiResourceProperties_Idp_ApiResources_ApiResourceId",
                table: "Idp_ApiResourceProperties",
                column: "ApiResourceId",
                principalTable: "Idp_ApiResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Idp_ApiScopeClaims_Idp_ApiScopes_ApiScopeId",
                table: "Idp_ApiScopeClaims",
                column: "ApiScopeId",
                principalTable: "Idp_ApiScopes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Idp_ApiScopes_Idp_ApiResources_ApiResourceId",
                table: "Idp_ApiScopes",
                column: "ApiResourceId",
                principalTable: "Idp_ApiResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Idp_ApiSecrets_Idp_ApiResources_ApiResourceId",
                table: "Idp_ApiSecrets",
                column: "ApiResourceId",
                principalTable: "Idp_ApiResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Idp_ClientClaims_Idp_Clients_ClientId",
                table: "Idp_ClientClaims",
                column: "ClientId",
                principalTable: "Idp_Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Idp_ClientCorsOrigins_Idp_Clients_ClientId",
                table: "Idp_ClientCorsOrigins",
                column: "ClientId",
                principalTable: "Idp_Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Idp_ClientGrantTypes_Idp_Clients_ClientId",
                table: "Idp_ClientGrantTypes",
                column: "ClientId",
                principalTable: "Idp_Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Idp_ClientIdPRestrictions_Idp_Clients_ClientId",
                table: "Idp_ClientIdPRestrictions",
                column: "ClientId",
                principalTable: "Idp_Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Idp_ClientPostLogoutRedirectUris_Idp_Clients_ClientId",
                table: "Idp_ClientPostLogoutRedirectUris",
                column: "ClientId",
                principalTable: "Idp_Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Idp_ClientProperties_Idp_Clients_ClientId",
                table: "Idp_ClientProperties",
                column: "ClientId",
                principalTable: "Idp_Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Idp_ClientRedirectUris_Idp_Clients_ClientId",
                table: "Idp_ClientRedirectUris",
                column: "ClientId",
                principalTable: "Idp_Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Idp_ClientScopes_Idp_Clients_ClientId",
                table: "Idp_ClientScopes",
                column: "ClientId",
                principalTable: "Idp_Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Idp_ClientSecrets_Idp_Clients_ClientId",
                table: "Idp_ClientSecrets",
                column: "ClientId",
                principalTable: "Idp_Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Idp_IdentityClaims_Idp_IdentityResources_IdentityResourceId",
                table: "Idp_IdentityClaims",
                column: "IdentityResourceId",
                principalTable: "Idp_IdentityResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Idp_IdentityResourceProperties_Idp_IdentityResources_IdentityResourceId",
                table: "Idp_IdentityResourceProperties",
                column: "IdentityResourceId",
                principalTable: "Idp_IdentityResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
