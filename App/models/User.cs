namespace App.models
{

    abstract class User
    {
        private int id;
        private string fullname;
        private string username;
        private string password;
        private double salary;

    }

    class Admin : User
    {

    }

    class Employee : User
    {

    }


}
