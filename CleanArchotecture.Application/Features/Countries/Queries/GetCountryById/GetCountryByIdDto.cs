using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTeamHost.Application.Common.Mappings;
using WebTeamHost.Domain.Entities;

namespace WebTeamHost.Application.Features.Countries.Queries.GetCountryById
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
