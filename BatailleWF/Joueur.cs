using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatailleWF
{
    /// <summary>
    /// Classe représentant un joueur de jeux de carte
    /// </summary>
    public class Joueur
    {
        public string Nom { set; get; }
        public Queue<Carte> Main { set; get; } // Utilisation d'une queue car on ajoute toujours les cartes à la fin et on récupère toujours les premières cartes

        public Joueur(string nom)
        {
            this.Nom = nom;
            this.Main = new Queue<Carte>();
        }
    }
}
