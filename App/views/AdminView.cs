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
            Console.WriteLine("1. Profile");
            Console.WriteLine("2. Create Employee");
            Console.WriteLine("3. Show Employees");
            Console.WriteLine("4. Search Employee");
            Console.WriteLine("5. Logout");
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
                        CreateEmployee();
                        break;
                    case 3:
                        ShowEmployees();
                        break;
                    case 4:
                        SearchEmployee();
                        break;
                    case 5:
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
            Console.WriteLine($"ID : {Data.Session["signin"].Id}");
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
            Console.Write("Username : ");
            string username = Console.ReadLine();
            Console.Write("Password : ");
            string password = Console.ReadLine();
            User profileEdited = default;


            profileEdited = new User(fullname, username, password, user.Salary, user.Type);


            bool updated = UserModel.Update(profileEdited, previousData: user);

            if (updated)
            {
                Console.WriteLine("Successfully updated profile");
                Data.Session["signin"] = user;
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

        public static void ShowEmployees()
        {
            Console.Clear();
            Console.WriteLine("*** Employee List ***");
            List<User> employees = UserModel.FindAllEmployees();

            if (employees.Count > 0)
            {
                foreach (User employee in employees)
                {
                    Console.WriteLine("***************");
                    Console.WriteLine("ID        : {0}", employee.Id);
                    Console.WriteLine("Fullname  : {0}", employee.Fullname);
                    Console.WriteLine("Username  : {0}", employee.Username);
                    Console.WriteLine("Salary    : {0}", employee.Salary);
                    Console.WriteLine("***************");
                }

                Console.WriteLine("\n\n");
                Console.WriteLine("Menu : ");
                Console.WriteLine("1. Edit User");
                Console.WriteLine("2. Delete User");
                Console.WriteLine("3. Back");
                Console.WriteLine("***************");
                Console.Write("Choice : ");

                try
                {
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            RequestEmployeeIdForEdit();
                            break;
                        case 2:
                            RequestEmployeeIdForDelete();
                            break;
                        case 3:
                            Dashboard();
                            break;
                        default:

                            Console.WriteLine("Invalid input!!!");
                            Console.ReadKey();
                            ShowEmployees();
                            break;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid input!!!");
                    Console.ReadKey();
                    ShowEmployees();
                }

            }
            else
            {
                Console.WriteLine("Employee data is empty!!!");
                Console.ReadKey();
                Dashboard();
            }


        }

        public static void RequestEmployeeIdForEdit()
        {
            Console.Clear();
            Console.Write("Enter id employee : ");
            int id = default;
            try
            {
                id = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid input!!!");
                Console.ReadKey();
                ShowEmployees();
            }

            List<User> user = UserModel.FindUser(id);

            if (user.Count == 0)
            {
                Console.WriteLine("User not found!!!");
                Console.ReadKey();
                ShowEmployees();
            }
            else
            {
                EditEmployee(user[0]);
            }

        }


        public static void EditEmployee(User user)
        {
            Console.Clear();

            Console.WriteLine("Previous Employee Profile : ");
            Console.WriteLine("Fullname : {0}", user.Fullname);
            Console.WriteLine("Username : {0}", user.Username);
            Console.WriteLine("Password : {0}", user.Password);
            Console.WriteLine("Salary : {0}", user.Salary);

            Console.Write("\n\n*** Form Edit Employee ***\n");
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
                EditEmployee(user);
            }

            User userEdited = new User(fullname, username, password, salary, "employee");

            bool updated = UserModel.Update(userEdited, previousData: user);

            if (updated)
            {
                Console.WriteLine("Successfully updated employee profile");
                Console.ReadKey();
                ShowEmployees();
            }
            else
            {
                Data.PrintErrorMessage();
                Console.ReadKey();
                ShowEmployees();
            }

        }

        public static void RequestEmployeeIdForDelete()
        {
            Console.Clear();
            Console.Write("Enter id employee : ");
            int id = default;
            try
            {
                id = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid input!!!");
                Console.ReadKey();
                ShowEmployees();
            }

            // id with value 0 is admin
            if (id == 0)
            {
                Console.WriteLine("You cannot deleted this data!!!");
                Console.ReadKey();
                ShowEmployees();
            }

            List<User> user = UserModel.FindUser(id);

            if (user.Count == 0)
            {
                Console.WriteLine("User not found!!!");
                Console.ReadKey();
                ShowEmployees();
            }
            else
            {
                bool deleted = UserModel.Delete(user[0].Id);

                if (deleted)
                {
                    Console.WriteLine("Successfully to deleted employee data.");
                    Console.ReadKey();
                    ShowEmployees();
                }
                else
                {
                    Console.WriteLine("Something error");
                    Console.ReadKey();
                    ShowEmployees();
                }
            }

        }

        public static void SearchEmployee()
        {
            Console.Clear();
            Console.WriteLine("*** Search employee by fullname ***");
            Console.Write("\nEnter keyword : ");
            string fullname = Console.ReadLine();

            List<User> employees = UserModel.SearchEmployeeByFullname(fullname);

            Console.WriteLine("\nSearch Result :");
            if (employees.Count > 0)
            {
                employees.ForEach(employee =>
                {
                    Console.WriteLine("***************");
                    Console.WriteLine("ID        : {0}", employee.Id);
                    Console.WriteLine("Fullname  : {0}", employee.Fullname);
                    Console.WriteLine("Username  : {0}", employee.Username);
                    Console.WriteLine("Salary    : {0}", employee.Salary);
                    Console.WriteLine("***************");
                });

                Console.ReadKey();
                Dashboard();
            }
            else
            {
                Console.WriteLine("Employee not found!!!");
                Console.ReadKey();
                Dashboard();
            }
        }


    }
}
