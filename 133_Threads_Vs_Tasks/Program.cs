// 133. Concurrency: Threads vs Tasks
/*
    In the old days of C# (before 2010), we used the 'Thread' class to run 
    background processes. 
    
    Today, we almost EXCLUSIVELY use the 'Task' class.
    Tasks are "Promises" that a job will finish eventually. They use the 
    Thread Pool automatically, making them incredibly lightweight and efficient.
*/
using System;
using System.Threading;
using System.Threading.Tasks;

class Test
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- 1. The Old Way (Threads) ---");
        // Threads are "heavy". Creating a new thread asks the OS to allocate 1MB of memory.
        Thread oldThread = new Thread(() => 
        {
            Console.WriteLine("Old Thread is running...");
            Thread.Sleep(1000); // Freeze this background thread for 1 second
            Console.WriteLine("Old Thread finished.");
        });
        
        oldThread.Start();


        Console.WriteLine("\n--- 2. The Modern Way (Tasks) ---");
        // Tasks are "lightweight". They borrow existing threads from the .NET Thread Pool.
        Task modernTask = Task.Run(() => 
        {
            Console.WriteLine("Modern Task is running...");
            Thread.Sleep(1000); 
            Console.WriteLine("Modern Task finished.");
        });

        // The Main thread will finish instantly and exit the app!
        // We add thisReadLine so the console stays open long enough to see the background jobs finish.
        Console.WriteLine("Main thread is done! Press Enter to exit...");
        Console.ReadLine(); 
    }
}
