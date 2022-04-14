using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SandboxApi.Entities.UserInfos;

/// <summary>
///     Mapping for UserInfo entity
/// </summary>
public class UserInfoMapping : IEntityTypeConfiguration<UserInfo>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<UserInfo> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Created).IsRequired().ValueGeneratedOnAdd();
        builder.Property(x => x.Modified).IsRequired().ValueGeneratedOnAddOrUpdate();

        builder.Property(x => x.EmailAddress).IsRequired();
        builder.Property(x => x.Name);
        builder.Property(x => x.Password);
    }
}