using System;
using Models;
using DAL;
using Models.Fournisseur;
using DAL.DALFournisseur;

namespace View
{
    public class ViewConsole
    {
        public static Article GetArticleFromInterface()
        {
            Article article = new Article();
            Console.WriteLine("\n **** Saisie d'un Article **** ");
            Console.Write(" Reference  : ");
            article.Reference = Int32.Parse(Console.ReadLine());
            Console.Write(" CodeF  : ");
            article.CodeF = Int32.Parse(Console.ReadLine());
            Console.Write(" Designation  : ");
            article.Designation = Console.ReadLine();
            Console.Write(" Prix  : ");
            article.Prix = float.Parse(Console.ReadLine());          
            return article;
        }

        public static void ShowArticle(Article article)
        {
            Console.Write("\n Reference : " + article.Reference);
            Console.Write("\n CodeF : " + article.CodeF);
            Console.Write("\n Designation : " + article.Designation);
            Console.Write("\n Prix : " + article.Prix);        
        }

        public static Fournisseur GetFournisseurFromInterface()
        {
            Fournisseur fournisseur = new Fournisseur();
            Console.WriteLine("\n **** Saisie d'un Fournisseur **** ");
            Console.Write(" Code  : ");
            fournisseur.Code = Int32.Parse(Console.ReadLine());
            Console.Write(" Nom  : ");
            fournisseur.Nom = Console.ReadLine();       
            return fournisseur;
        }

        public static void ShowFournisseur(Fournisseur fournisseur)
        {
            Console.WriteLine("\n Code : " + fournisseur.Code);
            Console.WriteLine("\n Nom : " + fournisseur.Nom);
            Console.WriteLine("\n Articles :");
            foreach(Article a in fournisseur.LesArticles){
                ShowArticle(a);
                Console.WriteLine();
            }   
        }

        static char ChoixAction1()
        {
            char Choix=' ';
            do
            {
                Console.Clear();
                Console.WriteLine( "***************************************************** \n");
                Console.WriteLine( "                   PRINCIPALE MENU                    \n");
                Console.WriteLine( "  F : FOURNISSEUR" );
                Console.WriteLine( "  A : ARTICLE" );
                Console.WriteLine( "  Q : QUITTER" );

                Console.WriteLine( "\n*****************************************************" );
                Console.Write( "Donner votre choix : ");
                string str = Console.ReadLine();
                if(str.Length!=0)
                    Choix = Char.ToLower(str.Trim()[0]);
            }
            while (Choix != 'a' && Choix != 'f' && Choix != 'q');
            return Choix;
        }

        static char ChoixAction2()
        {
            char Choix=' ';
            do
            {
                Console.Clear();
                Console.WriteLine( "***************************************************** \n");
                Console.WriteLine( "                  Fournisseur MENU                     \n");
                Console.WriteLine( "  A : AJOUT" );
                Console.WriteLine( "  S : SUPPRESSION" );
                Console.WriteLine( "  C : CONSULTATION PAR CODE" );
                Console.WriteLine( "  Q : QUITTER" );

                Console.WriteLine( "\n*****************************************************" );
                Console.Write( "Donner votre choix : ");
                string str = Console.ReadLine();
                if(str.Length!=0)
                    Choix = Char.ToLower(str.Trim()[0]);

            }
            while (Choix != 'a' && Choix != 's' && Choix != 'c' && Choix != 'q');
            return Choix;
        }

        static char ChoixAction3()
        {
            char Choix=' ';
            do
            {
                Console.Clear();
                Console.WriteLine( "***************************************************** \n");
                Console.WriteLine( "                     ARTICLE MENU                     \n");
                Console.WriteLine( "  A : AJOUT" );
                Console.WriteLine( "  S : SUPPRESSION" );
                Console.WriteLine( "  D : SUPPRESSION PAR CODE DE FOURNISSEUR" );
                Console.WriteLine( "  C : CONSULTATION PAR REFERENCE " );
                Console.WriteLine( "  V : CONSULTATION PAR CODE DE FOURNISSEUR" );
                Console.WriteLine( "  B : CONSULTATION" );
                Console.WriteLine( "  Q : QUITTER" );

                Console.WriteLine( "\n*****************************************************" );
                Console.Write( "Donner votre choix : ");
                string str = Console.ReadLine();
                if(str.Length!=0)
                    Choix = Char.ToLower(str.Trim()[0]);

            }
            while (Choix != 'a' && Choix != 's' && Choix != 'd' && Choix != 'c' && Choix != 'v' && Choix != 'b' && Choix != 'q');
            return Choix;
        }

