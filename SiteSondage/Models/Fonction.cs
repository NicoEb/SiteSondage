using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteSondage.Models
{
    public class Fonction
    {

        public static int VerifiSiEstNull(string Parametre)
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