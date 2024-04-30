//using AutoMapper;
//using MediatR;

//using WebTeamHost.Application.Interfaces.Repositories;
//using WebTeamHost.Shared;
//using WebTeamHost.Domain.Entities;
//using WebTeamHost.Application.Common.Mappings;

//namespace WebTeamHost.Application.Features.Games.Commands.CreateGame
//{
//    public record CreatePlayerCommand : IRequest<Result<int>>, IMapFrom<Game>
//    {
//        public string Name { get; set; }
//        public int ShirtNo { get; set; }
//        public string PhotoUrl { get; set; }
//        public DateTime? BirthDate { get; set; }
//    }

//    internal class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, Result<int>>
//    {
//        private readonly IUnitOfWork _unitOfWork;
//        private readonly IMapper _mapper;

//        public CreatePlayerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
//        {
//            _unitOfWork = unitOfWork;
//            _mapper = mapper;
//        }

//        public async Task<Result<int>> Handle(CreatePlayerCommand command, CancellationToken cancellationToken)
//        {
//            var player = new Game()
//            {
//                Name = command.Name,
//                ShirtNo = command.ShirtNo,
//                PhotoUrl = command.PhotoUrl,
//                BirthDate = command.BirthDate
//            };

//            await _unitOfWork.Repository<Player>().AddAsync(player);
//            player.AddDomainEvent(new PlayerCreatedEvent(player));

//            await _unitOfWork.Save(cancellationToken);

//            return await Result<int>.SuccessAsync(player.Id, "Player Created.");
//        }
//    }
//}