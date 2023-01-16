using Chat.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chat.Infrastructure.Data.Configurations;

public class ChatRoomConfig : IEntityTypeConfiguration<ChatRoom>
{
    public void Configure(EntityTypeBuilder<ChatRoom> builder)
    {
        builder.Property(prop => prop.Name).HasMaxLength(50).IsRequired();
        builder.Property(prop => prop.Description).HasMaxLength(500).IsRequired();
        builder.Property(prop => prop.CreatedAt).IsRequired();

        builder.HasData(new ChatRoom
            {
                Id = 1,
                Name = "Chat Room 1",
                Description = "The first Chat Room",
                CreatedAt = DateTime.Now
            }, 
            new ChatRoom 
            {
                Id = 2,
                Name = "Chat Room 2",
                Description = "The second Chat Room",
                CreatedAt = DateTime.Now
            });

        // Property OwnerId is foreign key of ApplicationUser
        /*builder.HasOne(prop => prop.Owner)
            .WithMany(prop => prop.ChatRooms)
            .HasForeignKey(prop => prop.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);*/
    }
}