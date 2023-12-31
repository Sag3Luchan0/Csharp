﻿using System;

namespace Task2
{
    internal class ArrayDynamic
    {
        public static dynamic Sum(dynamic[] array)
        {
            dynamic sum = 0;

            foreach (var item in array)
            {
                sum += item;
            }

            return sum;
        }

        public static dynamic Average(dynamic[] array)
        {
            return Sum(array) / array.Length;
        }
    }

    internal class Fraction
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public Fraction() { }
        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new Exception("Can't divide by zero!");

            Numerator = numerator;
            Denominator = denominator;
        }

        public override string ToString()
        {
            if (Numerator == 0 || Denominator == 1)
                return Numerator + "";

            return $"{Numerator}/{Denominator}";
        }

        private Fraction Reduce()
        {
            Fraction result = new Fraction(Numerator, Denominator);
            for (int i = 2; i <= result.Numerator && i <= result.Denominator; i++)
            {
                if (result.Numerator % i == 0 && result.Denominator % i == 0)
                {
                    result.Numerator /= i;
                    result.Denominator /= i;
                    i--;
                }
            }
            return result;
        }

        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            return new Fraction
            {
                Numerator = f1.Numerator * f2.Denominator + f2.Numerator * f1.Denominator,
                Denominator = f1.Denominator * f2.Denominator
            }.Reduce();
        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            return new Fraction
            {
                Numerator = f1.Numerator * f2.Denominator - f2.Numerator * f1.Denominator,
                Denominator = f1.Denominator * f2.Denominator
            }.Reduce();
        }

        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            return new Fraction
            {
                Numerator = f1.Numerator * f2.Numerator,
                Denominator = f1.Denominator * f2.Denominator
            }.Reduce();
        }

        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            if (f2.Numerator == 0)
                throw new Exception("Can't divide by zero!");

            return new Fraction
            {
                Numerator = f1.Numerator * f2.Denominator,
                Denominator = f2.Numerator * f1.Denominator
            }.Reduce();
        }

        public static Fraction operator +(int n, Fraction f1)
        {
            Fraction f2 = new Fraction
            {
                Numerator = n,
                Denominator = 1
            }.Reduce();
            return f2 + f1;
        }

        public static Fraction operator /(Fraction f1, int n)
        {
            if (n == 0)
                throw new Exception("Can't divide by zero!");

            Fraction f2 = new Fraction(n, 1);
            return f1 / f2;
        }
    }

    public class Program
    {
        public static void Main()
        {
            dynamic[] array = new dynamic[] { 2.3, 1.9, 8.0 };
            Console.WriteLine("Double array: " + string.Join("  ", array));
            Console.WriteLine("Sum: " + ArrayDynamic.Sum(array));
            Console.WriteLine("Average: " + ArrayDynamic.Average(array));

            Console.WriteLine();

            array = new dynamic[] { new Fraction(1, 2), new Fraction(3, 9), new Fraction(1, 3) };
            Console.WriteLine("Fraction array: " + string.Join("  ", array));
            Console.WriteLine("Sum: " + ArrayDynamic.Sum(array));
            Console.WriteLine("Average: " + ArrayDynamic.Average(array));
        }
    }
}