using System;
using System.Collections.Generic;

namespace poo01 {
   public class Docente {
      public ushort NumeroInterno { get; set; }
      public string PrimeiroNome { get; set; }
      public string Apelido { get; set; }
      public string OutrosNomes { get; set; }
      public string Nome { get { return $"{PrimeiroNome} {Apelido}"; } }
      public ICollection<ServicoDocente> Servico { get; private set; } = new List<ServicoDocente>();

      public byte GetHorasLetivas(ushort anoLetivo, Semestre s) {
         byte ret = 0;
         foreach (var sd in Servico)
            if (sd.Turma.AnoLetivo == anoLetivo
               && sd.Turma.UnidadeCurricular.Semestre == s)
               ret += sd.HorasLetivas;
         return ret;
      }

      public ServicoDocente AtribuiServico(Turma t, byte horas) {
         if (horas > 5 || horas == 0)
            throw new ArgumentException("0 < horas <= 5");
         return AtribuiServico(t, Regime.Outro, horas);
      }

      public ServicoDocente AtribuiServico(Turma t, RegimeLecionacao r) {
         byte horas = 0;
         switch (r) {
            case RegimeLecionacao.TeoricoPratica:
            case RegimeLecionacao.PraticaLaboratorial: horas = 3; break;
            case RegimeLecionacao.Projeto:
            case RegimeLecionacao.Teorica: horas = 1; break;
         }
         return AtribuiServico(t, (Regime)r, horas);
      }

      private ServicoDocente AtribuiServico(Turma t, Regime r, byte horas) {
         if (CheckHoras(t, horas)) {
            var sd = new ServicoDocente {
               Docente = this,
               Regime = r,
               HorasLetivas = horas,
               Turma = t,
            };
            Servico.Add(sd);
            return sd;
         }
         throw new Exception("Número de Horas Inválido!");
      }

      private bool CheckHoras(Turma t, byte horas) {
         var s1 = GetHorasLetivas(t.AnoLetivo, Semestre.Primeiro);
         var s2 = GetHorasLetivas(t.AnoLetivo, Semestre.Segundo);
         bool ok = true;
         //Horas/semestre
         switch (t.UnidadeCurricular.Semestre) {
            case Semestre.Primeiro: ok &= (s1 + horas <= 15); break;
            case Semestre.Segundo: ok &= (s2 + horas <= 15); break;
         }
         //Horas/Ano Letivo
         ok &= (s1 + s2 + horas <= 27);
         //horas/Turma
         ok &= (t.GetHorasLetivas(t.AnoLetivo) + horas <= 5);
         return ok;
      }
   }
}
