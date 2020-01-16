using System;
using System.Linq;
using System.Collections.Generic;
using contigencia.Models;

namespace contigencia.Dados
{

    public class TransacaoDados
    {
        public TransacaoDados(){}

        public void SalvarTransacao(Transacao transacao)
        {
            var contexto =new FinanceiroContext();
            contexto.Transacao.Add(transacao);
            contexto.SaveChanges();
        }
        public IEnumerable<Transacao> ListarTransacoes( Usuario use)
        {
            var result =  from Transacao in new FinanceiroContext().Transacao.ToList()
                          where  Transacao.UsuarioId==use.IdUsuario
                          select Transacao;
                return result;          
                 
        }

        public Transacao ListarTransacao(int id)
        {   Transacao transacaoConsulta = new Transacao();
            var result = from Transacao in new FinanceiroContext().Transacao
                            where Transacao.IdTransacao== id
                            select Transacao;
                        foreach (var item in result)
                        {
                            transacaoConsulta.IdTransacao=item.IdTransacao;
                            transacaoConsulta.Descricao=item.Descricao;
                            transacaoConsulta.Data=item.Data;
                            transacaoConsulta.Valor=item.Valor;
                            transacaoConsulta.Tipo=item.Tipo;
                            transacaoConsulta.PlanoContasIdPlanoContas=item.PlanoContasIdPlanoContas;
                            transacaoConsulta.ContaIdconta=item.ContaIdconta;
                            transacaoConsulta.UsuarioId=item.UsuarioId;
                            
                        } 
                        return transacaoConsulta;   

        }
        public void EditarTransacao(Transacao transacao)
        {
            var contexto = new FinanceiroContext();
            contexto.Transacao.Update(transacao);
            contexto.SaveChanges();
        }

        public void ExcluirTransacao(Transacao transacao)
        {
            var contexto= new FinanceiroContext();
            contexto.Transacao.Remove(transacao);
            contexto.SaveChanges();
        }
    }
}