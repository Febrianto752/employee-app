﻿namespace App
{
    class Data
    {
        // inisialiasi list users dan akun admin
        public static List<User> Users = new List<User>() { new User(fullname: "febrianto", username: "admin", password: "Admin123", salary: 100000, type: "admin") };
        public static int AutoIncrementId = 1;
        public static Dictionary<string, User> Session = new Dictionary<string, User>();
        public static List<string> ErrorMessage = new List<string>();

        public static void PrintErrorMessage()
        {
            Console.WriteLine("\nError Message : ");
            ErrorMessage.ForEach(err => Console.WriteLine(err));
            ErrorMessage.Clear();
        }

    }
}
