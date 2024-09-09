using MainApp.Models;

namespace MainApp.Services;
/*
// fields
private string _fieldNAme;

// Properties 
public string PropertyName { get; set; }

// Methods
public void MethodName()
{

}

public static string MethodName_2(string inputParameter)
{
    return inputParameter;
}

public void MethodName_3(string inputParameter, string outputParameter)
{
    outputParameter = "";
}

// Constructor
public MenuService()
{
    _fieldNAme = null!;
    PropertyName = null!;
}

public MenuService(string fieldName, string propertName)
{
    _fieldNAme = fieldName;
    PropertyName =propertName;
}
*/

internal static class MenuService
{
    private static readonly UserService _userService = new UserService();

    private static void CreateUsersMenu()
    {
        var user = new User();

        Console.Clear();
        Console.WriteLine("-- CREATE NEW USER --");

        Console.Write("Enter firstname: ");
        user.FirstName = Console.ReadLine() ?? "";

        Console.Write("Enter lastname: ");
        user.LastName = Console.ReadLine() ?? "";

        Console.Write("Enter email: ");
        user.Email = Console.ReadLine() ?? "";

        Console.Write("Enter phonenumber: ");
        user.PhoneNumber = Console.ReadLine() ?? "";

        var response = _userService.CreateUser(user);
        Console.WriteLine(response.Message);
    }

    private static void ListAllUsersMenu()
    {
        Console.Clear();
        Console.WriteLine("-- USER LIST --");

        var users = _userService.GetAllUsers();
        if (users != null)
        {
            foreach (var user in users)
            {
                Console.WriteLine($"{user.FirstName} {user.LastName} <{user.Email}>");
            }
        }
        else
        {
            Console.WriteLine("No users was found.");
        }
    }

    private static void ExitApplicationMenu()
    {
        Console.Clear();
        Console.Write("Are you sure ypu want to exit? (y/n) ");
        var answer = Console.ReadLine() ?? "n";
        if (answer.ToLower() == "y")
        Environment.Exit(0);
    }

    public static void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("1. Create New User");
        Console.WriteLine("2. List All User");
        Console.WriteLine("0. Exit");

        Console.Write("Enter an option: ");

        if (int.TryParse(Console.ReadLine(), out int option)) // om det är sant (int) gör det som är i if-satsen
        {
            switch (option)
            {
                case 1:
                    CreateUsersMenu();
                    Console.ReadKey();
                    break;

                case 2:
                    ListAllUsersMenu();
                    Console.ReadKey();
                    break;

                case 0:
                    ExitApplicationMenu();
                    break;

                default:
                    Console.WriteLine("Invalide option selected.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}