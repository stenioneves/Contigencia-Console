using System;
using System.Linq;

namespace contigencia.UXGUI
{
    public class TextoNo
    {
        public TextoNo(){}

        public void UserNoOwner(){
            Console.WriteLine("S01- Você não é o dono dessa conta!"+
                "Operação ilegal");
        }
    }
}