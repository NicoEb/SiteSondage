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

        public static string ListeChoix1(string Choix)
        {
            string ResultatChoix1 = "Choix1"; /*string ResultatChoix2 = "Choix2"; string ResultatChoix3 = "Choix3"; string ResultatChoix4 = "Choix4";
*/

            if (Choix == ResultatChoix1)
            {
                ResultatChoix1 = "1";
            }
            else
            {
                ResultatChoix1 = null;



            }

            return ResultatChoix1;



        }
        public static string ListeChoix2(string Choix)
        {
            string ResultatChoix2 = "Choix2"; /*string ResultatChoix2 = "Choix2"; string ResultatChoix3 = "Choix3"; string ResultatChoix4 = "Choix4";
*/

            if (Choix == ResultatChoix2)
            {
                ResultatChoix2 = "1";
            }
            else
            {

                ResultatChoix2 = null;


            }

            return ResultatChoix2;



        }
        public static string ListeChoix3(string Choix)
        {
            string ResultatChoix3 = "Choix3"; /*string ResultatChoix2 = "Choix2"; string ResultatChoix3 = "Choix3"; string ResultatChoix4 = "Choix4";
*/

            if (Choix == ResultatChoix3)
            {
                ResultatChoix3 = "1";
            }
            else
            {

                ResultatChoix3 = null;


            }

            return ResultatChoix3;



        }
        public static string ListeChoix4(string Choix)
        {
            string ResultatChoix4 = "Choix4"; /*string ResultatChoix2 = "Choix2"; string ResultatChoix3 = "Choix3"; string ResultatChoix4 = "Choix4";
*/

            if (Choix == ResultatChoix4)
            {
                ResultatChoix4 = "1";
            }
            else
            {

                ResultatChoix4 = null;


            }

            return ResultatChoix4;



        }
    }
}