using WebTeamHost.Domain.Common;
using WebTeamHost.Domain.Entities;

namespace WebTeamHost.Application.Features.Messages.Commands.CreateMessage
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
