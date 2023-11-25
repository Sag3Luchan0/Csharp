using System;

public class Vector
{
    private double[] elements;

    public Vector(params double[] elements)
    {
        this.elements = elements;
    }

    public static Vector operator +(Vector v1, Vector v2)
    {
        if (v1.elements.Length != v2.elements.Length)
            throw new ArgumentException("Vectors must have the same length");

        double[] sumElements = new double[v1.elements.Length];
        for (int i = 0; i < v1.elements.Length; i++)
        {
            sumElements[i] = v1.elements[i] + v2.elements[i];
        }

        return new Vector(sumElements);
    }

    public static Vector operator -(Vector v1, Vector v2)
    {
        if (v1.elements.Length != v2.elements.Length)
            throw new ArgumentException("Vectors must have the same length");

        double[] diffElements = new double[v1.elements.Length];
        for (int i = 0; i < v1.elements.Length; i++)
        {
            diffElements[i] = v1.elements[i] - v2.elements[i];
        }

        return new Vector(diffElements);
    }

    public static Vector operator *(Vector v, double scalar)
    {
        double[] prodElements = new double[v.elements.Length];
        for (int i = 0; i < v.elements.Length; i++)
        {
            prodElements[i] = v.elements[i] * scalar;
        }

        return new Vector(prodElements);
    }

    public static double operator *(Vector v1, Vector v2)
    {
        if (v1.elements.Length != v2.elements.Length)
            throw new ArgumentException("Vectors must have the same length");

        double dotProduct = 0;
        for (int i = 0; i < v1.elements.Length; i++)
        {
            dotProduct += v1.elements[i] * v2.elements[i];
        }

        return dotProduct;
    }

    public static Vector operator /(Vector v, double scalar)
    {
        if (scalar == 0)
            throw new ArgumentException("Scalar cannot be zero");

        double[] divElements = new double[v.elements.Length];
        for (int i = 0; i < v.elements.Length; i++)
        {
            divElements[i] = v.elements[i] / scalar;
        }

        return new Vector(divElements);
    }

    public override string ToString()
    {
        return string.Format("({0})", string.Join(", ", elements));
    }
}

class Program
{
    static void Main(string[] args)
    {
        Vector v1 = new Vector(1, 2, 3);
        Vector v2 = new Vector(4, 5, 6);
        Vector v3 = new Vector(2, 4, 6);

        Vector sum = v1 + v2;
        Vector difference = v1 - v2;
        Vector scalarProduct = v1 * 2.5;
        double dotProduct = v1 * v3;
        Vector scalarDivision = v2 / 3;

        Console.WriteLine("v1: " + v1);                     // Виведе: v1: (1, 2, 3)
        Console.WriteLine("v2: " + v2);                     // Виведе: v2: (4, 5, 6)
        Console.WriteLine("Sum: " + sum);                   // Виведе: Sum: (5, 7, 9)
        Console.WriteLine("Difference: " + difference);     // Виведе: Difference: (-3, -3, -3)
        Console.WriteLine("Scalar product: " + scalarProduct);       // Виведе: Scalar product: (2.5, 5, 7.5)
        Console.WriteLine("Dot product: " + dotProduct);     // Виведе: Dot product: 28
        Console.WriteLine("Scalar division: " + scalarDivision);     // Виведе: Scalar division: (1.33333333333333, 1.66666666666667, 2)
    }
}