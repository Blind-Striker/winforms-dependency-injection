using FormApplication.Models;

namespace FormApplication.Services
{
    public class UserService : IUserService
    {
        public UserModel GetUser(int Id)
        {
            return new UserModel() { Id = Id, Name = "Anakin Skywalker" };
        }
    }
}
