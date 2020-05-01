using System;
using System.Collections;
using System.Collections.Generic;

namespace SebastianSuwalaHelloWorld
{
    class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Species { get; set; }

        public virtual void move() { Console.WriteLine("Mkne i hasam!"); }

        public override string ToString()
        {
            return $"Bonjour, jestem {Name}, moj wiek to: {Age}, zas gatunek: {Species}";
        }
    }

    class Fish : Animal { public override void move() { Console.WriteLine("Bul bul bul"); } }
    class Dog : Animal { public override void move() { Console.WriteLine("<Bieg> hau hau"); } }

    class Program
    {
        static void Main(string[] args)
        {
            Animal fluffyHorse = new Animal { Name = "Basiur", Age = 2, Species = "Kon" };
            Console.WriteLine(fluffyHorse);
            fluffyHorse.move();
            Console.WriteLine();

            Fish fish1 = new Fish { Name = "Nemo", Age = 1, Species = "Blazenek" };
            Console.WriteLine(fish1);
            fish1.move();
            Console.WriteLine();

            Animal fish2 = new Fish { Name = "Dziwny twor", Age = 8, Species = "Ryba z lapami?" };
            Console.WriteLine(fish2);
            fish2.move();
            Console.WriteLine();

            Dog piesel = new Dog { Name = "Dyzio", Age = 5, Species = "Mops" };
            Console.WriteLine(piesel);
            piesel.move();

            //Collections();
            //Sort();
            //Tables();
            //ConditionsAndLoops();
            //Calculator();
            Console.ReadKey();
        }

        private static void Collections()
        {
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();

            for (int i = 1; i < 11; i++)
            {
                Console.WriteLine($"Podaj {i} liczbe listy:");
                try
                {
                    int givenNumber = int.Parse(Console.ReadLine());
                    list1.Add(givenNumber);
                }
                catch
                {
                    Console.WriteLine("Podano nieprawidlowy element! Awaryjne konczenie pracy!");
                }
            }

            Console.WriteLine("Lista pierwsza przed modyfikacja:");
            writeList(list1);
            Console.WriteLine();
            Console.WriteLine("Lista druga przed modyfikacja:");
            Console.WriteLine("<Pusta>");
            Console.WriteLine();

            Console.WriteLine("Z listy pierwszej zostana usuniete wszystkie liczby mniejsze od 2, pozostale zostana skopiowane do listy drugiej");
            Console.WriteLine();

            for (int i = list1.Count - 1; i >= 0; i--)
            {
                if (list1[i] < 2) list1.RemoveAt(i);
                else list2.Add(list1[i]);
            }

            Console.WriteLine("Lista pierwsza po modyfikacji:");
            writeList(list1);
            Console.WriteLine();
            Console.WriteLine("Lista druga po modyfikacji:");
            writeList(list2);
            Console.WriteLine();
        }

        private static void writeList(List<int> list)
        {
            foreach (int number in list)
            {
                Console.Write($"{number} ");
            }
        }

        private static void Sort()
        {
            Console.WriteLine("Podaj rozmiar tablicy:");
            string sizeAsString = Console.ReadLine();
            Console.WriteLine("Podaj maksymalna wartosc jaka moze byc przechowywana w komorkach tablicy:");
            string maxValueAsString = Console.ReadLine();

            int[] table = null;

            generateTable(ref table, sizeAsString, maxValueAsString);
            Console.WriteLine("Tablica nieposortowana:");
            writeTable(ref table);

            Console.WriteLine();
            bubbleSort(ref table, sizeAsString);

            Console.WriteLine("Tablica posortowana:");
            writeTable(ref table);
        }

        private static void writeTable(ref int[] table)
        {
            foreach (int number in table)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine();
        }

        private static void bubbleSort(ref int[] table, string sizeAsString)
        {
            try
            {
                int holder;
                int size = int.Parse(sizeAsString);

                for (int i = 0; i < size; i++)
                    for (int j = 0; j < size - i - 1; j++)
                        if (table[j] > table[j + 1])
                        {
                            holder = table[j];
                            table[j] = table[j + 1];
                            table[j + 1] = holder;
                        }
            }
            catch(NullReferenceException)
            {
                Console.WriteLine("Program napotkal nieistniejacy element! Awaryjne konczenie pracy!");
            }
        }

        private static int[] generateTable(ref int[] table, string sizeAsString, string maxValueAsString)
        {
            int[] zeroTable = { 0 };

            try
            {
                int size = int.Parse(sizeAsString);
                int maxValue = int.Parse(maxValueAsString);
                Random randomNumber = new Random();

                if (size > 0)
                {
                    table = new int[size];
                    for (int i = 0; i < size; i++)
                    {
                        table[i] = randomNumber.Next(maxValue) + 1;
                    }

                    return table;
                }
                else Console.WriteLine("Rozmiar tablicy musi byc wiekszy od 0!");

                return zeroTable;
            }
            catch
            {
                Console.WriteLine("Co najmniej jedna z podanych wartosci jest nieprawidlowa!");
                return zeroTable;
            }
        }

        private static void Tables()
        {
            Console.WriteLine("Podaj rozmiar tablicy:");
            string sizeAsString = Console.ReadLine();
            Console.WriteLine("Podaj maksymalna wartosc jaka moze byc przechowywana w komorkach tablicy:");
            string maxValueAsString = Console.ReadLine();

            try
            {
                int size = int.Parse(sizeAsString);
                int maxValue = int.Parse(maxValueAsString);
                Random randomNumber = new Random();

                if (size > 0)
                {
                    int[] someNumbers = new int[size];
                    for (int i = 0; i < size; i++)
                    {
                        someNumbers[i] = randomNumber.Next(maxValue) + 1;
                    }

                    foreach (int number in someNumbers)
                    {
                        Console.Write($"{number} ");
                    }
                    Console.WriteLine();
                }
                else Console.WriteLine("Rozmiar tablicy musi byc wiekszy od 0!");
            }
            catch
            {
                Console.WriteLine("Co najmniej jedna z podanych wartosci jest nieprawidlowa!");
            }
        }

        private static void ConditionsAndLoops()
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

        private static double silnia(double number)
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
