using AccountService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountService.DataAccess.EF
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => new { x.UserName, x.BankName }).IsUnique();

            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(x => x.UserName).IsRequired();
            builder.Property(x => x.BankName).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate);

        }
    }
}