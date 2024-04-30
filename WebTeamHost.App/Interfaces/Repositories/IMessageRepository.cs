using WebTeamHost.Domain.Entities;

namespace WebTeamHost.App.Interfaces.Repositories
{
    public interface IMessageRepository
    {
        Task<List<Message>> GetListMessageByGroupAsync(int groupId);
    }
}
