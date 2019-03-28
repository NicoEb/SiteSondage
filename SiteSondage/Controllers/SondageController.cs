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
        const string ChaineConnexionBDD = "Data Source=ADMIN-PC;Initial Catalog = SondageBDD; Integrated Security = True";
        public ActionResult PageAccueil()
        {
            return View();
        }
        public ActionResult PageSondage()
        {
            return View(RecupererEnBdd());
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
            return View(RecupererEnBdd());
        }
        public ActionResult PageVoteEffectue()
        {
            return View();
        }
        public ActionResult PageResultat()
        {
            return View( RecupererEnBdd());
        }
        public ClassSondage RecupererEnBdd()
        {
            using (SqlConnection connection = new SqlConnection(ChaineConnexionBDD))
            {
                connection.Open();

                SqlCommand requeteSQL = new SqlCommand(@"SELECT Question,Choix1,Choix2,Choix3,Choix4,ChoixMultiple,NombreDeVotant,ResultatChoix1,ResultatChoix2,ResultatChoix3,ResultatChoix4 FROM Sondage", connection);
                
             
                SqlDataReader reader = requeteSQL.ExecuteReader();

                reader.Read();


                string question = reader.GetString(0);
                string choix1 = reader.GetString(1);
                string choix2 = reader.GetString(2);
                string choix3 = reader.GetString(3);
                string choix4 = reader.GetString(4);
                bool choixMultiple = reader.GetBoolean(5);
                int nombreVotant = reader.GetInt32(6);
                int resultatChoix1 = reader.GetInt32(7);
                int resultatChoix2 = reader.GetInt32(8);
                int resultatChoix3 = reader.GetInt32(9);
                int resultatChoix4 = reader.GetInt32(10);



                ClassSondage sondage = new ClassSondage(question, choix1, choix2, choix3, choix4, choixMultiple, nombreVotant,resultatChoix1,resultatChoix2,resultatChoix3,resultatChoix4);

                return sondage;

            }

        }
        
    }
}