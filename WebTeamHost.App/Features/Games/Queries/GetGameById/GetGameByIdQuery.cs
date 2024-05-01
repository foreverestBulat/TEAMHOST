using AutoMapper;
using AutoMapper.QueryableExtensions;

using WebTeamHost.App.Extensions;
using WebTeamHost.App.Interfaces.Repositories;
using WebTeamHost.Domain.Common.Interfaces;
using WebTeamHost.Domain.Entities;
using WebTeamHost.Shared;
using MediatR;

namespace WebTeamHost.App.Features.Games.Queries.GetGameById
{
    public record GetGameByIdQuery : IRequest<Result<GetGameByIdDto>>
    {
        public int Id { get; set; }

        public GetGameByIdQuery()
        {

        }

        public GetGameByIdQuery(int id)
        {
            Id = id;
        }
    }

    internal class GetGameByIdQueryHandler : IRequestHandler<GetGameByIdQuery, Result<GetGameByIdDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetGameByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetGameByIdDto>> Handle(GetGameByIdQuery query, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Repository<Game>().GetFromCacheById(query.Id, cancellationToken);
            //var entity = await _unitOfWork.Repository<Game>().GetByIdAsync(query.Id); // GetFromCacheById(query.Id, cancellationToken);
            Console.WriteLine(entity.Name);
            var game = _mapper.Map<GetGameByIdDto>(entity);
            return await Result<GetGameByIdDto>.SuccessAsync(game);
        }
    }
}
