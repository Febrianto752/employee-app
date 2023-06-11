using App.models;

namespace App.views
{
    class GeneralView
    {
        static public void HomePage()
        {
            Console.Clear();
            Console.WriteLine("**** Home Page ****");
            Console.WriteLine("1. SignIn");
            Console.WriteLine("2. Exit");
            Console.WriteLine("*******************");
            Console.Write("Choice : ");
            try
            {
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        SignIn();
                        break;
                    case 2:
                        Environment.Exit(0);
                        break;
                    default:

                        Console.WriteLine("Invalid input!!!");
                        Console.ReadKey();
                        HomePage();
                        break;
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Invalid input!!!");
                Console.ReadKey();
                HomePage();
            }
        }

        public static void SignIn()
        {
            Console.Clear();
            Data.Session.Clear();

            Console.WriteLine("**** SignIn ****");
            try
            {
                Console.Write("Username : ");
                string username = Console.ReadLine();
                Console.Write("Password : ");
                string password = Console.ReadLine();

                List<User> user = UserModel.FindUser(username, password);

                if (user.Count < 1)
                {
                    Console.WriteLine("Username or Password is wrong!!!");
                    Console.ReadKey();
                    SignIn();
                }

                Data.Session.Add("signin", user[0]);

                if (user[0].Type == "admin")
                {
                    AdminView.Dashboard();
                }
                else
                {
                    EmployeeView.Dashboard();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
