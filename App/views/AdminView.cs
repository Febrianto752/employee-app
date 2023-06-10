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
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:

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
    }
}
