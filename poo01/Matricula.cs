using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo01 {
   public enum RegimeIngresso {
      Normal, Maiores23,
      Transferencia, Mudanca,
      Reingresso, TitularDET,
      Bolseiro,
   }

   public class Matricula {
      public Aluno Aluno { get; set; }
      public Curso Curso { get; set; }
      public DateTime DataMatricula { get; set; }
      public string AnoLetivo { get; set; }
      public RegimeIngresso Regime { get; set; }
   }
}
