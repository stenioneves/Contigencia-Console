using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using contigencia.Models;
using System.Collections.Generic;
namespace contigencia.Dados
{
    public class PlanoContaDados
    {
        public PlanoContaDados(){}

        public  IEnumerable<PlanoContas> ListarPlanosContas(Usuario use)
        {
            var result = from PlanoContas in new FinanceiroContext().PlanoContas.ToList()
                            where PlanoContas.UsuarioId==use.IdUsuario
                            select PlanoContas;

                            return result;
        }
    }
}