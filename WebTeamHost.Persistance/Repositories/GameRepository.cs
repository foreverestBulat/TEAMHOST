using WebTeamHost.App.Interfaces.Repositories;
using WebTeamHost.Domain.Entities;

namespace WebTeamHost.Persistance.Repositories
{
    internal class GameRepository : IGameRepository
    {
        private readonly IGenericRepository<Game> _repository;

        public GameRepository(IGenericRepository<Game> repository)
        {   
            _repository = repository;
        }
        
        public async Task<Game> GetGameFromCacheById(int id, CancellationToken cancellationToken)
        {

            return await _repository.GetByIdAsync(id);
        }
    }
}
