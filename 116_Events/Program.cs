// 116. Events (Publisher / Subscriber Model)
/*
    An 'event' is a special type of multicast delegate.
    It allows a class (Publisher) to "shout" that something happened, 
    and other classes (Subscribers) can listen and execute their own code when they hear it!
    
    This is how UI buttons work (Button clicks -> Fires Event -> Your code runs).
*/
using System;

// 1. Publisher Class
public class VideoEncoder
{
    // Define the event based on an Action delegate (takes a string, returns void)
    public event Action<string> VideoEncoded;

    public void Encode(string title)
    {
        Console.WriteLine($"Encoding Video: '{title}'...");
        // Imagine encoding takes 3 seconds...
        Console.WriteLine("Encoding Finished!");

        // Fire the event! (Check if anyone is actually listening first using ?.)
        VideoEncoded?.Invoke(title);
    }
}

// 2. Subscriber Class A
public class MailService
{
    public void OnVideoEncoded(string title)
    {
        Console.WriteLine($"MailService: Sending email... '{title}' is ready!");
    }
}

// 3. Subscriber Class B
public class SmsService
{
    public void OnVideoEncoded(string title)
    {
        Console.WriteLine($"SmsService: Sending text... '{title}' is ready!");
    }
}

class Test
{
    public static void Main(string[] args)
    {
        VideoEncoder encoder = new VideoEncoder(); // Publisher
        MailService mailer = new MailService();    // Subscriber 1
        SmsService messenger = new SmsService();   // Subscriber 2

        // 4. Wiring them up (Subscription)
        // We attach the subscribers' methods to the publisher's event!
        encoder.VideoEncoded += mailer.OnVideoEncoded;
        encoder.VideoEncoded += messenger.OnVideoEncoded;

        // 5. Trigger the action
        // The encoder does its job, and automatically notifies MailService and SmsService!
        encoder.Encode("My_Vacation.mp4");
    }
}
