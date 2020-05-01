using System;

namespace SebastianSuwalaHelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj liczbe calkowita:");

            try
            {
                int userValue = int.Parse(Console.ReadLine());
                Console.WriteLine($"Twoja liczba to: {userValue}");
            }
            catch
            {
                Console.WriteLine("Nie podano prawidlowej wartosci!");
            }
            Console.ReadKey();
        }
    }
}
