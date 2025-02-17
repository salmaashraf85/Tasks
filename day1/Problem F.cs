using System;
class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(" ");
        long x = long.Parse(input[0]);
        long y = long.Parse(input[1]);
        Console.WriteLine((x % 10) + (y % 10));
    }
}