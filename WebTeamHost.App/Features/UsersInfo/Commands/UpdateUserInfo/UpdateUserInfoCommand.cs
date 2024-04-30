using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using WebTeamHost.App.Common.Mappings;
using WebTeamHost.App.Features.UsersInfo.Queries.GetUserInfoById;
using WebTeamHost.App.Interfaces.Repositories;
using WebTeamHost.Domain.Entities;
using WebTeamHost.Shared;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebTeamHost.App.Features.UsersInfo.Commands.UpdateUserInfo
{
    public class UpdateUserInfoCommand : IRequest<Result<int>>, IMapFrom<UserInfo>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string About { get; set; }
        public DateOnly? Birthday { get; set; }
        public Country? Country { get; set; }
        public int? CountryId { get; set; }
        public string UserId { get; set; }

        public UpdateUserInfoCommand() { }

        public UpdateUserInfoCommand(GetUserInfoByUserDto request)
        {
            Id = request.Id;
            FirstName = request.FirstName;
            LastName = request.LastName;
            About = request.About;
            CountryId = request.CountryId;
            Birthday = request.BirthDay;
        }

        //public UpdateUserInfoCommand(RequestUserInfo requestUserInfo)
        //{
        //    Id = requestUserInfo.Id;
        //    FirstName = requestUserInfo.FirstName;
        //    LastName = requestUserInfo.LastName;
        //    About = requestUserInfo.About;
        //    Country = requestUserInfo.Country;
        //    CountryId = requestUserInfo.CountryId;
        //    Birthday = requestUserInfo.Birthday;
        //    UserId = requestUserInfo.UserId;
        //}
    }

    public class UpdateUserInfoCommandHandler : IRequestHandler<UpdateUserInfoCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IMapper _mapper;

        public UpdateUserInfoCommandHandler(IUnitOfWork unitOfWork, IUserInfoRepository userInfoRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userInfoRepository = userInfoRepository;
            _mapper = mapper;
        }
        public async Task<Result<int>> Handle(UpdateUserInfoCommand request, CancellationToken cancellationToken)
        {
            var userInfo = await _userInfoRepository.GetUserInfoByUserAsync(request.UserId);
            if (userInfo is not null)
            {
                //userInfo.UserId1 = request.UserId;
                userInfo.FirstName = request.FirstName;
                userInfo.LastName = request.LastName;
                userInfo.About = request.About;
                userInfo.CountryId = request.CountryId;
                userInfo.Birthday = request.Birthday;
                //userInfo.Country = request.Country;
                //userInfo.CreatedDate = DateTime.Now;

                await _unitOfWork.Repository<UserInfo>().UpdateAsync(userInfo);
                userInfo.AddDomainEvent(new UserInfoUpdatedEvent(userInfo));

                await _unitOfWork.Save(cancellationToken);

                return await Result<int>.SuccessAsync(userInfo.Id, "UserInfo Updated");
            }
            else
            {
                return await Result<int>.FailureAsync("UserInfo Not Found.");
            }
        }
    }
}
