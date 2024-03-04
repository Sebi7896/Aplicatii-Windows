using Seminar2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar2.Models
{
    public class MixedExhibit : Exhibit,IAquaticExhibit,ITerrestrialExhibit
    {
        public MixedExhibit(int number) : base(number)
        {
        }

        public void ChangeWater()
        {
            if (Animals.Any())
                Console.WriteLine("Changing water on mixed exhibit");
            else
                Console.WriteLine("Dont change the water"   );
        }

        public void CutGrass()
        {
            Console.WriteLine("Cutting grass on mixed exhibit");
        }

        public override void RunMaintance()
        {
            ChangeWater();
            CutGrass();
        }
    }
}
