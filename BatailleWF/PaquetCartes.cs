using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatailleWF
{
    /// <summary>
    /// Classe générique représentant un paquet de carte générique
    /// </summary>
    /// <typeparam name="T">N'importe quel type de Carte</typeparam>
    public class PaquetCartes<T>:List<T> where T:Carte
    {
        /// <summary>
        /// Créateur par défaut générant un paquet standard de 52 cartes
        /// </summary>
        public PaquetCartes():base()
        {
            for(int i = 0; i < 13; i++)
            {
                this.Add((T)Activator.CreateInstance(typeof(T),i, "Coeur", PuissanceCarte.Standard)); // Permet de générer aussi bien des Carte que des CarteGraphique en fonction du type T choisi lors de l'appel du créateur
                this.Add((T)Activator.CreateInstance(typeof(T),i, "Trèfle", PuissanceCarte.Standard));
                this.Add((T)Activator.CreateInstance(typeof(T),i, "Carreau", PuissanceCarte.Standard));
                this.Add((T)Activator.CreateInstance(typeof(T),i, "Pique", PuissanceCarte.Standard));
            }
        }

        /// <summary>
        /// Permet de mélanger un paquet de carte
        /// </summary>
        public void Melanger()
        {
            List<T> listeMelangee = new List<T>();
            Random geneRandom = new Random();
            while (this.Count > 0)
            {
                int nbRandom = geneRandom.Next(this.Count);
                listeMelangee.Add(this.ElementAt(nbRandom));
                this.RemoveAt(nbRandom);
            }
            this.AddRange(listeMelangee);
        }

        /// <summary>
        /// Permet de distribuer les cartes à un nombre joueurs permettant de répartir les cartes équitablement
        /// </summary>
        /// <param name="joueurs"></param>
        public void DistribuerCartes(List<Joueur> joueurs)
        {
            while (this.Count > 0)
            {
                foreach (Joueur joueur in joueurs)
                {
                    joueur.Main.Enqueue(this.ElementAt(0));
                    this.RemoveAt(0);
                }
            }
        }
    }
}
