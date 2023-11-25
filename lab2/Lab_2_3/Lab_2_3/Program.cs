using System;

public class Complex
{
    private double real;
    private double imaginary;

    public Complex(double real, double imaginary)
    {
        this.real = real;
        this.imaginary = imaginary;
    }

    public static Complex operator +(Complex c1, Complex c2)
    {
        double realSum = c1.real + c2.real;
        double imaginarySum = c1.imaginary + c2.imaginary;
        return new Complex(realSum, imaginarySum);
    }

    public static Complex operator -(Complex c1, Complex c2)
    {
        double realDiff = c1.real - c2.real;
        double imaginaryDiff = c1.imaginary - c2.imaginary;
        return new Complex(realDiff, imaginaryDiff);
    }

    public static Complex operator *(Complex c1, Complex c2)
    {
        double realProd = c1.real * c2.real - c1.imaginary * c2.imaginary;
        double imaginaryProd = c1.real * c2.imaginary + c1.imaginary * c2.real;
        return new Complex(realProd, imaginaryProd);
    }

    public static Complex operator /(Complex c1, Complex c2)
    {
        double denominator = c2.real * c2.real + c2.imaginary * c2.imaginary;
        double realQuotient = (c1.real * c2.real + c1.imaginary * c2.imaginary) / denominator;
        double imaginaryQuotient = (c1.imaginary * c2.real - c1.real * c2.imaginary) / denominator;
        return new Complex(realQuotient, imaginaryQuotient);
    }

    public static implicit operator string(Complex c)
    {
        return $"{c.real} + {c.imaginary}i";
    }
}
class Program
{
    static void Main(string[] args)
    {
        Complex c1 = new Complex(1, 2);
        Complex c2 = new Complex(3, 4);

        Complex sum = c1 + c2;
        Complex difference = c1 - c2;
        Complex product = c1 * c2;
        Complex quotient = c1 / c2;

        Console.WriteLine("Sum: " + sum);
        Console.WriteLine("Difference: " + difference);
        Console.WriteLine("Product: " + product);
        Console.WriteLine("Quotient: " + quotient);

        // Приклад неявного приведення до типу string
        string complexString = c1;
        Console.WriteLine("Complex as string: " + complexString);
    }
}