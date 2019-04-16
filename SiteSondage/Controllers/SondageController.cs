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
        public ActionResult RecuperationVoteIntermediaire(int idSondage, string ResultatChoix1, string ResultatChoix2, string ResultatChoix3, string ResultatChoix4,bool ChoixMultiple)
        {
          
          
            if (ChoixMultiple == false)
            {
                return RedirectToAction("RecuperationVoteChoixUnique", new { idS = idSondage, resultatchoix = ResultatChoix1});



            }

            return RedirectToAction("RecuperationVote", new { idS = idSondage, resultatchoix1 = ResultatChoix1, resultatchoix2 = ResultatChoix2, resultatchoix3 = ResultatChoix3, resultatchoix4 = ResultatChoix4 });

        }
        public ActionResult RecuperationVote(int idS, string resultatchoix1, string resultatchoix2, string resultatchoix3, string resultatchoix4)
        {

            DataAcces.InsererResultatEnBDD(idS, Fonction.VerifiSiEstNull(resultatchoix1), Fonction.VerifiSiEstNull(resultatchoix2), Fonction.VerifiSiEstNull(resultatchoix3), Fonction.VerifiSiEstNull(resultatchoix4));
            return RedirectToAction("PageResultat", new { IdSondage = idS });
        }


        public ActionResult RecuperationVoteChoixUnique(int idS, string resultatchoix)
        {
           

            DataAcces.InsererResultatEnBDD(idS, Fonction.VerifiSiEstNull(Fonction.ListeChoix1(resultatchoix)), Fonction.VerifiSiEstNull(Fonction.ListeChoix2(resultatchoix)), Fonction.VerifiSiEstNull(Fonction.ListeChoix3(resultatchoix)), Fonction.VerifiSiEstNull(Fonction.ListeChoix4(resultatchoix)));
            return RedirectToAction("PageResultat", new { IdSondage = idS });
        }



        public ActionResult PageVoteEffectue()
        {
            return View();
        }
        public ActionResult PageResultat( int IdSondage)
        {
            
            return View(DataAcces.RecupererResultatEnBdd(IdSondage));
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