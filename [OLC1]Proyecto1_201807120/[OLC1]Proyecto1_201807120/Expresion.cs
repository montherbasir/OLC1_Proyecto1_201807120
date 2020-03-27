using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_Proyecto1_201807120
{
    public class Expresion
    {
        public String nombre { get; set; }
        public AFN afn { get; set; }
        public List<Token> tokens { get; set; }

        public Expresion(string nombre)
        {
            this.nombre = nombre;
            this.tokens = new List<Token>();
        }

        public void addToken(Token t)
        {
            tokens.Add(t);
        }

        public void ponerAFN()
        {
            afn = new AFN(this.tokens, this.nombre);
            try
            {
                afn.generarAFD();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
