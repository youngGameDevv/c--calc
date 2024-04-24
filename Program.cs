using System;
using System.Threading;

class Program
{
    static double a = 0.0;
    static double b = 0.0;
    static int x = 0;
    static int z = 0;
    static int operationNumber = 0;
    static bool loop = true;
    static string result = "";

    static void Main(string[] args)
    {
        while (loop)
        {
            Console.Clear();
            PrintMenu();
            if (int.TryParse(Console.ReadLine(), out operationNumber))
            {
                switch (operationNumber)
                {
                    case 1:
                        ShowResultDouble("wybrano dodawanie podaj 2 liczby rzeczywiste:", "wynik dodawania = ");
                        break;

                    case 2:
                        ShowResultDouble("wybrano odejmowanie  podaj 2 liczby rzeczywiste:", "wynik odejmowania  = ");
                        break;

                    case 3:
                        ShowResultDouble("wybrano mnozenie  podaj 2 liczby rzeczywiste:", "wynik mnozenia  = ");
                        break;

                    case 4:
                        ShowResultDouble("wybrano dzielenie  podaj 2 liczby rzeczywiste:", "wynik dzielenia  = ");
                        break;

                    case 5:
                        ShowResultInt("wybrano potegowanie pod pierw podstawe potem wykladnik", "wynik potegowania = ");
                        break;

                    case 6:
                        CalculateResult("podaj liczbe z ktorej ma byc policzona silnia", "wynik = ");
                        break;

                    case 7:
                        CalculateResult("podaj liczbe do zmiany na system dwojkowy ", "wynik = ", 2);
                        break;

                    case 8:
                        CalculateResult("podaj liczbe do zmiany na system osemkowy ", "wynik = ", 8);
                        break;

                    case 9:
                        CalculateResult("podaj liczbe do zmiany na system szesnastkowy ", "wynik = ", 16);
                        break;

                    case 10:
                        loop = false;
                        Console.WriteLine("dowidzenia!");
                        break;

                    default:
                        Console.WriteLine("podano nieobslugiwana liczbe!");
                        WaitOnMenu();
                        break;
                }
            }
            else
            {
                BadData();
                WaitOnMenu();
            }
            Console.Clear();
        }
    }

    static void PrintMenu()
    {
        Console.WriteLine("Witaj w moim kalkulatorze!");
        Console.WriteLine("wpisz typ operacji:");
        Console.WriteLine("dodwanie - 1");
        Console.WriteLine("odejmowanie - 2");
        Console.WriteLine("mnozenie - 3");
        Console.WriteLine("dzielenie - 4");
        Console.WriteLine("potegowanie - 5");
        Console.WriteLine("silnia - 6");
        Console.WriteLine("zmiana na system binarny - 7");
        Console.WriteLine("zmiana na system oktalny - 8");
        Console.WriteLine("zmiana na system heksadycemalny - 9");
        Console.WriteLine("wyjscie z programu  - 10");
    }

    static void BadData()
    {
        Console.WriteLine("podano nieprawidlowa wartosc!" + Environment.NewLine + "sprobuj ponownie:");
        Console.ReadLine();
    }

    static void WaitOnMenu()
    {
        for (int i = 7; i != 0; i--)
        {
            Console.WriteLine("program przejdzie do menu za: " + i);
            Thread.Sleep(1000);
        }
    }

    static void ShowResultDouble(string textOne, string textLast)
    {
        Console.WriteLine(textOne);
        while (true)
        {
            if (double.TryParse(Console.ReadLine(), out a) && double.TryParse(Console.ReadLine(), out b))
            {
                Console.Write(textLast);
                switch (operationNumber)
                {
                    case 1:
                        Console.WriteLine(a + b);
                        break;

                    case 2:
                        Console.WriteLine(a - b);
                        break;

                    case 3:
                        Console.WriteLine(a * b);
                        break;

                    case 4:
                        Console.WriteLine(a / b);
                        break;
                }
                WaitOnMenu();
                break;
            }
            else
            {
                BadData();
                continue;
            }
        }
    }

    static void ShowResultInt(string textOne, string textLast)
    {
        Console.WriteLine(textOne);
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out x) && int.TryParse(Console.ReadLine(), out z))
            {
                Console.WriteLine(textLast);
                switch (operationNumber)
                {
                    case 5:
                        Console.WriteLine(Math.Pow(x, z));
                        break;
                }
                WaitOnMenu();
                break;
            }
            else
            {
                BadData();
                continue;
            }
        }
    }

    static void CalculateSystem(int num, int system)
    {
        result = ""; // reseting data after last usage 
        if (system == 2 || system == 8)
        {
            while (num > 0)
            {
                switch (system)
                {
                    case 2:
                        result += (num % system).ToString();
                        break;

                    case 8:
                        result = (num % system) + result;
                        break;
                }
                num = num / system;
            }
        }
        else
        {
            while (num != 0)
            {
                int s = num % 16;
                if (s < 10)
                    result += ((char)(s + 48)).ToString(); // asci table 
                else
                    result += ((char)(s + 55)).ToString(); // asci table 
                num = num / 16;
            }
            char[] arr = result.ToCharArray();
            Array.Reverse(arr);
            result = new string(arr);
        }
        Console.WriteLine(result);
    }

    static int Silnia(int s)
    {
        if (s == 0)
            return 1;
        int w = Silnia(s - 1) * s;
        return w;
    }

    static void CalculateResult(string textOne, string textLast, int system = 0)
    {
        Console.WriteLine(textOne);
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine(textLast);
                switch (operationNumber)
                {
                    case 6:
                        Console.WriteLine(Silnia(x));
                        break;

                    case 7:
                        CalculateSystem(x, 2);
                        break;

                    case 8:
                        CalculateSystem(x, 8);
                        break;

                    case 9:
                        CalculateSystem(x, 16);
                        break;
                }
                WaitOnMenu();
                break;
            }
            else
            {
                BadData();
                continue;
            }
        }
    }
}
