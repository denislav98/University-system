using System;

namespace UserLoginn
{
    class Program
    {
        public static void ShowActionErrorMessage(string errorMsg)
        {
            Console.WriteLine("!!! " + errorMsg + " !!!");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();
            User user = new User();

            LoginValidation loginValidation = new LoginValidation(username, password, ShowActionErrorMessage);

            if (loginValidation.ValidateUserInput(ref user))
            {
                Console.WriteLine(user.ToString());
                // Console.WriteLine(LoginValidation.currentUserRole);
                UserRole role = LoginValidation.currentUserRole;

                switch (user.role)
                {
                    case 1:
                        {
                            Console.WriteLine("Current User Role is : " + UserRole.ANONYMOUS);
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Current User Role is : " + UserRole.ADMIN);
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Current User Role is : " + UserRole.INSPECTOR);
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Current User Role is : " + UserRole.PROFESSOR);
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Current User Role is : " + UserRole.STUDENT);
                            break;
                        }
                }
            }
        }
    }
}