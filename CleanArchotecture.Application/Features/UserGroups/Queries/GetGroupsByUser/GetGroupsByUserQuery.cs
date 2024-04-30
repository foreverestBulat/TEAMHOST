using AutoMapper;
using MediatR;
using WebTeamHost.Application.Interfaces.Repositories;
using WebTeamHost.Shared;

namespace WebTeamHost.Application.Features.UserGroups.Queries.GetGroupsByUser
{
    public class GetGroupsByUserQuery : IRequest<Result<List<GetGroupsByUserDto>>>
    {
        public string UserId { get; set; }
        public GetGroupsByUserQuery() { }
        public GetGroupsByUserQuery(string userId)
        {
            UserId = userId;
        }
    }

    internal class GetGroupsByUserHandler : IRequestHandler<GetGroupsByUserQuery, Result<List<GetGroupsByUserDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserGroupRepository _userGroupRepository;
        private readonly IMapper _mapper;

        public GetGroupsByUserHandler(IUnitOfWork unitOfWork, IUserGroupRepository userGroupRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userGroupRepository = userGroupRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<GetGroupsByUserDto>>> Handle(GetGroupsByUserQuery request, CancellationToken cancellationToken)
        {
            var entities = await _userGroupRepository.GetGroupsByUserAsync(request.UserId);
            var groups = new List<GetGroupsByUserDto>();
            foreach (var entity in entities)
            {
                var groupDto = _mapper.Map<GetGroupsByUserDto>(entity);
                groups.Add(groupDto);
            }
            return await Result<List<GetGroupsByUserDto>>.SuccessAsync(groups);
        }
    }
}
