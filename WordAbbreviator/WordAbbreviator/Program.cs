using System;
using System.Text.RegularExpressions;

namespace WordAbbreviator
{
    public class Abbreviator
    {
        public static void Abbreviate(string word)
        {
            if (!Regex.IsMatch(word, @"^[a-zA-Z]+$"))
            {
                Console.WriteLine("Invalid entry");
            }
            else if (word.Length > 2)
            {
                int middleLetters = word.Length - 2;
                Console.WriteLine(word[0] + middleLetters.ToString() + word[word.Length - 1]);
            }
            else if (word.Length > 0)
            {
                Console.WriteLine(word);
            }
            else
            {
                Console.WriteLine("No word was given");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Abbreviator test
            Abbreviator.Abbreviate("Hello"); // expecting H3o
            Abbreviator.Abbreviate("Antidisestablishmentarianism"); // expecting A26m
            Abbreviator.Abbreviate("Invalid string"); // expecting Invalid Entry
            Abbreviator.Abbreviate("H4ll0"); // expecting Invalid Entry
        }
    }
}
