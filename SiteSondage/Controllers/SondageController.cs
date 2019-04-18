using SiteSondage.Models;
using System;
using System.Web.Mvc;

namespace SiteSondage.Controllers
{
    public class SondageController : Controller
    {

        public ActionResult PageAccueil()
        {
            return View();
        }
        public ActionResult PageSondage()
        {

            return View();
        }
        public ActionResult PageChoix(int idSondage)
        {
            return View(DataAcces.RecupererEnBdd(idSondage));

        }
        public ActionResult PageSupprimer(int idSondage, int numeroSecurite)
        {
            ClassResultat sondage = DataAcces.RecupererSondagePourDesactiver(idSondage, numeroSecurite);
            if (sondage != null)
            {
                DataAcces.MetAJourEtatDuSOndage(sondage);
                return View(sondage);
            }
            return View();
        }

        public ActionResult PageVoter(int idSondage)
        {

            return View(DataAcces.RecupererEnBdd(idSondage));
        }

        public ActionResult RecuperationVoteChoixMultiple(int idSondage, string ResultatChoix1, string ResultatChoix2, string ResultatChoix3, string ResultatChoix4)
        {

            DataAcces.InsererResultatEnBDD(idSondage, ClassResultat.VerifiSiEstNull(ResultatChoix1), ClassResultat.VerifiSiEstNull(ResultatChoix2), ClassResultat.VerifiSiEstNull(ResultatChoix3), ClassResultat.VerifiSiEstNull(ResultatChoix4));
            return RedirectToAction("PageResultat", new { IdSondage = idSondage });
        }


        public ActionResult RecuperationVoteChoixUnique(int idSondage, string resultatchoix)
        {
             ClassResultat Vote = new ClassResultat(0, 0, 0, 0, idSondage);
            switch (resultatchoix)
            {
                case "Choix1":
                    Vote.ResultatChoix1 = 1;
                    break;

                case "Choix2":
                    Vote.ResultatChoix2 = 1;
                    break;
                case "Choix3":
                    Vote.ResultatChoix3 = 1;
                    break;
                case "Choix4":
                    Vote.ResultatChoix4 = 1;
                    break;
            }


                    DataAcces.InsererResultatEnBDD(idSondage, Vote.ResultatChoix1, Vote.ResultatChoix2, Vote.ResultatChoix3, Vote.ResultatChoix4 );
            return RedirectToAction("PageResultat", new { IdSondage = idSondage });
        }



        
        public ActionResult PageResultat(int idSondage)
        {
            ClassResultat Sondage = DataAcces.RecupererResultatEnBdd(idSondage);
            Sondage.PoucentageChoix1 = ClassResultat.PourcentageVote(Sondage.ResultatChoix1, Sondage.NombreDevotant);
            Sondage.PoucentageChoix2 = ClassResultat.PourcentageVote(Sondage.ResultatChoix2, Sondage.NombreDevotant);
            Sondage.PoucentageChoix3 = ClassResultat.PourcentageVote(Sondage.ResultatChoix3, Sondage.NombreDevotant);
            Sondage.PoucentageChoix4 = ClassResultat.PourcentageVote(Sondage.ResultatChoix4, Sondage.NombreDevotant);
            return View(Sondage);
        }
        public ActionResult CreationSondage(string Question, string Choix1, string Choix2, string Choix3, string Choix4, bool? ChoixMultiplePeutEtreNull)
        {
            bool choixMultiple = ChoixMultiplePeutEtreNull.GetValueOrDefault(false);
            Random aleatoire = new Random();
            int cleSecurite = aleatoire.Next(1000, 100000);
            ClassSondage sondage = new ClassSondage(0, Question, Choix1, Choix2, Choix3, Choix4, choixMultiple, false, cleSecurite);
          
            int idSondageCree = DataAcces.InsererEnBDD(sondage);


            return RedirectToAction("PageChoix", new { idSondage = idSondageCree });




        }





    }



}