using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTeamHost.App.Features.Games.Queries.GetGameById;
using WebTeamHost.App.Interfaces.Repositories;
using WebTeamHost.Domain.Entities;
using WebTeamHost.Shared;

namespace WebTeamHost.App.Features.Users.Queries.GetUserById
{
    //public record GetUserByIdQuery : IRequest<Result<GetUserByIdDto>>
    //{
    //    public string Id { get; set; }

    //    public GetUserByIdQuery()
    //    {

    //    }

    //    public GetUserByIdQuery(int id)
    //    {
    //        Id = id;
    //    }
    //}

    //internal class GetGameByIdQueryHandler : IRequestHandler<GetGameByIdQuery, Result<GetGameByIdDto>>
    //{
    //    private readonly IUnitOfWork _unitOfWork;
    //    private readonly IMapper _mapper;

    //    public GetGameByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    //    {
    //        _unitOfWork = unitOfWork;
    //        _mapper = mapper;
    //    }

    //    public async Task<Result<GetGameByIdDto>> Handle(GetGameByIdQuery query, CancellationToken cancellationToken)
    //    {
    //        var entity = await _unitOfWork.Repository<Game>().GetByIdAsync(query.Id);
    //        Console.WriteLine(entity.Name);
    //        var game = _mapper.Map<GetGameByIdDto>(entity);
    //        return await Result<GetGameByIdDto>.SuccessAsync(game);
    //    }
    //}
    public class GetUserByIdQuery
    {
    }
}
