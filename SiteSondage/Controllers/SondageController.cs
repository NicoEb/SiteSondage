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
        public ActionResult CreationSondage(int? IdSondage, string Question, string Choix1, string Choix2, string Choix3, string Choix4, bool? ChoixMultiplePeutEtreNull)
        {
            bool choixMultiple = ChoixMultiplePeutEtreNull.GetValueOrDefault(false);

            ClassSondage sondage = new ClassSondage(IdSondage, Question, Choix1, Choix2, Choix3, Choix4, choixMultiple);
            CreationSondage Sondage = new CreationSondage(sondage);
            DataAcces.InsererEnBDD(sondage);



            if (DataAcces.RecupererIdLivreSondade(sondage, out ClassSondage idSondage))
            {
                return RedirectToAction("PageVoter", new { idSondage = sondage.IdSondage });

            }
            else
            {
                string messageErreur = "Probleme en recuperant Id du Livre";
                return RedirectToAction("Erreur", new { messageErreur = messageErreur });
            }


        }





    }



}