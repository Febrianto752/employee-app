using App.models;

namespace App.views
{
    class EmployeeView
    {
        public static void Dashboard()
        {
            Console.Clear();
            Console.WriteLine("***** Welcome {0} *****", Data.Session["signin"].Fullname);
            Console.WriteLine("Main Menu : ");
            Console.WriteLine("1. Profile");
            Console.WriteLine("2. Logout");
            Console.WriteLine("***********************");
            Console.Write("Choice : ");
            try
            {
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Profile();
                        break;
                    case 2:
                        GeneralView.HomePage();
                        Data.Session.Clear();
                        break;
                    default:

                        Console.WriteLine("Invalid input!!!");
                        Console.ReadKey();
                        Dashboard();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid input!!!");
                Console.ReadKey();
                Dashboard();
            }
        }

        public static void Profile()
        {
            Console.Clear();
            Console.WriteLine("**** Your Profile ****");
            Console.WriteLine($"Fullname : {Data.Session["signin"].Fullname}");
            Console.WriteLine($"Username : {Data.Session["signin"].Username}");
            Console.WriteLine($"Password : {Data.Session["signin"].Password}");
            Console.WriteLine("***************");
            Console.WriteLine("\n\nMenu : ");
            Console.WriteLine("1. Edit Profile");
            Console.WriteLine("2. Back");
            Console.WriteLine("***************");
            Console.Write("Choice : ");

            try
            {
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        List<User> user = UserModel.FindUser(Data.Session["signin"].Id);
                        EditProfile(user[0]);
                        break;
                    case 2:
                        Dashboard();
                        break;
                    default:
                        Console.WriteLine("Invalid input!!!");
                        Console.ReadKey();
                        Profile();
                        break;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid input!!!");
                Console.ReadKey();
                Dashboard();
            }

        }

        public static void EditProfile(User user)
        {
            Console.Clear();

            Console.WriteLine("Previous Profile Data : ");
            Console.WriteLine("Fullname : {0}", user.Fullname);
            Console.WriteLine("Username : {0}", user.Username);
            Console.WriteLine("Password : {0}", user.Password);

            Console.Write("\n\n*** Form Edit Employee ***\n");
            Console.Write("Fullname : ");
            string fullname = Console.ReadLine();
            Console.Write("Password : ");
            string password = Console.ReadLine();
            User profileEdited = default;

            profileEdited = new User(fullname, user.Username, password, user.Salary, user.Type);

            bool updated = UserModel.Update(profileEdited, previousData: user);

            if (updated)
            {
                Console.WriteLine("Successfully updated profile");
                Console.ReadKey();
                Profile();
            }
            else
            {
                Data.PrintErrorMessage();
                Console.ReadKey();
                Profile();
            }

        }
    }
}
