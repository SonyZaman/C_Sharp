// 109. Advanced Structs (readonly struct & ref struct)
/*
    'readonly struct': Forces the struct to be completely immutable.
                       Massive performance boost because the compiler knows data won't change.
                       
    'ref struct': Guarantees the struct will NEVER leave the Stack memory (cannot be Boxed).
                  Used in extremely high-performance scenarios (like 'Span<T>').
*/
using System;

// 1. Readonly Struct
public readonly struct Coordinate
{
    // These properties CANNOT be modified after the constructor finishes
    public double Latitude { get; }
    public double Longitude { get; }

    public Coordinate(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }
}

// 2. Ref Struct
// Cannot implement interfaces, cannot be used in async methods, cannot be a field in a normal class!
public ref struct TemporaryBuffer
{
    // Extremely fast stack-only memory
    public ReadOnlySpan<int> Data { get; }

    public TemporaryBuffer(ReadOnlySpan<int> data)
    {
        Data = data;
    }
}

class Test
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Readonly Struct ---");
        Coordinate ny = new Coordinate(40.7128, -74.0060);
        Console.WriteLine($"New York: {ny.Latitude}, {ny.Longitude}");

        // ny.Latitude = 50.0; // ERROR! Cannot assign to a read-only property. It is totally safe!

        Console.WriteLine("\n--- Ref Struct ---");
        // Creating an array on the heap
        int[] numbers = { 10, 20, 30, 40, 50 };
        
        // Creating a stack-only Span wrapper
        TemporaryBuffer buffer = new TemporaryBuffer(numbers);
        Console.WriteLine($"Buffer length: {buffer.Data.Length}");
        Console.WriteLine($"First item in buffer: {buffer.Data[0]}");
    }
}
