

//type casting

//implicit casting//automatic casting
//char->int->long->float->double
//explicit casting//manual casting
//double->float->long->int->char

class Test
{
    
    public static void Main(string[] args)
    {
        
        double salary=2547.89;

        Console.WriteLine(salary);

        //explicit casting

        int salary2=(int)salary;

        Console.WriteLine(salary2);

        Console.WriteLine(Convert.ToString(salary));

       // Console.WriteLine(Convert.ToChar(salary));//error


    }
}