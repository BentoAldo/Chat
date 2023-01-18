using AutoMapper;
using Chat.Application.Common.Models.DataTransferObjects;
using Chat.Domain.Entities;

namespace Chat.Application.Common.MappingProfile;

public class ChatRoomMappingProfile : Profile
{
    public ChatRoomMappingProfile()
    {
        CreateMap<ChatRoom, ChatRoomDto>().ReverseMap();
    }
}