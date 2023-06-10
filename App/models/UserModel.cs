namespace App.models
{
    class UserModel
    {
        public bool Create()
        {
            return false;
        }
        public List<User> FindAllEmployees()
        {
            return new List<User>();
        }

        public static List<User> FindUser(string username, string password)
        {
            List<User> user = Data.Users.Where(user => user.Username == username && user.Password == password).ToList();
            return user;
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
