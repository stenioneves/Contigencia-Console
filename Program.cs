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

              Usuario us = new Usuario();
              Login lg =new Login();
             lg.TelaLogin();
             
              
        }
    }
}