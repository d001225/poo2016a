using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace poo01.Tests {
   [TestClass]
   public class TestarMatriculas {
      [TestMethod]
      public void MatricularAlunoEmInformatica() {
         Curso inf = new Curso {
            Tipo = TipoCurso.Licenciatura,
            Nome = "Informática",
            NumAnos = 3
         };
         Aluno a = new Aluno {
            Nome = "Jorge",
            DataNascimento = new DateTime(1995, 3, 5),
            Contacto = "912345678",
            Residencia = "Rua das Flores, 23"
         };
         inf.MatricularAluno(a, 2016, RegimeIngresso.Reingresso);

         Assert.AreEqual(1, inf.AlunosMatriculados.Count);
         Assert.IsTrue(inf.AlunosMatriculados.Contains(a));
         Assert.AreEqual(1, a.Matriculas.Count);
      }
   }
}
