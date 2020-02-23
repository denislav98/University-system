using System;

namespace UserLoginn
{
    class Program
    {
        public static void ShowActionErrorMessage(string errorMsg)
        {
            Console.WriteLine("!!! " + errorMsg + " !!!");
        }
        static void Main()
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

                switch (user.Role)
                {
                    case 1:
                        {
                            Console.WriteLine("Current User Role is : " + UserRole.ANONYMOUS);
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Current User Role is : " + UserRole.ADMIN);
                            bool showMenu = true;
                            while (showMenu)
                            {
                                showMenu = AdminMenu(user);
                            }
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
        private static bool AdminMenu(User user)
        {
            //Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("0: Exit");
            Console.WriteLine("1: Change User role");
            Console.WriteLine("2: Change User activity");
            Console.Write("\r\nSelect an option: ");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: return false;

                case 1:
                    PrintAllUserRoles();
                    Console.WriteLine("Enter new User Role: ");
                    int userOptionForRole = int.Parse(Console.ReadLine());
                    if (Enum.IsDefined(typeof(UserRole), userOptionForRole))
                    {
                        UserRole newRole = (UserRole)userOptionForRole;
                        UserData.AssignUserRole(user.Username, newRole);
                    }
                    Console.WriteLine(user.Username + " " + user.Role);
                    return true;
                case 2:
                    Console.WriteLine("Enter new valid to Date: ");
                    string newDate = Console.ReadLine();  // "01.01.2020 00:00:00";
                    DateTime dt = DateTime.Parse(newDate);
                    UserData.SetUserActiveTo(user.Username, dt);
                    Console.WriteLine(user.ToString());
                    return true;
                default:
                    return true;
            }
        }

        private static void PrintAllUserRoles()
        {
            var roles = Enum.GetValues(typeof(UserRole));
            int roleCounter = 0;
            foreach (UserRole role in roles)
            {
                Console.WriteLine(roleCounter + " " + role);
                roleCounter++;
            }
        }
    }
}