using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SP.Idp.Core.IdentityCore.Extenstions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace SP.Idp.Core.IdentityCore.IdentityContext
{
    public class IdpPersistedGrantDbContext : PersistedGrantDbContext
    {
        public IdpPersistedGrantDbContext(DbContextOptions<PersistedGrantDbContext> options, OperationalStoreOptions storeOptions) : base(options, storeOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PersistedGrant>(b =>
            {
                b.ToTable("Idp_PersistedGrants");
            });
            modelBuilder.Entity<DeviceFlowCodes>(b =>
            {
                b.ToTable("Idp_DeviceFlowCodes");
            });
        }
    }

    /// <summary>
    /// 用于EF迁移时解析IdentityServer的DBContext，返回具体的DBContext的实例工厂
    /// </summary>
    public class PersistedGrantContextDesignTimeFactory : DesignTimeDbContextFactoryBase<PersistedGrantDbContext>
    {
        public PersistedGrantContextDesignTimeFactory()
            : base("IDPDataDBConnectionString", typeof(IdpPersistedGrantDbContext).GetTypeInfo().Assembly.GetName().Name)
        {
        }

        protected override PersistedGrantDbContext CreateNewInstance(DbContextOptions<PersistedGrantDbContext> options)
        {
            return new PersistedGrantDbContext(options, new OperationalStoreOptions());
        }
    }

 


}
