using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_Proyecto1_201807120
{
    public class Nodo
    {
        public Transicion t1 { get; set; }
        public Transicion t2 { get; set; }
        public int Id { get; set; }

        public Nodo(int id)
        {
            Id = id;
        }

    }
}
