using Microsoft.AspNetCore.Components;

namespace Chat.Web.Components;

public partial class ChatRoomPanel
{
    [Parameter] public string RoomName { get; set; }
    [Parameter] public string RoomId { get; set; }
    [Parameter] public string RoomDescription { get; set; }
    [Parameter] public string RoomIcon { get; set; }
    
    [Parameter] public EventCallback<string> OnRoomSelected { get; set; }
    
    private void SelectRoom()
    {
        OnRoomSelected.InvokeAsync(RoomId);
    }
    
    private string GetRoomIcon()
    {
        return string.IsNullOrWhiteSpace(RoomIcon) ? "fas fa-comments" : RoomIcon;
    }
    
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