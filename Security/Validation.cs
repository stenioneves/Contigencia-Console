using Microsoft.EntityFrameworkCore;
using System.Linq;
using contigencia.Models;
using System;


namespace contigencia.Security
{


    public class Validation
    {

        /**
         Método de validaçã do usuário e consulta no banco de dados usando o Linq 
        */
        public Usuario ConsultarUsuario(Usuario us)
        {  Usuario usuario = new Usuario();
             var result = from Usuario in new FinanceiroContext().Usuario
                                where Usuario.Email==us.Email && Usuario.Senha==us.Senha
                                select Usuario;
                                Console.WriteLine(us.Nome);
                                foreach (var item in result)
                                {
                                    usuario.IdUsuario= item.IdUsuario;
                                    usuario.Nome=item.Nome;
                                    usuario.Email=item.Email;
                                    usuario.Senha=item.Senha;
                                    usuario.DataNascimento=item.DataNascimento;
                                    //Console.WriteLine(item.Nome);
                                }
                return usuario;                
        }


/**
  Método para ocutar a senha no terminal e retorna o dado digitado pelo usuario tratado,
  esse método e chamado na tela de Login e faz a letura da senha.
*/

        public string MascaraSenha(){
            string pass = "";
//Console.Write("Enter your password: ");
ConsoleKeyInfo key;

do
{
    key = Console.ReadKey(true);

    // Backspace Should Not Work
    if (key.Key != ConsoleKey.Backspace)
    {
        pass += key.KeyChar;
        Console.Write("*");
    }
    else
    {
        Console.Write("\b");
    }
}
// Stops Receving Keys Once Enter is Pressed
while (key.Key != ConsoleKey.Enter);

//Remove o espaco adcional do enter 
 string correcao ="";
for (int i = 0; i < pass.Length-1; i++)
{
    correcao+= pass[i];
}
//Console.WriteLine();
//Console.WriteLine("The Password You entered is : " + pass);
     return correcao;
              
        }

        
    }
}