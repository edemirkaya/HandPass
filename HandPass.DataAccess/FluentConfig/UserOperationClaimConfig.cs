using HandPass.Core.CoreEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HandPass.DataAccess.FluentConfig
{
    public class UserOperationClaimConfig : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.OperationClaimId).IsRequired();

            builder.ToTable("UserOperationClaims");
        }
    }
}
