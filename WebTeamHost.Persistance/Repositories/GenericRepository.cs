using WebTeamHost.App.Interfaces.Repositories;
using WebTeamHost.Domain.Common;
using WebTeamHost.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace WebTeamHost.Persistance.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseAuditableEntity
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IDistributedCache _distributedCache;

        public GenericRepository(ApplicationDbContext dbContext, IDistributedCache distributedCache)
        {
            _dbContext = dbContext;
            _distributedCache = distributedCache;
        }

        public IQueryable<T> Entities => _dbContext.Set<T>();

        public async Task<T> GetFromCacheById(int id, CancellationToken cancellationToken)
        {
            string key = $"{typeof(T).Name}-{id}";

            string? cachedEntity = await _distributedCache.GetStringAsync(key, cancellationToken);

            if (string.IsNullOrEmpty(cachedEntity))
            {
                T entity = await GetByIdAsync(id);
                if (entity is null)
                {
                    return entity;
                }
                await _distributedCache.SetStringAsync(key, JsonConvert.SerializeObject(entity), cancellationToken);
                return entity;
            }
            return JsonConvert.DeserializeObject<T>(cachedEntity);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public Task UpdateAsync(T entity)
        {
            T exist = _dbContext.Set<T>().Find(entity.Id);
            _dbContext.Entry(exist).CurrentValues.SetValues(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbContext
                .Set<T>()
                .ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
    }
}