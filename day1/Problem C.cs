using System;
class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int x = int.Parse(input[0]);
        int y = int.Parse(input[1]);
        Console.WriteLine($"{x} + {y} = {x + y}");
        Console.WriteLine($"{x} * {y} = {(long)x * y}");
        Console.WriteLine($"{x} - {y} = {x - y}");
    }
}
