using System.Text.RegularExpressions;

namespace WebTeamHost.Application.Interfaces.Repositories
{
    public interface IGroupRepository 
    {
        Task<List<Group>> GetGroupsByIdsAsync(List<int> ids);
        Task<int> GetAllCount();
    }
}
