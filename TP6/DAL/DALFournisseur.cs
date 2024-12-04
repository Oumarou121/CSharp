using System;
using Models.Fournisseur;
using Models;
using DAL;
using System.Collections.Generic;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace DAL.DALFournisseur
{
    class DBConnection
    {        
        public static MySqlConnection GetConnection()
        {
            string strcnn = "Server=localhost;Database=TP6;User ID=root;Password=Mamoudou123;";
            return new MySqlConnection(strcnn);
        }
    }

    public class DALFournisseur
    {
        public static void Add(Fournisseur a){
            MySqlConnection conn = DBConnection.GetConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO Fournisseur (Code, Nom) VALUES (@code, @nom)", conn);
            cmd.Parameters.AddWithValue("@code", a.Code);
            cmd.Parameters.AddWithValue("@nom", a.Nom);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void Delete(int code){
            MySqlConnection conn = DBConnection.GetConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM Fournisseur WHERE Code=@code", conn);
            cmd.Parameters.AddWithValue("@code", code);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static Fournisseur SelectByCode(int code){
            MySqlConnection conn = DBConnection.GetConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Fournisseur WHERE Code=@code", conn);
            cmd.Parameters.AddWithValue("@code", code);
            MySqlDataReader reader = cmd.ExecuteReader();
            Fournisseur a = null;
            if (reader.Read()){
                a = new Fournisseur(reader.GetInt32(0), reader.GetString(1));
            }

            List<Article> lesArticles = DALArticles.SelectByCodeF(code);
            a.LesArticles = lesArticles;
            conn.Close();
            return a;
        }

    }    
}