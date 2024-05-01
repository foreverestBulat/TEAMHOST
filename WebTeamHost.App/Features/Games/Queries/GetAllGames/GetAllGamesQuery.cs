using AutoMapper;
using AutoMapper.QueryableExtensions;

using WebTeamHost.Application.Extensions;
using WebTeamHost.App.Interfaces.Repositories;
using WebTeamHost.Domain.Entities;
using WebTeamHost.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static WebTeamHost.App.Features.Games.Queries.GetAllGames.GetAllGamesDto;
using System.Numerics;

namespace WebTeamHost.App.Features.Games.Queries.GetAllGames
{
    public record GetAllGamesQuery : IRequest<Result<List<GetAllGamesDto>>>;

    internal class GetAllGamesQueryHandler : IRequestHandler<GetAllGamesQuery, Result<List<GetAllGamesDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllGamesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllGamesDto>>> Handle(GetAllGamesQuery query, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.Repository<Game>().GetAllAsync();
            var games = _mapper.Map<List<GetAllGamesDto>>(entities);
                //.Entities
                   //.ProjectTo<GetAllGamesDto>(_mapper.ConfigurationProvider)
                   //.ToListAsync(cancellationToken);

            return await Result<List<GetAllGamesDto>>.SuccessAsync(games);
        }
    }
}
