using FormApplication.Models;

namespace FormApplication.Services
{
    public interface IUserService
    {
        UserModel GetUser(int Id);
    }
}
