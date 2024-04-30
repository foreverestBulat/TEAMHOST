using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTeamHost.Application.Interfaces.Repositories;
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
