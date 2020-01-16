using System;
using System.Linq;
using contigencia.Dados;
using contigencia.Models;
using contigencia.Security;
using System.Collections.Generic;

namespace contigencia.UXGUI
{
    public class TelaTransacao
    {
        public TelaTransacao(){}
        ConsoleColor[] f={ConsoleColor.Blue,ConsoleColor.DarkCyan,ConsoleColor.Yellow,
        ConsoleColor.Green,ConsoleColor.Magenta,ConsoleColor.White};
        Random rm = new Random();

        public void ListarTransacao(Usuario use)
        {   TextoNo texto =new TextoNo();
            //ListarOrdenado(new TransacaoDados().ListarTransacoes(use));
            Console.Clear();
            texto.SaudacaoUser(use);
            texto.TextoOpcoesTransacao();
            int op= int.Parse(Console.ReadLine());



            switch (op)
            {
                
                default:
                break;
            }
        }
        private void ListarOrdenado(IEnumerable<Transacao> transacaos)
        {  int p= 0;
            foreach (var item in transacaos)
            {   ++p;
                Console.ForegroundColor=f[rm.Next(0,5)];
                Console.WriteLine("---------------------------------------------------++");
                Console.WriteLine($"Código:{item.IdTransacao}");
                Console.WriteLine($"Histórico: {item.Descricao}");
                Console.WriteLine($"Data: {item.Data}");
                Console.WriteLine($"Valor: {item.Valor}");
                Console.WriteLine($"Tipo: {item.Tipo}");
                Console.WriteLine($"Plano Conta:"+ new PlanoContaDados().ConsultarPlanoConta(item.PlanoContasIdPlanoContas).Descricao);
                Console.WriteLine($"Conta:"+ new ContasDados().ConsultarConta(item.ContaIdconta).NomeConta);
                Console.WriteLine("---------------------------------------------------++");
                if(p==5)
                {   Console.ForegroundColor=ConsoleColor.DarkCyan;
                    Console.WriteLine("Aperte uma tecla para continuar");
                    string op = Console.ReadLine();
                    if(op.Equals("0"))
                    {}
                    else{
                        p=0;
                        continue;
                    }

                }
            }
        }


    }
}