using System;
using System.Collections.Generic;
using System.Text;
using Music.DataAccess.Entities;
using Music.DataAccess.Repositories.Impementations;
using Music.DataAccess.Repositories.Interfaces;

namespace Music.DataAccess.Repositories.Implementations
{
    public class AlbumRepository : GenericRepository<Album>, IAlbumRepository
    {
        public AlbumRepository(MusicDbContext dbContext)
            : base(dbContext, nameof(Album))
        {
        }
    }
}
