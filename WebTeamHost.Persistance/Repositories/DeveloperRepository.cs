using WebTeamHost.App.Interfaces.Repositories;
using WebTeamHost.Domain.Entities;

namespace WebTeamHost.Persistance.Repositories
{
    internal class DeveloperRepository : IDeveloperRepository
    {
        private readonly IGenericRepository<Developer> _repository;

        public DeveloperRepository(IGenericRepository<Developer> repository)
        {
            _repository = repository;
        }
    }
}
