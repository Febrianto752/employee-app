namespace App.utils
{
    class Mathematic
    {
        public static string EvenOddNumberCheck(string strBilangan)
        {
            int intBilangan = int.Parse(strBilangan);

            if (intBilangan % 2 == 0)
            {
                return "Genap";
            }
            else
            {
                return "Ganjil";
            }
        }

        public static int[] GenerateEvenNumber(int limit)
        {
            int totalNumber = limit / 2;
            int[] evenNumbers = new int[totalNumber];

            int number = 2;
            for (int i = 0; i < totalNumber; i++)
            {
                evenNumbers[i] = number;
                number += 2;
            }

            return evenNumbers;
        }

        public static void PrintEvenNumberToLimit(int limit)
        {
            Console.WriteLine($"Print bilangan 1 - {limit} : ");
            var evenNumbers = GenerateEvenNumber(limit);
            Console.WriteLine(String.Join(",", evenNumbers));
        }

        public static int[] GenerateOddNumber(int limit)
        {
            int totalNumber = (limit / 2) + 1;
            int[] oddNumbers = new int[totalNumber];

            int number = 1;
            for (int i = 0; i < totalNumber; i++)
            {
                oddNumbers[i] = number;
                number += 2;
            }

            return oddNumbers;
        }

        public static void PrintOddNumberToLimit(int limit)
        {
            Console.WriteLine($"Print bilangan 1 - {limit} : ");
            var oddNumbers = GenerateOddNumber(limit);
            Console.WriteLine(String.Join(",", oddNumbers));
        }
    }
}
