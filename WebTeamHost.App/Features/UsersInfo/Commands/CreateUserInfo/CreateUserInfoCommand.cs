using AutoMapper;
using MediatR;
using System.Numerics;
using WebTeamHost.App.Common.Mappings;
using WebTeamHost.App.Features.UsersInfo.Queries.GetUserInfoById;
using WebTeamHost.App.Interfaces.Repositories;
using WebTeamHost.Domain.Entities;
using WebTeamHost.Shared;

namespace WebTeamHost.App.Features.UsersInfo.Commands.CreateUserInfo
{
    public record CreateUserInfoCommand : IRequest<Result<int>>, IMapFrom<UserInfo>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string About { get; set; }
        public DateOnly? Birthday { get; set; }
        public Country? Country { get; set; }
        public int? CountryId { get; set; }
        public string UserId { get; set; }

        public CreateUserInfoCommand() { }

        public CreateUserInfoCommand(GetUserInfoByUserDto request)
        {
            FirstName = request.FirstName;
            LastName = request.LastName;
            About = request.About;
            CountryId = request.CountryId;
            Birthday = request.BirthDay;
            //UserId = request.UserId1;
        }
    }

    public class CreateUserInfoCommandHandler : IRequestHandler<CreateUserInfoCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateUserInfoCommand request, CancellationToken cancellationToken)
        {
            var userInfo = new UserInfo()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                About = request.About,
                Birthday = request.Birthday,
                Country = request.Country,
                CountryId = request.CountryId,
                UserId = request.UserId
            };

            await _unitOfWork.Repository<UserInfo>().AddAsync(userInfo);
            userInfo.AddDomainEvent(new UserInfoCreatedEvent(userInfo));
            await _unitOfWork.Save(cancellationToken);
            return await Result<int>.SuccessAsync(userInfo.Id, "UserInfo Created.");
        }
    }
}
