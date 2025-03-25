using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
        Console.Write("Masukkan angka: ");
        int input = int.Parse(Console.ReadLine());

        string expanded = ExpandNumber(Math.Abs(input));
        Console.WriteLine($"Jabaran angka: {expanded}");

        string converted = ConvertToLetters(expanded);
        Console.WriteLine($"Output huruf: {converted}");
    }

    static string ExpandNumber(int num)
    {
        List<int> parts = new List<int>();
        int sum = 0, i = 0;

        while (sum + i <= num)
        {
            parts.Add(i);
            sum += i;
            i++;
        }

        while (sum < num)
        {
            int remainder = num - sum;
            parts.Add(remainder);
            sum += remainder;
        }

        return string.Join(" ", parts);
    }

    static string ConvertToLetters(string expandedNumbers)
    {
        string upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        int[] upperValues = { 0, 1, 1, 1, 2, 3, 3, 3, 4, 5, 5, 5, 5, 5, 6, 7, 7, 7, 7, 7, 8, 9, 9, 9, 9, 9 };

        Dictionary<int, char> numberToLetter = new Dictionary<int, char>();
        HashSet<int> assignedNumbers = new HashSet<int>();
        for (int i = 0; i < upperCase.Length; i++)
        {
            if (!assignedNumbers.Contains(upperValues[i]))
            {
                numberToLetter[upperValues[i]] = upperCase[i];
                assignedNumbers.Add(upperValues[i]);
            }
        }

        StringBuilder result = new StringBuilder();
        foreach (string numStr in expandedNumbers.Split(' '))
        {
            int num = int.Parse(numStr);
            if (numberToLetter.ContainsKey(num))
            {
                result.Append(numberToLetter[num]);
            }
        }

        return result.ToString();
    }
}