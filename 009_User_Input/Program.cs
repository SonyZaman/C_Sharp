using System;

// take user Input

//take input from user
public class Test
{
    
    public static void Main(string[] args)
    {
        
       Console.Write("Enter your name: ");
       string? studentName=Console.ReadLine();//'?' nullable handle
       Console.WriteLine("Student Name: "+studentName);

       Console.Write("Enter your age: ");
       int? age = Convert.ToInt32(Console.ReadLine());// because we always take input as a string
       Console.WriteLine("Student Age: "+age+" years old");

       Console.Write("Enter your gpa: ");
       double? gpa=Convert.ToDouble(Console.ReadLine());
       Console.WriteLine("Student GPA: "+gpa);

       Console.Write("Have you already registered: ");
       bool isRegistered= Convert.ToBoolean(Console.ReadLine());
       Console.WriteLine("Already registered: "+isRegistered);


       // --- USING TryParse (SAFER ALTERNATIVE) ---
       // EXPLANATION: The Convert methods above will crash the program if the user enters letters instead of numbers.
       // TryParse is safer. It tries to convert the string. If it succeeds, it returns true and puts the result in the 'out' variable.
       // If it fails, it returns false (and assigns a default value like 0) without crashing the program.

       Console.WriteLine("\n--- Now let's try safely with TryParse ---");
       
       Console.Write("Enter your age safely: ");
       int safeAge;
       bool isAgeValid = int.TryParse(Console.ReadLine(), out safeAge);
       Console.WriteLine("Successfully parsed age? " + isAgeValid + " | Age: " + safeAge);

       Console.Write("Enter your gpa safely: ");
       double safeGpa;
       bool isGpaValid = double.TryParse(Console.ReadLine(), out safeGpa);
       Console.WriteLine("Successfully parsed GPA? " + isGpaValid + " | GPA: " + safeGpa);

       Console.Write("Have you already registered safely (true/false): ");
       bool safeIsRegistered;
       bool isRegisteredValid = bool.TryParse(Console.ReadLine(), out safeIsRegistered);
       Console.WriteLine("Successfully parsed registration? " + isRegisteredValid + " | Registered: " + safeIsRegistered);

    }
}