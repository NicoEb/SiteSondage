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
        public ActionResult PageChoix()
        {
            return View();
        }
        public ActionResult PageSupprimer()
        {
            return View();
        }
        public ActionResult PageVoter(int idSondage)
        {
            ClassSondage sondage = DataAcces.RecupererEnBdd(idSondage);
            return View(sondage);
        }
        public ActionResult PageVoteEffectue()
        {
            return View();
        }
        public ActionResult PageResultat()
        {
            
            return View();
        }
        public ActionResult CreationSondage( string Question, string Choix1, string Choix2, string Choix3, string Choix4, bool? ChoixMultiplePeutEtreNull)
        {
            bool choixMultiple = ChoixMultiplePeutEtreNull.GetValueOrDefault(false);

            ClassSondage sondage = new ClassSondage( Question, Choix1, Choix2, Choix3, Choix4, choixMultiple);
            CreationSondage Sondage = new CreationSondage(sondage);
             int idSondageCree = DataAcces.InsererEnBDD(sondage);
            
            
             return RedirectToAction("PageChoix", new { idSondage = idSondageCree });

          


        }





    }



}