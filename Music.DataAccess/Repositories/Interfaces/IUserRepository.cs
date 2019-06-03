using Music.DataAccess.Entities;
using System.Threading.Tasks;

namespace Music.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUser(string login, string password);
    }
}
