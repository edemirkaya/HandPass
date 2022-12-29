using HandPass.Entities.Entitiy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HandPass.DataAccess.FluentConfig
{
    public class UserPasswordConfig : IEntityTypeConfiguration<UserPassword>
    {
        public void Configure(EntityTypeBuilder<UserPassword> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PassDefinition).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Url).HasMaxLength(150).IsRequired();
            builder.Property(x => x.UserName).HasMaxLength(150).IsRequired();
            builder.Property(x => x.PassCategory).IsRequired();

            builder.ToTable("UserPasswords");
        }
    }
}
