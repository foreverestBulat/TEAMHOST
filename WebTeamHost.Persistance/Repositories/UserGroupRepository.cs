using Microsoft.EntityFrameworkCore;
using WebTeamHost.App.Interfaces.Repositories;
using WebTeamHost.Domain.Entities;

namespace WebTeamHost.Persistance.Repositories
{
    public class UserGroupRepository : IUserGroupRepository
    {
        private readonly IGenericRepository<UserGroup> _repository;

        public UserGroupRepository(IGenericRepository<UserGroup> repository)
        {
            _repository = repository;
        }

        public async Task<List<UserGroup>> GetUserGroupsByUserAsync(string userId)
        {
            return await _repository.Entities.Where(x => x.UserId == userId).ToListAsync();
            //Console.WriteLine(await _repository.Entities.Where(x => x.UserId1 == userId).CountAsync());
            
        }

        public async Task<List<Group>> GetGroupsByUserAsync(string userId)
        {
            return await _repository.Entities.Where(x => x.UserId == userId).Select(x => x.Group).ToListAsync();
            //return await (from @userGroup in _repository.Entities
            //              where @userGroup.UserId1 == userId
            //              select @userGroup.Group).ToListAsync();
        }

            //_repository.Entities.Where(x => x.UserId1 == userId).Select(x => x.GroupId);
        //public async Task<List<>> HasGroupUserWithUser(string checkouterUserId, string userId)
        //{
        //    var userGroups = await _repository.Entities.Where(x => x.UserId1 == checkouterUserId || x.UserId1 == userId).ToListAsync();
        //    foreach (var userGroup in userGroups)
        //    {
        //        if 
        //    }

        //    return await _repository.Entities.Where(x => x.UserId1 == checkouterUserId || x.UserId1 == userId).ToListAsync();
        //}
    }
}
