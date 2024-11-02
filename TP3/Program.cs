using System;
using Models.ListArticles;

class Program{
    static void Main(string [] args)
    {
        ListArticles articleListe = new ListArticles();

        Console.WriteLine("0 : Ajouter un article");
        Console.WriteLine("1 : Supprimer un article");
        Console.WriteLine("2 : Afficher la liste des articles");
        Console.WriteLine("3 : Quitter");

        while(true){

            Console.Write("Donner votre choix: ");
            int choix = int.Parse(Console.ReadLine());
            switch(choix){
                case 0:
                    articleListe.Ajouter();
                    break;
                case 1:
                    articleListe.Supprimer();
                    break;
                case 2:
                    articleListe.Afficher();
                    break;
                case 3:
                    break; 
            }

            if(choix == 3){break;}
        }
    }
}