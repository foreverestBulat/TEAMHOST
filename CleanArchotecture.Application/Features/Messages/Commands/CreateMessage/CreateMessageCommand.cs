using AutoMapper;
using MediatR;
using WebTeamHost.Application.Common.Mappings;
using WebTeamHost.Application.Interfaces.Repositories;
using WebTeamHost.Domain.Entities;
using WebTeamHost.Shared;

namespace WebTeamHost.Application.Features.Messages.Commands.CreateMessage
{
    public class CreateMessageCommand : IRequest<Result<int>>, IMapFrom<Message>
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public string Text { get; set; }
    }

    internal class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateMessageCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var message = new Message()
            {
                UserId = request.UserId,
                GroupId = request.GroupId,
                Text = request.Text,
                CreatedDate = DateTime.UtcNow,
            };

            await _unitOfWork.Repository<Message>().AddAsync(message);
            message.AddDomainEvent(new MessageCreatedEvent(message));
            await _unitOfWork.Save(cancellationToken);
            return await Result<int>.SuccessAsync(message.Id, $"Message User: {request.UserId} Created!");
        }
    }
}
