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
    }
}
