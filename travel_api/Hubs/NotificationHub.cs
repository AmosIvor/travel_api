using Microsoft.AspNetCore.SignalR;

namespace travel_api.Hubs
{
    public class NotificationHub : Hub
    {
        public NotificationHub() { }
        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"{Context.ConnectionId} has joined to NotificationHub");
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            Console.WriteLine($"{Context.ConnectionId} has left the NotificationHub");
            return base.OnDisconnectedAsync(exception);
        }
    }
}
