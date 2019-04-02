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
            ClassSondage sondage = DataAcces.RecupererEnBdd();
            return View(sondage);
        }
        public ActionResult PageChoix()
        {
            return View();
        }
        public ActionResult PageSupprimer()
        {
            return View();
        }
        public ActionResult PageVoter()
        {
            ClassVoter vote = DataAcces.RecupererEnBdd1();
            return View(vote);
        }
        public ActionResult PageVoteEffectue()
        {
            return View();
        }
        public ActionResult PageResultat()
        {
            ClassSondage resultat = DataAcces.RecupererEnBdd();
            return View(resultat);
        }
       
        
    }
}