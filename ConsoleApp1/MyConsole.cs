using System;
using System.Threading;

namespace ConsoleApp1
{
    public static class MyConsole
    {
        public static void WriteLine(string text)
        {
            Console.WriteLine($"{text.PadRight(30)} " + 
                 $"Thread: {Thread.CurrentThread.ManagedThreadId.ToString().PadRight(5)}" +
                 $"Thread pool: {Thread.CurrentThread.IsThreadPoolThread.ToString().PadRight(9)}" +
                 $"Context: {SynchronizationContext.Current?.ToString() ?? "null"}");
        }
    }
}