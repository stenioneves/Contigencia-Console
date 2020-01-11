using System;
using System.Collections.Generic;

namespace contigencia.Models
{
    public partial class Transacao
    {
        public Transacao()
        {
            Lancamento = new HashSet<Lancamento>();
        }

        public int IdTransacao { get; set; }
        public DateTime Data { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public int ContaIdconta { get; set; }
        public int PlanoContasIdPlanoContas { get; set; }
        public int UsuarioId { get; set; }

        public virtual Conta ContaIdcontaNavigation { get; set; }
        public virtual PlanoContas PlanoContasIdPlanoContasNavigation { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Lancamento> Lancamento { get; set; }
    }
}
