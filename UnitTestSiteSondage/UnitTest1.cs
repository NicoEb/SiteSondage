using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SiteSondage.Models;

namespace UnitTestSiteSondage
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestClassResultatFalse()
        {
            ClassResultat testResultat = new ClassResultat(1,1,0,0,4);
            Assert.IsFalse(testResultat.ResultatChoix1 < 0 && testResultat.ResultatChoix2 < 0 && testResultat.ResultatChoix3 < 0 && testResultat.ResultatChoix4 < 0 && testResultat.NombreDevotant < 0 , "test réussi");

        }

        [TestMethod]
        public void TestClassResultatTrue()
        {
            ClassResultat testResultat = new ClassResultat(1, 1, 0, 0, 4);
            Assert.IsTrue(testResultat.ResultatChoix1 >= 0 && testResultat.ResultatChoix2 >= 0 && testResultat.ResultatChoix3 >= 0 && testResultat.ResultatChoix4 >= 0 && testResultat.NombreDevotant >= 0, "test réussi");

        }

        [TestMethod]

        public void TestClassSondageTrue()
        {
            ClassSondage testSondage = new ClassSondage(1, "sport préféré", "tennis", "foot", "natation", "petanque", false, false, 12345);
            Assert.IsTrue(testSondage.ChoixMultiple == false && testSondage.EtatDuSondage == false && testSondage.NumeroSecurite > 0 , "test réussi");

        }
        [TestMethod]

        public void TestClassSondageFalse()
        {
            ClassSondage testSondage = new ClassSondage(1, "sport préféré", "tennis", "foot", "natation", "petanque", false, false, 12345);
            Assert.IsFalse(testSondage.Question == "" && testSondage.Choix1 == "" && testSondage.Choix2 == "" && testSondage.Choix3 == "" && testSondage.Choix3 == "", "test réussi");

        }

        [TestMethod]

        public void TestDataAcces()
        {
            int nombre
        }




    }



}
