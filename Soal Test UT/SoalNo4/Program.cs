using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
        Console.Write("Masukkan huruf: ");
        string input = Console.ReadLine().Replace(" ", "");

        int reconstructedNumber = ReconstructNumber(input);
        Console.WriteLine($"Bilangan hasil rekonstruksi: {reconstructedNumber}");

        string expandedNumbers = ExpandNumber(reconstructedNumber);
        Console.WriteLine($"Jabaran angka baru: {expandedNumbers}");

        string finalOutput = ConvertToLetters(expandedNumbers);
        Console.WriteLine($"Sample Output: {finalOutput}");
    }

    static string ExpandNumber(int num)
    {
        List<int> parts = new List<int>();
        int sum = 0;
        int i = 0;

        while (sum + i <= num)
        {
            parts.Add(i);
            sum += i;
            i++;
        }

        while (sum < num)
        {
            parts.Add(1);
            sum += 1;
        }

        return string.Join(" ", parts);
    }

    static string ConvertToLetters(string expandedNumbers)
    {
        Dictionary<int, char> numberToLetter = new Dictionary<int, char>
        {
            { 0, 'A' }, { 1, 'B' }, { 2, 'E' }, { 3, 'F' }, { 4, 'I' }, { 5, 'J' },
            { 6, 'O' }, { 7, 'P' }, { 8, 'U' }, { 9, 'V' }
        };

        StringBuilder result = new StringBuilder();
        foreach (string numStr in expandedNumbers.Split(' '))
        {
            if (int.TryParse(numStr, out int num) && numberToLetter.ContainsKey(num))
                result.Append(numberToLetter[num]);
        }

        return string.Join(" ", result.ToString().ToCharArray());
    }

    static int ReconstructNumber(string letters)
    {
        Dictionary<char, int> letterToNumber = new Dictionary<char, int>
        {
            { 'A', 0 }, { 'B', 1 }, { 'E', 2 }, { 'F', 3 }, { 'I', 4 }, { 'J', 5 },
            { 'O', 6 }, { 'P', 7 }, { 'U', 8 }, { 'V', 9 }
        };

        int sum = 0;
        foreach (char c in letters)
        {
            if (letterToNumber.ContainsKey(c))
                sum += letterToNumber[c];
        }

        return sum;
    }
}
