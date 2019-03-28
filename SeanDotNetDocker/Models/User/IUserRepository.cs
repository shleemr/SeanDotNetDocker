//[User][3]
using System.Threading.Tasks;

namespace SeanDotNetDocker.Models.User
{
    public interface IUserRepository
    {
        Task AddUserAsync(UserModel user);
        Task<UserModel> GetUserByUserIdAsync(string userId);
        Task<bool> IsCorrectUserAsync(string userId, string password);
        Task ModifyUserAsync(UserModel user);
    }
}