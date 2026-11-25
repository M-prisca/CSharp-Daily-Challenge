
using System;

public static class WordCounter
{
    public static int CountOccurrences(string? text, string? targetWord)
    {
        if (string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(targetWord))
        {
            return 0;
        }

        char[] punctuation = { '.', ',', '!', '?', ';', ':', '(', ')', '[', ']' };

        targetWord = targetWord.Trim(punctuation);

        string[] words = text.Split(
            (char[]?)null,
            StringSplitOptions.RemoveEmptyEntries
        );

        int count = 0;

        foreach (string word in words)
        {
            string cleanedWord = word.Trim(punctuation);

            if (string.Equals(cleanedWord, targetWord, StringComparison.OrdinalIgnoreCase))
            {
                count++;
            }
        }

        return count;
    }
}
