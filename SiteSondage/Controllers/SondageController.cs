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

            DataAcces.InsererResultatEnBDD(idSondage, Fonction.VerifiSiEstNull(ResultatChoix1), Fonction.VerifiSiEstNull(ResultatChoix2), Fonction.VerifiSiEstNull(ResultatChoix3), Fonction.VerifiSiEstNull(ResultatChoix4));
            return RedirectToAction("PageResultat", new { IdSondage = idSondage });
        }


        public ActionResult RecuperationVoteChoixUnique(int idSondage, string resultatchoix)
        {


            DataAcces.InsererResultatEnBDD(idSondage, Fonction.VerifiSiEstNull(Fonction.ListeChoix1(resultatchoix)), Fonction.VerifiSiEstNull(Fonction.ListeChoix2(resultatchoix)), Fonction.VerifiSiEstNull(Fonction.ListeChoix3(resultatchoix)), Fonction.VerifiSiEstNull(Fonction.ListeChoix4(resultatchoix)));
            return RedirectToAction("PageResultat", new { IdSondage = idSondage });
        }



        
        public ActionResult PageResultat(int idSondage)
        {
            ClassResultat model = DataAcces.RecupererResultatEnBdd(idSondage);
            model.PoucentageChoix1 = ClassResultat.PourcentageVote(model.ResultatChoix1, model.NombreDevotant);
            model.PoucentageChoix2 = ClassResultat.PourcentageVote(model.ResultatChoix2, model.NombreDevotant);
            model.PoucentageChoix3 = ClassResultat.PourcentageVote(model.ResultatChoix3, model.NombreDevotant);
            model.PoucentageChoix4 = ClassResultat.PourcentageVote(model.ResultatChoix4, model.NombreDevotant);
            return View(model);
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