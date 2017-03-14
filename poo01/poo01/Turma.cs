using System.Collections.Generic;

namespace poo01 {
   public class Turma {
      public ushort AnoLetivo { get; set; }
      public UnidadeCurricular UnidadeCurricular { get; set; }
      private char letra;
      public char Letra { get { return letra; } set { letra = char.ToUpper(letra); } }
      public ICollection<Inscricao> AlunosInscritos 
         { get; private set; } = new List<Inscricao>();
      public ICollection<Turma> TurmasAssociadas 
         { get; private set; } = new List<Turma>();
      public ICollection<ServicoDocente> Servico 
         { get; private set; } = new List<ServicoDocente>();
      public byte GetHorasLetivas(ushort anoLetivo) {
         byte ret = 0;
         foreach (var sd in Servico) ret += sd.HorasLetivas;
         return ret;
      }
   }
}