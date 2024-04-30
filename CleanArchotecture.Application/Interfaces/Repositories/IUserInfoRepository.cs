using WebTeamHost.Domain.Entities;

namespace WebTeamHost.Application.Interfaces.Repositories
{
    public interface IUserInfoRepository
    {
        Task<UserInfo> GetUserInfoByUserAsync(string userId);
    }
}
