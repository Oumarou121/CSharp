using System;

namespace Models
{
    public class Article{
        private int Reference;
        private string Designation;
        private float Prix;

        public Article(){}

        public Article(int reference, string des, float prix){
            this.Reference = reference;
            this.Designation = des;
            this.Prix = prix;
        }

        public int reference{
            get { return Reference; }
            set { Reference = value;}
        }

        public string designation{
            get { return Designation; }
            set { Designation = value; }
        }

        public float prix{
            get { return Prix; }
            set { Prix = value; }
        }

        public void Saisir(){
            Console.Write("Donner la reference de l'article : ");
            int reference = int.Parse(Console.ReadLine());

            Console.Write("Donner la designation de l'article : ");
            string des = Console.ReadLine();

            Console.Write("Donner le prix de l'article : ");
            float prix = float.Parse(Console.ReadLine());

            this.Reference = reference;
            this.Designation = des;
            this.Prix = prix;
        }

        public void Afficher(){
            Console.WriteLine("Les donner de l'article : ");
            Console.WriteLine("La reference : " + this.Reference);
            Console.WriteLine("La Designation : " + this.Designation);
            Console.WriteLine("Le Prix : " + this.Prix);
        }

    }

}