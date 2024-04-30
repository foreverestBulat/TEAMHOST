using WebTeamHost.Domain.Entities;

namespace WebTeamHost.Application.Interfaces.Repositories
{
    public interface IMessageRepository
    {
        Task<List<Message>> GetListMessageByGroupAsync(int groupId);
    }
}
