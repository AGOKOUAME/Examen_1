using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_GestionCompteBancaire
{
    public class Person
    {
        public void AfficherInfo()
        {
            Console.WriteLine("Nom: " + Nom + "\nNumero du compte: " + NumeroCompte);
        }

        public Person()
        {
            Nom = "AGO KOUAME BERTAND";
            NumeroCompte = "AKB-2023-0001254698963";

        }
        public int Solde { get; set; }
        public int Epargne { get; set; }

        public string Nom { get; set; }
        public string NumeroCompte { get; set; }

    }
}
