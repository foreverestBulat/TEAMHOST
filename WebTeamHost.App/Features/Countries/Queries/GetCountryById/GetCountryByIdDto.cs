using WebTeamHost.App.Common.Mappings;
using WebTeamHost.Domain.Entities;

namespace WebTeamHost.App.Features.Countries.Queries.GetCountryById
{
    public class GetCountryByIdDto : IMapFrom<Country>
    {
        public string? Name { get; set; }
        public int? Code { get; set; }
        public string? FullName { get; set; }
        public string? Alpha2 { get; set; }
        public string? Alpha3 { get; set; }
    }
}
