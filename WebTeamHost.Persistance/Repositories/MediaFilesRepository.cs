using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTeamHost.Application.Interfaces.Repositories;
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
