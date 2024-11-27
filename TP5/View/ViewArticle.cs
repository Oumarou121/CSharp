using System;
using Models;
using DAL;

namespace View
{
    public class ViewArticle
    {
        public static Article GetArticleFromInterface()
        {
            Article article = new Article();
            Console.WriteLine("\n **** Saisie d'un Article **** ");
            Console.Write(" Reference  : ");
            article.Reference = Int32.Parse(Console.ReadLine());
            Console.Write(" Designation  : ");
            article.Designation = Console.ReadLine();
            Console.Write(" Prix  : ");
            article.Prix = float.Parse(Console.ReadLine());          
            return article;
        }

        public static void ShowArticle(Article article)
        {
            Console.Write("\n Reference : " + article.Reference);
            Console.Write("\n Designation : " + article.Designation);
            Console.Write("\n Prix : " + article.Prix);        
        }

        static char ChoixAction()
        {
            char Choix=' ';
            do
            {
                Console.Clear();
                Console.WriteLine( "***************************************************** \n");
                Console.WriteLine( "                         MENU                         \n");
                Console.WriteLine( "  A : AJOUT" );
                Console.WriteLine( "  S : SUPPRESSION" );
                Console.WriteLine( "  M : MODIFICATION" );
                Console.WriteLine( "  C : CONSULTATION" );
                Console.WriteLine( "  Q : QUITTER" );

                Console.WriteLine( "\n*****************************************************" );
                Console.Write( "Donner votre choix : ");
                string str = Console.ReadLine();
                if(str.Length!=0)
                    Choix = Char.ToLower(str.Trim()[0]);
            }
            while (Choix != 'a' && Choix != 's' && Choix != 'm' && Choix != 'c' && Choix != 'q');
            return Choix;
        }

        public static void Menu()
        {
            char Choix;
            do
            {  
                Choix = ChoixAction();
                switch (Choix)
                {
                    case 'a':
                        {
                            Console.Clear();
                            Console.WriteLine( "\n************ Ajout ************" );
                            DALArticle.Insert(ViewArticle.GetArticleFromInterface());                            
                            break;
                        }

                    case 's':
                        {
                            Console.Clear();
                            Console.WriteLine( "\n************ Suppression ************" );
                            Console.Write("\n\nDonner la reference de l'article à supprimer : ");
                            DALArticle.Delete(Int32.Parse(Console.ReadLine()));                            
                            break;
                            
                        }

                    case 'm':
                        {
                            int Inv;
                            Console.Clear();
                            Console.WriteLine( "\n************ Modification ************" );
                            Console.Write("\n\nDonner la reference de l'article à modifier : ");
                            Inv = Int32.Parse(Console.ReadLine());
                            ViewArticle.ShowArticle(DALArticle.SelectByInv(Inv));                            
                            Console.WriteLine("\nDonner les nouvelles données de l' article :");
                            DALArticle.Update(Inv, ViewArticle.GetArticleFromInterface());                            
                            break;
                        }

                    case 'c':
                        {
                            Console.Clear();
                            Console.WriteLine( "\n************ Consultation ************"); 
                            List<Article> LesArticles = DALArticle.SelectAll();
                            foreach (Article article in LesArticles)
                            {
                                Console.WriteLine("\n \n ------------------------- ");
                                ViewArticle.ShowArticle(article);
                            }
                            Console.Read();
                            break;
                        }
                }
            } while (Choix != 'q');
        }
    }
}