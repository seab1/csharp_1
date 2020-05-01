using System;

namespace SebastianSuwalaHelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //Conditions();
            //Calculator();
            Console.ReadKey();
        }

        private static void Conditions()
        {
            string ifToContinue = null;

            do
            {
                Calculator();

                Console.WriteLine("Kontynuowac? (t/n):");
                ifToContinue = Console.ReadLine();

                if (ifToContinue != "n" && ifToContinue != "N" && ifToContinue != "t" && ifToContinue != "T")
                {
                    Console.WriteLine("Nie powiedziales nie... zatem kontynuuje");
                    Console.WriteLine();
                }
            } while (ifToContinue != "n" && ifToContinue != "N");
        }

        public static double silnia(double number)
        {
            if (number > 1) return number * silnia(number - 1);
            else return 1;
        }

        private static void Calculator()
        {
            Console.WriteLine("Podaj pierwsza liczbe:");
            string number1AsString = Console.ReadLine();
            Console.WriteLine("Podaj druga liczbe:");
            string number2AsString = Console.ReadLine();
            Console.WriteLine("Podaj znak/dzialanie (+, -, *, /, silnia):");
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

                    case "silnia":
                        Console.WriteLine($"Silnia bedzie obliczona dla liczby {number1}");
                        if(number1AsString.Contains(","))
                        {
                            number1 = Math.Truncate(number1);
                            Console.WriteLine($"Liczba {number1AsString} zostala sprowadzona do liczby calkowitej: {number1}");
                        }
                        Console.WriteLine($"{number1}! = {silnia(number1)}");
                        break;

                    default:
                        Console.WriteLine("Nieprawidlowy znak/dzialanie!");
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
