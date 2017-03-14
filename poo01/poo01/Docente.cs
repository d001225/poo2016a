using System.Collections.Generic;

namespace poo01 {
   public class Docente {
      public ushort NumeroInterno { get; set; }
      public string PrimeiroNome { get; set; }
      public string Apelido { get; set; }
      public string OutrosNomes { get; set; }
      public string Nome { get { return $"{PrimeiroNome} {Apelido}"; } }
      public ICollection<ServicoDocente> Servico 
         { get; private set; } = new List<ServicoDocente>();

      public byte GetHorasLetivas(ushort anoLetivo) {
         byte ret = 0;
         foreach (var sd in Servico) ret += sd.HorasLetivas;
         return ret;
      }
   }
}
