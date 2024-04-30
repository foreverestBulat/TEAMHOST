using Microsoft.EntityFrameworkCore;
using WebTeamHost.App.Interfaces.Repositories;
using WebTeamHost.Domain.Entities;

namespace WebTeamHost.Persistance.Repositories
{ 
    public class GroupRepository : IGroupRepository
    {
        private readonly IGenericRepository<Group> _repository;

        public GroupRepository(IGenericRepository<Group> repository)
        {
            _repository = repository;
        }

        //public async Task<List<Group>> GetGroupsByIdsAsync(List<int> ids)
        //{
            
        //}

        public async Task<List<Group>> GetGroupsByIdsAsync(List<int> ids)
        {
            return await (from @group in _repository.Entities
                          where ids.Contains(@group.Id)
                          select @group
                          ).ToListAsync();
        }

        public async Task<int> GetAllCount()
        {
            return await _repository.Entities.CountAsync();
        }

        Task<List<System.Text.RegularExpressions.Group>> IGroupRepository.GetGroupsByIdsAsync(List<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
