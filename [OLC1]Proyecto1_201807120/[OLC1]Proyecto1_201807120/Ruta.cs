using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_Proyecto1_201807120
{
    public class Ruta
    {
        private string path { get; set; }
        private string name { get; set; }

        public string nombre { get => name; set => name = value; }
        public string ruta { get => path; set => path = value; }
        public Ruta(string path, string name)
        {
            this.path = path;
            this.name = name;
        }
    }
}
