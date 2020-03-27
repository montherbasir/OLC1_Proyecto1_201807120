using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_Proyecto1_201807120
{
    public class Error
    {
        private String valor;
        private int row;
        private int col;

        public string val { get => valor; set => valor = value; }
        public int fila { get => row; set => row = value; }
        public int columna { get => col; set => col = value; }


        public Error(string val, int fila, int columna)
        {
            this.val = val;
            this.fila = fila;
            this.columna = columna;
        }
        public int getcolumna()
        {
            int n = valor.Length;
            return col - n;
        }
    }
}
