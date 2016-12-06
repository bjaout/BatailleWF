using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BatailleWF
{
    /// <summary>
    /// Classe permettant de décrire une carte avec aspect graphique
    /// </summary>
    public class CarteGraphique:Carte
    {
        public Image Image{ get; set; }

        /// <summary>
        /// Constructeur permettant de récupérer en plus des informations de base, l'image correspondant à la carte
        /// </summary>
        /// <param name="valeur"></param>
        /// <param name="couleur"></param>
        /// <param name="type"></param>
        public CarteGraphique(int valeur, string couleur, Dictionary<int,string> type):base(valeur,couleur,type)
        {
            int val;
            string coul;
            if(valeur==12)
            {
                val = 1;
            }
            else
            {
                val = valeur + 2;
            }
            switch(couleur)
            {
                case "Coeur":
                    coul = "c";
                    break;
                case "Carreau":
                    coul = "k";
                    break;
                case "Pique":
                    coul = "p";
                    break;
                case "Trèfle":
                    coul = "t";
                    break;
                default:
                    throw new NotImplementedException();
            }
            this.Image = (Image)global::BatailleWF.Properties.Resources.ResourceManager.GetObject(coul + String.Format("{0:00}",val));
        }
    }
}
