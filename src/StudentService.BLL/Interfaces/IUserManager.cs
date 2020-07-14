using StudentService.DAL.Models;

namespace StudentService.BLL.Interfaces
{
    public interface IUserManager
    {
        User Verify(User user);
    }
}
