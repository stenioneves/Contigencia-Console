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
        public PlanoContas ConsultarPlanoConta( int id)
        {  PlanoContas planoContasconsultada = new PlanoContas();
           var consulta = from PlanoContas in new FinanceiroContext().PlanoContas
                        where PlanoContas.IdPlanoContas==id 
                        select PlanoContas;
                        foreach (var item in consulta)
                        {
                            planoContasconsultada.IdPlanoContas=item.IdPlanoContas;
                            planoContasconsultada.Tipo= item.Tipo;
                            planoContasconsultada.Descricao= item.Descricao;
                            planoContasconsultada.UsuarioId=item.UsuarioId;
                        }
            return planoContasconsultada;

        }

        public void EditarPlanoConta(PlanoContas planoContas)
        {
            var context = new FinanceiroContext();
            context.PlanoContas.Update(planoContas);
            context.SaveChanges();
        }
        public void SalvarPlanoConta(PlanoContas planoContas)
        {
            var context = new FinanceiroContext();
            context.PlanoContas.Add(planoContas);
            context.SaveChanges();
        }

        public void RemoverPlanoConta(PlanoContas planoContas)
        {
            var context = new FinanceiroContext();
            context.PlanoContas.Remove(planoContas);
            context.SaveChanges();
        }
    }
}