using Seminar2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar2
{
    public class Program
    {
        static void Main(string[] args)
        {
            var terresrtrialExhibit = new TerrestrailExhibit(1);
            var mixedExhibit = new MixedExhibit(2);
            var unpopulatedExhibit = new MixedExhibit(3);
            var zoo = new Zoo();
            zoo.AddExhibit(terresrtrialExhibit);
            zoo.AddExhibit(mixedExhibit);
            zoo.AddExhibit(unpopulatedExhibit);

            zoo.AddAnimalToExhibit(2, new Lion("Roger"));

            zoo.RunMaintenance();
            Console.ReadKey();
        }
    }
}
