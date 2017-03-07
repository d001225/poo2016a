using System;
using System.Linq;

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
            case TipoCurso.MestradoIntegrado:return new[] { 5, 6, 7 };
            case TipoCurso.Mestrado:return new[] { 2, 3 };
            case TipoCurso.Doutoramento:return new[] { 3 };
            default:return new int[0];
         }
      }

      public TipoCurso Tipo { get; set; }
   }

   public enum TipoCurso {
      CTESP, Licenciatura, MestradoIntegrado,
      Mestrado, Doutoramento
   }
}