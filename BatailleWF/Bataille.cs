using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatailleWF
{
    /// <summary>
    /// Déclaration d'un délégué de gestion d'événement pour gérer l'affichage des cartes jouées
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void PlayedEventHandler(object sender, PlayedEventArgs e);

    /// <summary>
    /// Déclaration d'un délégué de gestion d'événement pour gérer l'affichage des gain de pli
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void BatailleEventHandler(object sender, EventArgs e);

    /// <summary>
    /// Déclaration d'un délégué de gestion d'événement pour gérer l'affichage des batailles
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void PliGainedEventHandler(object sender, PliGainedEventArgs e);


    class Bataille
    {
        private Joueur joueur1;
        private Joueur joueur2;
        private PaquetCartes<CarteGraphique> jeuDeCarte = new PaquetCartes<CarteGraphique>();
                
        // Déclaration des trois événement qui seront générés par notre classe
        public event PlayedEventHandler PlayedEvent;
        public event BatailleEventHandler BatailleEvent;
        public event PliGainedEventHandler PliGainedEvent;

        /// <summary>
        /// Créateur standard utilisé uniquement à des fins de test
        /// </summary>
        public Bataille()
        {
            joueur1 = new Joueur("Toto");
            joueur2 = new Joueur("Titi");
        }

        /// <summary>
        /// Créé une instance de la classe Bataille afin de pouvoir lancer une partie en appuyyant sur Run
        /// </summary>
        /// <param name="nameJ1">Nom du joueur 1</param>
        /// <param name="nameJ2">Nom du joueur 2</param>
        public Bataille(string nameJ1, string nameJ2)
        {
            joueur1 = new Joueur(nameJ1);
            joueur2 = new Joueur(nameJ2);
        }

        /// <summary>
        /// Lance une partie de Bataille en mélangeant puis distribuant les cartes avant de rentrer dans le vif du sujet
        /// </summary>
        /// <returns>Le joueur gagnant</returns>
        public Joueur Run()
        {
            List<Joueur> joueurs = new List<Joueur>() { joueur1, joueur2 };
            jeuDeCarte.Melanger();
            jeuDeCarte.DistribuerCartes(joueurs);
            return JouerPartie(joueurs);
        }

        /// <summary>
        /// Joue tous les plis d'une partie afin de déterminer le vainqueur
        /// </summary>
        /// <param name="joueurs">La liste des joueurs participants. Pour notre GUI il vaut mieux se limiter à 2 joueurs</param>
        /// <returns>Le Joueur gagnant de la partie</returns>
        private Joueur JouerPartie(List<Joueur> joueurs)
        {
            int i = 1;
            bool jouer = true;
            Joueur gagnant = null;
            while (jouer)
            {
                // On limite le nombre de pli à 1000 ce qui donne des parties de 1 minute environ
                if(i>=1000)
                {
                    jouer = false;
                    gagnant = null;
                }
                i++;
                // On laisse au système un peu de temps pour gérer les taches courantes
                System.Threading.Thread.Sleep(5);
                // On vérifie si l'un des joueur n'a plus de carte ce qui signifie alors que l'on a un gagnant
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
                // Si on a pas de gagnant il faut continuer à jouer
                if (jouer)
                {
                    Stack<Carte> pliActuelle = new Stack<Carte>();
                    Stack<Carte> batailleActuelle = new Stack<Carte>();
                    PliGainedEventArgs args = new PliGainedEventArgs();
                    int perdantPli;
                    // On joue un pli
                    int gagnantPli = JouerPli(joueurs, ref pliActuelle, ref batailleActuelle);
                    // On prépare les données qui seront envoyer dans l'événement PliGained                    
                    args.Gagnant = joueurs[gagnantPli];
                    // On calcule qui est le perdant
                    if (gagnantPli == 0) { perdantPli = 1; }
                    else { perdantPli = 0; }
                    args.Perdant = joueurs[perdantPli];
                    // On crée des copie des Stack pour pouvoir utiliser Pop() sans vider les Stack utilisés dans la Bataille
                    args.Pli = new Stack<Carte>(pliActuelle);
                    args.Bataille = new Stack<Carte>(batailleActuelle);
                    args.Joueurs = joueurs;
                    // On génère l'événement PliGained
                    OnGained(args);
                    // On donne les cartes en jeux au vainqueur
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

        /// <summary>
        /// Joue un pli de la partie de Bataille
        /// </summary>
        /// <param name="joueurs">La liste des joueurs</param>
        /// <param name="pliActuelle">Les cartes actuellement visibles</param>
        /// <param name="batailleActuelle">Les cartes à remporter en cas de bataille</param>
        /// <returns>L'index du Joueur gagnant dans la liste des joueurs</returns>
        private int JouerPli(List<Joueur> joueurs, ref Stack<Carte> pliActuelle, ref Stack<Carte> batailleActuelle)
        {
            int indexGagnant = 0;
            bool jouer = true;
            // On vérifie si on a un gagnant
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
            // Si on a pas de gagnant il faut jouer le pli
            if (jouer)
            {
                // Chaque joueur sort une carte
                foreach (Joueur joueur in joueurs)
                {
                    pliActuelle.Push(joueur.Main.Dequeue());
                }
                // On prépare la génération de l'événement Played
                PlayedEventArgs args = new PlayedEventArgs();
                args.CarteJoueurs = new Stack<Carte>(pliActuelle.Reverse());
                args.Joueurs = joueurs;
                // On génère l'événement Played
                OnPlayed(args);
                Carte meilleureCarte = null;
                int index = 0;
                // On vérifie si une carte est meilleure que l'autre
                // La méthode pourrait être améliorée car elle ne fonctionne actuellement que pour 2 joueurs
                foreach (Carte carte in pliActuelle)
                {
                    if (meilleureCarte != null)
                    {
                        if (meilleureCarte.CompareTo(carte) > 0)
                        {

                        }
                        else if (meilleureCarte.CompareTo(carte) == 0)
                        {
                            // On génère l'événement Bataille
                            OnBataille(EventArgs.Empty);
                            // On transfère les cartes dans le paquet des cartes à gagner en fin de bataille
                            foreach (Carte carte2 in pliActuelle)
                            {
                                batailleActuelle.Push(carte2);
                            }
                            pliActuelle.Clear();
                            foreach (Joueur joueur in joueurs)
                            {
                                batailleActuelle.Push(joueur.Main.Dequeue());
                            }
                            // On joue un nouveau pli avec les cartes à gagner en fin de bataille
                            indexGagnant = JouerPli(joueurs, ref pliActuelle, ref batailleActuelle);// Bataille
                            // On sort de la boucle foreach
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

        /// <summary>
        /// Génère l'événement Played si on gestionnaire a été déclaré
        /// </summary>
        /// <param name="e"></param>
        protected void OnPlayed(PlayedEventArgs e)
        {
            if (PlayedEvent != null)
            {
                PlayedEvent(this, e);
            }
        }

        /// <summary>
        /// Génère l'événement Bataille si on gestionnaire a été déclaré
        /// </summary>
        /// <param name="e"></param>
        protected void OnBataille(EventArgs e)
        {
            if(BatailleEvent!=null)
            {
                BatailleEvent(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Génère l'événement Gained si on gestionnaire a été déclaré
        /// </summary>
        /// <param name="e"></param>
        protected void OnGained(PliGainedEventArgs e)
        {
            if(PliGainedEvent!=null)
            {
                PliGainedEvent(this, e);
            }
        }
    }

    /// <summary>
    /// Classe représentant les paramètres de l'événement Played
    /// </summary>
    public class PlayedEventArgs : EventArgs
    {
        public Stack<Carte> CarteJoueurs { get; set; }
        public List<Joueur> Joueurs { get; set; }
    }

    /// <summary>
    /// Classe représentant les paramètres de l'événement Gained
    /// </summary>
    public class PliGainedEventArgs : EventArgs
    {
        public Stack<Carte> Pli { get; set; }
        public Stack<Carte> Bataille { get; set; }
        public Joueur Gagnant { get; set; }
        public Joueur Perdant { get; set; }
        public List<Joueur> Joueurs { get; set; }
    }
}
