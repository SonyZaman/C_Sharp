// 094. Multidimensional Arrays (2D Arrays / Matrices)
/*
    A 2D array can be thought of as a table with Rows and Columns.
    Syntax: type[,] arrayName = new type[rows, columns];
*/
using System;

class Test
{
    public static void Main(string[] args)
    {
        // Declaring a 2D array with 3 rows and 2 columns
        int[,] matrix = new int[3, 2] 
        {
            { 1, 2 },   // Row 0
            { 3, 4 },   // Row 1
            { 5, 6 }    // Row 2
        };

        // Accessing values: matrix[row, column]
        Console.WriteLine($"Value at Row 1, Column 0: {matrix[1, 0]}"); // Outputs 3

        Console.WriteLine("\nPrinting the entire matrix:");
        // GetLength(0) returns the number of Rows
        // GetLength(1) returns the number of Columns
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write($"{matrix[row, col]} ");
            }
            Console.WriteLine(); // Move to the next line after printing a row
        }
    }
}
