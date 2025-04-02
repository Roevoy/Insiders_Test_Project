using Insiders_Test_Project.Models;

namespace Insiders_Test_Project.DataProviders.Interfaces
{
    public interface IUserDataProvider
    {
        bool DeleteUser(Guid Id);
        ICollection<User> GetAllUsers();
        User GetUserById(Guid Id);
        bool InsertUser(User user);
        bool UpdateUser(Guid Id, User newUser);
    }
}