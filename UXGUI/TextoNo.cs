using System;
using System.Linq;
using contigencia.Models;
namespace contigencia.UXGUI
{
    public class TextoNo
    {
        public TextoNo(){}

        public void UserNoOwner(){
            Console.WriteLine("S01- Você não é o dono desse objeto! "+
                "Operação ilegal ");
        }
        public void CampoVazio()
        {
            Console.WriteLine(" 05- Campo vazio!");
        }

        public void TextoPlanoIdSelecao()
        {
            Console.Write("Digite o Código do Plano conta : ");
        }

        public void OperacionAborta()
        {
            Console.Write(" S06- Operação abortada pelo usuário! ");
        }

        public void TextoOpcoesTransacao()
        {
            Console.WriteLine("Opções:");
            Console.WriteLine("0- Voltar:");
            Console.ForegroundColor=ConsoleColor.DarkGreen;
            Console.WriteLine("1- Nova Transação:");
            Console.ForegroundColor=ConsoleColor.Yellow;
            Console.WriteLine("2- Editar Transação");
            Console.ForegroundColor=ConsoleColor.Magenta;
            Console.WriteLine("3- Excluir Transação");
            Console.ForegroundColor=ConsoleColor.Cyan;
            Console.WriteLine("4- Listar Todas Transações");
            Console.WriteLine("5- Listar uma Transação");
            Console.WriteLine("6- Listar Transações por ordem de data recente");
            Console.WriteLine("7- Listar Transações por período");
            Console.Write("Digite o número da opção: ");
            Console.ForegroundColor=ConsoleColor.DarkGray;

        }
        public void SaudacaoUser(Usuario use)
        {
            Console.ForegroundColor =ConsoleColor.DarkCyan;
            Console.Write("Usuario :");
            Console.ForegroundColor =ConsoleColor.Magenta;
            Console.WriteLine($"{use.Nome}");
        }
        public void TextoTransacaoIdSelecao()
        {
            Console.ForegroundColor=ConsoleColor.White;
            Console.Write("Digite o Código da Transacao : ");
        }
        public void TextoEdicaoTransacao()
        {
            Console.WriteLine("Opções:");
            Console.WriteLine("0- Voltar:");
            Console.ForegroundColor=ConsoleColor.DarkGreen;
            Console.WriteLine("1- Editar historico:");
            Console.ForegroundColor=ConsoleColor.Yellow;
            Console.WriteLine("2- Editar Data:");
            Console.ForegroundColor=ConsoleColor.Magenta;
            Console.WriteLine("3- Editar Valor:");
            Console.ForegroundColor=ConsoleColor.Cyan;
            Console.WriteLine("4- Editar Tipo:");
            Console.WriteLine("5- Editar Plano conta");
            Console.WriteLine("6- Editar Conta");
             Console.Write("Digite o número da opção: ");
            Console.ForegroundColor=ConsoleColor.DarkGray;
        }
    }
}