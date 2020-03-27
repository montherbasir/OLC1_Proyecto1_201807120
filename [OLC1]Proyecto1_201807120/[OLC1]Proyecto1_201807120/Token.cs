using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_Proyecto1_201807120
{
    public class Token
    {
        public enum Tipo
        {
            COM_SIM,
            COM_MULTI,
            LLAVE_IZQ,
            LLAVE_DER,
            ID,
            FLECHA,
            PUNTO_COMA,
            COMA,
            DOS_PUNTOS,
            CADENA,
            PUNTO,
            OR,
            INTERROGACION,
            ASTERISCO,
            MAS,
            RANGO,
            CONJ,
            NUMERO,
            ASCII,
            TODO
        }

        private Tipo tipo;
        private String valor;
        private int fila;
        private int columna;

        public Token(Tipo tipoDelToken, String val, int fila, int columna)
        {
            this.tipo = tipoDelToken;
            this.valor = val;
            this.fila = fila;
            this.columna = columna;
        }

        public void setVal(String valor)
        {
            this.valor = valor;
        }

        public String getVal()
        {
            if (tipo == Tipo.CADENA)
            {
                return valor.Remove(valor.Length - 1, 1).Remove(0, 1);
            }
                return valor;
        }
        public int getFila()
        {
            return fila;
        }
        public int getColumna()
        {
            int n = valor.Length;
            if (tipo != Tipo.COM_MULTI)
            {
                return columna - n;
            }
            return 0;
        }
        public Tipo getTipo()
        {
            return tipo;
        }
        public String getNombreTipo()
        {
            switch (tipo)
            {
                case Tipo.COM_MULTI:
                    return "Comentario multiple";
                case Tipo.COM_SIM:
                    return "Comentario simple";
                case Tipo.ID:
                    return "Identificador";
                case Tipo.FLECHA:
                    return "Flecha";
                case Tipo.PUNTO:
                    return "Punto";
                case Tipo.OR:
                    return "Or";
                case Tipo.INTERROGACION:
                    return "Interrogacion";
                case Tipo.DOS_PUNTOS:
                    return "Dos puntos";
                case Tipo.LLAVE_IZQ:
                    return "Llave abre";
                case Tipo.LLAVE_DER:
                    return "Llave cierra";
                case Tipo.PUNTO_COMA:
                    return "Punto y coma";
                case Tipo.ASTERISCO:
                    return "Asterisoc";
                case Tipo.CADENA:
                    return "Cadena";
                case Tipo.MAS:
                    return "Mas";
                case Tipo.RANGO:
                    return "Rango";
                case Tipo.CONJ:
                    return "Palabra Conjunto";
                case Tipo.TODO:
                    return "Conjunto todo";
                default:
                    return "Desconocido";
            }
        }
    }
}
