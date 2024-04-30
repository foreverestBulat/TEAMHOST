using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;
using WebTeamHost.App.Features.Messages.Commands.CreateMessage;

namespace WebTeamHost.SignalR.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IMediator _mediator;

        public ChatHub(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Send(string username, string userId, int groupIdReceiver, string message)
        {
            Console.WriteLine("DATA IN CHAT HUB");
            Console.WriteLine($"UserID: {userId}");
            Console.WriteLine($"GroupIDReceiver: {groupIdReceiver}");
            Console.WriteLine($"Message: {message}");
            Console.WriteLine("DATA IN CHAT HUB");
            await Clients.Group($"{groupIdReceiver}").SendAsync("Receive", message, username);
            await _mediator.Send(new CreateMessageCommand()
            {
                UserId = userId,
                GroupId = groupIdReceiver,
                Text = message
            });
            // save createMessageByUserInGroup
        }

        public async Task ConnectToGroup(string username, string userId, int groupId)
        {
            Console.WriteLine($"CONNECT GROUP TO: GROUPID={groupId}");
            Console.WriteLine($"Connected to {username}");
            Console.WriteLine($"Connected to {userId}");
            Console.WriteLine($"CONTEXT CONNECTIONID {Context.ConnectionId}");
            if (!userId.IsNullOrEmpty())
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, $"{groupId}");
                await Clients.Group($"{groupId}").SendAsync("Notify", $"{username} вошел в чат");
            }
        }
    }
}
