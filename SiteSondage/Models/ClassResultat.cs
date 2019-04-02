using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteSondage.Models
{
    public class ClassResultat
    {
        public ClassSondage Sondage { get; private set; }
       

        public int ResultatChoix1 { get; private set; }
        public int ResultatChoix2 { get; private set; }
        public int ResultatChoix3 { get; private set; }
        public int ResultatChoix4 { get; private set; }
        public int NombreVotant { get; private set; }

        public ClassResultat(ClassSondage sondage, int resultatChoix1, int resultatChoix2, int resultatChoix3, int resultatChoix4, int nombreVotant)
        {
            Sondage = sondage;
            ResultatChoix1 = resultatChoix1;
            ResultatChoix2 = resultatChoix2;
            ResultatChoix3 = resultatChoix3;
            ResultatChoix4 = resultatChoix4;
            NombreVotant = nombreVotant;
        }
    }
}