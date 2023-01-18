using Microsoft.AspNetCore.SignalR;

namespace Chat.Web.Hub;

public class ChatHub : Microsoft.AspNetCore.SignalR.Hub
{
    public async Task SendMessage(string room, string user, string message)
    {
        await Clients.Group(room).SendAsync("ReceiveMessage", user, message);
    }

    public async Task JoinRoom(string room)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, room);
        // await Clients.Group(room).SendAsync("ShowWho", $"{Context.ConnectionId} joined {room}");
    }
}