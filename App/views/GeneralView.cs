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
            Console.Write("Pilihan : ");
            try
            {
                int pilihan = int.Parse(Console.ReadLine());
                switch (pilihan)
                {
                    case 1:
                        Console.WriteLine("login");
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

        //static void SignIn()
        //{
        //    Console.WriteLine("**** SignIn ****");
        //    Console.Write("Username : ");
        //    Console.ReadLine();
        //    Console.Write("Password : ");
        //    Console.ReadLine();
        //}
    }
}
