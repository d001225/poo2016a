using System;
using System.Collections.Generic;

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
               switch (value[0]) {
                  case '2': break;
                  case '9':
                     switch (value[1]) {
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
         if (idade > 6) return true; else return false;
      }


      private DateTime dataNascimento;

      public ICollection<Matricula> Matriculas { get; set; }

      public Aluno() {
         Matriculas = new List<Matricula>();
      }
      
      /// 2017-03-07 -> Inscrições do Aluno
      ///NOVO CONCEITO: Dicionário!
      public IDictionary<string, List<UnidadeCurricular>> Inscricoes { get; private set; }

      ///INTERNAL -> Controlado, acesso apenas ao código nos ficheiros deste Assembly (Projeto)
      internal void Inscrever(uint anoLetivo, params UnidadeCurricular[] ucs) {
         if(Inscricoes == null)
            Inscricoes = new Dictionary<string, List<UnidadeCurricular>>();
         string anoLec = $"{anoLetivo}/{anoLetivo + 1}";
         if (!Inscricoes.ContainsKey(anoLec))
            Inscricoes.Add(anoLec, new List<UnidadeCurricular>());
         Inscricoes[anoLec].AddRange(ucs);
      }
   }
}
