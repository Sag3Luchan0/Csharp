using System;

class Program
{
    static void Main()
    {
        double x1 = 16.0;
        double x2 = -5.0;
        double x3 = 0.0;

        int errorCode1, errorCode2, errorCode3;
        double? result1 = CalculateSquareRoot(x1, out errorCode1);
        double? result2 = CalculateSquareRoot(x2, out errorCode2);
        double? result3 = CalculateSquareRoot(x3, out errorCode3);

        Console.WriteLine($"Result for {x1}: {result1}, Error Code: {errorCode1}");
        Console.WriteLine($"Result for {x2}: {result2}, Error Code: {errorCode2}");
        Console.WriteLine($"Result for {x3}: {result3}, Error Code: {errorCode3}");
    }

    static double? CalculateSquareRoot(double x, out int errorCode)
    {
        if (x < 0)
        {
            errorCode = -1;
            return null; // Неможливо обчислити корінь для від'ємного числа
        }

        double epsilon = 1e-10; // Точність обчислення
        double guess = 1.0; // Початкове наближення

        while (true)
        {
            double nextGuess = 0.5 * (guess + x / guess);
            if (Math.Abs(nextGuess - guess) < epsilon)
            {
                errorCode = 0; // Обчислення успішно завершено
                return nextGuess;
            }
            guess = nextGuess;
        }
    }
}
