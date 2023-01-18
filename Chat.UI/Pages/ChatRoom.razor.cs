using System.Security.Claims;
using Chat.Application.Common.Models.DataTransferObjects;
using Chat.Domain.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;

namespace Chat.Web.Pages;

public partial class ChatRoom
{
    [Parameter] public string Id { get; set; } = string.Empty;
    
    [Inject] public UserManager<ApplicationUser> UserManager { get; set; } = null!;
    
    [Inject] public IJSRuntime JsRuntime { get; set; } = null!;
    
    [Inject] public HttpClient HttpClient { get; set; } = null!;

    private LinkedList<string> Messages { get; set; } = new();
    
    private IEnumerable<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();

    private string NewMessage { get; set; } = string.Empty;
    
    private string UserId { get; set; } = string.Empty;
    
    private string UserName { get; set; } = string.Empty;
    
    private HubConnection? Connection { get; set; }
    
    private ElementReference LastMessage { get; set; }
    
    private async Task LoadUsers()
    {
        Users = await UserManager.Users.Where(x => x.Id != UserId).ToListAsync();
    }
    
    private async Task<string> GetStockPriceAsync(string stockCode)
    {
        var response = await BotServices.GetStockAsync(stockCode);
        var quote = response?.Data?.Close;
        
        return $"{stockCode} quote is {quote} per share";
    }

    private async Task SendMessage()
    {
        if (Connection is not null)
        {
            if(NewMessage.StartsWith("/stock="))
            {
                var stockCode = NewMessage.Replace("/stock=", string.Empty);
                var stockPrice = await GetStockPriceAsync(stockCode);
                var encodedMsg = $"[{DateTime.Now}] Bot: {stockPrice}";
                await Connection.SendAsync("SendMessage", Id, "Bot", stockPrice);
                var newMessage = new MessageDto
                {
                    Text = encodedMsg,
                    ChatRoomId = int.Parse(Id),
                    Date = DateTime.Now
                };

                await MessageServices.AddMessageAsync(Mapper.Map<Message>(newMessage));
            }
            else
            {
                await Connection.SendAsync("SendMessage", Id, UserName, NewMessage);
                var encodedMsg = $"[{DateTime.Now}] {UserName}: {NewMessage}";
                var newMessage = new MessageDto
                {
                    Text = encodedMsg,
                    UserId = UserId,
                    ChatRoomId = int.Parse(Id),
                    Date = DateTime.Now
                };

                await MessageServices.AddMessageAsync(Mapper.Map<Message>(newMessage));
            }
        }
    }
    
    private async Task SetUser()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;
        UserId = user.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new Exception("User not found");
        UserName = user.FindFirstValue(ClaimTypes.Name) ?? throw new Exception("User not found");
    }

    private async Task StartHubConnection()
    {
        Connection = new HubConnectionBuilder()
            .WithUrl(NavigationManager.ToAbsoluteUri("/chat"))
            .Build();

        Connection.On<string, string>("ReceiveMessage", async (username, message) =>
        {
            var encodedMsg = $"[{DateTime.Now}] {username}: {message}";
            if (Messages.Count == 50) Messages.RemoveFirst();
            Messages.AddLast(encodedMsg);
            await InvokeAsync(StateHasChanged);
            await JsRuntime.InvokeVoidAsync("SetFocusToElement", LastMessage);
        });

        await Connection.StartAsync();
    }

    private async Task Enter(KeyboardEventArgs e)
    {
        if (e.Code is "Enter" or "NumpadEnter")
        {
           await SendMessage();
        }
    }

    private async Task JoinRoom()
    {
        if (Connection is not null)
        {
            await Connection.SendAsync("JoinRoom", Id);
        }
    }

    private async Task LoadMessages()
    {
        var messages = await MessageServices.GetMessagesAsync(int.Parse(Id));
        Messages = new LinkedList<string>(messages.Select(x => x.Text));
    }

    protected override async Task OnParametersSetAsync()
    {
        if (!int.TryParse(Id, out _ )) NavigationManager.NavigateTo("/");
        await SetUser();
        await LoadUsers();
        await StartHubConnection();
        await JoinRoom();
        await LoadMessages();
    }
}