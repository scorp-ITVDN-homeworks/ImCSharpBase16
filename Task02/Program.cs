using System;
using System.Diagnostics;
using static InputTools.UIFeatures;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();

            long oldHouseTicks = 0;
            long newHouseTicks = 0;
            long anotherHouseTicks = 0;

            timer.Start();
            House oldHouse = new House("Wall street", 404, 999666);
            timer.Stop();
            oldHouseTicks = timer.Elapsed.Ticks;
            timer.Reset();

            timer.Start();
            House newHouse = oldHouse.Clone() as House;
            timer.Stop();
            newHouseTicks = timer.Elapsed.Ticks;
            timer.Reset();

            timer.Start();
            House anotherHouse = oldHouse.DeepClone() as House;
            timer.Stop();
            anotherHouseTicks = timer.Elapsed.Ticks;
            timer.Reset();

            Console.WriteLine($"oldHouse - {oldHouse.Street} - {oldHouse.Number} - {oldHouse.Index} - time of implementation {oldHouseTicks}");
            Console.WriteLine($"newHouse - {newHouse.Street} - {newHouse.Number} - {newHouse.Index} - time of shallow cloning {newHouseTicks}");
            Console.WriteLine($"anotherHouse - {anotherHouse.Street} - {anotherHouse.Number} - {anotherHouse.Index} - time of deep cloning {anotherHouseTicks}");

            DrawSymbolLine(50, '-', ConsoleColor.DarkGreen);

            timer.Start();
            newHouse.Street.Name = "1st Ave";
            newHouse.Number.Number = 505;
            //так как тип стрктурный - изменения его не коснуться
            newHouse.Index = new PostIndex() { Index = 000111 };
            timer.Stop();
            newHouseTicks = timer.Elapsed.Ticks;
            timer.Reset();

            Console.WriteLine($"oldHouse - {oldHouse.Street} - {oldHouse.Number} - {oldHouse.Index}");
            Console.WriteLine($"newHouse - {newHouse.Street} - {newHouse.Number} - {newHouse.Index} - time to redefine newHouse {newHouseTicks}");
            Console.WriteLine($"anotherHouse - {anotherHouse.Street} - {anotherHouse.Number} - {anotherHouse.Index}");

            DrawSymbolLine(50, '-', ConsoleColor.DarkGreen);

            timer.Start();
            anotherHouse.Street.Name = "Houstone west";
            anotherHouse.Number.Number = 333;            
            anotherHouse.Index = new PostIndex() { Index = 444888 };
            timer.Stop();
            anotherHouseTicks = timer.Elapsed.Ticks;
            timer.Reset();

            Console.WriteLine($"oldHouse - {oldHouse.Street} - {oldHouse.Number} - {oldHouse.Index}");
            Console.WriteLine($"newHouse - {newHouse.Street} - {newHouse.Number} - {newHouse.Index}");
            Console.WriteLine($"anotherHouse - {anotherHouse.Street} - {anotherHouse.Number} - {anotherHouse.Index} - time to redefine anotherHouse {anotherHouseTicks}");

            Console.ReadKey();
        }
    }
}
