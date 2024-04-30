using WebTeamHost.App.Interfaces.Repositories;
using WebTeamHost.Domain.Entities;

namespace WebTeamHost.Persistance.Repositories
{
    internal class MediaFilesRepository : IMediaFilesRepository
    {
        private readonly IGenericRepository<MediaFiles> _repository;

        public MediaFilesRepository(IGenericRepository<MediaFiles> repository)
        {
            _repository = repository;
        }
    }
}
