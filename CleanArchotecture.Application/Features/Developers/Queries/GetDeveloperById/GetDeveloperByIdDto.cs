using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTeamHost.Application.Common.Mappings;
using WebTeamHost.Domain.Entities;

namespace WebTeamHost.Application.Features.Developers.Queries.GetDeveloperById
{
    public class GetDeveloperByIdDto : IMapFrom<Developer>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        //public List<Game>? Games { get; set; }
    }
}
