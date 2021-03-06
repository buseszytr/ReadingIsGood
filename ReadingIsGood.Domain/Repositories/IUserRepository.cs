using ReadingIsGood.Domain.Models;

namespace ReadingIsGood.Domain.Repositories
{
    public interface IUserRepository
    {
        void AddUser(User user);
        void SaveToken(string userId, string token);
        User FindByEmailandPassword(string email, string password);
        User FindById(int userId);
    }
}
