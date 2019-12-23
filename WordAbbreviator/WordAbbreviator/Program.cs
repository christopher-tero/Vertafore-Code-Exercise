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
                return "Invalid entry";
            }
            else if (word.Length > 2)
            {
                int middleLetters = word.Length - 2;
                string abbreviation = word[0] + middleLetters.ToString() + word[word.Length - 1];
                return abbreviation;
            }
            else if (word.Length > 0)
            {
                return word;
            }
            else
            {
                return "No word was given";
            }
        }

        public static void ConsoleAbbreviator()
        {
            string userInput = "";
            while(userInput != "exit")
            {
                Console.WriteLine("Please enter word to abbreviate, or type 'exit' to exit:");
                userInput = Console.ReadLine();
                if (userInput != "exit")
                {
                    string abbreviatedInput = Abbreviate(userInput);
                    Console.WriteLine(abbreviatedInput);
                }
            }
        }
    }

    public class CheckUniqueness
    {
        public static string[] testDictionary = { "internationalization", "localization", "accessibility", "automatically" };

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

        public static Dictionary<string, int> AbbreviateDictionary(string[] array)
        {
            string[] arrayToCheck;
            arrayToCheck = AbbreviateArray(array);

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

            return dictionary;
        }

        public static bool IsWordUnique(string word)
        {
            string abbreviatedWord = Abbreviator.Abbreviate(word);
            Dictionary<string, int> abbreviatedDictionary = AbbreviateDictionary(testDictionary);

            foreach (var item in abbreviatedDictionary)
            {
                if (abbreviatedWord == item.Key)
                {
                    if (item.Value == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
    }

    class Program
    {
        static void Main()
        {
            // Abbreviator test
            Console.WriteLine(Abbreviator.Abbreviate("Hello")); // expecting H3o
            Console.WriteLine(Abbreviator.Abbreviate("Antidisestablishmentarianism")); // expecting A26m
            Console.WriteLine(Abbreviator.Abbreviate("Invalid string")); // expecting Invalid Entry
            Console.WriteLine(Abbreviator.Abbreviate("H3ll0")); // expecting Invalid Entry

            // Abbreviation uniqueness test
            Console.WriteLine(CheckUniqueness.IsWordUnique("internationalization"));
            Console.WriteLine(CheckUniqueness.IsWordUnique("localization"));
            Console.WriteLine(CheckUniqueness.IsWordUnique("accessibility"));
            Console.WriteLine(CheckUniqueness.IsWordUnique("automatically"));

            Abbreviator.ConsoleAbbreviator();
        }
    }
}
