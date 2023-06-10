using App.models;

namespace App.views
{
    class AdminView
    {
        public static void Dashboard()
        {
            Console.Clear();
            Console.WriteLine("***** Welcome {0} *****", Data.Session["signin"].Fullname);
            Console.WriteLine("Main Menu : ");
            Console.WriteLine("1. Create Employee");
            Console.WriteLine("2. Show Employees");
            Console.WriteLine("3. Search Employee");
            Console.WriteLine("4. Logout");
            Console.WriteLine("***********************");
            Console.Write("Choice : ");
            try
            {
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        CreateEmployee();
                        break;
                    case 2:

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

        public static void CreateEmployee()
        {
            Console.Clear();
            Console.WriteLine("*** Form Create New Employee ***");
            Console.Write("Fullname : ");
            string fullname = Console.ReadLine();
            Console.Write("Username : ");
            string username = Console.ReadLine();
            Console.Write("Password : ");
            string password = Console.ReadLine();
            Console.Write("Salary : ");
            double salary = default;
            try
            {
                salary = double.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid salary input!!!");
                Console.ReadKey();
                CreateEmployee();
            }

            bool created = UserModel.Create(fullname, username, password, salary);

            if (created)
            {
                Console.WriteLine("Successfully created new employee");
                Console.ReadKey();
                Dashboard();
            }
            else
            {
                Data.PrintErrorMessage();
                Console.ReadKey();
                Dashboard();
            }


        }
    }
}
