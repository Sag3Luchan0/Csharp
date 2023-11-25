using System;

public class Program
{
    public static void Main()
    {
        int a = 18;
        int b = 24;

        Console.WriteLine($"Початкові значення: a = {a}, b = {b}");

        CalculateGCD(ref a, ref b);

        Console.WriteLine($"Найбільший спільний дільник: {a}");

        int c = 56;
        int d = 48;

        Console.WriteLine($"Початкові значення: c = {c}, d = {d}");

        CalculateGCD(ref c, ref d);

        Console.WriteLine($"Найбільший спільний дільник: {c}");
    }

    public static void CalculateGCD(ref int a, ref int b)
    {
        while (b != 0)
        {
            int remainder = a % b;
            a = b;
            b = remainder;
        }
    }
}