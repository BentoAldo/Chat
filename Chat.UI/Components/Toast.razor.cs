using Microsoft.AspNetCore.Components;

namespace Chat.Web.Components;

public partial class Toast
{
    [Parameter] public string Title { get; set; } = string.Empty;
    [Parameter] public string Message { get; set; } = string.Empty;
}