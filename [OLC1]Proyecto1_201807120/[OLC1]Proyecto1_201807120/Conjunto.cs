using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_Proyecto1_201807120
{
    public class Conjunto
    {
        public HashSet<Char> caracteres { get; set; }
        public String nombre { get; set; }

        public Conjunto(string nombre)
        {
            this.nombre = nombre;
            caracteres = new HashSet<char>();
        }

        public void addCaracteres(Token t)
        {
            String str = t.getVal().Replace("\\t", "\t").Replace("\\n", "\n").Replace("\\\"", "\"");
            Console.WriteLine("REPLACED: " + str);
            if (t.getTipo().Equals(Token.Tipo.RANGO))
            {
                Char i = str.ElementAt(0);
                Char f = str.ElementAt(2);
                if ((int)i <= (int)f)
                {
                    for (int j = (int)i; j <= (int)f; j++)
                    {
                        caracteres.Add((char)j);
                        Console.WriteLine("Conj " + nombre + " add: " + (char)j);
                    }
                }                
            }
            else if (t.getTipo().Equals(Token.Tipo.ASCII))
            {
                caracteres.Add(str.ElementAt(0));
                Console.WriteLine("Conj " + nombre + " add: " + str.ElementAt(0));
            }
            else if(t.getTipo().Equals(Token.Tipo.TODO))
            {

                for (int k = 2; k < str.Length-2; k++)
                {
                    caracteres.Add(str.ElementAt(k));
                    Console.WriteLine("Conj " + nombre + " add: " + str.ElementAt(k));
                }
            }
        }

    }
}
