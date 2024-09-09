using MainApp.Models;
using System.Diagnostics;

namespace MainApp.Services;

public class UserService
{
    private List<User> _users = [];

    public ServiceResponse CreateUser(User user)
    {
        try
        {
            if (string.IsNullOrEmpty(user.Email))
                return new ServiceResponse { Succeeded = false, Message = "No email was provided."};

            if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName))
                return new ServiceResponse { Succeeded = false, Message = "Firstname and lastname must be provided." };

            if (_users.Any(x => x.Email == user.Email))
                return new ServiceResponse { Succeeded = false, Message = "User with same email already exist." };

            _users.Add(user);
            return new ServiceResponse { Succeeded = false, Message = "User was created." };
        }

        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return new ServiceResponse { Succeeded = false, Message = ex.Message };
        }
    }

    public IEnumerable<User> GetAllUsers() //IEnumerable = skickar tillbaka en lista som inte går att ändra
    {
        try //alltid en try catch om vi ska utföra någon handling
        {
            return _users;
        }

        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        return null!;
    }
}
