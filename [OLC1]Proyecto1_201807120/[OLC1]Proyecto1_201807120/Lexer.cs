using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_Proyecto1_201807120
{
    public class Lexer
    {
        public static int contadorHTML = 0;
        public static int contadorHTML2 = 0;
        //Variable que representa la lista de tokens
        public List<Token> Salida;
        private List<Error> errores;
        //Variable que representa el estado actual
        private int estado;
        //Variable que representa el lexema que actualmente se esta acumulando
        private String auxlex;
        private Token.Tipo tipo;
        public int numErr;
        private String[] reservadas = { "CONJ" };
        private int fila;
        private int columna;
        public static int contador = 0;


        public List<Token> escanear(String entrada)
        {
            entrada = entrada + "¢";
            Salida = new List<Token>();
            errores = new List<Error>();
            fila = 1;
            columna = 0;
            estado = 0;
            this.numErr = 0;
            auxlex = "";
            char c;
            char k;
            char t;
            for (int i = 0; i <= entrada.Length - 1; i++)
            {
                c = entrada.ElementAt(i);
                k = c;
                t = c;
                if (i + 1 < entrada.Length)
                {
                    k = entrada.ElementAt(i + 1);
                }
                if (i - 1 >= 0)
                {
                    t = entrada.ElementAt(i - 1);
                }
                columna++;
                switch (estado)
                {
                    case 0:
                        if (Char.IsLetter(c))
                        {
                            estado = 1;
                            auxlex += c;
                        }
                        else if (Char.IsDigit(c))
                        {
                            estado = 4;
                            auxlex += c;
                        }
                        else if (c == '{')
                        {
                            auxlex += c;
                            if (k == '~')
                            {
                                estado = 7;
                            }
                            else if (k == ',')
                            {
                                estado = 9;
                            }
                            else
                            {
                                agregarToken(Token.Tipo.LLAVE_IZQ);
                            }
                        }
                        else if (c == '[')
                        {
                            auxlex += c;
                            if (k == '~')
                            {
                                estado = 7;
                            }
                            else if (k == ',')
                            {
                                estado = 9;
                            }
                            else
                            {
                                estado = 20;
                            }
                        }
                        else if (c == '}')
                        {
                            auxlex += c;
                            if (k == '~')
                            {
                                estado = 7;
                            }
                            else if (k == ',')
                            {
                                estado = 9;
                            }
                            else
                            {
                                agregarToken(Token.Tipo.LLAVE_DER);
                            }
                        }
                        else if (c == '/')
                        {
                            auxlex += c;
                            if (k == '~')
                            {
                                estado = 7;
                            }
                            else if (k == ',')
                            {
                                estado = 9;
                            }
                            else
                            {
                                estado = 11;
                            }
                        }
                        else if (c == '*')
                        {
                            auxlex += c;
                            if (k == '~')
                            {
                                estado = 7;
                            }
                            else if (k == ',')
                            {
                                estado = 9;
                            }
                            else
                            {
                                agregarToken(Token.Tipo.ASTERISCO);
                            }
                        }
                        else if (c == '%')
                        {
                            auxlex += c;
                            if (k == '~')
                            {
                                estado = 7;
                            }
                            else if (k == ',')
                            {
                                estado = 9;
                            }
                            else
                            {
                                agregarToken(Token.Tipo.ASCII);
                            }
                        }
                        else if (c == '<')
                        {
                            auxlex += c;
                            if (k == '~')
                            {
                                estado = 7;
                            }
                            else if (k == ',')
                            {
                                estado = 9;
                            }
                            else
                            {
                                estado = 13;
                            }
                        }
                        else if (c == ':')
                        {
                            auxlex += c;
                            if (k == '~')
                            {
                                estado = 7;
                            }
                            else if (k == ',')
                            {
                                estado = 9;
                            }
                            else
                            {
                                agregarToken(Token.Tipo.DOS_PUNTOS);
                            }
                        }
                        else if (c == ';')
                        {
                            auxlex += c;
                            if (k == '~')
                            {
                                estado = 7;
                            }
                            else if (k == ',')
                            {
                                estado = 9;
                            }
                            else
                            {
                                agregarToken(Token.Tipo.PUNTO_COMA);
                            }
                        }
                        else if (c == '.')
                        {
                            auxlex += c;
                            if (k == '~')
                            {
                                estado = 7;
                            }
                            else if (k == ',')
                            {
                                estado = 9;
                            }
                            else
                            {
                                agregarToken(Token.Tipo.PUNTO);
                            }
                        }
                        else if (c == ',')
                        {
                            auxlex += c;
                            if (k == '~')
                            {
                                estado = 7;
                            }
                            else if (k == ',')
                            {
                                estado = 9;
                            }
                            else
                            {
                                agregarToken(Token.Tipo.COMA);
                            }
                        }
                        else if (c == '"')
                        {
                            auxlex += c;
                            if (k == '~')
                            {
                                estado = 7;
                            }
                            else if (k == ',')
                            {
                                estado = 9;
                            }
                            else
                            {
                                estado = 17;
                            }
                        }
                        else if (c == '+')
                        {
                            auxlex += c;
                            if (k == '~')
                            {
                                estado = 7;
                            }
                            else if (k == ',')
                            {
                                estado = 9;
                            }
                            else
                            {
                                agregarToken(Token.Tipo.MAS);
                            }
                        }
                        else if (c == '?')
                        {
                            auxlex += c;
                            if (k == '~')
                            {
                                estado = 7;
                            }
                            else if (k == ',')
                            {
                                estado = 9;
                            }
                            else
                            {
                                agregarToken(Token.Tipo.INTERROGACION);
                            }
                        }
                        else if (c == '|')
                        {
                            auxlex += c;
                            if (k == '~')
                            {
                                estado = 7;
                            }
                            else if (k == ',')
                            {
                                estado = 9;
                            }
                            else
                            {
                                agregarToken(Token.Tipo.OR);
                            }
                        }
                        else if (c == '-')
                        {
                            auxlex += c;
                            if (k == '~')
                            {
                                estado = 7;
                            }
                            else if (k == ',')
                            {
                                estado = 9;
                            }
                            else
                            {
                                estado = 18;
                            }
                        }
                        else if (c == '\\')
                        {
                            auxlex += c;
                            if (k == '~')
                            {
                                estado = 7;
                            }
                            else if (k == ',')
                            {
                                estado = 9;
                            }
                            else
                            {
                                estado = 19;
                            }
                        }
                        else if (Char.IsWhiteSpace(c))
                        {
                            if (c == '\n')
                            {
                                columna = 0;
                                fila++;
                            }
                            auxlex = "";
                            estado = 0;
                        }
                        else if ((int)c >= 32 && (int)c <= 125)
                        {
                            auxlex += c;
                            if (k == '~')
                            {
                                estado = 7;
                            }
                            else if (k == ',')
                            {
                                estado = 9;
                            }
                            else
                            {
                                agregarToken(Token.Tipo.RANGO);
                            }
                        }
                        else
                        {
                            if (c == '¢' && i == entrada.Length - 1)
                            {
                                Console.WriteLine("Hemos concluido el analiss con exito");
                            }
                            else
                            {
                                auxlex += c;
                                agregarError(auxlex);
                            }
                        }
                        break;
                    case 1:
                        if (Char.IsLetter(c) || Char.IsDigit(c) || c == '_')
                        {
                            estado = 2;
                            auxlex += c;
                        }
                        else if (c == '~')
                        {
                            estado = 3;
                            auxlex += c;
                        }
                        else
                        {
                            columna--;
                            agregarToken(Token.Tipo.ID);
                            i -= 1;
                        }
                        break;
                    case 2:
                        if (Char.IsLetter(c) || Char.IsDigit(c) || c == '_')
                        {
                            estado = 2;
                            auxlex += c;
                        }
                        else if (Char.IsWhiteSpace(c))
                        {
                            columna--;
                            if (esReservada(auxlex))
                            {
                                agregarToken(tipo);
                            }
                            else
                            {
                                agregarToken(Token.Tipo.ID);
                            }
                            if (c == '\n')
                            {
                                columna = 0;
                                fila++;
                            }
                            columna++;
                        }
                        else
                        {
                            if (esReservada(auxlex))
                            {
                                columna--;
                                agregarToken(tipo);
                                i -= 1;
                            }
                            else
                            {
                                columna--;
                                agregarToken(Token.Tipo.ID);
                                i -= 1;
                            }
                        }
                        break;
                    case 3:
                        if (Char.IsLetter(c))
                        {
                            auxlex += c;
                            agregarToken(Token.Tipo.RANGO);
                        }
                        else
                        {
                            auxlex += c;
                            agregarError(auxlex);
                        }
                        break;
                    case 4:
                        if (Char.IsDigit(c))
                        {
                            estado = 4;
                            auxlex += c;
                        }
                        else if (c == '~')
                        {
                            estado = 5;
                            auxlex += c;
                        }
                        else if (Char.IsWhiteSpace(c))
                        {
                            columna--;
                            agregarToken(Token.Tipo.NUMERO);
                            if (c == '\n')
                            {
                                columna = 0;
                                fila++;
                            }
                            columna++;
                        }
                        else
                        {
                            columna--;
                            agregarToken(Token.Tipo.NUMERO);
                            i -= 1;
                        }
                        break;
                    case 5:
                        if (Char.IsDigit(c))
                        {
                            estado = 6;
                            auxlex += c;
                        }
                        else
                        {
                            auxlex += c;
                            agregarError(auxlex);
                        }
                        break;
                    case 6:
                        if (Char.IsDigit(c))
                        {
                            estado = 6;
                            auxlex += c;
                        }
                        else if (Char.IsWhiteSpace(c))
                        {
                            columna--;
                            agregarToken(Token.Tipo.RANGO);
                            if (c == '\n')
                            {
                                columna = 0;
                                fila++;
                            }
                            columna++;
                        }
                        else
                        {
                            columna--;
                            agregarToken(Token.Tipo.RANGO);
                            i -= 1;
                        }
                        break;
                    case 7:
                        if (c == '~')
                        {
                            estado = 8;
                            auxlex += c;
                        }
                        else
                        {
                            auxlex += c;
                            agregarError(auxlex);
                        }
                        break;
                    case 8:
                        if ((int)c >= 32 && (int)c <= 125)
                        {
                            auxlex += c;
                            agregarToken(Token.Tipo.RANGO);
                        }
                        else
                        {
                            auxlex += c;
                            agregarError(auxlex);
                        }
                        break;
                    case 9:
                        if (c == ',')
                        {
                            agregarToken(Token.Tipo.ASCII);
                            estado = 10;
                            auxlex += c;
                            agregarToken(Token.Tipo.COMA);
                        }
                        else if (Char.IsWhiteSpace(c))
                        {
                            columna--;
                            agregarToken(Token.Tipo.ASCII);
                            if (c == '\n')
                            {
                                columna = 0;
                                fila++;
                            }
                            columna++;
                        }
                        else
                        {
                            columna--;
                            agregarToken(Token.Tipo.ASCII);
                            i -= 1;
                        }
                        break;
                    case 10:
                        if ((int)c >= 32 && (int)c <= 125)
                        {
                            auxlex += c;
                            estado = 9;
                        }
                        else
                        {
                            auxlex += c;
                            agregarError(auxlex);
                        }
                        break;
                    case 11:
                        if (c == '/')
                        {
                            estado = 12;
                            auxlex += c;
                        }
                        else
                        {
                            columna--;
                            agregarToken(Token.Tipo.ASCII);
                            i -= 1;
                        }
                        break;
                    case 12:
                        if (c == '\n')
                        {
                            Console.WriteLine("COl " + columna);
                            agregarToken(Token.Tipo.COM_SIM);
                            fila++;
                            columna = 0;
                        }
                        else
                        {
                            estado = 12;
                            auxlex += c;
                        }
                        break;
                    case 13:
                        if (c == '!')
                        {
                            estado = 14;
                            auxlex += c;
                        }
                        else
                        {
                            columna--;
                            agregarToken(Token.Tipo.ASCII);
                            i -= 1;
                        }
                        break;
                    case 14:
                        if (c == '!')
                        {
                            estado = 15;
                        }
                        else if (c == '\n')
                        {
                            fila++;
                            columna = 0;
                        }
                        else
                        {
                            estado = 14;
                        }
                        auxlex += c;
                        break;
                    case 15:
                        if (c == '>')
                        {
                            auxlex += c;
                            agregarToken(Token.Tipo.COM_MULTI);
                        }
                        else
                        {
                            estado = 14;
                            auxlex += c;
                        }
                        break;
                    case 17:
                        if (c == '"' && t != '\\')
                        {
                            auxlex += c;
                            agregarToken(Token.Tipo.CADENA);
                        }
                        else if (c == '\n')
                        {
                            auxlex += c;
                            fila++;
                            columna = 0;
                        }
                        else
                        {
                            estado = 17;
                            auxlex += c;
                        }
                        break;
                    case 18:
                        if (c == '>')
                        {
                            auxlex += c;
                            agregarToken(Token.Tipo.FLECHA);
                        }
                        else
                        {
                            columna--;
                            agregarToken(Token.Tipo.ASCII);
                            i -= 1;
                        }
                        break;
                    case 19:
                        if (c == 'n')
                        {
                            auxlex = "\n";
                            agregarToken(Token.Tipo.ASCII);
                        }
                        else if (c == 't')
                        {
                            auxlex = "\t";
                            agregarToken(Token.Tipo.ASCII);
                        }
                        else if (c == '"')
                        {
                            auxlex = "\"";
                            agregarToken(Token.Tipo.ASCII);
                        }
                        else
                        {
                            columna--;
                            agregarToken(Token.Tipo.ASCII);
                            i -= 1;
                        }
                        break;
                    case 20:
                        if (c == ':')
                        {
                            auxlex += c;
                            estado = 21;
                        }
                        else
                        {
                            auxlex += c;
                            agregarError(auxlex);
                        }
                        break;
                    case 21:
                        if (c == ':')
                        {
                            auxlex += c;
                            estado = 22;
                        }
                        else
                        {
                            auxlex += c;
                            estado = 21;
                        }
                        break;
                    case 22:
                        if (c == ']')
                        {
                            auxlex += c;
                            agregarToken(Token.Tipo.TODO);
                        }
                        else
                        {
                            auxlex += c;
                            agregarError(auxlex);
                        }
                        break;
                }
            }
            return Salida;
        }

        public void agregarToken(Token.Tipo tipo)
        {
            Salida.Add(new Token(tipo, auxlex, fila, columna));
            auxlex = "";
            estado = 0;
        }

        public void agregarError(String valor)
        {
            errores.Add(new Error(valor, fila, columna));
            Console.WriteLine("Error lexico con: " + auxlex);
            Form1._Form1.cout("Error lexico con: " + auxlex);
            this.numErr += 1;
            auxlex = "";
            estado = 0;
        }

        private Boolean esReservada(String palabra)
        {
            Boolean res = false;
            foreach (String reservada in reservadas)
            {
                if (palabra.Equals(reservada))
                {
                    if (reservada.Equals("CONJ"))
                    {
                        tipo = Token.Tipo.CONJ;
                    }
                    res = true;
                }
            }
            return res;
        }

        public void imprimirListaToken(List<Token> lista)
        {
            foreach (Token item in lista)
            {
                Console.WriteLine(item.getTipo() + "           " + item.getVal());
            }
            Console.WriteLine("Numero de errores: " + numErr);
            Form1._Form1.cout("Analisis concliudo No. de errores: " + numErr + "\n");
        }

        public List<Expresion> generarExpresiones(List<Token> entrada)
        {
            List<Expresion> expresiones = new List<Expresion>();
            for (int i = 0; i < entrada.Count; i++)
            {
                if (entrada.ElementAt(i).getTipo() == Token.Tipo.ID)
                {
                    if ((entrada.ElementAt(i + 1).getTipo() == Token.Tipo.FLECHA) && (entrada.ElementAt(i - 2).getTipo() != Token.Tipo.CONJ))
                    {
                        Expresion ex = new Expresion(entrada.ElementAt(i).getVal());
                        int j = i + 2;
                        Token tok = entrada.ElementAt(j);
                        while (tok.getTipo() != Token.Tipo.PUNTO_COMA)
                        {
                            if ((tok.getTipo() != Token.Tipo.LLAVE_IZQ) && (tok.getTipo() != Token.Tipo.LLAVE_DER))
                            {
                                ex.addToken(tok);
                            }
                            j++;
                            tok = entrada.ElementAt(j);
                        }
                        ex.ponerAFN();
                        expresiones.Add(ex);
                    }
                }
            }
            return expresiones;
        }

        public List<Conjunto> generarConjuntos(List<Token> entrada)
        {
            List<Conjunto> conjuntos = new List<Conjunto>();
            for (int i = 0; i < entrada.Count; i++)
            {
                if (entrada.ElementAt(i).getTipo() == Token.Tipo.ID)
                {
                    if ((entrada.ElementAt(i + 1).getTipo() == Token.Tipo.FLECHA) && (entrada.ElementAt(i - 2).getTipo() == Token.Tipo.CONJ))
                    {
                        Conjunto conj = new Conjunto(entrada.ElementAt(i).getVal());
                        int j = i + 2;
                        Token tok = entrada.ElementAt(j);
                        while (tok.getTipo() != Token.Tipo.PUNTO_COMA)
                        {
                            if ((tok.getTipo() != Token.Tipo.COMA))
                            {
                                conj.addCaracteres(tok);
                            }
                            j++;
                            tok = entrada.ElementAt(j);
                        }
                        conjuntos.Add(conj);
                    }
                }
            }
            return conjuntos;
        }

        

        public List<Lexema> validarLexemas(List<Token> entrada)
        {

            List<Lexema> lexemas = new List<Lexema>();
            for (int i = 0; i < entrada.Count; i++)
            {
                if (entrada.ElementAt(i).getTipo() == Token.Tipo.ID)
                {
                    if ((entrada.ElementAt(i + 1).getTipo() == Token.Tipo.DOS_PUNTOS))
                    {
                        Lexema l = new Lexema(entrada.ElementAt(i).getVal(), entrada.ElementAt(i + 2).getVal(), entrada.ElementAt(i).getFila(), 0);
                        foreach (Expresion ex in Form1.expresiones)
                        {
                            if (ex.nombre.Equals(entrada.ElementAt(i).getVal()))
                            {
                                l.aceptado = ex.afn.evaluarExpresion(entrada.ElementAt(i + 2).getVal());
                                Console.WriteLine("ACEPTADO ? " + l.aceptado + "   " + l.lexema + "   " + l.nombreExpresion);
                                String a;
                                if (l.aceptado == true)
                                {
                                    a = "VALIDA";
                                }
                                else
                                {
                                    a = "INVALIDA";
                                }
                                Form1._Form1.cout(l.nombreExpresion + " - " + l.lexema + " : " + a + "\n");
                            }
                        }
                        lexemas.Add(l);
                    }
                }
            }
            return lexemas;
        }

        public void tokens_html()
        {
            String cont1;
            String cont2;
            String tokens = "";
            String temp;
            cont1 = "<html>" +
            "<body>" +
            "<h1 align='center'><font face='verdana'>Listado de Tokens</font></h1>" +
            "<table cellpadding='10' border = '1' align='center'>" +
            "<tr>" +
            "<td><strong>No." +
            "</strong></td>" +
            "<td><strong>Lexema" +
            "</strong></td>" +
            "<td><strong>Fila" +
            "</strong></td>" +
            "<td><strong>Columna" +
            "</strong></td>" +
            "<td><strong>Token" +
            "</strong></td>" +
            "</tr>";

            for (int i = 0; i < Salida.Count; i++)
            {
                Token tok = Salida.ElementAt(i);
                temp = "";
                temp = "<tr>" +
                "<td><strong>" + (i + 1).ToString() +
                "</strong></td>" +
                "<td>" + tok.getVal() +
                "</td>" +
                "<td>" + tok.getFila() +
                "</td>" +
                "<td>" + tok.getColumna() +
                "</td>" +
                "<td>" + tok.getTipo() +
                "</td>" +
                "</tr>";
                tokens += temp;
            }

            cont2 = "</table>" +
            "</body>" +
            "</html>";

            File.WriteAllText("Tokens_" + contadorHTML + ".html", cont1 + tokens + cont2);
            System.Diagnostics.Process.Start("Tokens_" + contadorHTML++ + ".html");
        }

        public void errores_html()
        {
            String cont1;
            String cont2;
            String body = "";
            String temp;
            cont1 = "<html>" +
            "<body>" +
            "<h1 align='center'><font face='verdana'>Listado de errores</font></h1>" +
            "<table cellpadding='10' border = '1' align='center'>" +
            "<tr>" +
            "<td><strong>No." +
            "</strong></td>" +
            "<td><strong>Caracter" +
            "</strong></td>" +
            "<td><strong>Fila" +
            "</strong></td>" +
            "<td><strong>Columna" +
            "</strong></td>" +
            "<td><strong>Tipo" +
            "</strong></td>" +
            "</tr>";

            for (int i = 0; i < errores.Count; i++)
            {
                Error err = errores.ElementAt(i);
                temp = "";
                temp = "<tr>" +
                "<td><strong>" + (i + 1).ToString() +
                "</strong></td>" +
                "<td>" + err.val +
                "</td>" +
                "<td>" + err.fila +
                "</td>" +
                "<td>" + err.getcolumna() +
                "</td>" +
                "<td>Desconocido" +
                "</td>" +
                "</tr>";
                body += temp;
            }

            cont2 = "</table>" +
            "</body>" +
            "</html>";

            File.WriteAllText("Errores_" + contadorHTML2 + ".html", cont1 + body + cont2);
            System.Diagnostics.Process.Start("Errores_" + contadorHTML2++ + ".html");
        }

    }
}
