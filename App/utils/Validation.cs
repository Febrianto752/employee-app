namespace App.utils
{
    class Validation
    {
        public static bool PasswordIsValid(string password)
        {
            if (password.Length > 7 && password.Any<char>(new Func<char, bool>(char.IsUpper)) && password.Any<char>(new Func<char, bool>(char.IsLower)) && password.Any<char>(new Func<char, bool>(char.IsNumber)))
            {
                return true;
            }
            else
            {
                Data.ErrorMessage.Add("Password must have at least 8 characters with at least one Capital letter, at least one lower case letter and at least one number.");
                return false;
            }
        }

        public static bool FullnameIsValid(string fullname)
        {
            if (fullname.Length > 2)
            {
                return true;
            }
            else
            {
                Data.ErrorMessage.Add("Fullname must have at least 3 characters");
                return false;
            }

        }

        public static bool UsernameIsValid(string username)
        {
            if (username.Length > 4)
            {
                return true;
            }
            else
            {
                Data.ErrorMessage.Add("Username must have at least 5 characters");
                return false;
            }

        }
    }
}
