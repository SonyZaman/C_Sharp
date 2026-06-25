// 135. Concurrency with Task.WhenAll
/*
    If you need to download 3 separate files, you shouldn't 'await' them one by one.
    That's sequential, and it takes too long.
    
    You should start ALL of them at the same time, and then 'await Task.WhenAll()'
    to wait for them all to finish simultaneously!
*/
using System;
using System.Diagnostics; // For Stopwatch
using System.Threading.Tasks;

class Test
{
    public static async Task Main(string[] args)
    {
        Stopwatch timer = new Stopwatch();

        Console.WriteLine("--- 1. The Slow Way (Sequential) ---");
        timer.Start();
        
        // This takes 3 seconds
        await DownloadFileAsync("File_A"); 
        // This takes 3 seconds
        await DownloadFileAsync("File_B"); 
        // This takes 3 seconds
        await DownloadFileAsync("File_C"); 
        
        timer.Stop();
        Console.WriteLine($"Sequential time: {timer.Elapsed.TotalSeconds:F1} seconds\n");


        Console.WriteLine("--- 2. The Fast Way (Concurrent) ---");
        timer.Restart();
        
        // Start all 3 downloads IMMEDIATELY without awaiting them yet!
        Task task1 = DownloadFileAsync("File_X");
        Task task2 = DownloadFileAsync("File_Y");
        Task task3 = DownloadFileAsync("File_Z");

        // Wait for all 3 tasks to finish at the exact same time!
        // This will only take 3 seconds total!
        await Task.WhenAll(task1, task2, task3);

        timer.Stop();
        Console.WriteLine($"Concurrent time: {timer.Elapsed.TotalSeconds:F1} seconds\n");
    }

    public static async Task DownloadFileAsync(string fileName)
    {
        Console.WriteLine($"Downloading {fileName}...");
        await Task.Delay(3000); // Simulate a 3-second download
        Console.WriteLine($"{fileName} finished!");
    }
}
