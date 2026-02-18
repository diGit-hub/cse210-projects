using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Square shape1 = new Square("red", 24);
        Rectangle shape2 = new Rectangle("blue", 23, 54);
        Circle shape3 = new Circle("Alice Blue", 32);

        List<Shape> list = new List<Shape>();
        list.Add(shape1);
        list.Add(shape2);
        list.Add(shape3);

        foreach(Shape item in list)
        {
            Console.WriteLine(item.GetColor());
            Console.WriteLine(item.GetArea());  
        }
    }
}