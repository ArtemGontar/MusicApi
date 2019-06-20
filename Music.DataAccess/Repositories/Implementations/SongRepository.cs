using Microsoft.Extensions.Options;
using Music.DataAccess.Entities;
using Music.DataAccess.Repositories.Impementations;
using Music.DataAccess.Repositories.Interfaces;

namespace Music.DataAccess.Repositories.Implementations
{
    public class SongRepository : GenericRepository<Song>, ISongRepository
    {
        public SongRepository(IOptions<Settings> settings)
            : base(settings, "songs")
        {

        }
    }
}
