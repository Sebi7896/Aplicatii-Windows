using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar3
{
    public class Program
    {
        //private static void MessageReceived(bool increased,int value)
        //{

        //}
        static void Main(string[] args)
        {
            CollatzProcessor processor = new CollatzProcessor(5);
            processor.OnOperationProcessed += (bool incresead,int value) =>
            {
                Console.WriteLine(incresead == true ? $"Increasing\t\t{value}" :
                    $"Decreasing\t\t{value}");
            };
            processor.OnProcessingStarted += (int value) =>
            {
                ConsoleColor currentColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;   
                Console.WriteLine($"Beggining processing with value {value}");
                Console.ForegroundColor = currentColor;
            };
            processor.OnProcessingFinished += (int value) =>{
                ConsoleColor currentColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Finished processing with value {value}");
                Console.ForegroundColor = currentColor;
            };
            processor.OnImpossibleScenario += (int steps, string message) =>
            {

            };
            processor.Process();

            var processor2 = new CollatzProcessor(27);
            processor2.OnOperationProcessed += (bool incresead,int value) =>
            {
                Console.WriteLine(incresead == true ? $"Going up\t\t{value}" :
                    $"Going down\t\t{value}");
            };
            processor2.Process();
            Console.ReadKey();
        }
    }
}
