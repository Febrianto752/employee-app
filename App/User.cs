namespace App
{

    class User
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public double Salary { get; set; }
        public string Type { get; set; }

        public User(string fullname, string username, string password, double salary, string type)
        {
            this.Id = Data.AutoIncrementId;
            Data.AutoIncrementId++;

            this.Fullname = fullname;
            this.Username = username;
            this.Password = password;
            this.Salary = salary;
            this.Type = type;
        }
    }




}
