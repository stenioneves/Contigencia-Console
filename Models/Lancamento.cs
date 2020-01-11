using System;
using System.Collections.Generic;

namespace contigencia.Models
{
    public partial class Lancamento
    {
        public int Idlanc { get; set; }
        public string Nomelanc { get; set; }
        public decimal Valor { get; set; }
        public DateTime Datalanc { get; set; }
        public int? IdTransacao { get; set; }

        public virtual Transacao IdTransacaoNavigation { get; set; }
    }
}
