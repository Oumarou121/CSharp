using System;
using Models;
using System.Collections.Generic;

namespace Models.Fournisseur
{
    public class Fournisseur
    {
        private int code;
        private string nom;
        private List<Article> lesArticles;

        public Fournisseur(){}

        public Fournisseur(int code, string nom){
            this.code = code;
            this.nom = nom;
            lesArticles = new List<Article>();
        }

        public int Code{
            get { return code; }
            set { code = value; }
        }

        public string Nom{
            get { return nom; }
            set { nom = value; }
        }

        public List<Article> LesArticles{
            get { return lesArticles; }
            set { lesArticles = value; }
        }

    }
}