using System;

namespace UserLoginn
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter username: ");
            String username = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            String password = Console.ReadLine();
            User user = new User();

            LoginValidation loginValidation = new LoginValidation(username, password);

            if (loginValidation.ValidateUserInput(user))
            {
                Console.WriteLine(user.ToString());
                Console.WriteLine(LoginValidation.currentUserRole);
            }
        }
    }
}
