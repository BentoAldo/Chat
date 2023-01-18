using AutoMapper;
using Chat.Application.Common.Models.DataTransferObjects;
using Chat.Domain.Entities;

namespace Chat.Application.Common.MappingProfile;

public class MessageMappingProfile : Profile
{
    public MessageMappingProfile()
    {
        CreateMap<Message, MessageDto>().ReverseMap();
    }
}