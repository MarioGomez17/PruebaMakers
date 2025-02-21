using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security;
using PruebaTecnica.Domain.Models;

namespace PruebaTecnica.Infrastructure.Configuration
{
    public class PermissionConfiguration : IEntityTypeConfiguration<PermissionModel>
    {
        public void Configure(EntityTypeBuilder<PermissionModel> Builder)
        {
            Builder.ToTable("permissions");
            Builder.HasKey(Permission => Permission.Id);
            Builder.Property(Permission => Permission.PermissionName);
        }
    }
}
