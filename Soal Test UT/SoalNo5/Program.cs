using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
        Console.Write("Masukkan huruf: ");
        string input = Console.ReadLine().Replace(" ", "");

        // Konversi huruf ke angka berdasarkan kamus
        List<int> numbers = ConvertLettersToNumbers(input);
        Console.WriteLine($"Bilangan hasil konversi: {string.Join(" ", numbers)}");

        // Transformasi angka sesuai aturan
        List<int> transformedNumbers = TransformNumbers(numbers);
        Console.WriteLine($"Bilangan hasil rekonstruksi: {string.Join(" ", transformedNumbers)}");

        // Konversi kembali ke huruf
        string finalOutput = ConvertNumbersToLetters(transformedNumbers);
        Console.WriteLine($"Sample Output: {finalOutput}");
    }

    static List<int> ConvertLettersToNumbers(string input)
    {
        Dictionary<char, int> letterToNumber = new Dictionary<char, int>
        {
            {'A', 0}, {'B', 1}, {'C', 1}, {'D', 1}, {'E', 2},
            {'F', 3}, {'G', 3}, {'H', 3}, {'I', 4}, {'J', 5}, {'K', 5}, {'L', 5}, {'M', 5}, {'N', 5},
            {'O', 6}, {'P', 7}, {'Q', 7}, {'R', 7}, {'S', 7}, {'T', 7},
            {'U', 8}, {'V', 9}, {'W', 9}, {'X', 9}, {'Y', 9}, {'Z', 9}
        };

        List<int> numbers = new List<int>();
        foreach (char c in input)
        {
            if (letterToNumber.ContainsKey(c))
                numbers.Add(letterToNumber[c]);
        }

        return numbers;
    }

    static List<int> TransformNumbers(List<int> numbers)
    {
        List<int> transformed = new List<int>();

        foreach (int num in numbers)
        {
            if (num == 0 || num == 1)
                transformed.Add(1);
            else
                transformed.Add(num + 1);
        }

        return transformed;
    }

    static string ConvertNumbersToLetters(List<int> numbers)
    {
        Dictionary<int, char> numberToLetter = new Dictionary<int, char>
        {
            {0, 'A'}, {1, 'B'}, {2, 'E'}, {3, 'F'}, {4, 'I'},
            {5, 'J'}, {6, 'O'}, {7, 'P'}, {8, 'U'}, {9, 'V'}
        };

        StringBuilder result = new StringBuilder();
        foreach (int num in numbers)
        {
            if (numberToLetter.ContainsKey(num))
                result.Append(numberToLetter[num]);
        }

        return result.ToString();
    }
}
