using System;
class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int a = int.Parse(input[0]);
        int b = int.Parse(input[1]);
        int c = int.Parse(input[2]);
        int d = int.Parse(input[3]);
        long result = ((long)a * b) - ((long)c * d);
        Console.WriteLine($"Difference = {result}");
    }
}