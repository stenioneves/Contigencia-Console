using System;
using System.Collections.Generic;

namespace contigencia.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Conta = new HashSet<Conta>();
            PlanoContas = new HashSet<PlanoContas>();
            Transacao = new HashSet<Transacao>();
        }

        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }

        public virtual ICollection<Conta> Conta { get; set; }
        public virtual ICollection<PlanoContas> PlanoContas { get; set; }
        public virtual ICollection<Transacao> Transacao { get; set; }
    }
}
