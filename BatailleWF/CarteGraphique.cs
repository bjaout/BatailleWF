using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BatailleWF
{
    public class CarteGraphique:Carte
    {
        public Image Image{ get; set; }

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

        public override string ToString()
        {
            string strPuissance = "";
            Type.TryGetValue(this.Valeur, out strPuissance);
            return strPuissance + " de " + this.Couleur;
        }

        public int CompareTo(object obj)
        {
            int resultat = 0;
            try
            {
                Carte carte = obj as Carte;
                resultat = this.Valeur.CompareTo(carte.Valeur);
            }
            catch (Exception)
            {

            }
            return resultat;
        }
    }
}
