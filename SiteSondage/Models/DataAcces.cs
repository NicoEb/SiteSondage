﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SiteSondage.Models
{
    public class DataAcces
    {
        const string ChaineConnexionBDD = @"server=.\SQLEXPRESS;Initial Catalog=SondageBDD;Integrated Security=True";
        public static ClassSondage RecupererEnBdd(int idSondage)
        {
            using (SqlConnection connection = new SqlConnection(ChaineConnexionBDD))
            {
                connection.Open();

                SqlCommand requeteSQL = new SqlCommand(@"SELECT * FROM Sondage WHERE IdSondage = @ID", connection);

                requeteSQL.Parameters.AddWithValue("@ID", idSondage);
                SqlDataReader reader = requeteSQL.ExecuteReader();

                reader.Read();

                int idsondage = reader.GetInt32(0);
                string question = reader.GetString(1);
                string choix1 = reader.GetString(2);
                string choix2 = reader.GetString(3);
                string choix3 = reader.GetString(4);
                string choix4 = reader.GetString(5);
                bool choixMultiple = reader.GetBoolean(6);
               //int nombreVotant = reader.GetInt32(7);
                //int resultatChoix1 = reader.GetInt32(7);
                //int resultatChoix2 = reader.GetInt32(8);
                //int resultatChoix3 = reader.GetInt32(9);
                //int resultatChoix4 = reader.GetInt32(10);



                ClassSondage sondage = new ClassSondage(idsondage,question,choix1,choix2,choix3,choix4,choixMultiple);
                

                return sondage;

            }
        }
        public static ClassResultat RecupererResultatEnBdd(int idSondage)
        {
            using (SqlConnection connection = new SqlConnection(ChaineConnexionBDD))
            {
                connection.Open();

                SqlCommand requeteSQL = new SqlCommand(@"SELECT * FROM sondage,resultats WHERE IdSondage = @ID and FK_Id_sondage = @ID", connection);

                requeteSQL.Parameters.AddWithValue("@ID", idSondage);
                SqlDataReader reader = requeteSQL.ExecuteReader();

                reader.Read();

                int idsondage = reader.GetInt32(0);
                string question = reader.GetString(1);
                string choix1 = reader.GetString(2);
                string choix2 = reader.GetString(3);
                string choix3 = reader.GetString(4);
                string choix4 = reader.GetString(5);
                bool choixMultiple = reader.GetBoolean(6);
                int resultatChoix1 = reader.GetInt32(7);
                int resultatChoix2 = reader.GetInt32(8);
                int resultatChoix3 = reader.GetInt32(9);
                int resultatChoix4 = reader.GetInt32(10);
                int nombreDeVotant = reader.GetInt32(11);




                ClassSondage sondage = new ClassSondage(idsondage, question, choix1, choix2, choix3, choix4, choixMultiple);
                ClassResultat vote = new ClassResultat(sondage, resultatChoix1, resultatChoix2, resultatChoix3, resultatChoix4, nombreDeVotant);


                return vote;

            }
        }

        public static void InsererResultatEnBDD(int idSondage, int Choix1, int Choix2, int Choix3 , int Choix4)
        {
            InsererNombreDeVotant(idSondage);

            SqlConnection connection = new SqlConnection(ChaineConnexionBDD);

            connection.Open();

            SqlCommand requete = new SqlCommand("UPDATE Resultats SET ResultatChoix1 = ResultatChoix1 + @choix1 ,ResultatChoix2 = ResultatChoix2 + @choix2,ResultatChoix3 = ResultatChoix3 + @choix3,ResultatChoix4 = ResultatChoix4 + @choix4 WHERE FK_Id_sondage = @idSondage", connection);

            requete.Parameters.AddWithValue("@choix1", Choix1);
            requete.Parameters.AddWithValue("@choix2", Choix2);
            requete.Parameters.AddWithValue("@choix3", Choix3);
            requete.Parameters.AddWithValue("@choix4", Choix4);
            requete.Parameters.AddWithValue("@idSondage", idSondage);


            requete.ExecuteNonQuery();
            connection.Close();


        }
        public static void InsererNombreDeVotant(int idSondage)
        {
            SqlConnection connection = new SqlConnection(ChaineConnexionBDD);

            connection.Open();

            SqlCommand requete = new SqlCommand("UPDATE Resultats SET NombreDeVotant = NombreDeVotant + 1 WHERE FK_Id_sondage = @idSondage ", connection);

        
            requete.Parameters.AddWithValue("@idSondage", idSondage);


            requete.ExecuteNonQuery();
            connection.Close();


        }

        public static int InsererEnBDD(ClassSondage nouveauSondage)
            {
                using (SqlConnection connection = new SqlConnection(ChaineConnexionBDD))
                {


                    connection.Open();

                    SqlCommand requete = new SqlCommand("INSERT INTO Sondage(Question,Choix1,Choix2,Choix3,Choix4,ChoixMultiple) OUTPUT Inserted.IdSondage VALUES  (@question,@choix1,@choix2,@choix3,@choix4,@choixM)", connection);

                    requete.Parameters.AddWithValue("@question", nouveauSondage.Question);
                    requete.Parameters.AddWithValue("@choix1", nouveauSondage.Choix1);
                    requete.Parameters.AddWithValue("@choix2", nouveauSondage.Choix2);
                    requete.Parameters.AddWithValue("@choix3", nouveauSondage.Choix3);
                    requete.Parameters.AddWithValue("@choix4", nouveauSondage.Choix4);
                    requete.Parameters.AddWithValue("@choixM", nouveauSondage.ChoixMultiple);

                    int idInsere = (int)requete.ExecuteScalar();

                    InsererIDDansResultat(idInsere);

                    return idInsere;




                }

            }
        public static void InsererIDDansResultat(int idSondage)
        {
            using (SqlConnection connection = new SqlConnection(ChaineConnexionBDD))
            {


                connection.Open();

                SqlCommand requete = new SqlCommand("INSERT INTO Resultats(ResultatChoix1,ResultatChoix2,ResultatChoix3,ResultatChoix4,NombreDeVotant,FK_id_Sondage) VALUES  (@choix1,@choix2,@choix3,@choix4,@nombrevotant,@FKID)", connection);
                
                requete.Parameters.AddWithValue("@choix1", 0);
                requete.Parameters.AddWithValue("@choix2", 0);
                requete.Parameters.AddWithValue("@choix3", 0 );
                requete.Parameters.AddWithValue("@choix4", 0);
                requete.Parameters.AddWithValue("@nombrevotant", 0);
                requete.Parameters.AddWithValue("@FKID", idSondage);
                requete.ExecuteNonQuery();

                




            }

        }











    }
}