using AutoMapper;
using MediatR;
using WebTeamHost.App.Features.UserGroups.Queries.GetGroupsByUser;
using WebTeamHost.App.Interfaces.Repositories;
using WebTeamHost.Shared;

namespace WebTeamHost.App.Features.Messages.Queries.GetMessagesByGroup
{
    public class GetMessagesByGroupQuery : IRequest<Result<List<GetMessagesByGroupDto>>>
    {
        public int GroupId { get; set; }

        public GetMessagesByGroupQuery() { }

        public GetMessagesByGroupQuery(int groupId)
        {
            GroupId = groupId;
        }
    }

    internal class GetMessagesByGroupQueryHandler : IRequestHandler<GetMessagesByGroupQuery, Result<List<GetMessagesByGroupDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public GetMessagesByGroupQueryHandler(IUnitOfWork unitOfWork, IMessageRepository messageRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<GetMessagesByGroupDto>>> Handle(GetMessagesByGroupQuery request, CancellationToken cancellationToken)
        {
            var entities = await _messageRepository.GetListMessageByGroupAsync(request.GroupId);
            if (entities.Count() > 0)
            {
                //var messages = new List<GetMessagesByGroupDto>();
                //foreach (var entity in entities)
                //{
                //    var messageDto = _mapper.Map<GetMessagesByGroupDto>(entity);
                //    messages.Add(messageDto);
                //}
                var messages = _mapper.Map<List<GetMessagesByGroupDto>>(entities);
                return await Result<List<GetMessagesByGroupDto>>.SuccessAsync(messages);
            }
            return await Result<List<GetMessagesByGroupDto>>.FailureAsync();

            //var entities = await _userGroupRepository.GetGroupsByUserAsync(request.UserId);
            //var groups = new List<GetGroupsByUserDto>();
            //foreach (var entity in entities)
            //{
            //    var groupDto = _mapper.Map<GetGroupsByUserDto>(entity);
            //    groups.Add(groupDto);
            //}
            //return await Result<List<GetGroupsByUserDto>>.SuccessAsync(groups);
        }
    }
}
