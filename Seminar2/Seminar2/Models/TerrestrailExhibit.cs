using Seminar2.Interfaces;
using System;

namespace Seminar2.Models
{
    public class TerrestrailExhibit : Exhibit, ITerrestrialExhibit
    {
        public TerrestrailExhibit(int number) : base(number)
        {
        }

        public void CutGrass()
        {
            Console.WriteLine("Cutting grass on terrestrial exhibit!");
        }

        public override void RunMaintance()
        {
            CutGrass();
        }
    }
}
