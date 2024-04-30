using AutoMapper;
using MediatR;
using WebTeamHost.App.Interfaces.Repositories;
using WebTeamHost.Shared;

namespace WebTeamHost.App.Features.UsersInfo.Queries.GetUserInfoById
{
    public class GetUserInfoByUserQuery : IRequest<Result<GetUserInfoByUserDto>>
    {
        public string UserId { get; set; }

        public GetUserInfoByUserQuery() { }
        public GetUserInfoByUserQuery(string userId)
        {
            UserId = userId;
        }
    }

    internal class GetUserInfoByUserQueryHandler : IRequestHandler<GetUserInfoByUserQuery, Result<GetUserInfoByUserDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IMapper _mapper;

        public GetUserInfoByUserQueryHandler(IUnitOfWork unitOfWork, IUserInfoRepository userInfoRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userInfoRepository = userInfoRepository;
            _mapper = mapper;
        }

        public async Task<Result<GetUserInfoByUserDto>> Handle(GetUserInfoByUserQuery query, CancellationToken cancellationToken)
        {
            //var entity = await _unitOfWork.Repository<UserInfo>().Entities
            //    .ProjectTo<GetUserInfoByUserDto>(_mapper.ConfigurationProvider)
            //    .ToListAsync(cancellationToken);
            //return await Result<List<GetUserInfoByUserDto>>.SuccessAsync(entity);
            var entity = await _userInfoRepository.GetUserInfoByUserAsync(query.UserId);
            if (entity is null)
                return await Result<GetUserInfoByUserDto>.FailureAsync();
            var userInfo = _mapper.Map<GetUserInfoByUserDto>(entity);
            return await Result<GetUserInfoByUserDto>.SuccessAsync(userInfo);
        }
    }
}
