using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTeamHost.Application.Interfaces.Repositories;
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
