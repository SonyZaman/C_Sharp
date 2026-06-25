// 141. Advanced Async (CancellationTokens)
/*
    What happens if you start downloading a 5GB file asynchronously, 
    but the user clicks "Cancel"? 
    You need to be able to safely abort the Task halfway through!
*/
using System;
using System.Threading; // Critical for CancellationTokens
using System.Threading.Tasks;

class Test
{
    public static async Task Main(string[] args)
    {
        // 1. Create a CancellationTokenSource. This is the master control switch.
        CancellationTokenSource cts = new CancellationTokenSource();
        
        // 2. Get the actual token to pass into our async method.
        CancellationToken token = cts.Token;

        Console.WriteLine("Starting a long 10-second download...");
        Console.WriteLine("Press 'C' to cancel it early!\n");

        // Fire off the download in the background, passing the token!
        Task downloadTask = DownloadMassiveFileAsync(token);

        // Listen for user input on the main thread
        while (!downloadTask.IsCompleted)
        {
            if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.C)
            {
                Console.WriteLine("\n[Main Thread] User pressed Cancel! Aborting task...");
                cts.Cancel(); // Flip the kill switch!
                break;
            }
        }

        try
        {
            await downloadTask; // Wait for it to either finish or throw the cancellation exception
            Console.WriteLine("\nDownload completed successfully!");
        }
        catch (TaskCanceledException)
        {
            Console.WriteLine("\nException Caught: The background task was safely killed!");
        }
    }

    public static async Task DownloadMassiveFileAsync(CancellationToken token)
    {
        for (int i = 1; i <= 10; i++)
        {
            // Check if someone flipped the kill switch!
            // If they did, this throws a TaskCanceledException instantly.
            token.ThrowIfCancellationRequested();

            Console.WriteLine($"Downloading chunk {i} of 10...");
            await Task.Delay(1000); // Simulate 1 second of work
        }
    }
}
