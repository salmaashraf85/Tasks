using System;
class Program
{
    static void Main()
    {
        String S = Console.ReadLine();
        String[] DataTypes = S.Split(" ");
        for (int i = 0; i < DataTypes.Length; i++)
        {
            Console.WriteLine(DataTypes[i]);
        }

    }
}