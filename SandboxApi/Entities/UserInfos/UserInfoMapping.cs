using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SandboxApi.Core.BaseTypes;

namespace SandboxApi.Entities.UserInfos;

/// <summary>
///     Mapping for UserInfo entity
/// </summary>
public class UserInfoMapping : BaseMapping<UserInfo>
{
    /// <inheritdoc />
    public override void Configure(EntityTypeBuilder<UserInfo> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Created).IsRequired().ValueGeneratedOnAdd();
        builder.Property(x => x.Modified)
            .HasColumnName("Timestamp")
            .IsRequired()
            .ValueGeneratedOnAddOrUpdate()
            .IsConcurrencyToken();
        builder.Property(x => x.EmailAddress).IsRequired();
        builder.Property(x => x.Name);
        builder.Property(x => x.Password);
    }
}