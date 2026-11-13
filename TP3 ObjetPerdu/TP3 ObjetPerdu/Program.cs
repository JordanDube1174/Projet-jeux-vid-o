using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_ObjetPerdu
{
    // Classe abstraite Utilisateur
    abstract class Utilisateur
    {
        // Propriétés pour le nom d'utilisateur et le mot de passe
        private string nomUtilisateur;
        private string motdepasse;

        public string NomUtilisateur
        {
            get { return nomUtilisateur; }
            set { nomUtilisateur = value; }
        }

        public string Motdepasse
        {
            get { return motdepasse; }
            set { motdepasse = value; }
        }

        // Le constructeur
        public Utilisateur(string nomUtilisateur, string motdepasse)
        {
            this.nomUtilisateur = nomUtilisateur;
            this.motdepasse = motdepasse;
        }
    }


    // Classe UtilisateurAdministrateur
    class Administrateur : Utilisateur
    {
        public Administrateur(string nomUtilisateur, string motdepasse) : base(nomUtilisateur, motdepasse)
        {

        }

        private void Modifier()
        {
            Console.WriteLine("Modifier");
        }

        private void Trier()
        {
            Console.WriteLine("Trier");
        }

        private void ConsulterListeRéclam()
        {
            Console.WriteLine("Trier");
        }
        private void ConsulterListeTrouva()
        {
            Console.WriteLine("Trier");
        }
        private void ConsulterListeArchive()
        {
            Console.WriteLine("Trier");
        }
        private void ArchiverTrouvaille()
        {
            Console.WriteLine("Trier");
        }
        private void ValiderRéclam()
        {
            Console.WriteLine("Trier");
        }
    }

    // Classe UtilisateurStandard
    class AutreUtilisateur : Utilisateur
    {
        public AutreUtilisateur(string nomUtilisateur, string motdepasse) : base(nomUtilisateur, motdepasse)
        {
        }

        public void RemplirRéclammation()
        {
            FormRéclamation.Remplir();
        }
        public void RemplirTrouvaille()
        {
            FormTrouvaille.Trouvaille();
        }

        public void ConsulterListeObjetsPerdus()
        {
            Console.WriteLine("Liste des objets perdus : ");

            foreach (ObjetPerdu objet in Program.ObjetsPerdus)
            {
                Console.WriteLine($"Nom : {objet.Nom}, Catégorie : {objet.Categorie}");
            }
        }
    }

    abstract class Formulaire
    {
        private string catégorie;
        public string Catégorie
        {
            get { return catégorie; }
            set { catégorie = value; }
        }


    }

    //class objet perdu
    public class ObjetPerdu
    {
        private string nom;
        private string categorie;

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public string Categorie
        {
            get { return categorie; }
            set { categorie = value; }
        }

        public ObjetPerdu(string nom, string categorie)
        {
            this.nom = nom;
            this.categorie = categorie;
        }
    }

    class Réclamation
    {
        string datePerte;
        string photoActuelle;
        string endroitPerdu;
        string description;

        public string DatePerte
        {
            get { return datePerte; }
            set { datePerte = value; }
        }

        public string PhotoActuelle
        {
            get { return photoActuelle; }
            set { photoActuelle = value; }
        }

        public string EndroitPerdu
        {
            get { return endroitPerdu; }
            set { endroitPerdu = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public Réclamation(string datePerte, string photoActuelle, string endroitPerdu, string description)
        {
            this.DatePerte = datePerte;
            this.photoActuelle = photoActuelle;
            this.EndroitPerdu = endroitPerdu;
            this.Description = description;
        }
    }

    class Trouvaille
    {
        string dateTrouve;
        string photoActuelle;
        string endroitTrouve;

        public string DateTrouve
        {
            get { return dateTrouve; }
            set { dateTrouve = value; }
        }

        public string PhotoActuelle
        {
            get { return photoActuelle; }
            set { photoActuelle = value; }
        }

        public string EndroitTrouve
        {
            get { return endroitTrouve; }
            set { endroitTrouve = value; }
        }
        public Trouvaille(string dateTrouve, string photoActuelle, string endroitTrouve)
        {
            this.DateTrouve = dateTrouve;
            this.photoActuelle = photoActuelle;
            this.EndroitTrouve = endroitTrouve;
        }
    }

    class FormRéclamation : Formulaire
    {
        public static void Remplir()
        {
            string datePerte;
            string photoActuelle;
            string endroitPerdu;
            string description;

            Console.WriteLine("-----------FORMULAIRE DE RÉCLAMATION------------------");
            Console.WriteLine();
            Console.Write("Fournir la date (jj/MM/aaaa) : ");
            datePerte = Console.ReadLine();

            Console.Write("Fournir l'endroit perdu : ");
            endroitPerdu = Console.ReadLine();

            Console.Write("Fournir le lien vers la photo de l'objet : ");
            photoActuelle = Console.ReadLine();

            Console.Write("Fournir une derscription : ");
            description = Console.ReadLine();

            Réclamation reclamation = new Réclamation(datePerte,photoActuelle,endroitPerdu, description);

            Program.ReclamationList.Add(reclamation);

        }
    }

    class FormTrouvaille : Formulaire
    {
        public static void Trouvaille()
        {
            string dateTrouve;
            string photoActuelle;
            string endroitTrouve;

            Console.WriteLine("-----------FORMULAIRE DE Trouvaille------------------");
            Console.WriteLine();
            Console.Write("Fournir la date (jj/MM/aaaa) : ");
            dateTrouve = Console.ReadLine();

            Console.Write("Fournir l'endroit trouvé : ");
            endroitTrouve = Console.ReadLine();

            Console.Write("Fournir le lien vers la photo de l'objet : ");
            photoActuelle = Console.ReadLine();

            Trouvaille trouvaille = new Trouvaille(dateTrouve, photoActuelle, endroitTrouve);

            Program.TrouvailleList.Add(trouvaille);
        }
         
            
    }
    internal class Program
    {
        static string nomUtilisateur;
        static string motdepasse;
        static List<AutreUtilisateur> UserList = new List<AutreUtilisateur>();
        public static List<Réclamation> ReclamationList = new List<Réclamation>();
        public static List<Trouvaille> TrouvailleList = new List<Trouvaille>();
        public static List<ObjetPerdu> ObjetsPerdus = new List<ObjetPerdu>();

        //Menu principal

        static void MenuPrincipal()
        {
            Console.WriteLine();
            Console.WriteLine("Bienvenue dans le système de gestion des objets perdus !");
            Console.WriteLine();
            // Connexion et Inscription
            Console.WriteLine("1. Connexion");
            Console.WriteLine("2. Inscription");
            Console.WriteLine();
            Console.Write("Choisissez une option : ");
            int choix = int.Parse(Console.ReadLine());

            switch (choix)
            {
                case 1:
                    Connexion();
                    break;
                case 2:
                    Inscription();
                    break;
                default:
                    Console.WriteLine("Choix invalide.");
                    break;
            }

            if (nomUtilisateur == "admin" && motdepasse == "admin")
            {
                // Menu Admin
                Console.WriteLine();
                Console.WriteLine("Bienvenue, Administrateur !");
                Console.WriteLine();

                Console.WriteLine("1. Modifier");
                Console.WriteLine("2. Trier par catégorie");
                Console.WriteLine("3. Liste des réclamations");
                Console.WriteLine("4. Liste des trouvailles");
                Console.WriteLine("5. Liste archive");
                Console.WriteLine("6. Déconnexion");
                Console.WriteLine();
                Console.Write("Choisissez une option : ");
                int choixmenuadmin = int.Parse(Console.ReadLine());
                switch (choixmenuadmin)
                {
                    case 1:
                        
                        break;
                    case 2:
                        // Trier un objet perdu
                        break;
                    case 3:
                        //  Liste des réclamations objet perdu
                        break;
                    case 4:
                        // Liste des trouvailles objets perdus
                        break;
                    case 5:
                        // Liste archive objet perdu
                        break;
                    case 6:
                        MenuPrincipal();
                        break;
                    default:
                        Console.WriteLine("Choix invalide.");
                        break;

                }

            }
            else
            {
                //Menu Utilisateur
                Console.WriteLine();
                Console.WriteLine("Bienvenue, Utilisateur !");
                Console.WriteLine();

                Console.WriteLine("1. Remplir réclamation");
                Console.WriteLine("2. Remplir trouvaille");
                Console.WriteLine("3. Consulter liste des objets perdus");
                Console.WriteLine("4. Déconnexion");
                Console.WriteLine();
                Console.Write("Choisissez une option : ");
                int choixmenuutilisateur = int.Parse(Console.ReadLine());

                switch (choixmenuutilisateur)
                {
                    case 1:
                        Console.WriteLine();
                        UserList[0].RemplirRéclammation();
                        break;
                    case 2:
                        Console.WriteLine();
                        UserList[0].RemplirTrouvaille();
                        break;
                    case 3:
                        Console.WriteLine();
                        UserList[0].ConsulterListeObjetsPerdus();
                        break;
                    case 4:
                        MenuPrincipal();
                        break;
                    default:
                        Console.WriteLine("Choix invalide.");
                        break;

                }

            }
        }

        //Connexion 
        static void Connexion()
        {
            Console.Write("Nom d'utilisateur : ");
            nomUtilisateur = Console.ReadLine();
            Console.Write("Mot de passe : ");
            motdepasse = Console.ReadLine();

            if(nomUtilisateur == "admin" && motdepasse == "admin")
            {
                Console.WriteLine("Connexion réussie en tant qu'administrateur.");
            }
            else
            {
                bool utilisateurTrouve = false;
                foreach (var utilisateur in UserList)
                {
                    if (utilisateur.NomUtilisateur == nomUtilisateur && utilisateur.Motdepasse == motdepasse)
                    {
                        utilisateurTrouve = true;
                        break;
                    }
                }
                if (utilisateurTrouve)
                {
                    Console.WriteLine("Connexion réussie en tant qu'utilisateur.");
                }
                else
                {
                    Console.WriteLine("Nom d'utilisateur ou mot de passe incorrect.");
                    MenuPrincipal();
                }
            }
        }

        //Inscription 

        static void Inscription()
        {
            Console.Write("Nom d'utilisateur : ");
            string nomUtilisateur = Console.ReadLine();
            Console.Write("Mot de passe : ");
            string motdepasse = Console.ReadLine();

            Console.WriteLine("Un nouvel utilisateur sera créé au nom de :" + nomUtilisateur);
            AutreUtilisateur U = new AutreUtilisateur(nomUtilisateur, motdepasse);
            UserList.Add(U);
        }
        static void Main(string[] args)
        {
            new Administrateur("admin", "admin");
            ObjetPerdu objet1 = new ObjetPerdu("Clé", "Accessoire");
            ObjetPerdu objet2 = new ObjetPerdu("Sac à dos", "Accessoire");
            ObjetsPerdus.Add(objet1);
            ObjetsPerdus.Add(objet2);
            MenuPrincipal();
        }
    }
}
