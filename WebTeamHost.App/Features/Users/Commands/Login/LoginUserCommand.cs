using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTeamHost.App.Common.Mappings;
using WebTeamHost.Shared.Interfaces;

namespace WebTeamHost.App.Features.Users.Commands.Login
{
    public class LoginUserCommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
