using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_Proyecto1_201807120
{
    public class TransicionAFD
    {
            public Token caracter { get; set; }
            public Estado sig { get; set; }

            public TransicionAFD(Token caracter, Estado sig)
            {
                this.caracter = caracter;
                this.sig = sig;
            }
    }
}
