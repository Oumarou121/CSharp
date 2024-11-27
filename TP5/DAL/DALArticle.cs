using System;
using Models;
using MySql.Data.MySqlClient;

namespace DAL
{
    class DBConnection
    {        
        public static MySqlConnection GetConnection()
        {
            string strcnn = "Server=localhost;Database=Stock;User ID=root;Password=Mamoudou123;";
            return new MySqlConnection(strcnn);
        }
    }

    public class DALArticle
    {
        public static void Insert(Article article)
        {
            MySqlConnection cnn = DBConnection.GetConnection();
            cnn.Open();
            string strsql = @"INSERT INTO Article VALUES(?,?,?)";
            MySqlCommand cmd = new MySqlCommand(strsql, cnn);            

            MySqlParameter Reference = new MySqlParameter("Reference", article.Reference);
            MySqlParameter Designation = new MySqlParameter("Designation", article.Designation);
            // Designation.Value = article.Designation;

            MySqlParameter Prix = new MySqlParameter("Prix", article.Prix);
            // Prix.Value = article.Prix;

            cmd.Parameters.AddRange(new MySqlParameter[]{ Reference, Designation, Prix });
         
            cmd.ExecuteNonQuery();
            cnn.Close();
         }

        public static void Delete(int Reference)
        {
            MySqlConnection cnn = DBConnection.GetConnection();
            cnn.Open();
            string strsql = @"DELETE FROM Article WHERE Reference = ?";
            MySqlCommand cmd = new MySqlCommand(strsql, cnn);

            MySqlParameter reference = new MySqlParameter("Reference", Reference);
            
            cmd.Parameters.Add(reference);
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static void Update(int OldReference, Article newarticle)
        {
            MySqlConnection cnn = DBConnection.GetConnection();
            cnn.Open();
            string strsql = @"UPDATE Article SET Reference =?, Designation =?, Prix =? WHERE Reference = ?";

            MySqlCommand cmd = new MySqlCommand(strsql, cnn);

            cmd.Parameters.Add(new MySqlParameter("NewReference", newarticle.Reference));
            cmd.Parameters.Add(new MySqlParameter("Designation", newarticle.Designation));
            cmd.Parameters.Add(new MySqlParameter("Prix", newarticle.Prix));
            cmd.Parameters.Add(new MySqlParameter("OldReference", OldReference));
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static Article SelectByInv(int Reference)
        {
            Article article = new Article();
            MySqlConnection cnn = DBConnection.GetConnection();
            cnn.Open();
            string strsql = @"SELECT * FROM Article WHERE Reference = ?";
            MySqlCommand cmd = new MySqlCommand(strsql, cnn);
            cmd.Parameters.Add(new MySqlParameter("Reference", Reference));
            MySqlDataReader rd = cmd.ExecuteReader();

            if (rd!=null)
            {
                if(rd.Read())
                {
                    article.Reference = rd.GetInt32(0);
                    article.Designation = rd.GetString(1);
                    article.Prix = (float)rd.GetDecimal(2);
            
                }
            }
            return article;
        }

        // public static List<Article> SelectAll()
        // {
        //     List<Article> LesArticles = new List<Article>();
        //     MySqlConnection cnn = DBConnection.GetConnection();
        //     cnn.Open();
        //     string strsql = @"SELECT * FROM Article";
        //     MySqlCommand cmd = new MySqlCommand(strsql, cnn);
        //     MySqlDataAdapter DA = new MySqlDataAdapter(strsql, cnn);
        //     DataTable dt = new DataTable("Article");
        //     DA.Fill(dt);
        //     foreach (DataRow dr in dt.Rows)
        //     {
        //         LesArticles.Add(new Article((int)dr[0], dr[1].ToString(), (float)dr[2]));                                                                                        
        //     }
        //     return LesArticles;
        // }

        public static List<Article> SelectAll()
{
    List<Article> LesArticles = new List<Article>();

    using (MySqlConnection cnn = DBConnection.GetConnection())
    {
        cnn.Open();
        string strsql = "SELECT * FROM Article";

        using (MySqlCommand cmd = new MySqlCommand(strsql, cnn))
        {
            using (MySqlDataReader rd = cmd.ExecuteReader())
            {
                while (rd.Read())
                {
                    LesArticles.Add(new Article(
                        rd.GetInt32(0),        // Reference
                        rd.GetString(1),       // Designation
                        (float)rd.GetDecimal(2)       // Prix
                    ));
                }
            }
        }
    }

    return LesArticles;
}


        //public static List<Article> SelectByCriterium(string FieldName, string FieldValue)
        //{
        //}
    }
}