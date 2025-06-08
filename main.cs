
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços
builder.Services.AddSignalR();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurar pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<ChatHub>("/chatHub");

app.Run("http://0.0.0.0:5000");

// Hub do SignalR
public class ChatHub : Hub
{
    private static readonly Dictionary<string, string> ConnectedUsers = new();

    public override async Task OnConnectedAsync()
    {
        await Clients.All.SendAsync("UserConnected", Context.ConnectionId);
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception exception)
    {
        if (ConnectedUsers.ContainsKey(Context.ConnectionId))
        {
            var userName = ConnectedUsers[Context.ConnectionId];
            ConnectedUsers.Remove(Context.ConnectionId);
            await Clients.All.SendAsync("UserDisconnected", userName);
        }
        await base.OnDisconnectedAsync(exception);
    }

    public async Task JoinChat(string userName)
    {
        ConnectedUsers[Context.ConnectionId] = userName;
        await Clients.All.SendAsync("UserJoined", userName);
        await UpdateUsersList();
    }

    public async Task SendPublicMessage(string userName, string message)
    {
        await Clients.All.SendAsync("ReceivePublicMessage", userName, message, DateTime.Now.ToString("HH:mm"));
    }

    public async Task SendPrivateMessage(string senderName, string receiverName, string message)
    {
        var receiverConnectionId = ConnectedUsers.FirstOrDefault(x => x.Value == receiverName).Key;
        
        if (!string.IsNullOrEmpty(receiverConnectionId))
        {
            await Clients.Client(receiverConnectionId).SendAsync("ReceivePrivateMessage", senderName, message, DateTime.Now.ToString("HH:mm"));
            await Clients.Caller.SendAsync("PrivateMessageSent", receiverName, message, DateTime.Now.ToString("HH:mm"));
        }
        else
        {
            await Clients.Caller.SendAsync("UserNotFound", receiverName);
        }
    }

    

    private async Task UpdateUsersList()
    {
        var users = ConnectedUsers.Values.ToList();
        await Clients.All.SendAsync("UpdateUsersList", users);
    }
}

// Controller
public class HomeController : Microsoft.AspNetCore.Mvc.Controller
{
    public Microsoft.AspNetCore.Mvc.IActionResult Index()
    {
        return View();
    }
}
