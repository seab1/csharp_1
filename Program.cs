using System;
using System.Collections.Generic;
using System.Diagnostics;

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
            ifYouAreBored();

            //Classes();
            //Collections();
            //Sort();
            //Tables();
            //ConditionsAndLoops();
            //Calculator();
            Console.ReadKey();
        }

        private static void ifYouAreBored()
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

            int option = menu();
            action(ref table, sizeAsString, option);
        }

        static void binarySearch(int[] table, object key)
        {
            int result = Array.BinarySearch(table, key);

            if (result < 0)
            {
                Console.WriteLine("Szukany element " + "({0}) nie wystepuje w tablicy", key);
            }

            else
            {
                Console.WriteLine("Szukany element " + "({0}) posiada indeks {1}", key, result);
            }
        }

        private static void quicksort(ref int[] table, int left, int right)
        {
            var i = left;
            var j = right;
            var pivot = table[(left + right) / 2];
            while (i < j)
            {
                while (table[i] < pivot) i++;
                while (table[j] > pivot) j--;
                if (i <= j)
                {
                    var tmp = table[i];
                    table[i++] = table[j];
                    table[j--] = tmp;
                }
            }
            if (left < j) quicksort(ref table, left, j);
            if (i < right) quicksort(ref table, i, right);
        }

        private static void action(ref int[] table, string sizeAsString, int option)
        {
            Console.WriteLine();

            switch(option)
            {
                case 1:
                    bubbleSort(ref table, sizeAsString);
                    Console.WriteLine("Tablica posortowana:");
                    writeTable(ref table);
                    break;

                case 2:
                    insertSort(ref table, sizeAsString);
                    Console.WriteLine("Tablica posortowana:");
                    writeTable(ref table);
                    break;

                case 3:
                    selectionSort(ref table, sizeAsString);
                    Console.WriteLine("Tablica posortowana:");
                    writeTable(ref table);
                    break;

                case 4:
                    quicksort(ref table, 0, int.Parse(sizeAsString) - 1);
                    Console.WriteLine("Tablica posortowana:");
                    writeTable(ref table);
                    break;

                case 5:
                    Stopwatch timer_bubble = new Stopwatch();
                    Stopwatch timer_insert = new Stopwatch();
                    Stopwatch timer_selection = new Stopwatch();
                    Stopwatch timer_quick = new Stopwatch();

                    timer_bubble.Start();
                    bubbleSort(ref table, sizeAsString);
                    timer_bubble.Stop();
                    Console.WriteLine($"Czas wykonania algorytmu bubble sort to: {timer_bubble.ElapsedMilliseconds / 1000}");
                    Console.WriteLine();

                    timer_insert.Start();
                    insertSort(ref table, sizeAsString);
                    timer_insert.Stop();
                    Console.WriteLine($"Czas wykonania algorytmu insert sort to: {timer_insert.ElapsedMilliseconds / 1000}");
                    Console.WriteLine();

                    timer_selection.Start();
                    selectionSort(ref table, sizeAsString);
                    timer_selection.Stop();
                    Console.WriteLine($"Czas wykonania algorytmu selection sort to: {timer_selection.ElapsedMilliseconds / 1000}");
                    Console.WriteLine();

                    timer_quick.Start();
                    quicksort(ref table, 0, int.Parse(sizeAsString) - 1);
                    timer_quick.Stop();
                    Console.WriteLine($"Czas wykonania algorytmu quicksort to: {timer_quick.ElapsedMilliseconds / 1000}");
                    Console.WriteLine();

                    quicksort(ref table, 0, int.Parse(sizeAsString) - 1);
                    Console.WriteLine("Tablica posortowana:");
                    writeTable(ref table);
                    break;

                case 6:
                    Console.Write("Podaj liczbe, ktora chcesz wyszukac w tablicy, program znajdzie jej pierwsze wystapienie: ");
                    try
                    {
                        int key = int.Parse(Console.ReadLine());
                        binarySearch(table, key);
                    }
                    catch
                    {
                        Console.WriteLine("Podana wartosc jest nieprawidlowa!");
                    }
                    break;

                case 7:
                    Console.WriteLine("Konczenie pracy programu");
                    break;

                default:
                    Console.WriteLine("Wybrana akcja nie istnieje!");
                    break;
            }
        }

        private static int menu()
        {
            Console.WriteLine("Wybierz akcje:");
            Console.WriteLine("1) Bubble sort");
            Console.WriteLine("2) Insert sort");
            Console.WriteLine("3) Selection Sort");
            Console.WriteLine("4) Quicksort");
            Console.WriteLine("5) Wszystkie sortowania wraz z czasem dzialania algorytmow");
            Console.WriteLine("6) Wyszukiwanie binarne");
            Console.WriteLine("7) Wyjdz");

            Console.Write("Twoj wybor: ");

           try
            {
                int choice = int.Parse(Console.ReadLine());
                return choice;
            }
            catch
            {
                Console.WriteLine("Nieprawidlowe wprowadzenie!");
                return 7;
            }
        }

        private static void selectionSort(ref int[] table, string sizeAsString)
        {
            int size = int.Parse(sizeAsString);
            int holder, minValue;

            try
            {
                for (int i = 0; i < size - 1; i++)
                {
                    minValue = i;
                    for (int j = i + 1; j < size; j++) if (table[j] < table[minValue]) minValue = j;
                    holder = table[minValue];
                    table[minValue] = table[i];
                    table[i] = holder;
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Program napotkal nieistniejacy element! Awaryjne konczenie pracy!");
            }
        }

        private static void insertSort(ref int[] table, string sizeAsString)
        {
            int size = int.Parse(sizeAsString);
            int flag, value;

            try
            {
                for (int i = 1; i < size; i++)
                {
                    value = table[i];
                    flag = 0;
                    for (int j = i - 1; j >= 0 && flag != 1;)
                    {
                        if (value < table[j])
                        {
                            table[j + 1] = table[j];
                            j--;
                            table[j + 1] = value;
                        }
                        else flag = 1;
                    }
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Program napotkal nieistniejacy element! Awaryjne konczenie pracy!");
            }
        }

        private static void Classes()
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
