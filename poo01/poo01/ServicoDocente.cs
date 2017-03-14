namespace poo01 {
   public enum RegimeLecionacao {
      TeoricoPratica = 1,
      PraticaLaboratorial = 2,
      Teorica = 3,
      Projeto = 4,
   }
   public enum Regime {
      TeoricoPratica = 1,
      PraticaLaboratorial = 2,
      Teorica = 3,
      Projeto = 4,
      Outro = 0,
   }
   public class ServicoDocente {
      public Docente Docente { get; set; }
      public Turma Turma { get; set; }
      public byte HorasLetivas { get; set; }
      public Regime Regime { get; set; }
   }
}
