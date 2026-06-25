// 095. Jagged Arrays
/*
    A Jagged Array is an "Array of Arrays".
    Unlike a 2D Array where every row has the same number of columns,
    in a Jagged Array, each row can have a DIFFERENT length!
    
    Syntax: type[][] arrayName = new type[numberOfRows][];
*/
using System;

class Test
{
    public static void Main(string[] args)
    {
        // Declare a jagged array with 3 rows
        int[][] jaggedArray = new int[3][];

        // Initialize each row with a different size array!
        jaggedArray[0] = new int[] { 1, 2, 3 };         // Row 0 has 3 columns
        jaggedArray[1] = new int[] { 4, 5 };            // Row 1 has 2 columns
        jaggedArray[2] = new int[] { 6, 7, 8, 9, 10 };  // Row 2 has 5 columns

        // Accessing elements: jaggedArray[row][column]
        Console.WriteLine($"Value at Row 2, Column 3: {jaggedArray[2][3]}"); // Outputs 9

        Console.WriteLine("\nPrinting the Jagged Array:");
        for (int row = 0; row < jaggedArray.Length; row++)
        {
            // The inner loop iterates based on the specific row's length
            for (int col = 0; col < jaggedArray[row].Length; col++)
            {
                Console.Write($"{jaggedArray[row][col]} ");
            }
            Console.WriteLine();
        }
    }
}
