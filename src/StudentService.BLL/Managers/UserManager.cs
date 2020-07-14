using StudentService.BLL.Interfaces;
using StudentService.DAL.Models;
using StudentService.DAL.Repositories;
using System.Linq;

namespace StudentService.BLL.Managers
{
    public class UserManager : IUserManager
    {
        private readonly UserContext _userDb;

        public UserManager(UserContext userDb)
        {
            this._userDb = userDb;
        }

        public User Verify (User user)
        {
            return _userDb.Users
                .FirstOrDefault(u => (u.UserName == user.UserName) &&
                                    (u.Password == user.Password));
        }
    }
}
