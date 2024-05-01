using WebTeamHost.Domain.Entities;

namespace WebTeamHost.App.Interfaces.Repositories
{
    public interface IGameRepository
    {
        Task<Game> GetGameFromCacheById(int id, CancellationToken cancellationToken);
    }
}
