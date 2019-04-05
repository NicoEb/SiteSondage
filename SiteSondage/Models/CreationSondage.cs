using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteSondage.Models
{
    public class CreationSondage
    {
        public ClassSondage NouveauSondage { get; private set; }

        public CreationSondage(ClassSondage nouveauSondage)
        {
            NouveauSondage = nouveauSondage;
        }
    }
}