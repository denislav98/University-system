using System;

namespace UserLoginn
{
    class Program
    {
        static void Main(string[] args)
        {
            LoginValidation loginValidation = new LoginValidation();
            if (loginValidation.ValidateUserInput(UserData.TestUser))
            {
                Console.WriteLine(UserData.TestUser.username + " " + UserData.TestUser.password);
                Console.WriteLine(LoginValidation.currentUserRole);
            }
        }
    }
}
