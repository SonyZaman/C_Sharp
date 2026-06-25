// 105. Queue<T> and Stack<T> Collections
/*
    Queue<T>: First-In, First-Out (FIFO). Like a line of people waiting.
              Use Enqueue() to add, Dequeue() to remove.
              
    Stack<T>: Last-In, First-Out (LIFO). Like a stack of books or an "Undo" button.
              Use Push() to add, Pop() to remove.
*/
using System;
using System.Collections.Generic;

class Test
{
    public static void Main(string[] args)
    {
        Console.WriteLine("========== QUEUE (FIFO) ==========");
        Queue<string> printerQueue = new Queue<string>();
        
        // Enqueue adds to the end of the line
        printerQueue.Enqueue("Document1.pdf");
        printerQueue.Enqueue("Photo.png");
        printerQueue.Enqueue("Report.docx");

        // Dequeue removes and returns the FIRST item in the line
        Console.WriteLine($"Printing: {printerQueue.Dequeue()}"); // Document1
        Console.WriteLine($"Printing: {printerQueue.Dequeue()}"); // Photo
        Console.WriteLine($"Items left in queue: {printerQueue.Count}");


        Console.WriteLine("\n========== STACK (LIFO) ==========");
        Stack<string> webHistory = new Stack<string>();
        
        // Push adds to the TOP of the stack
        webHistory.Push("google.com");
        webHistory.Push("youtube.com");
        webHistory.Push("github.com");

        // Pop removes and returns the TOP (most recent) item
        Console.WriteLine($"Going back from: {webHistory.Pop()}"); // github
        Console.WriteLine($"Going back from: {webHistory.Pop()}"); // youtube
        Console.WriteLine($"Current page: {webHistory.Peek()}");   // google (Peek looks without removing!)
    }
}
