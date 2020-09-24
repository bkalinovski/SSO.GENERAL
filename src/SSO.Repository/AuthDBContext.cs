using LinqToDB;
using LinqToDB.Data;
using LinqToDB.Mapping;
using Microsoft.Extensions.Configuration;
using SSO.Repository.Infrastructure;
using System;
using SSO.Contract.Models.Entities;

namespace SSO.Repository
{
    public class AuthDBContext : DataConnection
    {
        public ITable<UserEntity> Users => GetTable<UserEntity>();
        public ITable<RoleEntity> Roles => GetTable<RoleEntity>();
        public ITable<UserRoleEntity> UserRoles => GetTable<UserRoleEntity>();

        public AuthDBContext(IConfiguration configuration) : base(ProviderName.SqlServer2014, configuration.GetAuthDBConnectionString(), CreateMappingSchema())
        {

        }

        private static MappingSchema CreateMappingSchema()
        {
            var mappingSchema = new MappingSchema();
            var mappingBuilder = mappingSchema.GetFluentMappingBuilder();

            mappingBuilder.Entity<UserEntity>()
                          .HasTableName("Users")
                          .HasPrimaryKey(t => t.Id);

            mappingBuilder.Entity<RoleEntity>()
                          .HasTableName("Roles")
                          .HasPrimaryKey(t => t.Id);

            mappingBuilder.Entity<UserRoleEntity>()
                          .HasTableName("UserRoles")
                          .HasPrimaryKey(t => t.Id);

            return mappingSchema;
        }
    }
}
