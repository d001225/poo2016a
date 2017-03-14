namespace poo01 {
   public enum RegimeLecionacao {
      TeoricoPratica = 1,
      PraticaLaboratorial,
      Teorica,
      Projeto,
   }
   public enum Regime {
      Outro = 0,
      TeoricoPratica,
      PraticaLaboratorial,
      Teorica,
      Projeto,
   }
   public class ServicoDocente {
      public Docente Docente { get; set; }
      public Turma Turma { get; set; }
      public byte HorasLetivas { get; set; }
      public Regime Regime { get; set; }
   }
}