        public static void Menu1()
        {
            char Choix;
            do
            {  
                Choix = ChoixAction1();
                switch (Choix)
                {
                    case 'f':
                        {
                            Menu2();
                            break;
                        }

                    case 'a':
                        {
                            Menu3();                            
                            break;
                            
                        }
                }
            } while (Choix != 'q');
        }

        public static void Menu2()
        {
            char Choix;
            do
            {  
                Choix = ChoixAction2();
                switch (Choix)
                {
                    case 'a':
                        {
                            Console.Clear();
                            Console.WriteLine( "\n************ Ajout ************" );
                            DALFournisseur.Add(ViewConsole.GetFournisseurFromInterface());                            
                            break;
                        }

                    case 's':
                        {
                            Console.Clear();
                            Console.WriteLine( "\n************ Suppression ************" );
                            Console.Write("\n\nDonner le code du fournisseur à supprimer : ");
                            DALFournisseur.Delete(Int32.Parse(Console.ReadLine()));                            
                            break;
                            
                        }

                    case 'c':
                        {
                            Console.Clear();
                            Console.WriteLine( "\n************ Consultation ************");
                            Fournisseur fournisseur = new Fournisseur();
                            Console.Write("\n\nDonner le code du fournisseur : ");
                            fournisseur = DALFournisseur.SelectByCode(Int32.Parse(Console.ReadLine()));
                            ViewConsole.ShowFournisseur(fournisseur); 
                            Console.Read();
                            break;
                        }
                }
            } while (Choix != 'q');
        }

        public static void Menu3()
        {
            char Choix;
            do
            {  
                Choix = ChoixAction3();
                switch (Choix)
                {
                    case 'a':
                        {
                            Console.Clear();
                            Console.WriteLine( "\n************ Ajout ************" );
                            DALArticles.Add(ViewConsole.GetArticleFromInterface());                            
                            break;
                        }

                    case 's':
                        {
                            Console.Clear();
                            Console.WriteLine( "\n************ Suppression ************" );
                            Console.Write("\n\nDonner la reference de l'article à supprimer : ");
                            DALArticles.Delete(Int32.Parse(Console.ReadLine()));                            
                            break;
                            
                        }

                    case 'd':
                        {
                            Console.Clear();
                            Console.WriteLine( "\n************ Suppression ************" );
                            Console.Write("\n\nDonner le code fournisseur des articles à supprimer : ");
                            DALArticles.DeleteByCodeF(Int32.Parse(Console.ReadLine()));                            
                            break;
                            
                        }

                    case 'c':
                        {
                            Console.Clear();
                            Console.WriteLine( "\n************ Consultation Par Reference ************"); 
                            Console.Write("\n\nDonner la reference de l'article à consulte : ");
                            Article article = DALArticles.SelectByRef(Int32.Parse(Console.ReadLine()));
                            Console.WriteLine("\n ------------------------- ");
                            ViewConsole.ShowArticle(article);
                            Console.Read();
                            break;
                        }

                    case 'v':
                        {
                            Console.Clear();
                            Console.WriteLine( "\n************ Consultation Par Fournisseur ************"); 
                            Console.Write("\n\nDonner le code fournisseur des articles à consulter : ");
                            List<Article> LesArticles = DALArticles.SelectByCodeF(Int32.Parse(Console.ReadLine()));
                            foreach (Article article in LesArticles)
                            {
                                Console.WriteLine("\n \n ------------------------- ");
                                ViewConsole.ShowArticle(article);
                            }
                            Console.Read();
                            break;
                        }

                    case 'b':
                        {
                            Console.Clear();
                            Console.WriteLine( "\n************ Consultation ************"); 
                            List<Article> LesArticles = DALArticles.SelectAll();
                            foreach (Article article in LesArticles)
                            {
                                Console.WriteLine("\n \n ------------------------- ");
                                ViewConsole.ShowArticle(article);
                            }
                            Console.Read();
                            break;
                        }
                }
            } while (Choix != 'q');
        }

    }

    
}