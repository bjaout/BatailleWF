using System;
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
        private BackgroundWorker taskBataille = new BackgroundWorker();
        private Bataille bataille;
        private Joueur gagnant;

        public BatailleWindow()
        {
            InitializeComponent();
            taskBataille.DoWork += new DoWorkEventHandler(tb_DoWork);
            taskBataille.RunWorkerCompleted += new RunWorkerCompletedEventHandler(tb_RunWorkerCompleted);
        }

        private void PliJouee(object sender, PlayedEventArgs e)
        {
            CarteGraphique card = (CarteGraphique)e.CarteJoueurs.Pop();
            this.Invoke((MethodInvoker)delegate ()
            {
                this.rtbDisplay.AppendText(e.Joueurs[0].Nom + " joue : " + card);
                this.pbJ1.Image = card.Image;
                this.rtbDisplay.AppendText("\t");
            });
            card = (CarteGraphique)e.CarteJoueurs.Pop();
            this.Invoke((MethodInvoker)delegate ()
            {
                this.rtbDisplay.AppendText(e.Joueurs[1].Nom + " joue : " + card + "\n");
                this.pbJ2.Image = card.Image;
                this.lblJ1NbCard.Text = "Nb Cartes : " + e.Joueurs[0].Main.Count;
                this.lblJ2NbCard.Text = "Nb Cartes : " + e.Joueurs[1].Main.Count;
                this.rtbDisplay.ScrollToCaret();
                this.Update();

            });
        }

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

        private void BatailleEv(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                this.rtbDisplay.AppendText("Bataille\n");
                this.rtbDisplay.ScrollToCaret();
            });            
        }


        private void btnPlay_Click(object sender, EventArgs e)
        {
            this.rtbDisplay.Clear();

            bataille = new Bataille(txtbJ1Name.Text, txtbJ2Name.Text);
            bataille.PlayedEvent += new PlayedEventHandler(PliJouee);
            bataille.PliGainedEvent += new PliGainedEventHandler(PliGagnee);
            bataille.BatailleEvent += new BatailleEventHandler(BatailleEv);
            taskBataille.RunWorkerAsync();
        }

        private void tb_DoWork(object sender, DoWorkEventArgs e)
        {
            gagnant = bataille.Run();
        }

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
            });
        }
    }
}
