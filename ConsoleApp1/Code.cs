using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Controller
    {
        private readonly Service _service = new Service();

        public async Task<string> GetThingAsync()
        {
            MyConsole.WriteLine("Controller starting (async)");

            var result = await _service.GetThingAsync(); //.ConfigureAwait(false);

            MyConsole.WriteLine("Controller finished (async)");

            return result;
        }

        public string GetThing()
        {
            MyConsole.WriteLine("Controller starting (sync)");

            // var result = _service.GetThingAsync().Result();
            // var result = _service.GetThingAsync().GetAwaiter().GetResult();
            var result = Task.Run(_service.GetThingAsync).GetAwaiter().GetResult();

            MyConsole.WriteLine("Controller finished (sync)");

            return result;
        }
    }

    public class Service
    {
        private readonly ThirdPartyLibrary _library = new ThirdPartyLibrary();

        public async Task<string> GetThingAsync()
        {
            MyConsole.WriteLine("Service starting");

            var hello = await _library.GetPart1(); //.ConfigureAwait(false);

            MyConsole.WriteLine("Service in progress");

            var world = await _library.GetPart2(); //.ConfigureAwait(true);

            MyConsole.WriteLine("Service finished");

            return hello + " " + world;
        }
    }

    public class ThirdPartyLibrary
    {
        public async Task<string> GetPart1()
        {
            MyConsole.WriteLine("Library starting part 1");
            Console.WriteLine("...");

            await Task.Delay(100); //.ConfigureAwait(false);

            MyConsole.WriteLine("Library finished part 1");

            return "Hello";
        }

        public async Task<string> GetPart2()
        {
            MyConsole.WriteLine("Library starting part 2");
            Console.WriteLine("...");

            await Task.Delay(100); //.ConfigureAwait(false);

            MyConsole.WriteLine("Library finished part 2");

            return "World";
        }
    }
}