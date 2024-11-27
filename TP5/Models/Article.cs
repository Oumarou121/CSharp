using System;

namespace Models
{
    public class Article{
        private int reference;
        private string designation;
        private float prix;

        public Article(){}

        public Article(int reference, string designation, float prix){
            this.reference = reference;
            this.designation = designation;
            this.prix = prix;
        }

        public int Reference{
            get { return reference; }
            set { reference = value; }
        }

        public string Designation{
            get { return designation; }
            set { designation = value; } 
        }

        public float Prix{
            get { return prix; }
            set { prix = value; }

        }
    }
}