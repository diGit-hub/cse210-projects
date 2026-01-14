using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> list = new List<int>();
        Console.WriteLine("Enter a list of numbers. Type 0 (zero) when finished.");

        Console.Write("Enter number: ");
        int num = int.Parse(Console.ReadLine());
        list.Add(num);
        while (num != 0)
        {
            Console.Write("Enter number: ");
            num = int.Parse(Console.ReadLine());
            if (num != 0)
            {
                list.Add(num);
            }
        }

        int sum = 0;
        int bigger = 0;
        foreach (int number in list)
        {
            sum = sum + number;
            if (number > bigger)
            {
                bigger = number;
            }
        }
        int average = sum/list.Count;
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {bigger}");

        for (int p1 = 0; p1 < list.Count; p1++)
        {
            for (int p2 = p1+1; p2 < list.Count; p2++)
            {
                if (list[p2] < list[p1])
                {
                    (list[p1], list[p2]) = (list[p2], list[p1]);         
                }
            }
        }

        List<int> list2 = new List<int>(list);
        for (int number = 0; number < list2.Count; number++)
        {
            if (list2[number] < 1)
            {
                list2.RemoveAt(number);
                number--;
            }
        }
        Console.WriteLine($"The smallest positive number is: {list2[0]}");

        Console.WriteLine($"The sorted list is:");
        foreach (int number in list)
        {
            Console.WriteLine(number);
        }
    }
}