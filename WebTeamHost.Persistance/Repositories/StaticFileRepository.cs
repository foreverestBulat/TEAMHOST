using WebTeamHost.App.Interfaces.Repositories;
using WebTeamHost.Domain.Entities;

namespace WebTeamHost.Persistance.Repositories
{
    internal class StaticFileRepository : IStaticFileRepository
    {
        private readonly IGenericRepository<StaticFile> _repository;

        public StaticFileRepository(IGenericRepository<StaticFile> repository)
        {
            _repository = repository;
        }
    }
}
