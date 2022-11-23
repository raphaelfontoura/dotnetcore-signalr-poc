using Microsoft.AspNetCore.SignalR;

class ChatHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }

    public async IAsyncEnumerable<DateTime> Streaming(CancellationToken cancellationToken)
    {
        while (true)
        {
            yield return DateTime.Now;
            await Task.Delay(1000, cancellationToken);
        }
    }
}