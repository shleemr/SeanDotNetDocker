//[User][4]
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SeanDotNetDocker.DataAccess;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SeanDotNetDocker.Models.User
{
    public class UserRepository : IUserRepository
    {
        private IConfiguration _config;
        private IdentityContext _db;
        private SqlConnection con;

        public UserRepository(IConfiguration config, IdentityContext db)
        {
            _config = config;
            _db = db;
        }

        /// <summary>
        /// 회원 가입
        /// </summary>
        public async Task AddUserAsync(UserModel user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// 특정 회원 정보
        /// </summary>
        public async Task<UserModel> GetUserByUserIdAsync(string email)
        {
            return await _db.Users.Where(u => u.Email.Equals(email)).FirstOrDefaultAsync();
        }


        /// <summary>
        /// 회원 정보 수정
        /// </summary>
        public async Task ModifyUserAsync(UserModel user)
        {
            _db.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// 아이디와 암호가 동일한 사용자면 참(true) 그렇지 않으면 거짓
        /// </summary>
        public async Task<bool> IsCorrectUserAsync(string email, string password)
        {
            var user = await GetUserByUserIdAsync(email);

            if (user.Email.Equals(email) && user.Password.Equals(password))
                return true;

            return false;
        }
    }
}
