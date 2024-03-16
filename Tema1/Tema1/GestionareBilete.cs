using System;
using System.Collections.Generic;
using System.Linq;

namespace Tema1
{
    public class GestionareBilete
    {
        static void Main(string[] args)

        {
            //Bilete In Casa
            Console.ForegroundColor = ConsoleColor.White;  
            Bilet biletSub21Ani = new Bilet("Under21",1,100); 
            Bilet biletStandard = new Bilet("Standard",1,175);
            Bilet biletVIP = new Bilet("VIP",50,300);  
            CasaDeBilete casaDeBilete = new CasaDeBilete();
            casaDeBilete.MesajBileteSuplimentate += (stocSuplimentar, bilet) =>
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Biletele pentru categoria {bilet.Categorie} " +
                    $"au fost suplimentate cu {stocSuplimentar} bucati!");
                Console.ForegroundColor = ConsoleColor.White;
            };
            casaDeBilete.MesajBileteClientiCoada += (stocSuplimentar, bilet) =>
            {
                bilet.Stoc += stocSuplimentar;
                Console.ForegroundColor = ConsoleColor.Blue;
                foreach (var item in casaDeBilete.ClientiInAsteptare.Where(c => c.BiletAles.Equals(bilet)))
                {
                    Console.WriteLine($"{item.NumeClient}!!!vezi ca au mai aparut in stoc 10 bilete la {bilet.Categorie}!");
                }
                Console.ForegroundColor = ConsoleColor.White;
                casaDeBilete.ClientiInAsteptare = new Queue<Client>(casaDeBilete.ClientiInAsteptare.Where(c => !c.BiletAles.Equals(bilet)));
            };
            casaDeBilete.AdaugaBilet(biletSub21Ani);
            casaDeBilete.AdaugaBilet(biletStandard);
            casaDeBilete.AdaugaBilet(biletVIP);
            Console.WriteLine(casaDeBilete);
            
            //Clienti
            Client client = new Client("Sebi",18,"5032321312312");
            Client client1 = new Client("Ionel",20,"50542321332132");
            Client client2 = new Client("Cristi",21,"5032321312213");
            Client client3 = new Client("Matei",19,"50323233123432");
            Client client4 = new Client("Ionut",23,"50323453123432");
            Client client5 = new Client("Mirel",20,"50323673123432");
            casaDeBilete.Tranzactie(client,"VIP",3);
            casaDeBilete.Tranzactie(client, "Under21", 2);
            casaDeBilete.Tranzactie(client1, "Under21", 2);
            //adaugam 20 de bilete la VIP
            casaDeBilete.StocSuplimentar(100, biletVIP);
            casaDeBilete.Tranzactie(client2, "Under21", 2);
            casaDeBilete.Tranzactie(client3, "Under21", 2);
            casaDeBilete.Tranzactie(client4, "Standard", 2);//acesta nu va fi notificat
            casaDeBilete.Tranzactie(client5, "Under21", 3);
            Console.WriteLine("Dupa notificare coada este:");
            for(int i = 0; i < casaDeBilete.ClientiInAsteptare.Count;i++)
            {
                Console.WriteLine(casaDeBilete.ClientiInAsteptare.ElementAt(i));
            }
            Console.WriteLine();
            Console.WriteLine(casaDeBilete);

            Console.ReadKey();  
         
        }
    }
}
