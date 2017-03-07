using System;
using System.Collections.Generic;

namespace poo01 {
   public class Curso {
      public string Nome { get; set; }

      private byte nAnos;
      public byte NumAnos {
         get { return nAnos; }
         set {
            int[] anosPossiveis = AnosPossiveisTipoDeCurso();
            bool valorValido = false;
            foreach (var v in anosPossiveis) {
               if (value == v) valorValido = true;
            }
            if (!valorValido) { throw new Exception(); }
            nAnos = value;
         }
      }

      private int[] AnosPossiveisTipoDeCurso() {
         switch (Tipo) {
            case TipoCurso.CTESP: return new[] { 2 };
            case TipoCurso.Licenciatura: return new[] { 3, 4 };
            case TipoCurso.MestradoIntegrado: return new[] { 5, 6, 7 };
            case TipoCurso.Mestrado: return new[] { 2, 3 };
            case TipoCurso.Doutoramento: return new[] { 3 };
            default: return new int[0];
         }
      }

      public TipoCurso Tipo { get; set; }

      public ICollection<Aluno> AlunosMatriculados { get; set; }

      public void MatricularAluno(Aluno aluno, uint anoInicio, RegimeIngresso regime) {
         Matricula m = new Matricula {
            Aluno = aluno,
            Curso = this,
            DataMatricula = DateTime.Now,
            AnoLetivo = $"{anoInicio}/{anoInicio + 1}",
            Regime = regime
         };
         aluno.Matriculas.Add(m);
         AlunosMatriculados.Add(aluno);

         InscreverAlunoAno(aluno, anoInicio, 1);
      }

      public Curso() {
         AlunosMatriculados = new List<Aluno>();
      }

      /// 2017-mar-07 -> Conceito de Plano Curricular
      private IList<UnidadeCurricular> plano;

      public IEnumerable<UnidadeCurricular> PlanoCurricular {
         get {
            if (plano == null) plano = new List<UnidadeCurricular>();
            return plano;
         } }
      private int GetECTSAno(byte ano) {
         int ects = 0;
         foreach (var uc in PlanoCurricular)
            if (uc.AnoCurricular == ano) ects += uc.ECTS;
         return ects;
      }

      public void AdicionaUC(string nomeUnidade, byte anoCurricular,
                             byte ECTS, Semestre semestre) {
         if (anoCurricular > NumAnos || anoCurricular <= 0)
            throw new Exception();
         if (0 >= ECTS || GetECTSAno(anoCurricular) + ECTS > 60)
            throw new Exception();
         var uc = new UnidadeCurricular {
            //Curso = this, //O Curso sabe as suas Unidades Curriculares
            AnoCurricular = anoCurricular,
            Nome = nomeUnidade,
            ECTS = ECTS,
            Semestre = semestre,
         };
         plano?.Add(uc); //Apenas executa Add se plano != null
      }

      /// 2017-mar-07 -> Inscrição Automática no Ato de Matrícula
      ///             -> Inscrição Automática num dado Ano
      public void InscreverAlunoAno(Aluno aluno, uint anoLetivo, byte anoCurricular) {
         if (!AlunosMatriculados.Contains(aluno))
            throw new Exception(); //Aluno não está matriculado neste curso!

         var ucsAno = new List<UnidadeCurricular>();
         foreach (var uc in PlanoCurricular)
            if (uc.AnoCurricular == anoCurricular)
               ucsAno.Add(uc);
         aluno.Inscrever(anoLetivo, ucsAno.ToArray());
      }
   }

   public enum TipoCurso {
      CTESP, Licenciatura, MestradoIntegrado,
      Mestrado, Doutoramento
   }
}