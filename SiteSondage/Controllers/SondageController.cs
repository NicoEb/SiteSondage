using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteSondage.Controllers
{
    public class SondageController : Controller
    {
        // GET: Sondage
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
        public ActionResult PageVoter()
        {
            return View();
        }
        public ActionResult PageVoteEffectue()
        {
            return View();
        }
        public ActionResult PageResultat()
        {
            return View();
        }
    }
}