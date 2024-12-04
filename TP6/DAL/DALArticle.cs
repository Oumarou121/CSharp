using System;
using Models;
using MySql.Data.MySqlClient;

namespace DAL
{
    class DBConnection
    {        
        public static MySqlConnection GetConnection()
        {
            string strcnn = "Server=localhost;Database=TP6;User ID=root;Password=Mamoudou123;";
            return new MySqlConnection(strcnn);
        }
    }

    public class DALArticles
    {
        public static void Add(Article a){
            MySqlConnection conn = DBConnection.GetConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO Article (Reference, CodeF, Designation, Prix) VALUES (@reference, @codeF, @designation, @prix)", conn);
            cmd.Parameters.AddWithValue("@reference", a.Reference);
            cmd.Parameters.AddWithValue("@codeF", a.CodeF);
            cmd.Parameters.AddWithValue("@designation", a.Designation);
            cmd.Parameters.AddWithValue("@prix", a.Prix);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void Delete(int Ref){
            MySqlConnection conn = DBConnection.GetConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM Article WHERE Reference=@reference", conn);
            cmd.Parameters.AddWithValue("@reference", Ref);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void DeleteByCodeF(int codeF){
            MySqlConnection conn = DBConnection.GetConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM Article WHERE CodeF=@codeF", conn);
            cmd.Parameters.AddWithValue("@codeF", codeF);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static Article SelectByRef(int Ref){
            MySqlConnection conn = DBConnection.GetConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Article WHERE Reference=@reference", conn);
            cmd.Parameters.AddWithValue("@reference", Ref);
            MySqlDataReader reader = cmd.ExecuteReader();
            Article a = null;
            if (reader.Read()){
                a = new Article(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetDouble(3));
            }
            conn.Close();
            return a;
        }

        public static List<Article> SelectByCodeF(int codeF){
            MySqlConnection conn = DBConnection.GetConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Article WHERE CodeF=@codeF", conn);
            cmd.Parameters.AddWithValue("@codeF", codeF);
            MySqlDataReader reader = cmd.ExecuteReader();
            List<Article> lesArticles = new List<Article>();
            while (reader.Read()){
                lesArticles.Add(new Article(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetDouble(3)));
            }
            conn.Close();
            return lesArticles;
        }

        public static List<Article> SelectAll(){
            MySqlConnection conn = DBConnection.GetConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Article", conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            List<Article> lesArticles = new List<Article>();
            while (reader.Read()){
                lesArticles.Add(new Article(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetDouble(3)));
            }
            conn.Close();
            return lesArticles;
        }
    }
}