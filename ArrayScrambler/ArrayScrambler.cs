using System;

namespace VertaforeCodeExercise
{
    public class ScrambleArray
    {
        public static void ScrambleNumbers(int[] array)
        {
            int arrayLength = array.Length;
            Random random = new Random();

            for (int i = arrayLength - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                int temporary = array[i];
                array[i] = array[j];
                array[j] = temporary;
            }

            foreach (int i in array)
            {
                Console.Write(i + " ");
            }
            Console.Write("\n");
        }
    }

    class Program
    {
        static void Main()
        {
            // Test Arrays
            int[] firstArray = { 7, 13, 13, 18, 29, 33 };
            int[] secondArray = { 33, 29, 18, 13, 13, 7 };

            // Test Cases
            ScrambleArray.ScrambleNumbers(firstArray);
            ScrambleArray.ScrambleNumbers(secondArray);
            return;
        }
    }
}
