using System;

public struct Point3D
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    public Point3D(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public double DistanceToOrigin()
    {
        return Math.Sqrt(X * X + Y * Y + Z * Z);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Point3D point = new Point3D(3, 4, 5);
        double distance = point.DistanceToOrigin();

        Console.WriteLine("Point: (" + point.X + ", " + point.Y + ", " + point.Z + ")");
        Console.WriteLine("Distance to origin: " + distance);
    }
}