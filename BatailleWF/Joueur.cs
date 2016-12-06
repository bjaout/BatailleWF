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
        public Queue<Carte> Main { set; get; }

        public Joueur(string nom)
        {
            this.Nom = nom;
            this.Main = new Queue<Carte>();
        }
    }
}
