﻿using WebTeamHost.Domain.Entities;

namespace WebTeamHost.App.Interfaces.Repositories
{
    public interface IUserGroupRepository
    {
        //Task<List<UserGroup>> HasGroupUserWithUser(string user, string userId);
        Task<List<UserGroup>> GetUserGroupsByUserAsync(string userId);

        Task<List<Group>> GetGroupsByUserAsync(string userId);
    }
}
