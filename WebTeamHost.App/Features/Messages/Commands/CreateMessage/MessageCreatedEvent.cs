using WebTeamHost.Domain.Common;
using WebTeamHost.Domain.Entities;

namespace WebTeamHost.App.Features.Messages.Commands.CreateMessage
{
    public class MessageCreatedEvent : BaseEvent
    {
        public Message Message { get; set; }

        public MessageCreatedEvent(Message message)
        {
            Message = message;
        }
    }
}
