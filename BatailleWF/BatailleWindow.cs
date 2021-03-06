﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatailleWF
{
    public partial class BatailleWindow : Form
    {
        // Création d'un backgroundworker (thread indépendant du thread IHM)
        private BackgroundWorker taskBataille = new BackgroundWorker();
        private Bataille bataille;
        private Joueur gagnant;

        /// <summary>
        /// Constructeur par défaut de la fenêtre
        /// </summary>
        public BatailleWindow()
        {
            InitializeComponent();
            // Enregistrement des gestionnaires d'événement liés au BackgroundWorker
            taskBataille.DoWork += new DoWorkEventHandler(tb_DoWork);
            taskBataille.RunWorkerCompleted += new RunWorkerCompletedEventHandler(tb_RunWorkerCompleted);
        }

        /// <summary>
        /// Gestionnaire de l'événement Played défini dans Bataille
        /// Il est généré à chaque fois qu'un pli est joué
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PliJouee(object sender, PlayedEventArgs e)
        {
            // Récupération de la carte du premier joueur
            CarteGraphique card = (CarteGraphique)e.CarteJoueurs.Pop();
            // On appelle this.Invoke afin de pouvoir faire les modifications d'IHM dans le thread IHM.
            // En effet l'événement est levé par le BackgroundWorker qui n'a pas accès aux éléments de l'IHM.
            this.Invoke((MethodInvoker)delegate ()
            {
                this.rtbDisplay.AppendText(e.Joueurs[0].Nom + " joue : " + card);
                this.pbJ1.Image = card.Image;
                this.rtbDisplay.AppendText("\t");
            });
            // Récupération de la carte du deuxième joueur
            card = (CarteGraphique)e.CarteJoueurs.Pop();
            this.Invoke((MethodInvoker)delegate ()
            {
                this.rtbDisplay.AppendText(e.Joueurs[1].Nom + " joue : " + card + "\n");
                this.pbJ2.Image = card.Image;
                this.lblJ1NbCard.Text = "Nb Cartes : " + e.Joueurs[0].Main.Count;
                this.lblJ2NbCard.Text = "Nb Cartes : " + e.Joueurs[1].Main.Count;
                this.rtbDisplay.ScrollToCaret(); // Force la barre de défilement verticale à aller en bas de la zone de texte
                this.Update();
            });
        }

        /// <summary>
        /// Gestionnaire d'événement pour l'événement Gained défini dans Bataille
        /// Evenement généré à la fin de chaque pli pour indiquer l'état du jeu à la suite de ce dernier
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PliGagnee(object sender, PliGainedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                this.rtbDisplay.AppendText("\n");
                this.rtbDisplay.AppendText("Gagnant du pli : " + e.Gagnant.Nom + " avait " + e.Gagnant.Main.Count + " cartes. \n");
                this.rtbDisplay.AppendText("Il gagne sur le dernier pli :\n");
                foreach (Carte carte in e.Pli)
                {
                    this.rtbDisplay.AppendText("\t- " + carte + "\n");
                }
                if (e.Bataille.Count != 0)
                {
                    this.rtbDisplay.AppendText("Il gagne grâce aux batailles :\n");
                    foreach (Carte carte in e.Bataille)
                    {
                        this.rtbDisplay.AppendText("\t- " + carte + "\n");
                    }
                }
                this.rtbDisplay.AppendText("Le perdant du pli : " + e.Perdant.Nom + " avait encore " + e.Perdant.Main.Count + "\n");
                this.rtbDisplay.ScrollToCaret();
                this.lblJ1NbCard.Text = "Nb Cartes : " + e.Joueurs[0].Main.Count;
                this.lblJ2NbCard.Text = "Nb Cartes : " + e.Joueurs[1].Main.Count;
            });
        }

        /// <summary>
        /// Gestionnaire d'événement pour l'événement Bataille défini dans Bataille
        /// Evenement généré en cas de bataille
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BatailleEv(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                this.rtbDisplay.AppendText("Bataille\n");
                this.rtbDisplay.ScrollToCaret();
            });            
        }

        /// <summary>
        /// Gestionnaire d'événement pour le clic sur le bouton Play
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlay_Click(object sender, EventArgs e)
        {
            // On vide l'afficheur texte
            this.rtbDisplay.Clear();
            // Instanciation d'une nouvelle Bataille
            bataille = new Bataille(txtbJ1Name.Text, txtbJ2Name.Text);
            // Enregistrement des gestionnaires d'événement définis dans Bataille
            bataille.PlayedEvent += new PlayedEventHandler(PliJouee);
            bataille.PliGainedEvent += new PliGainedEventHandler(PliGagnee);
            bataille.BatailleEvent += new BatailleEventHandler(BatailleEv);
            btnPlay.Enabled = false; // On désactive le bouton pour éviter que l'utilisateur ne clique une deuxième fois
            txtbJ1Name.ReadOnly = true; // On passe les noms en ReadOnly car cette information a été utilisée pour générer nos joueurs
            txtbJ2Name.ReadOnly = true;
            // Lancement du thread de BackgroundWorker
            taskBataille.RunWorkerAsync();
        }

        /// <summary>
        /// Appelé lors du lancement du thread BackgroundWorker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_DoWork(object sender, DoWorkEventArgs e)
        {
            gagnant = bataille.Run(); // On lance la bataille qui va durer un certain temps dans notre thread en tache de fond
        }

        /// <summary>
        /// Appelé lors de la fin de l'exécution du thread BackgroundWorker
        /// donc quand la bataille est finie et que l'on a un vainqueur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                if (gagnant != null)
                {
                    rtbDisplay.AppendText("Gagnant : " + gagnant.Nom + "\n");
                }
                else
                {
                    rtbDisplay.AppendText("Aucun gagnant\n");
                }
                this.rtbDisplay.ScrollToCaret();
                this.btnPlay.Enabled = true;
                this.txtbJ1Name.ReadOnly = false;
                this.txtbJ2Name.ReadOnly = false;
            });
        }

        /// <summary>
        /// Gestion de l'appui sur la croix pour quitter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BatailleWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Si une bataille est en cours
            if(taskBataille.IsBusy)
            {
                // Alors on ne veut pas quitter sinon il y a des risques d'exception
                // Une autre solution serait de permettre de couper l'exécution de la bataille entre deux plis afin de pouvoir quitter quand on le souhaite
                MessageBox.Show("Désolé impossible de quitter pendant la partie");
                // On annule donc l'événement de fermeture
                e.Cancel = true;
            }
        }
    }
}
