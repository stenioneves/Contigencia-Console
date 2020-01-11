using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using contigencia.Models;



namespace contigencia.Dados
{
    public class ContasDados
    {
        public ContasDados(){}

        public Conta ConsultarConta(int id)
        { Conta ContaConsultada= new Conta();
            var consul = from Conta in new FinanceiroContext().Conta
                        where Conta.Idconta==id
                        select Conta;
                        foreach (var item in consul)
                        {
                            ContaConsultada.Idconta=item.Idconta;
                            ContaConsultada.NomeConta=item.NomeConta;
                            ContaConsultada.Saldo=item.Saldo;
                            ContaConsultada.UsuarioIdUsuario=item.UsuarioIdUsuario;
                        }
            return ContaConsultada;
        }
        public  void SalvarEdicao(Conta conta){
            var contex =new FinanceiroContext(); 
            contex.Conta.Update(conta);
            contex.SaveChanges();   
        
        }

        public void Salvar(Conta conta){
            var contexto = new FinanceiroContext();
            contexto.Conta.Add(conta);
            contexto.SaveChanges();
        }

        public void ExcluirConta(Conta conta)
        {  var contexto = new FinanceiroContext();
            contexto.Conta.Remove(conta);
            contexto.SaveChanges();
            
        }
    }
}