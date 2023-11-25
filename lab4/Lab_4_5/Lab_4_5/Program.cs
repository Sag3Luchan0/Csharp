using System;
using System.Collections.Generic;
using System.Linq;

namespace Task6
{
    public static class ListUtils
    {
        public static List<int> GetSquaresLambda(List<int> list)
        {
            return list.FindAll(x => x == Math.Pow(Math.Sqrt(x), 2));
        }

        public static List<int> GetSquaresLinq(List<int> list)
        {
            return list.Where(x => x == Math.Pow(Math.Sqrt(x), 2)).ToList();
        }

        public static void SortByAbsLambda(List<int> list)
        {
            list.Sort((x1, x2) => Math.Abs(x2).CompareTo(Math.Abs(x1)));
        }

        public static void SortByAbsLinq(List<int> list)
        {
            list = list.OrderByDescending(x => Math.Abs(x)).ToList();
        }
    }

    public class Program
    {
        public static void Main()
        {
            List<int> list = new List<int> { -2, 5, 21, -19, 90 };
            Console.WriteLine("Original List: " + string.Join(", ", list));

            List<int> squaresLambda = ListUtils.GetSquaresLambda(list);
            Console.WriteLine("Squares (Lambda): " + string.Join(", ", squaresLambda));

            List<int> squaresLinq = ListUtils.GetSquaresLinq(list);
            Console.WriteLine("Squares (LINQ): " + string.Join(", ", squaresLinq));

            List<int> sortedByAbsLambda = new List<int>(list);
            ListUtils.SortByAbsLambda(sortedByAbsLambda);
            Console.WriteLine("Sorted by Absolute Value (Lambda): " + string.Join(", ", sortedByAbsLambda));

            List<int> sortedByAbsLinq = new List<int>(list);
            ListUtils.SortByAbsLinq(sortedByAbsLinq);
            Console.WriteLine("Sorted by Absolute Value (LINQ): " + string.Join(", ", sortedByAbsLinq));
        }
    }
}