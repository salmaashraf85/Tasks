using System;
class Program
{
    const double pi = 3.141592653;
    static void Main()
    {
        string input = Console.ReadLine();
        double Radius = double.Parse(input);

        Console.WriteLine(Radius * Radius * pi);
    }
}