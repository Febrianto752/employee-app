using App.utils;

namespace App.models
{
    class UserModel
    {
        public static bool Create(string fullname, string username, string password, double salary = 0)
        {
            bool validFullname = Validation.FullnameIsValid(fullname);
            bool validUsername = Validation.UsernameIsValid(username);
            bool validPassword = Validation.PasswordIsValid(password);
            bool usernameIsExist = false;
            List<User> user = FindUser(username);

            if (user.Count > 0)
            {
                usernameIsExist = true;
                Data.ErrorMessage.Add("Username already exist");
            }

            if (validFullname && validUsername && validPassword && !usernameIsExist)
            {
                User newUser = new User(fullname, username, password, salary, "employee");
                Data.Users.Add(newUser);

                return true;
            }
            else
            {
                return false;
            }
        }


        public static List<User> FindUser(string username, string password)
        {
            List<User> user = Data.Users.Where(user => user.Username == username && user.Password == password).ToList();
            return user;
        }

        public static List<User> FindUser(string username)
        {
            List<User> user = Data.Users.Where(user => user.Username == username).ToList();
            return user;
        }

        public static List<User> FindUser(int id)
        {
            List<User> user = Data.Users.Where(user => user.Id == id).ToList();
            return user;
        }

        public static List<User> FindAllEmployees()
        {
            List<User> employees = Data.Users.Where(user => user.Type == "employee").ToList();
            return employees;
        }



        public static bool Update(User userEdited, User previousData)
        {
            bool validFullname = Validation.FullnameIsValid(userEdited.Fullname);
            bool validUsername = Validation.UsernameIsValid(userEdited.Username);

            bool usernameIsExist = false;
            if (userEdited.Username != previousData.Username)
            {
                List<User> user = FindUser(userEdited.Username);

                if (user.Count > 0)
                {
                    usernameIsExist = true;
                    Data.ErrorMessage.Add("Username already exist");
                }
            }

            bool validPassword = Validation.PasswordIsValid(userEdited.Password);

            if (validFullname && validUsername && validPassword && !usernameIsExist)
            {
                // update object previous user
                previousData.Fullname = userEdited.Fullname;
                previousData.Username = userEdited.Username;
                previousData.Password = userEdited.Password;
                previousData.Salary = userEdited.Salary;

                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool Delete(int id)
        {
            int index = Data.Users.FindIndex(user => user.Id == id);
            Data.Users.RemoveAt(index);
            return true;
        }

        public static List<User> SearchEmployeeByFullname(string fullname)
        {
            List<User> employees = Data.Users.Where(user => user.Fullname.ToLower().Contains(fullname.ToLower()) && user.Type == "employee").ToList();
            return employees;
        }
    }
}
