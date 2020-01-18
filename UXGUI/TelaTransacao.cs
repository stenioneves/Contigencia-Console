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
                case 2:
                this.EditarTransacao(use);
                this.ListarTransacao(use);
                break;
                case 4:
                this.ListarOrdenado(new TransacaoDados().ListarTransacoes(use));
                this.ListarTransacao(use);
                break;
                case 5:
                this.ListarUmaTransacao();
                this.ListarTransacao(use);
                break;
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

        public void ListarUmaTransacao()
        {
            new TextoNo().TextoTransacaoIdSelecao();
            int id = int.Parse(Console.ReadLine());
            this.TexListarumaTransacao(new TransacaoDados().ListarTransacao(id));
            Console.ForegroundColor=ConsoleColor.DarkCyan;
                    Console.WriteLine("Aperte uma tecla para continuar");
                    string op = Console.ReadLine();
                    if(op.Equals("0"))
                    {}
                    else{
                        
                       return;
                    }

            
        }

        public  void TexListarumaTransacao(Transacao item)
        {
            Console.WriteLine($"Código:{item.IdTransacao}");
                Console.WriteLine($"Histórico: {item.Descricao}");
                Console.WriteLine($"Data: {item.Data}");
                Console.WriteLine($"Valor: {item.Valor}");
                Console.WriteLine($"Tipo: {item.Tipo}");
                Console.WriteLine($"Plano Conta:"+ new PlanoContaDados().ConsultarPlanoConta(item.PlanoContasIdPlanoContas).Descricao);
                Console.WriteLine($"Conta:"+ new ContasDados().ConsultarConta(item.ContaIdconta).NomeConta);
        }

        public void EditarTransacao(Usuario user)
        { new TextoNo().TextoTransacaoIdSelecao();
          Transacao editartransacao= this.EditarTransacao(int.Parse(Console.ReadLine()));
          Console.WriteLine("Transação selecionada :");
          this.TexListarumaTransacao(editartransacao);
          new TextoNo().TextoEdicaoTransacao();
          editartransacao=DecicaoTransacao(int.Parse(Console.ReadLine()),editartransacao,user);
          this.TexListarumaTransacao(editartransacao);
          new  TransacaoDados().EditarTransacao(editartransacao);


        }
        private Transacao EditarTransacao(int id)
        {
            return new TransacaoDados().ListarTransacao(id);
        }

        private Transacao DecicaoTransacao(int op, Transacao editar,Usuario use)
        {  
            switch (op)
            {
                case 1:
                Console.ForegroundColor=ConsoleColor.White;
                Console.Write($"Digite o nome para Historico[{editar.Descricao}] : ");
                Console.ForegroundColor=ConsoleColor.DarkCyan;
                editar.Descricao=Console.ReadLine();
                return editar;
                case 2:
                Console.ForegroundColor=ConsoleColor.White;
                Console.Write($"Digite a data(dd/mm/aaaa)[{editar.Data}] : ");
                Console.ForegroundColor=ConsoleColor.DarkCyan;
                editar.Data=DateTime.Parse(Console.ReadLine());
                return editar;
                case 3:
                Console.ForegroundColor=ConsoleColor.White;
                Console.Write($"Digite um valor(0.00)[{editar.Valor}] : ");
                Console.ForegroundColor=ConsoleColor.DarkCyan;
                editar.Valor=decimal.Parse(Console.ReadLine());
                return editar;
                case 4:
                Console.ForegroundColor=ConsoleColor.White;
                Console.Write($"Digite um tipo:[{editar.Descricao}]D ou R : ");
                Console.ForegroundColor=ConsoleColor.DarkCyan;
                editar.Tipo=Console.ReadLine();
                return editar;
                case 5:
                Console.ForegroundColor=ConsoleColor.White;
                Console.Write($"Digite o código do plano conta:[{new PlanoContaDados().ConsultarPlanoConta(editar.PlanoContasIdPlanoContas)}] : ");
                Console.WriteLine("Suas opções:");
                new TelaPlanoConta().InteracaoPlanoConta(use);
                Console.Write("Digite o código:");
                Console.ForegroundColor=ConsoleColor.DarkCyan;
                editar.PlanoContasIdPlanoContas=int.Parse(Console.ReadLine());
                return editar;
                case 6:
                Console.ForegroundColor=ConsoleColor.White;
                Console.Write($"Digite o código da conta:[{new ContasDados().ConsultarConta(editar.ContaIdconta)}] : ");
                Console.WriteLine("Suas opções:");
                new Telaconta().ListarContasUsuarios(use);
                Console.Write("Digite o código:");
                Console.ForegroundColor=ConsoleColor.DarkCyan;
                editar.ContaIdconta=int.Parse(Console.ReadLine());
                return editar;
                
                default:
                return editar;
            
            }
        }

        


    }
}