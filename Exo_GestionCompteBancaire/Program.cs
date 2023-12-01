using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Exo_GestionCompteBancaire
{
    class Program
    {
        //public int compteCourant;
        //public int compteEpargne;
        public static int depotCompteCourant;
        public static int depotCompteEpargne;
        static void Main(string[] args)
        {          
            Menu();
            Console.ReadKey();
        }
        private static void Menu()
        {
            //int soldeTotal = 0;
            //int soldeEpargne = 0;
            int retraitFondCourant = 0;
            int retraitFondEpargne = 0;
            Person soldePerson = new Person();
            HistoriqueTransaction historiqueTransaction = new HistoriqueTransaction();
            IList<string> detailTransaction = new List<string>();

            string choix = "I,CS,CD,CR,ES,ED,ER,X";
            try
            {
                do
                { //Afficher le menu
                    Console.WriteLine("Appuyez sur entre pour afficher le menu");
                    Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("");
                    Console.WriteLine("Veuillez sélectionner une option ci-dessous :");
                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine("");
                    Console.WriteLine("[I] Voir les informations sur le titulaire du compte");
                    Console.WriteLine("[CS] Compte courant - Consulter le solde");
                    Console.WriteLine("[CD] Compte courant - Déposer des fonds");
                    Console.WriteLine("[CR] Compte courant - Retirer des fonds");
                    Console.WriteLine("[ES] Compte épargne - Consulter le solde");
                    Console.WriteLine("[ED] Compte épargne - Déposer des fonds");
                    Console.WriteLine("[ER] Compte épargne - Retirer des fonds");
                    Console.WriteLine("[X] Quitter");
                    Console.WriteLine("");

                    //Saisir votre choix
                    choix = Console.ReadLine().ToUpper();
                    Console.Clear();


                    switch (choix)
                    {

                        case "I":
                            Console.WriteLine("Voir les informations sur le titulaire du compte");
                            Person personne = new Person();
                            personne.AfficherInfo();
                            break;
                        case "CS":

                            Console.WriteLine("Compte courant - Consulter le solde");
                            Console.WriteLine("");

                            Console.WriteLine("Votre compte courant est de : " + soldePerson.Solde);
                            break;

                        case "CD":
                            Console.WriteLine("Compte courant - Déposer des fonds");
                            Console.WriteLine("");
                            Console.Write("Quel montant souhaitez vous déposer? : ");
                            if(!int.TryParse(Console.ReadLine(), out depotCompteCourant ) || depotCompteCourant <= 0)
                            {
                                Console.WriteLine("Veuillez saisir un montant exacte");
                            }
                            //depotCompteCourant = int.Parse(Console.ReadLine());
                            soldePerson.Solde = soldePerson.Solde + depotCompteCourant;
                            //Console.WriteLine(soldeTotal);
                            Console.WriteLine("");


                            break;
                        case "CR":
                            Console.WriteLine("Compte courant - Retirer des fonds");
                            Console.WriteLine("");
                            Console.Write("Quel montant souhaitez vous retirer? : ");
                            //retraitFondCourant = int.Parse(Console.ReadLine());
                            while(!int.TryParse(Console.ReadLine(), out retraitFondCourant)||retraitFondCourant<=0)
                            {
                                Console.WriteLine("Veuillez saisir un montant exacte");
                            }
                            if (soldePerson.Solde > retraitFondCourant)
                            {
                                soldePerson.Solde = soldePerson.Solde - retraitFondCourant;
                            }
                            else
                            {
                                Console.WriteLine("Veuillez verifier votre solde");
                            }
                            break;

                        case "ES":
                            Console.WriteLine("Compte épargne - Consulter le solde");
                            Console.WriteLine("");
                            Console.WriteLine("Votre compte d'épargne est de : " + soldePerson.Epargne);
                            break;

                        case "ED":
                            Console.WriteLine("Compte épargne - Déposer des fonds");
                            Console.WriteLine("");
                            Console.Write("Quel montant souhaitez vous déposer? : ");
                            //depotCompteEpargne = int.Parse(Console.ReadLine());
                            while(!int.TryParse(Console.ReadLine(), out depotCompteEpargne)|| depotCompteEpargne<=0)
                            {
                                Console.WriteLine("Veuillez saisir un montant exacte");
                            }
                            soldePerson.Epargne = soldePerson.Epargne + depotCompteEpargne;
                            Console.WriteLine("");

                            break;

                        case "ER":
                            Console.WriteLine("Compte épargne - Retirer des fonds");
                            Console.WriteLine("");
                            Console.Write("Quel montant souhaitez vous retirer? : ");
                            //retraitFondEpargne = int.Parse(Console.ReadLine());
                            while(!int.TryParse(Console.ReadLine(), out retraitFondEpargne)|| retraitFondEpargne<=0)
                            {
                                Console.WriteLine("Veuillez saisir un montant exacte");
                            }
                            if (soldePerson.Epargne > retraitFondEpargne)
                            {
                                soldePerson.Epargne = soldePerson.Epargne - retraitFondEpargne;
                            }
                            else
                            {
                                Console.WriteLine("Veuillez verifier votre solde");
                            }
                            break;

                        case "X":
                            Console.WriteLine("Quitter");
                           //Enregistrer les opetration suivi des dates

                            detailTransaction.Add("Depot compte courant effectué : "+ depotCompteCourant.ToString());
                            detailTransaction.Add("Date du dépot compte courant: "+ DateTime.Now.ToString());
                            detailTransaction.Add("Retrait compte courant effectué : "+ retraitFondCourant.ToString());
                            detailTransaction.Add("Date retrait compte courant: "+ DateTime.Now.ToString());
                            detailTransaction.Add("Depot compte epargne effectué : "+ depotCompteEpargne.ToString());
                            detailTransaction.Add("Date du dépot compte epargne: " + DateTime.Now.ToString());
                            detailTransaction.Add("Retrait compte epargne effectué : " + retraitFondEpargne.ToString());
                            detailTransaction.Add("Date du retrait compte epargne: " + DateTime.Now.ToString());
                            using (StreamWriter sw = new StreamWriter("detail transaction.txt"))
                            {
                                for (int i = 0; i < detailTransaction.Count; i++)
                                {
                                    //Console.WriteLine("Montant du dépot effectué : "+detailTransaction[0]);
                                    //Console.WriteLine("Date du depot : " + detailTransaction[1]);
                                    //Console.WriteLine(detailTransaction[i]);
                                    sw.WriteLine(detailTransaction[i]);

                                }
                            }
                            
                            Console.WriteLine("Operation enregistré avec succès");
                            
                            //Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("erreur de saisi");
                            break;
                    }
                    
                } while (choix != "X");   

            }
            catch (Exception e)
            {
                Console.WriteLine("Une erreur esr survenue " +e.ToString());
            }

        }
       
    }
    
   
}
