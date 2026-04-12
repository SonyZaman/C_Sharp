//gpa

class Test
{
    
    public static void Main(string[] args)
    {
        

        double marks;
        char grade;
        Console.Write("Enter your marks: ");
        marks=Convert.ToDouble(Console.ReadLine());

        //Invalid input check
        if(marks>=0 && marks <= 100)
        {
            if(marks>=80)
            {
                grade='A';
            }
            else if(marks>=70)
            {
                grade='B';
            }
            else if(marks>=60)
            {
                grade='C';
            }
            else if(marks>=50)
            {
                grade='D';
            }
            else
            {
                grade='F';
            }

            Console.WriteLine("Your grade is: " + grade);
        }
        else
        {
            Console.WriteLine("Invalid input.");

        }

    }
}