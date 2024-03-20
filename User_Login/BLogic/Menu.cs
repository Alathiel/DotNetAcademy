
using User_Login.DataModels.Enums;

namespace User_Login.BLogic.Menu
{
    internal class Menu
    {
        internal static void ShowMainMenu()
        {
            AuthenticationHelper authenticationHelper = new AuthenticationHelper();
            ConsoleKeyInfo menuChoice;
            Dictionary<string, string> items = [];
            do
            {
                Console.Clear();
                Console.WriteLine("MENU LOGIN\n\n");
                Console.WriteLine("A) Login");
                Console.WriteLine("B) SignUp");
                Console.WriteLine("F) Esci\n\n");

                menuChoice = Console.ReadKey();

                switch ((Enums.Menu)menuChoice.Key)
                {
                    case Enums.Menu.Login:

                        if (authenticationHelper.Login())
                            Console.WriteLine("Login Successful.");
                        else
                            Console.WriteLine("Wrong username or password, retry to login.");

                        Console.ReadLine();
                        break;

                    case Enums.Menu.SignUp:

                        if (authenticationHelper.SignUp())
                            Console.WriteLine("Signup successful.");
                        else
                            Console.WriteLine("Signup error.");

                        Console.ReadLine();
                        break;

                }

            } while (menuChoice.Key.ToString() != "F");
        }
    }
}
