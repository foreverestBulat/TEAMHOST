using WebTeamHost.Domain.Entities;

namespace WebTeamHost.App.Interfaces.Repositories
{
    public interface IUserInfoRepository
    {
        Task<UserInfo> GetUserInfoByUserAsync(string userId);
    }
}
