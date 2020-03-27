using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_Proyecto1_201807120
{
    public class Estado
    {
        public HashSet<Nodo> nodos { get; set; }
        public String nombre { get; set; }
        public List<TransicionAFD> transiciones { get; set; }
        public Boolean aceptacion { get; set; }

        public Estado(HashSet<Nodo> nodos, string nombre)
        {
            this.nodos = nodos;
            this.nombre = nombre;
            transiciones = new List<TransicionAFD>();
            aceptacion = false;
        }

        
    }
}
