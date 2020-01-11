using System;
using System.Collections.Generic;

namespace contigencia.Models
{
    public partial class Conta
    {
        public Conta()
        {
            Transacao = new HashSet<Transacao>();
        }

        public int Idconta { get; set; }
        public string NomeConta { get; set; }
        public decimal Saldo { get; set; }
        public int UsuarioIdUsuario { get; set; }

        public virtual Usuario UsuarioIdUsuarioNavigation { get; set; }
        public virtual ICollection<Transacao> Transacao { get; set; }
    }
}
