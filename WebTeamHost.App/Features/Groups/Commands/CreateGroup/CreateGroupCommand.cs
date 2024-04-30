using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using WebTeamHost.App.Common.Mappings;
using WebTeamHost.App.Interfaces.Repositories;
using WebTeamHost.Domain.Entities;
using WebTeamHost.Shared;

namespace WebTeamHost.App.Features.Groups.Commands.CreateGroup
{
    public class CreateGroupCommand : IRequest<Result<int>>, IMapFrom<Group>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string AddUserId { get; set; }
        public User OwnerUser { get; set; }

    }

    public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGroupRepository _repository;
        private readonly IMapper _mapper;

        public CreateGroupCommandHandler(IUnitOfWork unitOfWork, IGroupRepository groupRepository, IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _repository = groupRepository;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            //var hasGroup = await _userGroupRepository.HasGroupUserWithUser(request.OwnerUser.Id, request.AddUserId);
            //Console.WriteLine(hasGroup);
            //Console.WriteLine("-------------------");
            //return await Result<int>.FailureAsync();
            var group = new Group()
            {
                //Id = await _repository.GetAllCount() + 1,
                Name = "Личный",
                Description = "Общайтесь с другом!",
                UserId = request.OwnerUser.Id,
                User = request.OwnerUser,
                CreatedDate = DateTime.UtcNow
            };

            await _unitOfWork.Repository<Group>().AddAsync(group);
            group.AddDomainEvent(new GroupCreatedEvent(group));
            await _unitOfWork.Save(cancellationToken);
            var result = await Result<int>.SuccessAsync(group.Id, "Group Created.");
            if (result.Succeeded)
            {
                var userGroup1 = new UserGroup()
                {
                    UserId = request.OwnerUser.Id,
                    Group = group,
                    GroupId = group.Id
                };
                await _unitOfWork.Repository<UserGroup>().AddAsync(userGroup1);
                await _unitOfWork.Save(cancellationToken);
                result = await Result<int>.SuccessAsync(userGroup1.Id, "UserGroup Created.");
                if (!result.Succeeded)
                    return await Result<int>.FailureAsync();
                var userGroup2 = new UserGroup()
                {
                    UserId = request.AddUserId,
                    Group = group,
                    GroupId = group.Id
                };
                await _unitOfWork.Repository<UserGroup>().AddAsync(userGroup2);
                await _unitOfWork.Save(cancellationToken);
                return await Result<int>.SuccessAsync(userGroup2.Id, "UserGroup Created.");
            }
            return await Result<int>.FailureAsync();
        }
    }
}
