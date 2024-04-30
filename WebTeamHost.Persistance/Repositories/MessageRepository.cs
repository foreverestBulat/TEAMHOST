using Microsoft.EntityFrameworkCore;
using WebTeamHost.App.Interfaces.Repositories;
using WebTeamHost.Domain.Entities;

namespace WebTeamHost.Persistance.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IGenericRepository<Message> _repository;

        public MessageRepository(IGenericRepository<Message> repository)
        {
            _repository = repository;
        }

        public async Task<List<Message>> GetListMessageByGroupAsync(int groupId)
        {
            return await _repository.Entities.Where(x => x.Group.Id == groupId).ToListAsync();
        }
    }
}
