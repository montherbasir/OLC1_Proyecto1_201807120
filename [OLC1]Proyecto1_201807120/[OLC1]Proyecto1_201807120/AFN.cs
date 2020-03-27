using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_Proyecto1_201807120
{
    public class AFN
    {
        public Nodo inicio { get; set; }
        public Nodo fin { get; set; }
        private int cont;
        private int n;
        public List<Token> tokens { get; private set; }
        private Token EPSILON = new Token(Token.Tipo.CADENA, "\"&#603;\"", 0, 0);
        private List<Nodo> visitados;
        private HashSet<Token> terminales;
        private HashSet<String> ts;
        public String nombre { get; set; }
        public List<Estado> afd { get; set; }
        public AFN(List<Token> tokens, String n)
        {
            nombre = n;
            this.inicio = new Nodo(0);
            this.fin = new Nodo(1);
            this.tokens = tokens;
            this.visitados = new List<Nodo>();
            this.cont = 0;
            this.n = 2;
            ts = new HashSet<string>();
            terminales = new HashSet<Token>();
            add(inicio, fin);
            graficar();
        }

        public void add(Nodo i, Nodo f)
        {
            Token t = tokens.ElementAt(cont++);
            
            switch (t.getTipo())
            {
                case Token.Tipo.OR:
                    Nodo t1 = new Nodo(n++);
                    Nodo t2 = new Nodo(n++);
                    Nodo t3 = new Nodo(n++);
                    Nodo t4 = new Nodo(n++);
                    i.t1 = new Transicion(EPSILON, t1);
                    i.t2 = new Transicion(EPSILON, t2);
                    t3.t1 = new Transicion(EPSILON, f);
                    t4.t1 = new Transicion(EPSILON, f);
                    add(t1, t3);
                    add(t2, t4);
                    break;
                case Token.Tipo.ASTERISCO:
                    Nodo n1 = new Nodo(n++);
                    Nodo n2 = new Nodo(n++);
                    i.t1 = new Transicion(EPSILON, n1);
                    i.t2 = new Transicion(EPSILON, f);
                    n2.t1 = new Transicion(EPSILON, f);
                    n2.t2 = new Transicion(EPSILON, n1);
                    add(n1, n2);
                    break;
                case Token.Tipo.INTERROGACION:
                    Nodo x1 = new Nodo(n++);
                    Nodo x2 = new Nodo(n++);
                    Nodo x3 = new Nodo(n++);
                    Nodo x4 = new Nodo(n++);
                    i.t1 = new Transicion(EPSILON, x1);
                    i.t2 = new Transicion(EPSILON, x2);
                    x2.t1 = new Transicion(EPSILON, x4);
                    x3.t1 = new Transicion(EPSILON, f);
                    x4.t1 = new Transicion(EPSILON, f);
                    add(x1, x3);
                    break;
                case Token.Tipo.PUNTO:
                    Nodo a1 = new Nodo(n++);
                    add(i, a1);
                    add(a1, f);
                    break;
                case Token.Tipo.MAS:
                    Nodo b1 = new Nodo(n++);
                    Nodo b2 = new Nodo(n++);
                    i.t1 = new Transicion(EPSILON, b1);
                    b2.t1 = new Transicion(EPSILON, f);
                    b2.t2 = new Transicion(EPSILON, b1);
                    add(b1, b2);
                    break;
                case Token.Tipo.CADENA:
                case Token.Tipo.ID:
                    i.t1 = new Transicion(t, f);
                    if (!ts.Contains(t.getVal()))
                    {
                        terminales.Add(t);
                        ts.Add(t.getVal());
                    }
                    break;
            }
        }

        public void graficar()
        {
            visitados.Clear();
            String g;
            g = "digraph {\n" +
                "overlap = false;\n" +
                "splines = true;\n" +
                "rankdir = LR;\n" +
                "node [shape=circle, height=0.5, width=1.5, fontsize=30];\n" +
                "edge [fontsize=26];\n" +
                "graph[dpi=75];\n\n";
            g += getGraph(inicio);
            g += "}";
            Console.WriteLine(g);
            generarGrafica(g, "afn_"+this.nombre);
        }

        public static void generarGrafica(String graphviz, String nombre)
        {
            System.IO.File.WriteAllText(nombre + ".dot", graphviz);
            String com = "dot -Tpng " + nombre + ".dot -o " + nombre + ".png ";
            var comando = string.Format(com);
            var procStart = new ProcessStartInfo("cmd", "/C" + comando);
            var proc = new Process();
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.StartInfo = procStart;
            proc.Start();
            proc.WaitForExit();
        }

        public String getGraph(Nodo n)
        {
            String g;
            visitados.Add(n);          

            g = "\"" + n.Id + "\" [label=\"" + n.Id + "\"";
            
            if (n.Equals(fin))
            {
                g += ", peripheries=2";
            }
            g += "];\n";

            if (n.t1 != null)
            {
                if (!visitados.Contains(n.t1.sig))
                {
                    g += getGraph(n.t1.sig);
                }
                g += "\"" + n.Id + "\" -> \"" + n.t1.sig.Id + "\"[label=\""+n.t1.caracter.getVal().Replace("\\","\\\\").Replace("\\\"", "\"") + "\"];\n";
            }
            if (n.t2 != null)
            {
                if (!visitados.Contains(n.t2.sig))
                {
                    g += getGraph(n.t2.sig);
                }
                g +=  "\"" + n.Id + "\" -> \"" + n.t2.sig.Id + "\"[label=\"" + n.t2.caracter.getVal().Replace("\\", "\\\\").Replace("\\\"", "\"") + "\"];\n";
            }
            return g;
        }

        public void generarAFD()
        {
            afd = new List<Estado>();
            foreach (Token s in terminales)
            {
                Console.WriteLine("terminal: " + s.getVal());
            }
            Queue<HashSet<Nodo>> estados = new Queue<HashSet<Nodo>>();
            HashSet<HashSet<Nodo>> estadosMarcados = new HashSet<HashSet<Nodo>>();
            HashSet<Nodo> nodosI = e_cerradura(inicio);
            estados.Enqueue(nodosI);
            estadosMarcados.Add(nodosI);
            Estado e = new Estado(nodosI, "S0");
            if (nodosI.Contains(fin))
            {
                e.aceptacion = true;
            }
            afd.Add(e);
            while (estados.Count > 0)
            {

                HashSet<Nodo> s = estados.Dequeue();
                foreach (Token terminal in terminales)
                {
                    HashSet<Nodo> nodosAux = e_cerradura(mover(s, terminal));
                    Estado es = null;
                    Boolean existe = false;
                    foreach (HashSet<Nodo> nodos in estadosMarcados.ToList())
                    {
                        int num = 0;
                        foreach (Nodo n in nodosAux.ToList())
                        {
                            foreach (Nodo nx in nodos.ToList())
                            {
                                if (nx.Id == n.Id)
                                {
                                    num++;
                                }
                            }
                        }
                        if (num == nodosAux.Count)
                        {
                            existe = true;
                        }
                    }
                    if (nodosAux.Count > 0 && !existe)
                    {
                        Console.WriteLine("entro " + nodosAux.Count);
                        estados.Enqueue(nodosAux);
                        estadosMarcados.Add(nodosAux);
                        es = new Estado(nodosAux, "S" + afd.Count);
                        if (nodosAux.Contains(fin))
                        {
                            es.aceptacion = true;
                        }
                        afd.Add(es);
                    }
                    else
                    {
                        Console.WriteLine("EXISTE ");
                        Boolean ex = false;
                        foreach (Estado es1 in afd.ToList())
                        {
                            int num = 0;
                            foreach (Nodo n in es1.nodos.ToList())
                            {
                                foreach (Nodo nx in nodosAux.ToList())
                                {
                                    if (nx.Id == n.Id)
                                    {
                                        num++;
                                    }
                                }
                            }
                            if (num == nodosAux.Count)
                            {
                                es = es1;
                            }
                        }
                        
                    }
                    Estado aux = null;
                    foreach (Estado es1 in afd.ToList())
                    {
                        int num = 0;
                        foreach (Nodo n in es1.nodos.ToList())
                        {
                            foreach (Nodo nx in s.ToList())
                            {
                                if (nx.Id == n.Id)
                                {
                                    num++;
                                }
                            }
                        }
                        if (num == es1.nodos.Count)
                        {
                            aux = es1;
                        }
                    }
                    if (nodosAux.Count > 0)
                    {
                        aux.transiciones.Add(new TransicionAFD(terminal, es));
                    }
                    
                }
                
            }
            graficarAFD();
            grafTablaSig();
        }


        public void graficarAFD()
        {
            StringBuilder g = new StringBuilder();
            g.Append("digraph {\n" +
                    //"splines=\"line\";\n" +
                    "overlap = false;\n" +
                    "splines = true;\n" +
                    "rankdir = LR;\n" +
                    "node [shape=circle, height=0.5, width=1.5, fontsize=20];\n" +
                    "edge [fontsize=20];\n" +
                    "graph[dpi=75];\n\n");

            foreach(Estado e in afd)
            {
                g.Append("\"").Append(e.nombre).Append("\" [label=\"").Append(e.nombre).Append("\"");
                if (e.aceptacion)
                {
                    g.Append(", peripheries=2");
                }
                g.Append("];\n");
            }
            foreach(Estado e in afd)
            {
                foreach(TransicionAFD t in e.transiciones)
                {
                    g.Append("\"").Append(e.nombre).Append("\" -> \"").Append(t.sig.nombre).Append("\"");
                    g.Append("[label=\"").Append(t.caracter.getVal().Replace("\\", "\\\\").Replace("\\\"", "\"")).Append("\"];\n");
                }
            }
            g.Append("}");
            generarGrafica(g.ToString(), "afd_" + this.nombre);
            Console.WriteLine("\n\n------------------------AFD--------------------------------\n" + g.ToString());
        }

        public HashSet<Nodo> e_cerradura(HashSet<Nodo> nodos)
        {
            HashSet<Nodo> r = new HashSet<Nodo>();
            foreach (Nodo n in nodos)
            {
                r.UnionWith(e_cerradura(n));
            }
            return r;
        }

        public HashSet<Nodo> e_cerradura(Nodo n)
        {
            Stack<Nodo> pila = new Stack<Nodo>();
            Nodo actual = n;
            HashSet<Nodo> resultado = new HashSet<Nodo>();
            Console.WriteLine("CERRADURA E: "+n.Id+" ->");
            pila.Push(actual);
            while (pila.Count>0)
            {
                actual = pila.Pop();
                if (actual.t1 != null)
                {
                    if (actual.t1.caracter.Equals(EPSILON) && !resultado.Contains(actual.t1.sig))
                    {
                        resultado.Add(actual.t1.sig);
                        Console.WriteLine(actual.t1.sig.Id);
                        pila.Push(actual.t1.sig);
                    }
                }
                if (actual.t2 != null)
                {
                    if (actual.t2.caracter.Equals(EPSILON) && !resultado.Contains(actual.t2.sig))
                    {
                        resultado.Add(actual.t2.sig);
                        Console.WriteLine(actual.t2.sig.Id);
                        pila.Push(actual.t2.sig);
                    }
                }                                                    
            }
            Console.WriteLine(n.Id);
            resultado.Add(n); 
            
            return resultado;
        }

        public HashSet<Nodo> mover(HashSet<Nodo> nodos, Token caracter)
        {
            HashSet<Nodo> alcanzados = new HashSet<Nodo>();
            
            foreach (Nodo n in nodos)
            {
                Console.WriteLine("MOVER: " + n.Id + " "+caracter.getVal()+" -> ");
                if (n.t1 != null)
                {                    
                    if (n.t1.caracter.getVal().Equals(caracter.getVal()))
                    {
                        Console.WriteLine(n.t1.sig.Id);
                        alcanzados.Add(n.t1.sig);
                    }
                }
                if (n.t2 != null)
                {
                    if (n.t2.caracter.getVal().Equals(caracter.getVal()))
                    {
                        Console.WriteLine(n.t2.sig.Id);
                        alcanzados.Add(n.t2.sig);
                    }
                }
                
            }
            return alcanzados;
        }

        public void grafTablaSig()
        {
            StringBuilder g = new StringBuilder();
            g.Append("digraph {\n" +
                "splines=\"line\";\n" +
                        "rankdir = TB;\n" +
                        "node [shape=plain, height=0.5, width=1.5, fontsize=25];\n" +
                        "graph[dpi=75];\n\n" +
                    "N [label=<\n" +
                    "<table border=\"0\" cellborder=\"1\" cellpadding=\"12\">\n");
            g.Append("  <tr><td>Estados AFN</td><td>Estado AFD</td>");
            foreach(Token t in terminales)
            {
                g.Append("<td>" + t.getVal().Replace("<", "&#60;").Replace(">", "&#62;") + "</td>");
            }
            g.Append("</tr>\n");
            foreach(Estado e in afd)
            {
                g.Append("  <tr><td>");
                foreach(Nodo n in e.nodos)
                {
                    g.Append(n.Id + " ");
                }
                g.Append("</td>");
                g.Append("<td>").Append(e.nombre).Append("</td>");
                foreach(Token tok in terminales)
                {
                    Boolean trans = false;
                    g.Append("<td>");
                    foreach(TransicionAFD tr in e.transiciones)
                    {
                        if (tok.getVal().Equals(tr.caracter.getVal()))
                        {
                            g.Append(tr.sig.nombre);
                            trans = true;
                            break;
                        }
                    }
                    if (!trans)
                    {
                        g.Append(" - ");
                    }
                    g.Append("</td>");
                }
                g.Append("</tr>\n");
            }
            g.Append("</table>>];\n}");
            generarGrafica(g.ToString(), "tabla_" + this.nombre);
        }
        public Boolean evaluarExpresion(String lexema)
        {
            Estado actual = afd.ElementAt(0);

            foreach (Char c in lexema)
            {
                Console.WriteLine(actual.nombre);
                Console.WriteLine("caracter " + c);
                Boolean exTrans = false;
                foreach (TransicionAFD t in actual.transiciones)
                {

                    if (t.caracter.getTipo().Equals(Token.Tipo.CADENA))
                    {
                        String str = t.caracter.getVal().Replace("\\t", "\t").Replace("\\n", "\n").Replace("\\\"", "\"").Replace("\\r", "\r");
                        if (c == str.ElementAt(0))
                        {
                            actual = t.sig;
                            exTrans = true;
                        }
                    }
                    else if (t.caracter.getTipo().Equals(Token.Tipo.ID))
                    {
                        Conjunto co = null;
                        foreach (Conjunto conj in Form1.conjuntos)
                        {
                            if (conj.nombre.Equals(t.caracter.getVal()))
                            {
                                Console.WriteLine("conjunto " + conj.nombre);
                                co = conj;
                                break;
                            }
                        }
                        if (co.caracteres.Contains(c))
                        {

                            actual = t.sig;
                            exTrans = true;
                        }
                    }
                }
                if (!exTrans)
                {
                    return false;
                }
            }
            if (actual.aceptacion == true)
            {
                return true;
            }
            return false;
        }
    }
}
