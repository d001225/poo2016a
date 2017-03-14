using System.Collections.Generic;

namespace poo01 {
   public class Turma {
      public ushort AnoLetivo { get; set; }
      public UnidadeCurricular UnidadeCurricular { get; set; }
      private string letra;
      public string Letra { get { return letra; } set { letra = letra.ToUpper(); } }
      public ICollection<Inscricao> AlunosInscritos 
         { get; private set; } = new List<Inscricao>();
   }
}