using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_Proyecto1_201807120
{
    public class Lexema
    {
        public String nombreExpresion { get; set; }
        public String lexema { get; set; }
        public Boolean aceptado { get; set; }
        public int fila { get; set; }
        public int col { get; set; }

        public Lexema(string nombreExpresion, string lexema, int fila, int col)
        {
            this.nombreExpresion = nombreExpresion;
            this.lexema = lexema;
            this.aceptado = false;
            this.fila = fila;
            this.col = col;
        }
    }
}
