using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Masukkan deretan angka hasil konversi No 1: ");
        string input = Console.ReadLine();

        int result = RumusSum(input);
        Console.WriteLine($"Output: {result}");
    }

    static int RumusSum(string input)
    {
        int[] numbers = input.Split(' ').Select(int.Parse).ToArray();
        int result = numbers[0];

        for (int i = 1; i < numbers.Length; i++)
        {
            if (i % 2 == 1)
                result += numbers[i];
            else
                result -= numbers[i];
        }

        return result;
    }
}
