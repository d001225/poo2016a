using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace poo01.Tests {
   [TestClass]
   public class TestarInscricoes {
      private Curso c;
      [TestInitialize]
      public void CriarCurso() {
         c = new Curso {
            Nome = "Informática",
            Tipo = TipoCurso.Licenciatura,
            NumAnos = 3,
         };

         c.AdicionaUC("Algoritmos e Estruturas de Dados", 1, 5, Semestre.Segundo);
         c.AdicionaUC("Programação Orientada a Objetos", 1, 5, Semestre.Segundo);
         c.AdicionaUC("Desenvolvimento de Aplicações com Interface Gráfica", 2, 5, Semestre.Primeiro);
         c.AdicionaUC("Integração de Sistemas", 3, 5, Semestre.Primeiro);
         c.AdicionaUC("Conceção de Interfaces para Aplicações Móveis", 3, 5, Semestre.Primeiro);
      }

      [TestMethod]
      public void MatricularAlunoPrimeiroAnoInformatica() {
         Aluno a = new Aluno { };
         c.MatricularAluno(a, 2016, RegimeIngresso.Normal);
         //Assert.AreEqual(2, a.Inscricoes["2016/2017"].Count); //2 UC no primeiro ano
      }

      [TestMethod]
      [ExpectedException(typeof(System.Exception))]
      public void InscreverAlunoSegundoAnoInformaticaSemMatricular() {
         Aluno a = new Aluno { };
         c.InscreverAlunoAno(a, 2016, 2);
         //Assert.AreEqual(1, a.Inscricoes["2016/2017"].Count); //1 UC no segundo ano
      }

      [TestMethod]
      public void InscreverAlunoSegundoAnoInformatica() {
         Aluno a = new Aluno { };
         c.MatricularAluno(a, 2015, RegimeIngresso.Normal);
         //Assert.AreEqual(2, a.Inscricoes["2015/2016"].Count); //2 UC no primeiro ano
         c.InscreverAlunoAno(a, 2016, 2);
         //Assert.AreEqual(1, a.Inscricoes["2016/2017"].Count); //1 UC no segundo ano
      }
   }
}
