using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaTecnica.Domain.Models;

namespace PruebaTecnica.Infrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> Builder)
        {
            Builder.ToTable("user");
            Builder.HasKey(User => User.Id);
            Builder.Property(User => User.UserName).HasMaxLength(200);
            Builder.Property(User => User.UserLastName).HasMaxLength(200);
            Builder.Property(User => User.UserEmail).HasMaxLength(400);
            Builder.Property(User => User.UserPassword).HasMaxLength(2000);
            Builder.HasIndex(User => User.UserEmail).IsUnique();
            Builder.HasMany(User => User.UserRole).WithMany().UsingEntity<UserRoleModel>();
        }
    }
}
