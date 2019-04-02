using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteSondage.Models
{
    public class ClassVoter
    {
        public ClassSondage Vote { get; private set; }
        public int NombreVotant { get; private set; }

        public ClassVoter(ClassSondage vote, int nombreVotant)
        {
            Vote = vote;
            NombreVotant = nombreVotant;
        }
    }
}