using System;

namespace VertaforeCodeExercise
{
    public class ScrambleArray
    {
        public static void ScrambleNumbers(int[] array)
        {
            Random random = new Random();

            Console.Write("Original array:  ");
            foreach (int i in array)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("");

            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                int temporary = array[i];
                array[i] = array[j];
                array[j] = temporary;
            }

            Console.Write("Scrambled array: ");
            foreach (int i in array)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\n");
        }
    }

    class Program
    {
        static void Main()
        {
            // Test Arrays
            int[] firstArray = { 7, 13, 13, 18, 29, 33 };
            int[] secondArray = { 33, 29, 18, 13, 13, 7 };
            int[] thirdArray = { 2, 5, 8, 8 };
            int[] fourthArray = { 100, 99, 98, 97, 96, 5, 4, 3, 2, 1, 0 };

            // Test Cases
            ScrambleArray.ScrambleNumbers(firstArray);
            ScrambleArray.ScrambleNumbers(secondArray);
            ScrambleArray.ScrambleNumbers(thirdArray);
            ScrambleArray.ScrambleNumbers(fourthArray);
        }
    }
}
