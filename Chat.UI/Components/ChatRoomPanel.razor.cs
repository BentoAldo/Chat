using Microsoft.AspNetCore.Components;

namespace Chat.Web.Components;

public partial class ChatRoomPanel
{
    [Parameter] [EditorRequired] public string RoomName { get; set; } = string.Empty;
    [Parameter] [EditorRequired] public string RoomId { get; set; } = string.Empty;
    [Parameter] [EditorRequired] public string RoomDescription { get; set; } = string.Empty;

    private string GetRoomDescription()
    {
        return string.IsNullOrWhiteSpace(RoomDescription) ? "No description" : RoomDescription;
    }

    private string GetRoomName()
    {
        return string.IsNullOrWhiteSpace(RoomName) ? "No name" : RoomName;
    }

    private string GetRoomId()
    {
        return string.IsNullOrWhiteSpace(RoomId) ? "No id" : RoomId;
    }
}