// 134. Async / Await Basics
/*
    The keywords 'async' and 'await' are the gold standard for C# development.
    Instead of manually creating Tasks, you mark a method as 'async'.
    Then, when you hit a heavy operation (like downloading a file), you 'await' it.
    
    'await' PAUSES that specific method, but ALLOWS the rest of the application 
    (like the UI or other web requests) to keep running!
*/
using System;
using System.Threading.Tasks;

class Test
{
    // 1. The Main method itself must be marked 'async Task' to use await!
    public static async Task Main(string[] args)
    {
        Console.WriteLine("1. Application started.");
        
        // We start the download, but we don't 'await' it yet.
        // It begins running in the background immediately!
        Task<string> downloadTask = DownloadFileAsync();

        Console.WriteLine("3. Main thread is doing other work while downloading...");

        // NOW we actually need the file data, so we 'await' the result.
        // The application pauses HERE until the download is 100% finished.
        string result = await downloadTask;

        Console.WriteLine($"5. Download complete! Result: {result}");
    }

    // 2. An async method returns a Task (if void) or Task<T> (if returning a value).
    public static async Task<string> DownloadFileAsync()
    {
        Console.WriteLine("2. Starting download...");
        
        // Task.Delay is the async version of Thread.Sleep! 
        // It simulates a 3-second network request WITHOUT freezing the main application thread.
        await Task.Delay(3000); 
        
        Console.WriteLine("4. Download finished internally.");
        return "Movie_File.mp4";
    }
}
