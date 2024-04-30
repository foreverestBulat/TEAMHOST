using AutoMapper;
using MediatR;
using WebTeamHost.Application.Interfaces.Repositories;
using WebTeamHost.Shared;

namespace WebTeamHost.Application.Features.UserGroups.Queries.GetUserGroupsByUser
{
    public class GetUserGroupsByUserQuery : IRequest<Result<List<GetUserGroupsByUserDto>>>
    {
        public string UserId { get; set; }
        
        public GetUserGroupsByUserQuery() { }
        public GetUserGroupsByUserQuery(string userId)
        {
            UserId = userId;
        }

    }

    internal class GetUserGroupsByUserQueryHandler : IRequestHandler<GetUserGroupsByUserQuery, Result<List<GetUserGroupsByUserDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserGroupRepository _userGroupRepository;
        private readonly IMapper _mapper;

        public GetUserGroupsByUserQueryHandler(IUnitOfWork unitOfWork, IUserGroupRepository userGroupRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userGroupRepository = userGroupRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<GetUserGroupsByUserDto>>> Handle(GetUserGroupsByUserQuery query, CancellationToken cancellationToken)
        {
            var entities = await _userGroupRepository.GetUserGroupsByUserAsync(query.UserId);
            var userGroups = _mapper.Map<List<GetUserGroupsByUserDto>>(entities);
            return await Result<List<GetUserGroupsByUserDto>>.SuccessAsync(userGroups);
        }
    }
}
