using System;
using System.Linq;
using contigencia.Models;
using contigencia.Dados;

namespace contigencia.UXGUI
{
    public class TelaPlanoConta
    {
        public TelaPlanoConta(){}

        ConsoleColor[] f={ConsoleColor.Blue,ConsoleColor.Red,ConsoleColor.Yellow,ConsoleColor.Green,ConsoleColor.Magenta,ConsoleColor.Cyan};
        Random rm = new Random();
        public void ListarPlanoConta(Usuario use)

        {
            Console.ForegroundColor =ConsoleColor.White;
            Console.WriteLine("Módulo Plano Conta");
            Console.ForegroundColor =ConsoleColor.Blue;
            Console.Write("Usuario :");
            Console.ForegroundColor =ConsoleColor.Green;
            Console.WriteLine($"{use.Nome}");
            Console.ForegroundColor=ConsoleColor.White;
            Console.WriteLine("Esses são seus planos conta cadastrado!");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("| Código  || Descrição  || Tipo ");
            Console.WriteLine("-------------------------------- \n");
            foreach (var item in new PlanoContaDados().ListarPlanosContas(use))
            {
                Console.ForegroundColor=f[rm.Next(0,5)];
                Console.WriteLine($"| {item.IdPlanoContas}  || {item.Descricao}  || {item.Tipo}");
                Console.WriteLine("---------------------------------");
            }
            Opcoes();
            int op = int.Parse(Console.ReadLine());

            switch (op)
            {
                case 0:
                new TelaPrincipal().TelaPS(use);
                break;
                case 1:
                CriarPlanoConta(use);
                break;
                case 2:
                EditarPlanoConta(use);
                break;
                case 3:
                ExcluirPlanoConta(use);
                break;
                default:
                this.ListarPlanoConta(use);
                break;
            }

        }
        private void Opcoes()
        {
            Console.ForegroundColor= ConsoleColor.White;
            Console.WriteLine("Lista de opções");
            Console.ForegroundColor= ConsoleColor.DarkGreen;
            Console.WriteLine("1- Criar plano conta");
            Console.ForegroundColor=ConsoleColor.Yellow;
            Console.WriteLine("2- Editar plano conta");
            Console.ForegroundColor=ConsoleColor.Magenta;
            Console.WriteLine("3- Excluir plano conta");
            Console.ForegroundColor= ConsoleColor.White;
            Console.WriteLine("0- Voltar");
            Console.Write("Digite uma opção:");


        }
        private PlanoContas CriarPlanoConta()
        {     PlanoContas NovoPlano= new PlanoContas();
              Console.ForegroundColor=ConsoleColor.White;
              Console.Write("Digite uma descrição:");
              Console.ForegroundColor=ConsoleColor.Magenta;
              NovoPlano.Descricao=Console.ReadLine();
              Console.Write("Digite o Tipo [0]Receita|[1] Despesa:");
              int op =int.Parse(Console.ReadLine());
              if(op==0)
              {
                  NovoPlano.Tipo="R";
              }
              else if(op==1)
              {
                  NovoPlano.Tipo="D";
              }
              else
              {
                  NovoPlano.Tipo="D";
              }

            return NovoPlano;


        }
        public void CriarPlanoConta(Usuario use)
        {
            PlanoContas Novo = CriarPlanoConta();
            Novo.UsuarioId=use.IdUsuario;
            new PlanoContaDados().SalvarPlanoConta(Novo);
            new TelaPlanoConta().ListarPlanoConta(use);

        }

        public PlanoContas EditarPlanoConta(int id)
        {
           return new PlanoContaDados().ConsultarPlanoConta(id);
        }
        public void EditarPlanoConta(Usuario use){
            Console.ForegroundColor=ConsoleColor.DarkMagenta;
            new TextoNo().TextoPlanoIdSelecao();
            Console.ForegroundColor=ConsoleColor.Red;
            PlanoContas editarPlano =EditarPlanoConta(int.Parse(Console.ReadLine()));
            Console.ForegroundColor=ConsoleColor.Gray;
            Console.WriteLine("Plano Conta selecionado :");
            Interação(editarPlano);
            Console.Write("Selecione:[0- Descrição| 1-Tipo] ");
            int op=int.Parse(Console.ReadLine());
            if(op==0)
            {
                Console.Write($"[{editarPlano.Descricao}] Digite uma nova descrição: ");
                Console.ForegroundColor=ConsoleColor.DarkRed;
                editarPlano.Descricao=Console.ReadLine();
                if(String.IsNullOrEmpty(editarPlano.Descricao))
                {
                    new TextoNo().CampoVazio();
                    new TelaPlanoConta().ListarPlanoConta(use);
                }
            } else if( op==1)
            {
                Console.Write($"[{editarPlano.Tipo}] Digite um novo tipo: ");
                Console.ForegroundColor=ConsoleColor.DarkRed;
                editarPlano.Tipo=Console.ReadLine();
                if(String.IsNullOrEmpty(editarPlano.Descricao))
                {
                    new TextoNo().CampoVazio();
                    new TelaPlanoConta().ListarPlanoConta(use);
                }
            }
            if(use.IdUsuario!=editarPlano.UsuarioId)
            {
                new TextoNo().UserNoOwner();
                new  TelaPlanoConta().ListarPlanoConta(use);
            }
            Console.WriteLine("Dados Alterados");
            Interação(editarPlano);
            new PlanoContaDados().EditarPlanoConta(editarPlano);
            new TelaPlanoConta().ListarPlanoConta(use);

        }
        private void Interação(PlanoContas plano)
        {
            
            Console.ForegroundColor=ConsoleColor.White;
            Console.WriteLine("|Código   | Descrição  | Tipo");
            Console.WriteLine($"|{plano.IdPlanoContas}  | {plano.Descricao} | {plano.Tipo}");


        }
        public void ExcluirPlanoConta( Usuario use)
        {   Console.ForegroundColor=ConsoleColor.DarkCyan;
            new TextoNo().TextoPlanoIdSelecao();
            Console.ForegroundColor=ConsoleColor.DarkRed;
            PlanoContas PlanoExcluir= EditarPlanoConta(int.Parse(Console.ReadLine()));
            Console.ForegroundColor=ConsoleColor.White;
            Console.WriteLine("Selecionado");
            Interação(PlanoExcluir);
            Console.WriteLine("Deseja excluir ?[0]-Sim |[1-9]- Não ");
            int op= int.Parse(Console.ReadLine());
            if(use.IdUsuario==PlanoExcluir.UsuarioId)
            {
            if(op==0)
            {
                
                new PlanoContaDados().RemoverPlanoConta(PlanoExcluir);
                new TelaPlanoConta().ListarPlanoConta(use);
            }else
            {
                new TextoNo().OperacionAborta();
                new TelaPlanoConta().ListarPlanoConta(use);
            }
            }else
            {
                Console.ForegroundColor=ConsoleColor.Yellow;
                new TextoNo().UserNoOwner();
                new TelaPlanoConta().ListarPlanoConta(use);
            }



        }
        public void InteracaoPlanoConta(Usuario use)
        {
            Console.WriteLine("| Código  || Descrição  || Tipo ");
            Console.WriteLine("-------------------------------- \n");
            foreach (var item in new PlanoContaDados().ListarPlanosContas(use))
            {
                Console.ForegroundColor=f[rm.Next(0,5)];
                Console.WriteLine($"| {item.IdPlanoContas}  || {item.Descricao}  || {item.Tipo}");
                Console.WriteLine("---------------------------------");
            }    
        }
    }
}