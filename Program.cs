using System;

namespace SebastianSuwalaHelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj liczbe calkowita:");
            int userValue = int.Parse(Console.ReadLine());
            Console.WriteLine($"Twoja liczba to: {userValue}");
            Console.ReadKey();
        }
    }
}
