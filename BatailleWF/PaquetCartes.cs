using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatailleWF
{
    public class PaquetCartes<T>:List<T> where T:Carte
    {
        public PaquetCartes():base()
        {
            for(int i = 0; i < 13; i++)
            {
                this.Add((T)Activator.CreateInstance(typeof(T),i, "Coeur", PuissanceCarte.Standard));
                this.Add((T)Activator.CreateInstance(typeof(T),i, "Trèfle", PuissanceCarte.Standard));
                this.Add((T)Activator.CreateInstance(typeof(T),i, "Carreau", PuissanceCarte.Standard));
                this.Add((T)Activator.CreateInstance(typeof(T),i, "Pique", PuissanceCarte.Standard));
            }
        }

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
