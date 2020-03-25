using System;

namespace ConsoleFinalExam
{
    public class Program
    {
        public static bool IsNumberHasMoreThanThreePrimesNumbers(int number)
        {
            var result = false;
            var counter = 1;
            Console.WriteLine($"1 is a prime factor by default");

            for (int i = 2; number > 1; i++)
            {
                if (number % i == 0)
                {
                    var x = 0;
                    while (number % i == 0)
                    {
                        number /= i;
                        x++;
                    }

                    Console.WriteLine($"{i} is a prime factor {x} times!");
                    counter++;
                }
                
            }

            if (counter > 2)
            {
                result = true;
            }
            return result;
        }

        public static void Main(string[] args) { }
    }
}
