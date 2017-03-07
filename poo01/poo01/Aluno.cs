using System;
using System.Linq;

namespace poo01 {
   public class Aluno {
      public string Nome { get; set; }
      public int NumeroMatricula { get; private set; }
      public string Residencia { get; set; }

      private string contacto;
      public string Contacto {
         get { return contacto; }
         set {
            if (value != null && value.Length > 0 && value.Length != 9)
               throw new Exception();
            if (value != null && value.Length > 0) {
               foreach (var d in value)
                  if (!char.IsNumber(d)) throw new Exception();
               //for(int idx = 0; idx < value.Length; ++idx) {
               //   char d = value[idx];
               //   if (!char.IsNumber(d)) throw new Exception();
               //}
               switch(value[0]) {
                  case '2': break;
                  case '9':
                     switch(value[1]) {
                        case '1': case '2': case '3': case '6': break;
                        default: throw new Exception();
                     }
                     break;
                  default: throw new Exception();
               }
            }
            contacto = value;
         }
      }

      public DateTime DataNascimento {
         get { return dataNascimento; }
         set {
            bool dataValida = ValidarDataNascimento(value);
            if (!dataValida) throw new Exception();
            dataNascimento = value;
         }
      }

      private bool ValidarDataNascimento(DateTime data) {
         var diasVida = DateTime.Now.Subtract(data).TotalDays;
         var anos = new DateTime(); //01/jan/0001
         anos = anos.AddDays(diasVida);
         var idade = anos.Year - 1;
         var confirmar = DataNascimento.AddYears(idade);
         if (DateTime.Now < confirmar)
            idade = idade - 1;
         //var anos = DateTime.Now
         //   .Subtract(data)
         //   .TotalDays / 365;
         //var diferenca = DateTime.Now.Subtract(data);
         //var diasVida = diferenca.TotalDays;
         //var anos = diasVida / 365;
         if (idade > 6) return true; else return false;
      }

      private DateTime dataNascimento;
   }
}
