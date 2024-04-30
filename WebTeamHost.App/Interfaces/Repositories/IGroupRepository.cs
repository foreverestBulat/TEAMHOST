using System.Text.RegularExpressions;

namespace WebTeamHost.App.Interfaces.Repositories
{
    public interface IGroupRepository 
    {
        Task<List<Group>> GetGroupsByIdsAsync(List<int> ids);
        Task<int> GetAllCount();
    }
}
