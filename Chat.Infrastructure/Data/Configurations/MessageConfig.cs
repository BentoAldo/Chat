using Chat.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chat.Infrastructure.Data.Configurations;

public class MessageConfig : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.Property(m => m.Date).HasDefaultValue(DateTime.Now);
    }
}