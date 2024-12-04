using System;

namespace Models
{
    public class Article{
        private int reference;
        private int codeF;
        private string designation;
        private double prix;

        public Article(){}

        public Article(int reference, int codeF, string designation, double prix){
            this.reference = reference;
            this.codeF = codeF;
            this.designation = designation;
            this.prix = prix;
        }

        public int Reference{
            get { return reference; }
            set { reference = value; }
        }

        public int CodeF{
            get{ return codeF; }
            set { codeF = value; }
        }

        public string Designation{
            get { return designation; }
            set { designation = value; } 
        }

        public double Prix{
            get { return prix; }
            set { prix = value; }

        }
    }
}