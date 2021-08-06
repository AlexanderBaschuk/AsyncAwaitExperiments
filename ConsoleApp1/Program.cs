using System;
using System.Threading.Tasks;
using Nito.AsyncEx;

namespace ConsoleApp1
{
    // https://docs.microsoft.com/en-us/archive/msdn-magazine/2015/july/async-programming-brownfield-async-development
    public static class Program
    {
        static async Task Main()
        {
            Console.WriteLine();
            Console.WriteLine("==============================");

            var controller = new Controller();

            // var result = await controller.GetThingAsync();

            // var result = AsyncContext.Run(async () => await controller.GetThingAsync());

            var result = AsyncContext.Run(() => controller.GetThing());

            Console.WriteLine();
            Console.WriteLine($"Result: {result}");
        }
    }
}