using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Tema1
{
    public class CasaDeBilete
    {
        private readonly List<Bilet> listaBilete = new List<Bilet>(3);
        public delegate void BileteSuplimetateEventHandler(int stocSuplimentar, Bilet bilet);
        public event BileteSuplimetateEventHandler MesajBileteSuplimentate;
        public event BileteSuplimetateEventHandler MesajBileteClientiCoada;
        Queue<Client> clientiInAsteptare = new Queue<Client>();
        public void AdaugaBilet(Bilet bilet)
        {
            if (listaBilete.Contains(bilet))
                throw new ArgumentException("Biletul exista deja!");
            listaBilete.Add(bilet);
        }
        public void StocSuplimentar(int stocSuplimentar, Bilet bilet)
        {
            if (listaBilete.Count == 0)
                throw new ArgumentNullException("Nu exista acest bilet!");
            if (stocSuplimentar <= 0)
                throw new ArgumentException("Stoc suplimentar invalid!");
            Bilet biletFromList = listaBilete.FirstOrDefault(b => b.Equals(bilet)) ?? throw new ArgumentException("Nu exista acest bilet in lista noastra!");
            biletFromList.Stoc += stocSuplimentar;
            MesajBileteSuplimentate?.Invoke(stocSuplimentar, bilet);
        }
        public void Tranzactie(Client client,string Categorie,int nrBilete)
        {
            if (listaBilete.Count == 0)
                throw new ArgumentNullException("Nu exista acest bilet!");
            if (nrBilete <= 0)
                throw new ArgumentException("Nr de bilete comandate invalid!");
            Bilet bilet = listaBilete.Find(b => b.Categorie.Equals(Categorie));
            if (bilet.Categorie.ToLower().CompareTo("under21") == 0 && client.Varsta > 21)
                throw new ArgumentException("Peste 21 ani!");
            if (nrBilete < bilet.Stoc)
            {
                bilet.Stoc -= nrBilete;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Tranzactie reusita pentru clientul {client.NumeClient}!");
                Console.ForegroundColor= ConsoleColor.White;  
            }
           else
            {
                //adaugam alegerea biletului clientului
                client.BiletAles = bilet;
                //il punem in coada
                clientiInAsteptare.Enqueue(client);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Tranzactie nereusita pentru clientul {client.NumeClient}!");
                Console.ForegroundColor= ConsoleColor.White;
                //am ajuns la 5 clienti in asteptarea aceluiasi bilet
                if (clientiInAsteptare.Count(c => c.BiletAles.Equals(bilet)) == 5)
                    MesajBileteClientiCoada?.Invoke(10, bilet);
            }    
        }
        public Queue<Client> ClientiInAsteptare
        {
            get { return clientiInAsteptare;}
            set {  clientiInAsteptare = value;}
        }
        public override string ToString()
        {
            StringBuilder CasaDeBilete = new StringBuilder();
            CasaDeBilete.AppendLine("-----Casa de bilete----");
            for (int i = 0; i < listaBilete.Count; i++)
            {
                CasaDeBilete.AppendLine($"{i + 1}." + listaBilete[i].ToString());
            }
            CasaDeBilete.AppendLine("-----------------------");
            return CasaDeBilete.ToString();
        }
    }
}
