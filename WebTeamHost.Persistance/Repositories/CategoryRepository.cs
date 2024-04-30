using WebTeamHost.Application.Interfaces.Repositories;
using WebTeamHost.Domain.Entities;
using WebTeamHost.Persistance.Contexts;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WebTeamHost.Persistance.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IGenericRepository<Category> _repository;

        public CategoryRepository(IGenericRepository<Category> repository)
        {
            _repository = repository;
        }
    }
}
