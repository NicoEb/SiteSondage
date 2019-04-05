using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SiteSondage.Models
{
    public class DataAcces
    {
        const string ChaineConnexionBDD = @"server=ADMIN-PC;Initial Catalog=SondageBDD;Integrated Security=True";
        public static ClassSondage RecupererEnBdd()
        {
            using (SqlConnection connection = new SqlConnection(ChaineConnexionBDD))
            {
                connection.Open();

                SqlCommand requeteSQL = new SqlCommand(@"SELECT Question,Choix1,Choix2,Choix3,Choix4,ChoixMultiple FROM Sondage", connection);


                SqlDataReader reader = requeteSQL.ExecuteReader();

                reader.Read();


                string question = reader.GetString(0);
                string choix1 = reader.GetString(1);
                string choix2 = reader.GetString(2);
                string choix3 = reader.GetString(3);
                string choix4 = reader.GetString(4);
                bool choixMultiple = reader.GetBoolean(5);
                //int nombreVotant = reader.GetInt32(6);
                //int resultatChoix1 = reader.GetInt32(7);
                //int resultatChoix2 = reader.GetInt32(8);
                //int resultatChoix3 = reader.GetInt32(9);
                //int resultatChoix4 = reader.GetInt32(10);



                ClassSondage sondage = new ClassSondage(question, choix1, choix2, choix3, choix4, choixMultiple);

                return sondage;

            }

        }
        public static ClassVoter RecupererEnBdd1()
        {
            using (SqlConnection connection = new SqlConnection(ChaineConnexionBDD))
            {
                connection.Open();

                SqlCommand requeteSQL = new SqlCommand(@"SELECT Question,Choix1,Choix2,Choix3,Choix4,ChoixMultiple,NombreDeVotant FROM Sondage INNER JOIN Resultats ON IdSondage = FK_Id_sondage", connection);


                SqlDataReader reader = requeteSQL.ExecuteReader();

                reader.Read();


                string question = reader.GetString(0);
                string choix1 = reader.GetString(1);
                string choix2 = reader.GetString(2);
                string choix3 = reader.GetString(3);
                string choix4 = reader.GetString(4);
                bool choixMultiple = reader.GetBoolean(5);
                int nombreVotant = reader.GetInt32(6);
                //int resultatChoix1 = reader.GetInt32(7);
                //int resultatChoix2 = reader.GetInt32(8);
                //int resultatChoix3 = reader.GetInt32(9);
                //int resultatChoix4 = reader.GetInt32(10);



                ClassSondage sondage = new ClassSondage(question,choix1,choix2,choix3,choix4,choixMultiple);
                ClassVoter vote = new ClassVoter(sondage, nombreVotant);

                return vote;

            }

        }
        public static ClassResultat RecupererEnBdd2()
        {
            using (SqlConnection connection = new SqlConnection(ChaineConnexionBDD))
            {
                connection.Open();

                SqlCommand requeteSQL = new SqlCommand(@"SELECT Question,Choix1,Choix2,Choix3,Choix4,ChoixMultiple,ResultatChoix1,ResultatChoix2,ResultatChoix3,ResultatChoix4,NombreDeVotant FROM Sondage INNER JOIN Resultats ON IdSondage = FK_Id_sondage", connection);


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



                ClassSondage sondage = new ClassSondage(question, choix1, choix2, choix3, choix4, choixMultiple);
                ClassResultat resultat = new ClassResultat(sondage,resultatChoix1,resultatChoix2,resultatChoix3,resultatChoix4,nombreVotant);

                return resultat;

            }

        }
        public static void InsererEnBDD(ClassSondage nouveauSondage)
        {
            SqlConnection connection = new SqlConnection(ChaineConnexionBDD);

            connection.Open();
            
            SqlCommand requeteSQL = new SqlCommand("INSERT INTO Sondage(Question,Choix1,Choix2,Choix3,Choix4) VALUES @question,@choix1,@choix2,@choix3,@choix4", connection);

            requeteSQL.Parameters.AddWithValue("@question", nouveauSondage.Question);
            requeteSQL.Parameters.AddWithValue("@choix1", nouveauSondage.Choix1);
            requeteSQL.Parameters.AddWithValue("@choix1", nouveauSondage.Choix2);
            requeteSQL.Parameters.AddWithValue("@choix1", nouveauSondage.Choix3);
            requeteSQL.Parameters.AddWithValue("@choix1", nouveauSondage.Choix4);
            requeteSQL.ExecuteReader();
            connection.Close();


        }
    }
}