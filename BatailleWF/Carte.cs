using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatailleWF
{
    /// <summary>
    /// Classe décrivant une Carte de jeux. Implémente IComparable<Carte> qui permet de comparer deux cartes. 
    /// </summary>
    public class Carte : IComparable<Carte>
    {
        public int Valeur { get; set; }
        public string Couleur { get; set; }
        public Dictionary<int, string> Type { get; set; }

        /// <summary>
        /// Constructeur de Carte
        /// </summary>
        /// <param name="valeur">La valeur de la carte allant de 0 à 13. Avec 0 égal à 2 et 13 égal à As</param>
        /// <param name="couleur">Le texte correspondant à la couleur désirée (Coeur, Carreau, Trèfle ou Pique)</param>
        /// <param name="type">Un dictionnaire permettant de faire la correspondant entre la valeur et le nom de la carte</param>
        public Carte(int valeur, string couleur, Dictionary<int, string> type)
        {
            this.Valeur = valeur;
            this.Couleur = couleur;
            this.Type = type;
        }

        /// <summary>
        /// Méthode permettant de transformer l'objet en chaine de caractères
        /// </summary>
        /// <returns>Une chaine décrivant l'objet</returns>
        public override string ToString()
        {
            string strPuissance = "";
            Type.TryGetValue(this.Valeur, out strPuissance);
            return strPuissance + " de " + this.Couleur;
        }

        /// <summary>
        /// Implémentation de l'interface IComparable
        /// </summary>
        /// <param name="carte">La deuxième carte pour la comparaison</param>
        /// <returns>-1 si inférieur, 0 si égal et 1 si supérieur </returns>
        public int CompareTo(Carte carte)
        {
            return this.Valeur.CompareTo(carte.Valeur);
        }
    }
}
