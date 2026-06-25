// 100. Array Copying: Shallow Copy vs Deep Copy
/*
    Because Arrays are "Reference Types", simply assigning one array to another (arr2 = arr1)
    does NOT copy the values. It copies the MEMORY ADDRESS.
    If you change arr2, it will also change arr1! This is a Shallow Copy.
    
    To truly duplicate the data into a brand new memory location, you need a Deep Copy.
*/
using System;

class Test
{
    public static void Main(string[] args)
    {
        int[] arr1 = { 10, 20, 30 };

        Console.WriteLine("--- Shallow Copy (Reference Copy) ---");
        int[] arr2 = arr1; // This does NOT duplicate the array! Both point to the SAME data.
        arr2[0] = 999;     // Changing arr2...

        // Wait! arr1 was also changed!
        Console.WriteLine($"arr1[0] is now: {arr1[0]}"); // Outputs 999
        Console.WriteLine($"arr2[0] is now: {arr2[0]}"); // Outputs 999

        
        Console.WriteLine("\n--- Deep Copy (True Duplication) ---");
        int[] arr3 = { 1, 2, 3 };
        
        // Method 1: Using .Clone()
        int[] arr4 = (int[])arr3.Clone(); // Creates a brand new copy in memory
        
        // Method 2: Using Array.Copy()
        // int[] arr4 = new int[3];
        // Array.Copy(arr3, arr4, arr3.Length);

        arr4[0] = 555; // Changing arr4...

        // arr3 remains completely untouched!
        Console.WriteLine($"arr3[0] remains: {arr3[0]}"); // Outputs 1
        Console.WriteLine($"arr4[0] is now: {arr4[0]}");  // Outputs 555
    }
}
