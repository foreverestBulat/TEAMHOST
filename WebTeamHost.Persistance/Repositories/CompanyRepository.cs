using WebTeamHost.App.Interfaces.Repositories;
using WebTeamHost.Domain.Entities;

namespace WebTeamHost.Persistance.Repositories
{
    internal class CompanyRepository : ICompanyRepository
    {
        private readonly IGenericRepository<Company> _repository;

        public CompanyRepository(IGenericRepository<Company> repository)
        {
            _repository = repository;
        }
    }
}
