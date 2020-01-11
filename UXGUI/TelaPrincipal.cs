using System;
using System.Linq;
using contigencia.Models;


namespace contigencia.UXGUI
{
    public class TelaPrincipal
    {
        private Login lg = new Login();
        public TelaPrincipal (){
            
        } 
       

        public  void TelaPS(Usuario us){
            Console.Clear();
            lg.HeadText();
            Console.ForegroundColor=ConsoleColor.DarkGreen;
            Console.WriteLine($"Bem vindo {us.Nome}!");
            OpcaoCentral(us);

        }
        public void OpcaoCentral( Usuario usw)
        {
            Console.ForegroundColor=ConsoleColor.White;
            Console.WriteLine("Painel Principal");
            Console.WriteLine("Selecione : ");
            Console.ForegroundColor=ConsoleColor.Yellow;
            Console.WriteLine("1- Conta");
            Console.ForegroundColor=ConsoleColor.Green;
            Console.WriteLine("2- Plano conta");
            Console.ForegroundColor=ConsoleColor.Blue;
            Console.WriteLine("3- Transação");
            Console.ForegroundColor=ConsoleColor.Gray;
            Console.WriteLine("0- Sair");
            Console.ForegroundColor=ConsoleColor.Red;
            Console.WriteLine("5- Futuro");
            Console.ForegroundColor= ConsoleColor.White;
            Console.WriteLine("Escolha um opção:");
            SelOpcao( int.Parse(Console.ReadLine()),usw);
        }
        public void SelOpcao( int op,Usuario use){
            
            switch (op)
            { case  1:
             Console.Clear();
             Telaconta tc = new Telaconta();
             tc.ListarConta(use);
             break;
             case 0:
             Console.Clear();
             Console.WriteLine("Sair selecionado!");
             lg.TelaLogin();
             break;


              default :
              Console.WriteLine("Opção invalida !");
              this.TelaPS(use);
              break; 
                
            }
        }
    }
}