//Oumarou Mamoudou Saidou TD07 TP14
//C# TP1

using System;
using System.Collections.Generic;

class Program{

    static void Main(string[] args){
        // Exercice1
        Console.Write("Donner la valeur de A : ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Donner la valeur de B : ");
        int b = int.Parse(Console.ReadLine());

        int somme = a + b;

        Console.Write($"Leur somme : {somme}");

        //Exercice2
        Console.Write("Donner la tailler du tableau : ");
        int n = int.Parse(Console.ReadLine());
        int[] tab = new int[n];

        int somme = 0;
        for(int i = 0; i < n; i++){
            Console.Write($"Donner la valeur du {i+1} élément : ");
            tab[i] = int.Parse(Console.ReadLine());
            somme += tab[i];
        }
        Console.Write($"La somme : {somme}");

        //Exercice3
        Console.Write("Donner la valeur de A : ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Donner la valeur de B : ");
        int b = int.Parse(Console.ReadLine());
        int somme = sommeDeuxEntiers(a,b);
        Console.Write($"Leur somme : {somme}\n");
        Console.Write("Donner la tailler du tableau : ");
        int n = int.Parse(Console.ReadLine());
        int[] tab = new int[n];
        tab = saisieTableau(n);
        int sommeTab = sommeTableau(tab);
        Console.Write($"La somme des éléments du tableau : {sommeTab}\n");

        //Exercice4
        string str=" C# programming 2024 or Csharp programming 2024 ";
        Console.WriteLine("Taille de la chaîne : " + str.Length);

        int firstOcc = str.IndexOf('C');
        int lastOcc = str.LastIndexOf('C');
        Console.WriteLine("Position de la première occurrence de 'C' : " + firstOcc);
        Console.WriteLine("Position de la dernière occurrence de 'C' : " + lastOcc);

        str = str.Trim();

        string CSharp = str.Substring(str.IndexOf("C#"), 2);
        Console.WriteLine("Copie de 'C#' : " + CSharp);

        int nbrChiffres = 0;
        foreach (char c in str)
        {
            if (char.IsDigit(c))
            {
                nbrChiffres++;
            }
        }

        Console.WriteLine("Nombre de chiffres dans la chaîne : " + nbrChiffres);

        //Exercice5
        List<string> personnes = new List<string>();

        ajouter(personnes);
        ajouter(personnes);
        ajouter(personnes);
        ajouter(personnes);
        ajouter(personnes);

        supprimer(personnes);

        rechercher(personnes);

        afficher(personnes);

        trier(personnes);

        afficher(personnes);
        
        void ajouter(List<string> personnes){
            Console.Write("Donner le nom de la personne a ajouter : ");
            string nom = Console.ReadLine();
            
            personnes.Add(nom);
        }

        void supprimer(List<string> personnes){
            Console.Write("Donner le nom de la personne a supprimer : ");
            string nom = Console.ReadLine();
            
            personnes.Remove(nom);
        }

        void rechercher(List<string> personnes){
            Console.Write("Donner le nom de la personne a rechercher : ");
            string nom = Console.ReadLine();
            
            if(personnes.Contains(nom)){
                Console.Write("La personne existe dans le groupe .\n");
            }else{
                Console.Write("La personne n'existe pas dans le groupe .\n");
            }
        }

        void afficher(List<string> personnes){
            Console.Write("Voici la liste des personnes : \n");
            foreach(string personne in personnes){
                Console.Write(personne + "\n");
            }
        }

        void trier(List<string> personnes){
            personnes.Sort();
        }
    }

    //Exercice3
    public static int sommeDeuxEntiers(int a, int b){
        return a + b;
    }

    public static int[] saisieTableau(int n){
        int[] tab = new int[n];
        for(int i = 0; i < n; i++){
            Console.Write($"Donner la valeur du {i+1} élément : ");
            tab[i] = int.Parse(Console.ReadLine());            
        }
        return tab;
    }

    public static int sommeTableau(int[] tab){
        int somme = 0;
        foreach(int i in tab){
            somme += i;
        }
        return somme;
    }
}