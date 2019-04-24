using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteSondage.Models
{
    public class ClassResultat
    {
        public ClassSondage Vote { get; private set; }

        public int ResultatChoix1 { get; set; }
        public int ResultatChoix2 { get;  set; }
        public int ResultatChoix3 { get;  set; }
        public int ResultatChoix4 { get;  set; }

        public int NombreDevotant { get;  set; }

        public int PoucentageChoix1 { get;  set; }
        public int PoucentageChoix2 { get; set; }
        public int PoucentageChoix3 { get; set; }
        public int PoucentageChoix4 { get; set; }

        public ClassResultat(ClassSondage vote, int resultatChoix1, int resultatChoix2, int resultatChoix3, int resultatChoix4, int nombreDevotant)
        {
            Vote = vote;
            ResultatChoix1 = resultatChoix1;
            ResultatChoix2 = resultatChoix2;
            ResultatChoix3 = resultatChoix3;
            ResultatChoix4 = resultatChoix4;
            NombreDevotant = nombreDevotant;
        }

        public ClassResultat()
        {
        }

        public ClassResultat(int resultatChoix1, int resultatChoix2, int resultatChoix3, int resultatChoix4, int nombreDevotant)
        {
            ResultatChoix1 = resultatChoix1;
            ResultatChoix2 = resultatChoix2;
            ResultatChoix3 = resultatChoix3;
            ResultatChoix4 = resultatChoix4;
            NombreDevotant = nombreDevotant;
        }
        // Convertie vote en pourcentage , méthode utilisé dans la page résultat
        public static int PourcentageVote(int nombreVote ,int NombreDevotant)
        {
            int resultat;
            if (NombreDevotant == 0)
            {

                resultat = 0;
            }
            else
            {
                resultat = nombreVote * 100 / (NombreDevotant);
            }
           
            return resultat; 
        }
        //Méthode qui donne valeur de 0 ou 1 a la checkbox lorsque que l'on vote en choix multiple
        public static int ValeurDuCHoix(string Parametre)
        {
            int Choix = 0;
            if (Parametre != null)
            {

                Choix = 1;
            }


            return Choix;
        }

    }
}