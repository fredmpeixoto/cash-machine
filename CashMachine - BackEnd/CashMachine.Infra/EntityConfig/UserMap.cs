using CashMachine.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashMachine.Infra.EntityConfig
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            #region User
            builder.Property(e => e.Email)
                .HasColumnType("varchar(200)");
            builder.Property(e => e.Cpf)
                .HasColumnType("varchar(11)")
                .IsRequired();
            #endregion
        }
    }
}
