using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using WebTeamHost.App.Interfaces.Repositories;
using WebTeamHost.Domain.Entities;

namespace WebTeamHost.Redis.Repositories
{
    public class CachedGameRepository // : IGameRepository
    {
        //private readonly IGameRepository _repository;
        private readonly IDistributedCache _distributedCache;
        private readonly IUnitOfWork _unitOfWork;

        public CachedGameRepository(IUnitOfWork unitOfWork, IDistributedCache distributedCache) // IGameRepository repository
        {
            //_repository = repository;
            _unitOfWork = unitOfWork;
            _distributedCache = distributedCache;
            Console.WriteLine("ASDSAASDASDAS");
        }

        public async Task<Game?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            string key = $"game-{id}";

            string? cachedGame = await _distributedCache.GetStringAsync(key, cancellationToken);

            if (string.IsNullOrEmpty(cachedGame))
            {
                var game = await _unitOfWork.Repository<Game>().GetByIdAsync(id);
                if (game is null)
                {
                    return game;
                }
                await _distributedCache.SetStringAsync(key, JsonConvert.SerializeObject(game), cancellationToken);
                return game;
            }
            return JsonConvert.DeserializeObject<Game>(cachedGame);
        }
    }
}
