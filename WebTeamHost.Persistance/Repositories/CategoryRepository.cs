using WebTeamHost.App.Interfaces.Repositories;
using WebTeamHost.Domain.Entities;

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
