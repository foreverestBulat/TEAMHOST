using MediatR;
using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;

using WebTeamHost.Application.Extensions;
using WebTeamHost.Application.Interfaces.Repositories;
using WebTeamHost.Domain.Common.Interfaces;
using WebTeamHost.Domain.Entities;
using WebTeamHost.Shared;
using MediatR;
using Microsoft.AspNetCore.Routing.Matching;
using System.Numerics;

namespace WebTeamHost.Application.Features.Developers.Queries.GetDeveloperById
{
    public record GetDeveloperByIdQuery : IRequest<Result<GetDeveloperByIdDto>>
    {
        public int Id { get; set; }

        public GetDeveloperByIdQuery()
        {

        }

        public GetDeveloperByIdQuery(int id)
        {
            Id = id;
        }
    }

    internal class GetDeveloperByIdQueryHandler : IRequestHandler<GetDeveloperByIdQuery, Result<GetDeveloperByIdDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDeveloperByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetDeveloperByIdDto>> Handle(GetDeveloperByIdQuery query, CancellationToken cancellationToken) 
        {
            var entity = await _unitOfWork.Repository<Developer>().GetByIdAsync(query.Id);
            var player = _mapper.Map<GetDeveloperByIdDto>(entity);
            return await Result<GetDeveloperByIdDto>.SuccessAsync(player);
        }
    }
}