using Microsoft.EntityFrameworkCore;
using WebTeamHost.App.Interfaces.Repositories;
using WebTeamHost.Domain.Entities;

namespace WebTeamHost.Persistance.Repositories
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private readonly IGenericRepository<UserInfo> _repository;

        public UserInfoRepository(IGenericRepository<UserInfo> repository)
        {
            _repository = repository;
        }

        public async Task<UserInfo> GetUserInfoByUserAsync(string userId)
        {
            return await _repository.Entities.Where(x => x.UserId == userId).FirstOrDefaultAsync();
        }
    }
}
