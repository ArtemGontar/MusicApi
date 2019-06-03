using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using Music.DataAccess.Entities;
using Music.DataAccess.Repositories.Impementations;
using Music.DataAccess.Repositories.Interfaces;

namespace Music.DataAccess.Repositories.Implementations
{
    public class GroupRepository : GenericRepository<Group>, IGroupRepository
    {
        public GroupRepository(IOptions<Settings> settings)
            : base(settings, nameof(Group))
        {

        }
    }
}
