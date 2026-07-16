using Microsoft.AspNetCore.SignalR;

namespace Chat.OhHell.Hubs
{
    public class ChatHub : Hub
    {
        public async Task JoinLobby(string lobbyId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, lobbyId);
        }

        public async Task LeaveLobby(string lobbyId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, lobbyId);
        }

        public async Task SendMessage(string lobbyid, string user, string message)
        {
            await Clients
                .Group(lobbyid)
                .SendAsync("ReceiveMessage", user, message);
        }
    }
}
