using Chat.Application.Common.Models.DataTransferObjects;

namespace Chat.Web.Pages;

public partial class Index
{
    private IEnumerable<ChatRoomDto> ChatRooms { get; set; } = new List<ChatRoomDto>();

    protected override async Task OnInitializedAsync()
    {
        ChatRooms = Mapper.Map<IEnumerable<ChatRoomDto>>(
            await ChatRoomServices.GetChatRoomsAsync(Settings.Value.MaxPageSize));
    }
}