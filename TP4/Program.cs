using System;
using MySql.Data.MySqlClient;

class Program
{
    static string connectionString = "Server=localhost;Database=Stock;User ID=root;Password=Mamoudou123;";

    static void Main(string [] args)
    {
        while(true){
            Console.WriteLine("0 : Ajouter un article");
            Console.WriteLine("1 : Modifier un article");
            Console.WriteLine("2 : Supprimer un article");
            Console.WriteLine("3 : Quitter");
            Console.Write("Donner votre choix : ");
            int choix = int.Parse(Console.ReadLine());
            switch(choix){
                case 0:
                    Console.Write("Donner la Reference de l'article à ajouter : ");
                    int ArticleReference = int.Parse(Console.ReadLine());
                    Console.Write("Donner la Designation de l'article à ajouter : ");
                    string ArticleDesignation = Console.ReadLine();
                    Console.Write("Donner le Prix de l'article à ajouter : ");
                    float ArticlePrix = float.Parse(Console.ReadLine());
                    Ajouter(ArticleReference, ArticleDesignation, ArticlePrix);
                    break;
                case 1:
                    Console.Write("Donner la Reference de l'article à modifier : ");
                    int ArticleReferenceUp = int.Parse(Console.ReadLine());
                    Console.Write("Donner le nouveau Prix de l'article : ");
                    float ArticlePrixUp = float.Parse(Console.ReadLine());
                    Modifier(ArticleReferenceUp, ArticlePrixUp);
                    break;
                case 2:
                    Console.Write("Donner la Reference de l'article à supprimer : ");
                    int ArticleReferenceDel = int.Parse(Console.ReadLine());
                    Supprimer(ArticleReferenceDel);
                    break;
                case 3:
                    Console.Write("Au revoir!");
                    return;

                default:
                    Console.WriteLine("Votre choix est incorrect, veuillez réessayer.");
                    break;
            }
        }
    }  

    /*
    PartieI
    static void Ajouter(MySqlConnection conn){
        string query = "INSERT INTO Article VALUES (1, 'chaise', 150)";
        MySqlCommand cmd = new MySqlCommand(query, conn);
        cmd.ExecuteNonQuery();
    }

    static void Modifier(MySqlConnection conn){
        string query = "UPDATE Article SET Prix = 250 WHERE Reference = 1";
        MySqlCommand cmd = new MySqlCommand(query, conn);
        cmd.ExecuteNonQuery();
    }

    static void Supprimer(MySqlConnection conn){
        string query = "DELETE FROM Article WHERE Reference = 1";
        MySqlCommand cmd = new MySqlCommand(query, conn);
        cmd.ExecuteNonQuery();
    }
    */

    //ParieII
    static void Ajouter(int reference, string designation, float prix){
        
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            try
                {
                    conn.Open();
                    string query = "INSERT INTO Article VALUES (@Reference, @Designation, @Prix)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Reference", reference);
                    cmd.Parameters.AddWithValue("@Designation", designation);
                    cmd.Parameters.AddWithValue("@Prix", prix);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Article ajouté avec succès!");
                }
            catch (Exception ex)
                {
                    Console.WriteLine("Échec : " + ex.Message);
                }
        }

    }

    static void Modifier(int reference, float prix){
        
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            try
                {
                    conn.Open();
                    string query = "UPDATE Article SET Prix = @newPrix WHERE Reference = @Reference";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Reference", reference);
                    cmd.Parameters.AddWithValue("@newPrix", prix);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Article mis à jour avec succès!");
                }
            catch (Exception ex)
                {
                    Console.WriteLine("Échec : " + ex.Message);
                }
        }
        
    }

    static void Supprimer(int reference){
        
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            try
                {
                    conn.Open();
                    string query = "DELETE FROM Article WHERE Reference = @Reference";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Reference", reference);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Article supprimé avec succès!");
                }
            catch (Exception ex)
                {
                    Console.WriteLine("Échec : " + ex.Message);
                }
        }
    }
}