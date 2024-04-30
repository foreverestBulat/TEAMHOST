using WebTeamHost.App.Interfaces.Repositories;
using WebTeamHost.Domain.Entities;

namespace WebTeamHost.Persistance.Repositories
{
    internal class CountryRepository : ICountryRepository
    {
        private readonly IGenericRepository<Country> _repository;

        public CountryRepository(IGenericRepository<Country> repository)
        {
            _repository = repository;
        }
    }
}
