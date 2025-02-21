using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Domain.Models;

namespace PruebaTecnica.Infrastructure.Configuration
{
    internal class UserRoleConfiguration : IEntityTypeConfiguration<UserRoleModel>
    {
        public void Configure(EntityTypeBuilder<UserRoleModel> Builder)
        {
            Builder.ToTable("user_roles");
            Builder.HasKey(UserRole => UserRole.Id);
            Builder.Property(UserRole => UserRole.UserId);
            Builder.Property(UserRole => UserRole.RoleId);
        }
    }
}