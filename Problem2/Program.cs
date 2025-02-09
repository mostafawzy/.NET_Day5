using System;

// GeoShape, Rectangle, Triangle, Circle classes
class GeoShape
{
    protected double dim1, dim2;

    public GeoShape(double d1, double d2)
    {
        dim1 = d1;
        dim2 = d2;
    }
    public GeoShape(double d1)
    {
        dim1 = dim2 = d1;
    }

    public virtual double CalcArea()
    {
        return 0;
    }

    public virtual string GetName()
    {
        return "GeoShape";
    }
}

// Rectangle class
class Rectangle : GeoShape
{
    public Rectangle(double width, double height) : base(width, height) { }

    public override double CalcArea()
    {
        return dim1 * dim2;
    }

    public override string GetName()
    {
        return "Rectangle";
    }
}

// Triangle class
class Triangle : GeoShape
{
    public Triangle(double baseLength, double height) : base(baseLength, height) { }

    public override double CalcArea()
    {
        return 0.5 * dim1 * dim2;
    }

    public override string GetName()
    {
        return "Triangle";
    }
}

// Circle class
class Circle : GeoShape
{
    public Circle(double radius) : base(radius) { }

    public override double CalcArea()
    {
        return Math.PI * dim1 * dim1;
    }

    public override string GetName()
    {
        return "Circle";
    }
}

class Program
{
    static void Main()
    {
        GeoShape[] shapes = new GeoShape[]
        {
            new Rectangle(5, 10),
            new Triangle(4, 6),
            new Circle(7)
        };

        foreach (GeoShape shape in shapes)
        {
            Console.WriteLine($"{shape.GetName()} Area: {shape.CalcArea()}");
        }
    }
}
