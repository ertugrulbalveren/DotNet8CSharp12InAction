//Microsoft documentation: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-12.0/using-alias-types

// C# 12 introduces the ability to use alias directives for tuples, arrays,
// and pointers, this feature not available in previous versions

// Alias for a tuple representing a 2D point
using Point = (int x, int y);

// Alias for an array of integers
using IntArray = int[];

// Alias for a pointer to an integer (unsafe context required)
using unsafe IntPtr = int*;

// Using the Point alias
Point p1 = (5, 10);
Console.WriteLine($"Point: X={p1.x}, Y={p1.y}");

// Using the IntArray alias
IntArray numbers = { 1, 2, 3, 4, 5 };
Console.WriteLine($"IntArray: {string.Join(", ", numbers)}");

// Using the IntPtr alias - this requires an unsafe context
unsafe
{
    int number = 42;
    IntPtr pointerToInt = &number; // Pointer to number

    Console.WriteLine($"Number: {number}");
    Console.WriteLine($"Pointer points to: {*pointerToInt}");

    *pointerToInt = 24; // Changing the value through the pointer
    Console.WriteLine($"Updated Number: {number}");
}

