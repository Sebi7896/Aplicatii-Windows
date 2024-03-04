using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar2.Models
{
    public class Zoo
    {
        public List<Exhibit> Exhibits {  get; set; }

        public Zoo() {
            Exhibits = new List<Exhibit>();
        }    
        public void AddAnimalToExhibit(int exhibitNumber, Animal animal)
        {
            var exhibit = Exhibits.FirstOrDefault(x => x.Number == exhibitNumber);
            if (exhibit == null)
            {
                throw new ArgumentException("There's not exhibit with this number");
            }
            exhibit.Animals.Add(animal);
        
        }
        public void AddExhibit(Exhibit exhibit)
        {
            if(Exhibits.Any(x => x.Number == exhibit.Number))
            {
                throw new ArgumentException("An exhibit with the same number already exists");
            }
            Exhibits.Add(exhibit);
        }
        public void RunMaintenance()
        {
            foreach(var exhibit  in Exhibits)
            {
                Console.WriteLine($"=========== Exhibit {0} =======",exhibit.Number);
                exhibit.RunMaintance();
            }
        }
    }
}
