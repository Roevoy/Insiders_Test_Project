using FluentValidation;
using Insiders_Test_Project.DataProviders.Interfaces;
using Insiders_Test_Project.Managers.Validators;
using Insiders_Test_Project.Models;

namespace Insiders_Test_Project.Managers
{
    public class UserManager
    {
        private readonly IUserDataProvider _userDataProvider;
        private readonly UserValidator _userValidator;
        public UserManager (IUserDataProvider userDataProvider, UserValidator userValidator)
        {
            _userValidator = userValidator;
            _userDataProvider = userDataProvider;
        }
        public Guid CreateUser(string Name, string Email, string Password) 
        {
            User user = new User()
            {
                Id = Guid.NewGuid(),
                Name = Name,
                Email = Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(Password)
            };
            _userValidator.ValidateAndThrow(user);
            _userDataProvider.InsertUser(user);
            return user.Id;
        }
        public bool DeleteUser(Guid UserId)
        {
            return _userDataProvider.DeleteUser(UserId);
        }
        public User GetUser (Guid Id)
        {
            return _userDataProvider.GetUserById(Id);
        }
        public ICollection<User> GetAllUsers()
        {
            return _userDataProvider.GetAllUsers();
        }
        public bool Updateuser(Guid UserId, User user)
        {
            //_userValidator.ValidateAndThrow(user);
            return _userDataProvider.UpdateUser(UserId, user);
        }

    }
}
