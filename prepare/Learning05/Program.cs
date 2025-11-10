using System;

class Program
{
    static void Main(string[] args)
    {
        Square david = new Square("Red", 4.0);
        Rectangle sarah = new Rectangle("Blue", 3.0, 5.0);
        Circle michael = new Circle("Green", 2.5);
        List<Shape> shapes = new List<Shape>();
        shapes.Add(david);
        shapes.Add(sarah);
        shapes.Add(michael);
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Shape Color: {shape.GetColor()}");
            Console.WriteLine($"Shape Area: {shape.GetArea()}");
            Console.WriteLine();
        }
    }
}