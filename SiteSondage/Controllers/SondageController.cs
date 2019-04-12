using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteSondage.Models;

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
        public ActionResult PageSupprimer()
        {
            return View();
        }
        public ActionResult PageVoter(int idSondage)
        {
            
            return View(DataAcces.RecupererEnBdd(idSondage));
        }
        public ActionResult RecuperationVote(int idSondage, string ResultatChoix1, string ResultatChoix2, string ResultatChoix3, string ResultatChoix4)
        {
        
            
            DataAcces.InsererResultatEnBDD( idSondage, Fonction.VerifiSiEstNull(ResultatChoix1), Fonction.VerifiSiEstNull(ResultatChoix2), Fonction.VerifiSiEstNull(ResultatChoix3), Fonction.VerifiSiEstNull(ResultatChoix4));
            return RedirectToAction("PageResultat");
        }
        public ActionResult PageVoteEffectue()
        {
            return View();
        }
        public ActionResult PageResultat( int idSondage)
        {
            
            return View(DataAcces.RecupererResultatEnBdd(idSondage));
        }
        public ActionResult CreationSondage( string Question, string Choix1, string Choix2, string Choix3, string Choix4, bool? ChoixMultiplePeutEtreNull)
        {
            bool choixMultiple = ChoixMultiplePeutEtreNull.GetValueOrDefault(false);

            ClassSondage sondage = new ClassSondage(0, Question, Choix1, Choix2, Choix3, Choix4, choixMultiple);
            CreationSondage Sondage = new CreationSondage(sondage);
             int idSondageCree = DataAcces.InsererEnBDD(sondage);
            
            
             return RedirectToAction("PageChoix", new { idSondage = idSondageCree });

          


        }





    }



}