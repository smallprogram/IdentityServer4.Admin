/// *************************************************************************************
/// Asp.net Core Identity 迁移
/// 
/// 添加迁移
/// add-migration InitAspNetCoreIdentity  -c IdentityCoreContext -o Migrations/AspNetCoreIdentity/AspNetCoreIdentityDB
/// 删除迁移
/// remove-migration -c IdentityCoreContext
/// 更新数据库
/// update-database -c IdentityCoreContext
/// 删除数据库
/// drop-database -c IdentityCoreContext
/// 
/// *************************************************************************************
/// 


///******************************************************************
/// IdentityServer4 迁移
/// 
/// 
/// 添加迁移
/// add-migration InitIdentityServerPersistedGrant -c IdpPersistedGrantDbContext -o Migrations/IdentityServer/PersistedGrantDb
/// add-migration InitIdentityServerConfiguration -c IdpConfigurationDbContext -o Migrations/IdentityServer/ConfigurationDb
/// 更新数据库
/// update-database -c IdpPersistedGrantDbContext
/// update-database -c IdpConfigurationDbContext
/// 
/// 
/// 
///******************************************************************