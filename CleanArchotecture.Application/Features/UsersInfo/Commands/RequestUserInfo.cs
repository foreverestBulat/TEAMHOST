using MediatR;
using WebTeamHost.Application.Common.Mappings;
using WebTeamHost.Application.Features.UsersInfo.Commands.CreateUserInfo;
using WebTeamHost.Application.Features.UsersInfo.Commands.UpdateUserInfo;
using WebTeamHost.Application.Features.UsersInfo.Queries.GetUserInfoById;
using WebTeamHost.Domain.Entities;
using WebTeamHost.Shared;

namespace WebTeamHost.Application.Features.UsersInfo.Commands
{
    public class RequestUserInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string About { get; set; }
        public DateOnly? Birthday { get; set; }
        public Country? Country { get; set; }
        public int? CountryId { get; set; }
        public string UserId { get; set; }

        public RequestUserInfo(CreateUserInfoCommand request)
        {
            FirstName = request.FirstName;
            LastName = request.LastName;
            About = request.About;
            Country = request.Country;
            CountryId = request.CountryId;
            UserId = request.UserId;
            Birthday = request.Birthday;
        }

        public RequestUserInfo(UpdateUserInfoCommand request) 
        { 
            Id = request.Id;
            FirstName = request.FirstName;
            LastName = request.LastName;
            About = request.About;
            Country = request.Country;
            CountryId = request.CountryId;
            UserId = request.UserId;
            Birthday = request.Birthday;
        }

        public RequestUserInfo(GetUserInfoByUserDto dto)
        {
            Id = dto.Id;
            FirstName = dto.FirstName;
            LastName = dto.LastName;
            About = dto.About;
            CountryId = dto.CountryId;
            UserId = dto.UserId1;
            Birthday = dto.BirthDay;
        }
    }
}
