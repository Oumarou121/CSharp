using System;
using Models;  // Importer l'espace de noms Models seulement

namespace Models.TabArticle
{
    public class TabArticle
    {
        private int NbArticle;
        private Article[] LesArticle;

        public TabArticle(int N)
        {
            this.NbArticle = N;
            this.LesArticle = new Article[N]; // Initialisation du tableau
        }

        public void Saisir()
        {
            for (int i = 0; i < NbArticle; i++)
            {
                Console.WriteLine("Les données de l'élément : " + (i + 1));
                Article current = new Article();
                current.Saisir();
                LesArticle[i] = current;
            }
        }

        public void Afficher()
        {
            Console.WriteLine("La liste des articles : ");
            for (int i = 0; i < NbArticle; i++)
            {
                LesArticle[i].Afficher();
            }
        }
    }
}
