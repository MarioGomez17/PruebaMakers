using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Domain.Models;

namespace PruebaTecnica.Infrastructure.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<RoleModel>
    {
        public void Configure(EntityTypeBuilder<RoleModel> Builder)
        {
            Builder.ToTable("roles");
            Builder.HasKey(Rol => Rol.Id);
            Builder.HasMany(Role => Role.Permissions).WithMany().UsingEntity<RolePermissionModel>();
        }
    }
}
