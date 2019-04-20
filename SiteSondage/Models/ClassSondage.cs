using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteSondage.Models
{
    public class ClassSondage
    {
        public int IdSondage { get; private set; }
        public string Question { get; private set; }
        public string Choix1 { get; private set; }
        public string Choix2 { get; private set; }
        public string Choix3 { get; private set; }
        public string Choix4 { get; private set; }
        public bool ChoixMultiple { get; private set; }
        public bool EtatDuSondage { get;  private set; }

        public int NumeroSecurite { get; private set; }

        public ClassSondage(int idSondage, string question, string choix1, string choix2, string choix3, string choix4, bool choixMultiple, bool etatDuSondage, int numeroSecurite)
        {
            IdSondage = idSondage;
            Question = question;
            Choix1 = choix1;
            Choix2 = choix2;
            Choix3 = choix3;
            Choix4 = choix4;
            ChoixMultiple = choixMultiple;
            EtatDuSondage = etatDuSondage;
            NumeroSecurite = numeroSecurite;
        }
    }
}