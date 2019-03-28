using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteSondage.Models
{
    public class ClassSondage
    {
        public string Question { get; private set; }
        public string Choix1 { get; private set; }
        public string Choix2 { get; private set; }
        public string Choix3 { get; private set; }
        public string Choix4 { get; private set; }
        public bool ChoixMultiple { get; private set; }

        public int NombreVotant { get; private set; }

        public int ResultatChoix1 { get; private set; }
        public int ResultatChoix2 { get; private set; }
        public int ResultatChoix3 { get; private set; }
        public int ResultatChoix4 { get; private set; }

        public ClassSondage(string question, string choix1, string choix2, string choix3, string choix4, bool choixMultiple, int nombreVotant, int resultatChoix1, int resultatChoix2, int resultatChoix3, int resultatChoix4)
        {
            Question = question;
            Choix1 = choix1;
            Choix2 = choix2;
            Choix3 = choix3;
            Choix4 = choix4;
            ChoixMultiple = choixMultiple;
            NombreVotant = nombreVotant;
            ResultatChoix1 = resultatChoix1;
            ResultatChoix2 = resultatChoix2;
            ResultatChoix3 = resultatChoix3;
            ResultatChoix4 = resultatChoix4;
        }
    }
}