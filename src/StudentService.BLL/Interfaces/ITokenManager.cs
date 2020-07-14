using StudentService.DAL.Models;

namespace StudentService.BLL.Interfaces
{
    public interface ITokenManager
    {
        string GenerateAccessToken(User user);
    }
}
