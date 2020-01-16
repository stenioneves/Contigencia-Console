using System;
using contigencia.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using contigencia.UXGUI;
namespace contigencia
{
    class Program
    {
        static void Main(string[] args)
        {  /**
        var dbContext = new FinanceiroContext();
            var transacoes = dbContext.Transacao.ToList();
            foreach (var t in transacoes)
            {
                Console.WriteLine($"Transação :{t.IdTransacao}-Tipo:{t.Tipo}-"+
                $"Descrição:{t.Descricao}- Valor:{t.Valor}-Data:{t.Data}");
                Console.WriteLine("\n");
                Console.WriteLine("*******-------***************************************");
            
            }*/
                try
                {
                     Usuario us = new Usuario();
                    Login lg =new Login();
                    lg.TelaLogin();
                    
                }
                catch (System.InvalidOperationException)
                {
                    Console.WriteLine("00- Falha na conexão com o banco de dados "+
                    " ou você está offline!");
                    
                    Console.WriteLine(" Favor acionar o suporte!");
                   
                } catch(System.FormatException)
                {
                    Console.WriteLine("07- Tipos de dados invalidos! ");
                }
             
             
              
        }
    }
}