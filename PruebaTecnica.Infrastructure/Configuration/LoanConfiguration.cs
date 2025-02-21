using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Domain.Models;

namespace PruebaTecnica.Infrastructure.Configuration
{
    public class LoanConfiguration : IEntityTypeConfiguration<LoanModel>
    {
        public void Configure(EntityTypeBuilder<LoanModel> Builder)
        {
            Builder.ToTable("loan");
            Builder.HasKey(Loan => Loan.Id);
            Builder.Property(Loan => Loan.LoanAmount);
            Builder.Property(Loan => Loan.LoanState);
            Builder.HasOne<UserModel>().WithOne();
        }
    }
}
