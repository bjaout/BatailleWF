using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatailleWF
{

    public delegate void PlayedEventHandler(object sender, PlayedEventArgs e);
    public delegate void BatailleEventHandler(object sender, EventArgs e);
    public delegate void PliGainedEventHandler(object sender, PliGainedEventArgs e);


    class Bataille
    {
        private Joueur joueur1;
        private Joueur joueur2;
        private PaquetCartes<CarteGraphique> jeuDeCarte = new PaquetCartes<CarteGraphique>();
        public event PlayedEventHandler PlayedEvent;
        public event BatailleEventHandler BatailleEvent;
        public event PliGainedEventHandler PliGainedEvent;

        public Bataille()
        {
            joueur1 = new Joueur("Toto");
            joueur2 = new Joueur("Titi");
        }

        public Bataille(string nameJ1, string nameJ2)
        {
            joueur1 = new Joueur(nameJ1);
            joueur2 = new Joueur(nameJ2);
        }

        public Joueur Run()
        {
            List<Joueur> joueurs = new List<Joueur>() { joueur1, joueur2 };
            jeuDeCarte.Melanger();
            jeuDeCarte.DistribuerCartes(joueurs);
            return JouerPartie(joueurs);
        }

        private Joueur JouerPartie(List<Joueur> joueurs)
        {
            int i = 1;
            bool jouer = true;
            Joueur gagnant = null;
            while (jouer)
            {
                if(i>=1000)
                {
                    jouer = false;
                    gagnant = null;
                }
                i++;
                System.Threading.Thread.Sleep(5);
                if ((joueurs[0].Main.Count() == 0))
                {
                    jouer = false;
                    gagnant = joueurs[1];
                }
                else if (joueurs[1].Main.Count() == 0)
                {
                    jouer = false;
                    gagnant = joueurs[0];
                }
                if (jouer)
                {
                    Stack<Carte> pliActuelle = new Stack<Carte>();
                    Stack<Carte> batailleActuelle = new Stack<Carte>();
                    PliGainedEventArgs args = new PliGainedEventArgs();
                    int perdantPli;
                    int gagnantPli = JouerPli(joueurs, ref pliActuelle, ref batailleActuelle);

                    
                    args.Gagnant = joueurs[gagnantPli];
                    if (gagnantPli == 0) { perdantPli = 1; }
                    else { perdantPli = 0; }
                    args.Perdant = joueurs[perdantPli];
                    args.Pli = new Stack<Carte>(pliActuelle);
                    args.Bataille = new Stack<Carte>(batailleActuelle);
                    args.Joueurs = joueurs;
                    OnGained(args);
                    foreach (Carte carte in pliActuelle)
                    {
                        joueurs[gagnantPli].Main.Enqueue(carte);
                    }
                    foreach (Carte carte in batailleActuelle)
                    {
                        joueurs[gagnantPli].Main.Enqueue(carte);
                    }
                }
            }
            return gagnant;
        }

        private int JouerPli(List<Joueur> joueurs, ref Stack<Carte> pliActuelle, ref Stack<Carte> batailleActuelle)
        {
            int indexGagnant = 0;
            bool jouer = true;
            if ((joueurs[0].Main.Count() == 0))
            {
                jouer = false;
                indexGagnant = 1;
            }
            else if (joueurs[1].Main.Count() == 0)
            {
                jouer = false;
                indexGagnant = 0;
            }
            if (jouer)
            {
                foreach (Joueur joueur in joueurs)
                {
                    pliActuelle.Push(joueur.Main.Dequeue());
                }
                PlayedEventArgs args = new PlayedEventArgs();
                args.CarteJoueurs = new Stack<Carte>(pliActuelle.Reverse());
                args.Joueurs = joueurs;
                OnPlayed(args);
                Carte meilleureCarte = null;
                int index = 0;
                foreach (Carte carte in pliActuelle)
                {
                    if (meilleureCarte != null)
                    {
                        if (meilleureCarte.CompareTo(carte) > 0)
                        {

                        }
                        else if (meilleureCarte.CompareTo(carte) == 0)
                        {
                            OnBataille(EventArgs.Empty);
                            foreach (Carte carte2 in pliActuelle)
                            {
                                batailleActuelle.Push(carte2);
                            }
                            pliActuelle.Clear();
                            foreach (Joueur joueur in joueurs)
                            {
                                batailleActuelle.Push(joueur.Main.Dequeue());
                            }
                            indexGagnant = JouerPli(joueurs, ref pliActuelle, ref batailleActuelle);// Bataille
                            break;
                        }
                        else
                        {
                            meilleureCarte = carte;
                            indexGagnant = index;
                        }
                    }
                    else
                    {
                        meilleureCarte = carte;
                    }
                    index++;
                }
            }
            return indexGagnant;

        }

        protected void OnPlayed(PlayedEventArgs e)
        {
            if (PlayedEvent != null)
            {
                PlayedEvent(this, e);
            }
        }

        protected void OnBataille(EventArgs e)
        {
            if(BatailleEvent!=null)
            {
                BatailleEvent(this, EventArgs.Empty);
            }
        }

        protected void OnGained(PliGainedEventArgs e)
        {
            if(PliGainedEvent!=null)
            {
                PliGainedEvent(this, e);
            }
        }
    }

    public class PlayedEventArgs : EventArgs
    {
        public Stack<Carte> CarteJoueurs { get; set; }
        public List<Joueur> Joueurs { get; set; }
    }

    public class PliGainedEventArgs : EventArgs
    {
        public Stack<Carte> Pli { get; set; }
        public Stack<Carte> Bataille { get; set; }
        public Joueur Gagnant { get; set; }
        public Joueur Perdant { get; set; }
        public List<Joueur> Joueurs { get; set; }
    }
}
