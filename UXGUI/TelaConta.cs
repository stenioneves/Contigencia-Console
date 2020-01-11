using System;
using System.Linq;
using contigencia.Models;
using contigencia.Dados;

namespace contigencia.UXGUI
{
    public class Telaconta
    {
        private FinanceiroContext fc = new FinanceiroContext();

        ConsoleColor[] f={ConsoleColor.Blue,ConsoleColor.Red,ConsoleColor.Yellow,ConsoleColor.Green,ConsoleColor.Magenta,ConsoleColor.Cyan};
        Random rm = new Random();
        public void ListarConta(Usuario us){
            var contas = from Conta in fc.Conta.ToList()
                        where Conta.UsuarioIdUsuario== us.IdUsuario
                        select Conta;
            Console.ForegroundColor =ConsoleColor.White;
            Console.WriteLine("Módulo Contas");
            Console.ForegroundColor =ConsoleColor.Blue;
            Console.Write("Usuario :");
            Console.ForegroundColor =ConsoleColor.Green;
            Console.WriteLine($"{us.Nome}");
            Console.ForegroundColor=ConsoleColor.White;
            Console.WriteLine("Essas são as suas contas cadastrada!");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("| Código  || Nome  || Saldo ");
            Console.WriteLine("-------------------------------- \n");
            foreach (var item in contas)
            {
                Console.ForegroundColor=f[rm.Next(0,5)];
                //Console.WriteLine("_________________________________");
                Console.WriteLine($"| {item.Idconta}  || {item.NomeConta}  || {item.Saldo}");
                Console.WriteLine("---------------------------------");
            }
             OpcoesTelaConta();

            int op= int.Parse(Console.ReadLine());
            switch (op)
            {  case 0:
                 new TelaPrincipal().TelaPS(us);
                break;
                case 1:
                TEdicaoConta(us);
                break;
                case 2:
                CriarConta(us);
                break;
                case 3:
                TExcuirConta(us);
                break;

                
                default: 
                break;
            }
        }   private void OpcoesTelaConta(){
             Console.ForegroundColor=ConsoleColor.DarkBlue;
             Console.WriteLine("Escolha uma opção :");
             Console.ForegroundColor=ConsoleColor.White;
             Console.WriteLine("0- Voltar tela Principal");
             Console.ForegroundColor=ConsoleColor.Yellow;
             Console.WriteLine("1- Editar Conta");
             Console.ForegroundColor=ConsoleColor.White;
             Console.WriteLine("2- Criar Conta");
             Console.ForegroundColor=ConsoleColor.Red;
             Console.WriteLine("3- Excluir Conta");
             Console.ForegroundColor=ConsoleColor.White;
             Console.Write("Digite a opção :");

        }
        private void TEdicaoConta( Usuario use){
            Console.ForegroundColor=ConsoleColor.White;
            Console.Write("Digite o código da conta para edição:");
            Conta contaSelecionada = new ContasDados().ConsultarConta(int.Parse(Console.ReadLine()));
            Console.WriteLine("Conta seleciona :");
            Console.WriteLine($"Nome:{contaSelecionada.NomeConta}");
            Console.WriteLine($"Saldo: {contaSelecionada.Saldo}");
            Conta editada= EdicaoConta(contaSelecionada);
            Console.ForegroundColor=ConsoleColor.White;
            Console.WriteLine("Sua Alteração:");
            Console.WriteLine($"Nome:{editada.NomeConta} || Saldo:{editada.Saldo}");
            if(use.IdUsuario==editada.UsuarioIdUsuario)
            {
                new  ContasDados().SalvarEdicao(editada);
                new Telaconta().ListarConta(use);
            }else{
                new TextoNo().UserNoOwner();
                this.ListarConta(use);
            }

            

        }

        private Conta EdicaoConta( Conta conta){
            Console.Write("0- Altera Nome | 1-Alterar Saldo:");
            int op =int.Parse(Console.ReadLine());
            Console.WriteLine("");
            if(op==0){
                Console.Write($"[{conta.NomeConta}] Digite um novo Nome:");
                Console.ForegroundColor=ConsoleColor.Red;
                conta.NomeConta=Console.ReadLine();
                return conta;

            }if(op==1){
                Console.Write($"[{conta.Saldo}] Digite um novo Saldo(0.00):");
                Console.ForegroundColor=ConsoleColor.Red;
                conta.Saldo=decimal.Parse(Console.ReadLine());
                return conta;
            }
            return conta;
        }
        private Conta TCriarConta(){
                Conta NovaConta = new Conta();
                
                Console.ForegroundColor= ConsoleColor.White;
                Console.WriteLine("Nova Conta");
                Console.Write("Digite o nome da conta:");
                Console.ForegroundColor= ConsoleColor.Yellow;
                NovaConta.NomeConta=Console.ReadLine();
                Console.Write("Digite um saldo :");
                NovaConta.Saldo=decimal.Parse(Console.ReadLine());
                return NovaConta;
        }
        public void CriarConta(Usuario use){
            Conta Nova_conta = TCriarConta();
            if(!String.IsNullOrEmpty(Nova_conta.NomeConta)){
            Nova_conta.UsuarioIdUsuario=use.IdUsuario;
            new ContasDados().Salvar(Nova_conta);
            new Telaconta().ListarConta(use);
            }
            else{
                Console.WriteLine(" 03- Os campos Senha e Saldo são obrigatorios!");
                this.ListarConta(use);
            }

        }
        public void TExcuirConta(Usuario use){
            Console.ForegroundColor=ConsoleColor.White;
            Console.Write("Digite código da conta para exclusão:");
            Console.ForegroundColor=ConsoleColor.Red;
            Conta contaSelecionada = new ContasDados().ConsultarConta(int.Parse(Console.ReadLine()));

            if(use.IdUsuario==contaSelecionada.UsuarioIdUsuario)
            {   Console.ForegroundColor=ConsoleColor.White;
                Console.WriteLine("Conta seleciona :");
                Console.WriteLine($"Nome:{contaSelecionada.NomeConta}");
                Console.WriteLine($"Saldo: {contaSelecionada.Saldo}");
                Console.ForegroundColor=ConsoleColor.DarkYellow;
                Console.Write("Conifirma a exclusão ? 0-Sim |[1-9] Não");
                int op = int.Parse(Console.ReadLine());
                if(op==0)
                {
                    new ContasDados().ExcluirConta(contaSelecionada);
                    new Telaconta().ListarConta(use);
                }
                else
                {
                    Console.ForegroundColor=ConsoleColor.DarkRed;
                    Console.WriteLine("04- Exclusão abortada!");
                    this.ListarConta(use);
                }

                

          

            }else {
                new TextoNo().UserNoOwner();
            }

            
        }





        
     
       
    }    
}