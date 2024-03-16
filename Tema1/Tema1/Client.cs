using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Tema1
{
    public class Client
    {
        private String numeClient;
        private int varsta;
        private bool areAbonament = false; //pentru o reducere
        private readonly string cNP;
        private Bilet alegereBilet;
        public Client(string numeClient, int varsta, string CNP)
        {
            this.numeClient = numeClient;
            this.varsta = varsta;
            cNP = CNP;
        }
        public Client(string numeClient, int varsta, bool areAbonament, string CNP)
        {
            this.numeClient = numeClient;
            this.varsta = varsta;
            this.areAbonament = areAbonament;
            cNP = CNP;
        }
        public String NumeClient
        {
            get { return numeClient; }  
            set { numeClient = value; } 
        }
        public int Varsta
        {
            get { return varsta; }  
            set { varsta = value; } 
        }
        public bool IsAbonament
        {
            get { return areAbonament; }    
            set { areAbonament = value; }   
        }
        public string CNP
        {
            get { return cNP; }
        }
        public Bilet BiletAles
        {
            get { return alegereBilet; }
            set { alegereBilet = value; }
        }
        public override string ToString()
        {
            String Client = $"Nume: {numeClient}," +
                $" Varsta: {varsta}," +
                $" Abonament Premium: {(areAbonament ? "Da" : "Nu")}," +
                $" CNP: {cNP}";
            return Client;
        }
        public override bool Equals(object obj)
        {
            return this.cNP.Equals(((Client) obj).cNP);
        }
        public override int GetHashCode()
        {
            return 1302851820 + EqualityComparer<string>.Default.GetHashCode(cNP);
        }
    }
}
