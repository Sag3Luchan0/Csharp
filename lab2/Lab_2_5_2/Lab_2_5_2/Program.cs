using System;

public interface IEquationSolver
{
    double Solve(Func<double, double> equation, double start, double end, double step);
}

public class IntervalSolver : IEquationSolver
{
    public double Solve(Func<double, double> equation, double start, double end, double step)
    {
        if (start >= end || step <= 0)
            throw new ArgumentException("Invalid interval or step");

        double x = start;
        double root = double.NaN;

        while (x <= end)
        {
            double y = equation(x);
            if (Math.Sign(y) != Math.Sign(equation(x + step)))
            {
                root = (x + x + step) / 2;
                Console.WriteLine("Root found at x = " + root);
            }

            x += step;
        }

        return root;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Func<double, double> equation = x => x * x - 4; // Приклад рівняння: x^2 - 4 = 0
        double start = -5;
        double end = 5;
        double step = 0.1;

        IEquationSolver solver = new IntervalSolver();
        solver.Solve(equation, start, end, step);
    }
}