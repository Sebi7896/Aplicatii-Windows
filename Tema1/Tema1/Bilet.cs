using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1
{
    public class Bilet
    {
        private String categorie;
        private int stoc= 0;
        private Decimal pret;
        public Bilet(string categorie, decimal pret)
        {
            this.categorie = categorie;
            this.pret = pret;
        }
        public Bilet(string categorie, int stoc, decimal pret)
        {
            this.categorie = categorie;
            this.stoc = stoc;
            this.pret = pret;
        }
        public String Categorie
        {
            get { return categorie; }   
            set { categorie = value; }
        }
        public int Stoc
        {
            get { return stoc; }
            set {  stoc = value; }  
        }
        public Decimal Pret
        {
            get { return pret; }
            set { pret = value; }
        }
        public override String ToString() {
            return $"Categoria: {categorie}" +
                $", Stoc_Curent: {stoc}" +
                $", Pret: {pret}";
        }
        public override bool Equals(object obj)
        {
            return obj is Bilet bilet &&
                   categorie == bilet.categorie &&
                   stoc == bilet.stoc &&
                   pret == bilet.pret;
        }
        public override int GetHashCode()
        {
            int hashCode = 1078214878;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(categorie);
            hashCode = hashCode * -1521134295 + stoc.GetHashCode();
            hashCode = hashCode * -1521134295 + pret.GetHashCode();
            return hashCode;
        }
    }
}
