﻿namespace poo01 {
   public enum Semestre { Primeiro = 1, Segundo = 2, }
   public class UnidadeCurricular {
      public string Nome { get; set; }
      public byte ECTS { get; set; }
      public byte AnoCurricular { get; set; }
      //public Curso Curso { get; set; }
      public Semestre Semestre { get; set; }
   }
}
