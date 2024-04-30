using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTeamHost.Application.Features.Games.Queries.GetGameById;
using WebTeamHost.Application.Interfaces.Repositories;
using WebTeamHost.Domain.Entities;
using WebTeamHost.Shared;

namespace WebTeamHost.Application.Features.Countries.Queries.GetCountryById
{
    public record GetCountryByIdQuery : IRequest<Result<GetCountryByIdDto>>
    {
        public int Id { get; set; }

        public GetCountryByIdQuery()
        {

        }

        public GetCountryByIdQuery(int id)
        {
            Id = id;
        }
    }

    internal class GetCountryByIdQueryHandler : IRequestHandler<GetCountryByIdQuery, Result<GetCountryByIdDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCountryByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetCountryByIdDto>> Handle(GetCountryByIdQuery query, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Repository<Country>().GetByIdAsync(query.Id);
            var game = _mapper.Map<GetCountryByIdDto>(entity);
            return await Result<GetCountryByIdDto>.SuccessAsync(game);
        }
    }
}
