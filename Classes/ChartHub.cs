using Microsoft.AspNetCore.SignalR;

namespace Classes
{
    public class ChartHub : Hub
    {
        public Task SendDirectMessage(CursorPosition position)
        {
            return Clients.All.SendAsync("SendDM", position);
        }

    }
}