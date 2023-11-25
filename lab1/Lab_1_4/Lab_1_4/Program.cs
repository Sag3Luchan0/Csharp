using System;

namespace Task_4
{
    class BinaryEq
    {
        public double? x1, x2;
        private double a, b, c;

        public BinaryEq(double x, double y, double z)
        {
            this.a = x;
            this.b = y;
            this.c = z;
        }

        public double? this[int index] // індексатор
        {
            get
            {
                switch (index)
                {
                    case 1: return x1;
                    case 2: return x2;
                    // В іншому випадку - максимальне double
                    default: return Double.MaxValue;
                }
            }
        }

        public void BinaryRoot()
        {
            // дискриминант
            var discriminant = Math.Pow(b, 2) - 4 * a * c;
            if (discriminant < 0)
            {
                Console.WriteLine("Quadratic equation has no roots");
            }
            else
            {
                if (discriminant == 0) // кв. уравнение имеет 2 корня
                {
                    x1 = -b / (2 * a);
                    x2 = x1;
                }
                else // кв. уравнение имеет 2 разных корня
                {
                    x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                    x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                }

                // вывод корней кв. уравнения
                Console.WriteLine($"x1 = {x1}; x2 = {x2}");
            }
        }
    }

    class Test
    {
        static void Main(string[] args)
        {
            Console.WriteLine("First test");
            BinaryEq b = new BinaryEq(2, -5, 2);
            b.BinaryRoot();

            Console.WriteLine("Second test");
            BinaryEq z = new BinaryEq(4, -3, 1);
            z.BinaryRoot();

            Console.WriteLine(b[1]);
            Console.WriteLine(b[2]);
        }
    }
}