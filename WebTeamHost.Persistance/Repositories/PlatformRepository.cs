using WebTeamHost.App.Interfaces.Repositories;
using WebTeamHost.Domain.Entities;

namespace WebTeamHost.Persistance.Repositories
{
    internal class PlatformRepository : IPlatformRepository
    {
        private readonly IGenericRepository<Platform> _repository;

        public PlatformRepository(IGenericRepository<Platform> repository)
        {
            _repository = repository;
        }
    }
}
