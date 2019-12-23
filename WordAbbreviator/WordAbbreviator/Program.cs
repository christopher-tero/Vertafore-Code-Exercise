using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WordAbbreviator
{
    public class Abbreviator
    {
        public static string Abbreviate(string word)
        {
            if (!Regex.IsMatch(word, @"^[a-zA-Z]+$"))
            {
                //Console.WriteLine("Invalid entry");
                return "Invalid entry";
            }
            else if (word.Length > 2)
            {
                int middleLetters = word.Length - 2;
                string abbreviation = word[0] + middleLetters.ToString() + word[word.Length - 1];
                //Console.WriteLine(abbreviation);
                return abbreviation;
            }
            else if (word.Length > 0)
            {
                //Console.WriteLine(word);
                return word;
            }
            else
            {
                //Console.WriteLine("No word was given");
                return "No word was given";
            }
        }
    }

    public class CheckUniqueness
    {
        public static string[] AbbreviateArray(string[] array)
        {
            int size = array.Length;
            string[] abbreviatedArray;
            abbreviatedArray = new string[size];

            for (int i = 0; i < size; i++)
            {
                string abbreviatedWord = Abbreviator.Abbreviate(array[i]);
                abbreviatedArray[i] = abbreviatedWord;
            }

            return abbreviatedArray;
        }

        public static string[] CheckArray(string[] array)
        {
            string[] arrayToCheck;
            string[] arrayUniqueness;
            arrayToCheck = AbbreviateArray(array);
            arrayUniqueness = new string[array.Length];

            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            foreach (string word in arrayToCheck)
            {
                if (dictionary.ContainsKey(word))
                {
                    dictionary[word] += 1;
                }
                else
                {
                    dictionary.Add(word, 1);
                }
            }

            foreach (var item in dictionary)
            {
                if (item.Value == 1)
                {
                    Console.WriteLine(item.Key + ": true");
                }
                else
                {
                    Console.WriteLine(item.Key + " false");
                }
            }



            return arrayUniqueness;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Abbreviator test
            Console.WriteLine(Abbreviator.Abbreviate("Hello")); // expecting H3o
            Console.WriteLine(Abbreviator.Abbreviate("Antidisestablishmentarianism")); // expecting A26m
            Console.WriteLine(Abbreviator.Abbreviate("Invalid string")); // expecting Invalid Entry
            Console.WriteLine(Abbreviator.Abbreviate("H4ll0")); // expecting Invalid Entry

            string[] dictionary = { "internationalization", "localization", "accessibility", "automatically" };
            CheckUniqueness.CheckArray(dictionary);
        }
    }
}
