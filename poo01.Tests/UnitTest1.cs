using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using poo01;

namespace poo01.Tests {
   [TestClass]
   public class CursosTests {
      [TestMethod]
      public void CriarLicenciatura3Anos() {
         Curso licInf;
         licInf = new Curso();
         licInf.Nome = "Informática";
         licInf.Tipo = TipoCurso.Licenciatura;
         licInf.NumAnos = 3;

         Assert.AreEqual(3, licInf.NumAnos);
      }

      [TestMethod, ExpectedException(typeof(Exception))]
      public void CriarLicenciatura10Anos() {
         Curso licInf;
         licInf = new Curso();
         licInf.Nome = "Informática";
         licInf.Tipo = TipoCurso.Licenciatura;
         licInf.NumAnos = 10;
      }
   }
}