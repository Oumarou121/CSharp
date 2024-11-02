using System;
using Models;
using System.Collections.Generic;

namespace Models.ListArticles
{
    public class ListArticles
    {
        private List<Article> LesArticles;

        public ListArticles(){
            this.LesArticles = new List<Article>();
        }

        public void Ajouter(){
            Article current = new Article();
            current.Saisir();

            this.LesArticles.Add(current);
            Console.WriteLine("L'article a bien été ajouter.");
        }

        public void Supprimer(){
            Console.Write("Donner l'indice de l'aticle à supprimer : ");
            int index = int.Parse(Console.ReadLine());

            this.LesArticles.RemoveAt(index);
        }

        public void Afficher(){
            Console.WriteLine("La liste des articles : ");
            foreach(Article current in LesArticles){
                current.Afficher();
            }
        }
    }    
}