using SiteSondage.Models;
using System;
using System.Web;
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
        public ActionResult PageVoirResultatEtVote(int idSondage)
        {

            return View(DataAcces.RecupererEnBdd(idSondage));
        }
        // page qui indique que le sondage est deja supprimer
        public ActionResult PageDejaSupprimer(int idSondage, int numeroSecurite)
        {
            ClassSondage sondage = DataAcces.RecupererSondagePourDesactiver(idSondage, numeroSecurite);
            return View(sondage);

        }
        // page qui indique que que le votant a deja voté sur le sondage et qu il ne peut plus revoter
        public ActionResult PageDejaVoter(int idSondage , int numeroSecurite)
        {
            ClassSondage sondage = DataAcces.RecupererSondagePourDesactiver(idSondage, numeroSecurite);
            return View(sondage);
            
        }
        // page ou se situe les liens pour voter , supprimer et voir résultat du sondage
        public ActionResult PageChoix(int idSondage)
        {

            return View(DataAcces.RecupererEnBdd(idSondage));

        }
        public ActionResult PageSupprimer(int idSondage, int numeroSecurite)
        {
            ClassSondage sondage = DataAcces.RecupererSondagePourDesactiver(idSondage, numeroSecurite);
            if (sondage.EtatDuSondage == false)
            {
                DataAcces.MetAJourEtatDuSOndage(sondage);
                return View(sondage);
            }
            else 
            {
                return RedirectToAction("PageDejaSupprimer", new { IdSondage = idSondage, NumeroSecurite = numeroSecurite });
            }
            
        }
        // page ou le votant vote
        public ActionResult PageVoter(int idSondage, int numeroSecurite)
        {
            ClassSondage sondage = DataAcces.RecupererSondagePourDesactiver(idSondage, numeroSecurite);
            if (sondage.EtatDuSondage == false)
            {
                return View(DataAcces.RecupererSondagePourDesactiver(idSondage, numeroSecurite));
            }
            else
            {
                return RedirectToAction("PageDejaSupprimer", new { IdSondage = idSondage , NumeroSecurite = numeroSecurite });
            }

        }
        // Récupère les choix du votant lorsque le sondage est à choix multiple
        public ActionResult RecuperationVoteChoixMultiple(int idSondage, string ResultatChoix1, string ResultatChoix2, string ResultatChoix3, string ResultatChoix4, int numeroSecurite)
        {
            if (TestSondagevote(Request.Cookies, idSondage))
            {
                return RedirectToAction("PageDejaVoter", new { IdSondage = idSondage, NumeroSecurite = numeroSecurite });
            }

            DataAcces.InsererResultatEnBDD(idSondage, ClassResultat.ValeurDuCHoix(ResultatChoix1), ClassResultat.ValeurDuCHoix(ResultatChoix2), ClassResultat.ValeurDuCHoix(ResultatChoix3), ClassResultat.ValeurDuCHoix(ResultatChoix4));
            SauvegardeDesCookie(idSondage);
            return RedirectToAction("PageResultat", new { IdSondage = idSondage });
        }

        // Récupère le choix du votant lorsque le sondage est à choix unique
        public ActionResult RecuperationVoteChoixUnique(int idSondage, string resultatchoix, int numeroSecurite)
        {
            if (TestSondagevote(Request.Cookies, idSondage))
            {
                return RedirectToAction("PageDejaVoter", new { IdSondage = idSondage , NumeroSecurite = numeroSecurite });
            }
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


            DataAcces.InsererResultatEnBDD(idSondage, Vote.ResultatChoix1, Vote.ResultatChoix2, Vote.ResultatChoix3, Vote.ResultatChoix4);
            SauvegardeDesCookie(idSondage);
            return RedirectToAction("PageResultat", new { IdSondage = idSondage });
        }



        // Recupère en base de donnée les résultats et les affiches dans le view résultat
        public ActionResult PageResultat(int idSondage)
        {
            ClassResultat Sondage = DataAcces.RecupererResultatEnBdd(idSondage);
            Sondage.PoucentageChoix1 = ClassResultat.PourcentageVote(Sondage.ResultatChoix1, Sondage.NombreDevotant);
            Sondage.PoucentageChoix2 = ClassResultat.PourcentageVote(Sondage.ResultatChoix2, Sondage.NombreDevotant);
            Sondage.PoucentageChoix3 = ClassResultat.PourcentageVote(Sondage.ResultatChoix3, Sondage.NombreDevotant);
            Sondage.PoucentageChoix4 = ClassResultat.PourcentageVote(Sondage.ResultatChoix4, Sondage.NombreDevotant);
            return View(Sondage);
        }
        // enregiste sondage en base de donnée lorsqu il est crée 
        public ActionResult CreationSondage(string Question, string Choix1, string Choix2, string Choix3, string Choix4, bool? ChoixMultiplePeutEtreNull)
        {
            bool choixMultiple = ChoixMultiplePeutEtreNull.GetValueOrDefault(false);
            Random aleatoire = new Random();
            int cleSecurite = aleatoire.Next(1000, 100000);
            ClassSondage sondage = new ClassSondage(0, Question, Choix1, Choix2, Choix3, Choix4, choixMultiple, false, cleSecurite);

            int idSondageCree = DataAcces.InsererEnBDD(sondage);


            return RedirectToAction("PageChoix", new { idSondage = idSondageCree });




        }
        // Gestion des cookies pour eviter de voter 2 fois pour un même sondage
        public void SauvegardeDesCookie(int idSondage)
        {
            string Votant = Request.UserHostAddress;
            HttpCookie gestionCookies = new HttpCookie("cookie" + idSondage);
            gestionCookies.Value = "";
            gestionCookies.Expires = DateTime.MaxValue;
            this.Response.Cookies.Add(gestionCookies);
        }


        public static bool TestSondagevote(HttpCookieCollection cookies, int idSondage)
        {
            return cookies["cookie" + idSondage] != null;
        }



    }



}