using System.Collections.Generic;

namespace poo01 {
   public enum Semestre { Primeiro = 1, Segundo = 2, }
   public class UnidadeCurricular {
      public string Nome { get; set; }
      public byte ECTS { get; set; }
      public byte AnoCurricular { get; set; }
      public Semestre Semestre { get; set; }
      private ICollection<Turma> turmas = new List<Turma>();
      public IEnumerable<Turma> Turmas { get { return turmas; } }
      public Docente Docente { get; set; }
      public int NumeroAlunosTurma { get; set; }
      public Turma AddTurma(ushort anoLetivo, char letra) {
         var turma = new Turma {
            AnoLetivo = anoLetivo,
            Letra = letra,
            UnidadeCurricular = this,
         };
         turmas.Add(turma);
         return turma;
      }

      public Turma GetTurmaLivre(ushort anoLetivo) {
         char ultimaLetra = (char) ('A' - 1);
         foreach (var turma in turmas) {
            if (turma.AlunosInscritos.Count < NumeroAlunosTurma)
               return turma;
            if (turma.Letra > ultimaLetra) ultimaLetra = turma.Letra;
         }
         ultimaLetra++;
         return AddTurma(anoLetivo, ultimaLetra);
      }
   }
}
