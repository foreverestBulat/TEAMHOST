using WebTeamHost.Application.Common.Mappings;
using WebTeamHost.Domain.Entities;

namespace WebTeamHost.Application.Features.Games.Queries.GetAllGames
{
    public class GetAllGamesDto : IMapFrom<Game>
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public float Price { get; init; }
        public string Images { get; init; }
        public string Description { get; init; }
        public string Rating { get; init; }
        public DateTime DateReleased { get; init; }
        public int DeveloperId { get; init; }
        public int CreatedBy { get; init; }
        public DateTime CreatedDate { get; init; }
        public int UpdatedBy { get; init; }
        public DateTime UpdatedDate { get; init; }
        public int DisplayOrder { get; init; }
        public string MainImage { get; init; }
    }
    
}
