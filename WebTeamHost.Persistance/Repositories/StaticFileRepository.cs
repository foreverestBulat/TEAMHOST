using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTeamHost.Application.Interfaces.Repositories;
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
