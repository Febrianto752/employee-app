namespace App
{

    class Program
    {
        static List<int> ListNumber = new List<int>() { 1, 2, 3, 4 };
        static void SetList(List<int> list)
        {
            list[1] = 100;
        }
        static void Main(string[] args)
        {
            List<int> listNumber = new List<int>() { 1, 2, 3, 4, 4, 4 };

            SetList(listNumber);
            //Console.WriteLine(String.Join(",", listNumber));

            Console.WriteLine(listNumber.Find(number => number == 4));

        }
    }
}
