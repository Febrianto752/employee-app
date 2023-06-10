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

        public List<User> FindAllEmployees()
        {
            return new List<User>();
        }

        public List<User> GetProfile()
        {
            return new List<User>();
        }

        public void Update()
        {

        }

        public bool Delete()
        {
            return false;
        }
    }
}
