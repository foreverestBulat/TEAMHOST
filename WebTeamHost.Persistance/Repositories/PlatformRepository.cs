using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTeamHost.Application.Interfaces.Repositories;
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
