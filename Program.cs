using System;

namespace SebastianSuwalaHelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            string ifToContinue = null;

            do
            {
                Punkt_II();

                Console.WriteLine("Kontynuowac? (t/n):");
                ifToContinue = Console.ReadLine();

                if (ifToContinue != "n" && ifToContinue != "N" && ifToContinue != "t" && ifToContinue != "T")
                {
                    Console.WriteLine("Nie powiedziales nie... zatem kontynuuje");
                    Console.WriteLine();
                }
            } while (ifToContinue != "n" && ifToContinue != "N");

            //Punkt_II();
            Console.ReadKey();
        }

        private static void Punkt_II()
        {
            Console.WriteLine("Podaj pierwsza liczbe:");
            string number1AsString = Console.ReadLine();
            Console.WriteLine("Podaj druga liczbe:");
            string number2AsString = Console.ReadLine();
            Console.WriteLine("Podaj znak (+, -, *, /):");
            string sign = Console.ReadLine();

            try
            {
                double number1 = double.Parse(number1AsString);
                double number2 = double.Parse(number2AsString);

                switch (sign)
                {
                    case "+":
                        Console.WriteLine($"{number1} + {number2} = {number1 + number2}");
                        break;

                    case "-":
                        Console.WriteLine($"{number1} - {number2} = {number1 - number2}");
                        break;

                    case "*":
                        Console.WriteLine($"{number1} * {number2} = {number1 * number2}");
                        break;

                    case "/":
                        Console.WriteLine($"{number1} / {number2} = {number1 / number2}");
                        break;

                    default:
                        Console.WriteLine("Podany znak jest nieprawidlowy!");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Co najmniej jedna z podanych wartosci jest nieprawidlowa!");
            }
        }
    }
}
