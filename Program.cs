using System;
using System.Collections.Generic;

namespace UserLoginn
{
    class Program
    {
        
    public static void ShowActionErrorMessage(string errorMsg)
        {
            Console.WriteLine("!!! " + errorMsg + " !!!");
        }
        public static void Main()
        {

            var users =UserData.TestUsers;
            

            if (LoginValidation.AreLoginAtemptsExceededInThreeMinutes())
            {
                Logger.LogActivity("You can not login anymore.Max tries exceeded");
                Logs currentLoggerActivity = Logger.GetCurrentSessionActivities();
                Console.WriteLine(currentLoggerActivity);
                return;
            }

            Console.WriteLine("Enter username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();
            User user = new User();

            LoginValidation loginValidation = new LoginValidation(username, password, ShowActionErrorMessage);


            if (loginValidation.ValidateUserInput(ref user))
            {
                Console.WriteLine(user.ToString());
                UserRole role = LoginValidation.currentUserRole;

                switch (user.Role)
                {
                    case UserRole.ANONYMOUS:
                        {
                            Console.WriteLine("Current User Role is : " + UserRole.ANONYMOUS);
                            break;
                        }
                    case UserRole.ADMIN:
                        {
                            Console.WriteLine("Current User Role is : " + UserRole.ADMIN);
                            bool showMenu = true;
                            while (showMenu)
                            {
                                showMenu = AdminMenu(user);
                            }
                            break;
                        }
                    case UserRole.INSPECTOR:
                        {
                            Console.WriteLine("Current User Role is : " + UserRole.INSPECTOR);
                            break;
                        }
                    case UserRole.PROFESSOR:
                        {
                            Console.WriteLine("Current User Role is : " + UserRole.PROFESSOR);
                            break;
                        }
                    case UserRole.STUDENT:
                        {
                            Console.WriteLine("Current User Role is : " + UserRole.STUDENT);
                            break;
                        }
                }
            }
            else
            {
                Logger.LogActivity("Failed to login at =" + DateTime.Now);
                bool isUserFailedToLogin = LoginValidation.AreLoginAtemptsExceededInThreeMinutes();
                if (isUserFailedToLogin)
                {
                    Console.WriteLine("Max login try exceeded in 3 minutes.Now you can`t login anymore");
                    return;
                }
            }
        }
        private static bool AdminMenu(User user)
        {
            Console.WriteLine();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("0: Exit");
            Console.WriteLine("1: Change User role");
            Console.WriteLine("2: Change User activity");
            Console.WriteLine("3: List all Users");
            Console.WriteLine("4: Show log file");
            Console.WriteLine("5: Show current log activity");
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
                        UserData.AssignUserRole(user.UserId, newRole);
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
                case 3:
                    // TODO
                    return true;
                case 4:
                    List<string> loggs = Logger.ReadLoggFileContent();
                    loggs.ForEach(Console.WriteLine);
                    return true;
                case 5:
                    Logs currentLogActivity = Logger.GetCurrentSessionActivities();
                    Console.WriteLine(currentLogActivity);
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