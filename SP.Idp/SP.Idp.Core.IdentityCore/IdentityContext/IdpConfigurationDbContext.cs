using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using SP.Idp.Core.IdentityCore.Extenstions;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SP.Idp.Core.IdentityCore.IdentityContext
{
    public class IdpConfigurationDbContext : ConfigurationDbContext<IdpConfigurationDbContext>
    {
        public IdpConfigurationDbContext(DbContextOptions<IdpConfigurationDbContext> options, ConfigurationStoreOptions storeOptions) : base(options, storeOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Client>(b =>
            {
                b.ToTable("Idp_Clients");
            });
            modelBuilder.Entity<ClientProperty>(b =>
            {
                b.ToTable("Idp_ClientProperties");
            });
            modelBuilder.Entity<ClientCorsOrigin>(b =>
            {
                b.ToTable("Idp_ClientCorsOrigins");
            });
            modelBuilder.Entity<ClientIdPRestriction>(b =>
            {
                b.ToTable("Idp_ClientIdPRestrictions");
            });
            modelBuilder.Entity<ClientClaim>(b =>
            {
                b.ToTable("Idp_ClientClaims");
            });
            modelBuilder.Entity<ClientSecret>(b =>
            {
                b.ToTable("Idp_ClientSecrets");
            });
            modelBuilder.Entity<ClientScope>(b =>
            {
                b.ToTable("Idp_ClientScopes");
            });
            modelBuilder.Entity<ClientPostLogoutRedirectUri>(b =>
            {
                b.ToTable("Idp_ClientPostLogoutRedirectUris");
            });
            modelBuilder.Entity<ClientRedirectUri>(b =>
            {
                b.ToTable("Idp_ClientRedirectUris");
            });
            modelBuilder.Entity<ClientGrantType>(b =>
            {
                b.ToTable("Idp_ClientGrantTypes");
            });
            modelBuilder.Entity<ApiResourceProperty>(b =>
            {
                b.ToTable("Idp_ApiResourceProperties");
            });
            modelBuilder.Entity<ApiResourceClaim>(b =>
            {
                b.ToTable("Idp_ApiResourceClaims");
            });
            modelBuilder.Entity<ApiScope>(b =>
            {
                b.ToTable("Idp_ApiScopes");
            });
            modelBuilder.Entity<ApiSecret>(b =>
            {
                b.ToTable("Idp_ApiSecrets");
            });
            modelBuilder.Entity<ApiResource>(b =>
            {
                b.ToTable("Idp_ApiResources");
            });
            modelBuilder.Entity<ApiScopeClaim>(b =>
            {
                b.ToTable("Idp_ApiScopeClaims");
            });
            modelBuilder.Entity<IdentityClaim>(b =>
            {
                b.ToTable("Idp_IdentityClaims");
            });
            modelBuilder.Entity<IdentityResource>(b =>
            {
                b.ToTable("Idp_IdentityResources");
            });
            modelBuilder.Entity<IdentityResourceProperty>(b =>
            {
                b.ToTable("Idp_IdentityResourceProperties");
            });
        }
    }


    //public class ConfigurationContextDesignTimeFactory : DesignTimeDbContextFactoryBase<ConfigurationDbContext>
    //{
    //    public ConfigurationContextDesignTimeFactory()
    //        : base("IDPDataDBConnectionString", typeof(IdpConfigurationDbContext).GetTypeInfo().Assembly.GetName().Name)
    //    {
    //    }

    //    protected override ConfigurationDbContext CreateNewInstance(DbContextOptions<ConfigurationDbContext> options)
    //    {
    //        return new ConfigurationDbContext(options, new ConfigurationStoreOptions());
    //    }
    //}
}
