using System;
using contigencia.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using contigencia.Security;
namespace contigencia.UXGUI

{
    public class Login 
    {
        private Usuario use = new Usuario();
        public Login()
        {

        }            
                
              public void TelaLogin(){
              Desenho();
              HeadText();
                  
              
              Console.ForegroundColor= ConsoleColor.Blue;
              Console.Write($" Usuário :");
              Console.ForegroundColor= ConsoleColor.Green;
               use.Email=Console.ReadLine();
               Console.ForegroundColor= ConsoleColor.Blue;
              Console.Write($" Senha :");
              Console.ForegroundColor= ConsoleColor.Red;
              use.Senha= new Validation().MascaraSenha();
               
              Console.Clear();
              Usuario user = new Validation().ConsultarUsuario(use);
                            
              if(use.Email.Equals(user.Email) && use.Senha.Equals(user.Senha)){

                  TelaPrincipal tp =new TelaPrincipal();
                  tp.TelaPS(user);
              } else
              {    HeadText();
                  Console.ForegroundColor= ConsoleColor.DarkRed;
                  Console.WriteLine($"  01 -Desculpa! Nenhum usuário encontrado com os dados  informados "+
                  "Favor verificar os dados");
                  Console.ForegroundColor=ConsoleColor.DarkGreen;
                  Console.WriteLine($"Acesso negado !");
              }
              }
              

          
          public void HeadText(){
              //Console.Clear();
             
              //Desenho2();
              Console.WriteLine($" SPGF- Login V-0.1 {DateTime.Now}");
          }
          private void Desenho(){

              Console.Clear();
              Console.WriteLine("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ");
               Console.WriteLine("████▌▄▌▄▐▐▌█████ ");
                Console.WriteLine("████▌▄▌▄▐▐▌▀████ ");
                 Console.WriteLine("▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ");

                                 
          }
          private void Desenho2(){
              Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+");
              Console.WriteLine("|F|i|n|a|n|c|e|i|r|o|");
              Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+");
          }

          
}
}