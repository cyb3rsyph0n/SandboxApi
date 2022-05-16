using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SandboxApi.Core.Extensions;

namespace SandboxApi.Entities.UserInfos;

/// <summary>
///     Mapping for UserInfo entity
/// </summary>
public class UserInfoMapping : IEntityTypeConfiguration<UserInfo>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<UserInfo> builder)
    {
        builder.RemoveALlProperties();

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