using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_Proyecto1_201807120
{
    public class Transicion
    {
        public Token caracter { get; set; }
        public Nodo sig { get; set; }

        public Transicion(Token caracter, Nodo sig)
        {
            this.caracter = caracter;
            this.sig = sig;
        }
    }
}
