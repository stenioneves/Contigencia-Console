using System;
using System.Collections.Generic;

namespace contigencia.Models
{
    public partial class PlanoContas
    {
        public PlanoContas()
        {
            Transacao = new HashSet<Transacao>();
        }

        public int IdPlanoContas { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public int UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Transacao> Transacao { get; set; }
    }
}
