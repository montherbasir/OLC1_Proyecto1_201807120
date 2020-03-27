using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _OLC1_Proyecto1_201807120
{
    public partial class Form1 : Form
    {        
        public static int contadorXML = 0;
        public static int contadorXML2 = 0;
        public static int contadorLEX = 0;
        public OpenFileDialog openFileDialog1;
        public List<RichTextBox> textAreas;
        private List<Ruta> rutas;
        private Lexer analizador;
        private Boolean err;
        int ax, bx = 10;
        public static HashSet<Expresion> expresiones;
        public static HashSet<Conjunto> conjuntos;
        public static HashSet<Lexema> lexemas;
        public Form1()
        {
            InitializeComponent();
            _Form1 = this;
            expresiones = new HashSet<Expresion>();
            conjuntos = new HashSet<Conjunto>();
            lexemas = new HashSet<Lexema>();
            openFileDialog1 = new OpenFileDialog()
            {
                Filter = "ER Files (*.er)|*.er",
            };
            textAreas = new List<RichTextBox>();
            textAreas.Add(richTextBox1);
            rutas = new List<Ruta>();
            err = true;
        }

        public static Form1 _Form1;
        public void cout(string message)
        {
            f1.AppendText(message);
        }

        public void cargarTreeview()
        {
            foreach(Expresion ex in expresiones)
                {
                treeView1.Nodes.Add(ex.nombre);
                }

            foreach(TreeNode n in treeView1.Nodes)
            {
                n.Nodes.Add("afd_" + n.Text);
                n.Nodes.Add("afn_" + n.Text);
                n.Nodes.Add("tabla_" + n.Text);
            }

        }

        private void cargarArchivoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textAreas[tabControl1.SelectedIndex].LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                tabControl1.SelectedTab.Text = openFileDialog1.SafeFileName;
                rutas.Add(new Ruta(openFileDialog1.FileName, openFileDialog1.SafeFileName));
            }
        }

        private void guardarArchivoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Boolean existe = false;
            string path = "";
            for (int i = 0; i < rutas.Count; i++)
            {
                Ruta ruta = rutas.ElementAt(i);
                if (ruta.nombre.Equals(tabControl1.SelectedTab.Text))
                {
                    path = ruta.ruta;
                    existe = true;
                }
            }
            if (existe == false)
            {
                guardarComo();
            }
            else
            {
                guardar(path);
            }
        }

        private void guardarArchivoComoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            guardarComo();
        }

        private void nuevaPestañaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox myRichTextBox;
            TabPage myTabPage;
            string title = "Pestaña " + (tabControl1.TabCount + 1).ToString();
            myTabPage = new TabPage(title);
            myRichTextBox = new RichTextBox();

            myRichTextBox.Size = this.richTextBox1.Size;
            myRichTextBox.Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, (byte)(0));
            myTabPage.Controls.Add(myRichTextBox);
            myTabPage.Padding = new Padding(3);
            myTabPage.Size = tabPage1.Size;

            this.textAreas.Add(myRichTextBox);
            this.tabControl1.TabPages.Add(myTabPage);
        }

        private void guardar(string path)
        {
            try
            {
                string text = this.textAreas[tabControl1.SelectedIndex].Text;
                StreamWriter writer = new StreamWriter(path);
                writer.Write(text);
                writer.Flush();
                writer.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void acercaDeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Creado por:" + "\n" + "Monther Basir" + "\n" + "201807120", "Acerca de");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            analizador = new Lexer();
            List<Token> toks = analizador.escanear(this.textAreas[tabControl1.SelectedIndex].Text);
            analizador.imprimirListaToken(toks);
            expresiones.UnionWith(analizador.generarExpresiones(toks));
            conjuntos.UnionWith(analizador.generarConjuntos(toks));

            treeView1.Nodes.Clear();
            cargarTreeview();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            analizador = new Lexer();
            List<Token> toks = analizador.escanear(this.textAreas[tabControl1.SelectedIndex].Text);
            analizador.imprimirListaToken(toks);
            lexemas.UnionWith(analizador.validarLexemas(toks));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1.expresiones.Clear();
            Form1.conjuntos.Clear();
            Form1.lexemas.Clear();
            treeView1.Nodes.Clear();
        }

        private void erroresHtmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            analizador.errores_html();
        }

        private void tokensHtmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            analizador.tokens_html();
        }

        private void lexemasToolStripMenuItem_Click(object sender, EventArgs e)
        {
                String cont1;
                String cont2;
                String tokens = "";
                String temp;
                cont1 = "<html>" +
                "<body>" +
                "<h1 align='center'><font face='verdana'>Listado de Lexemas evaluados</font></h1>" +
                "<table cellpadding='10' border = '1' align='center'>" +
                "<tr>" +
                "<td><strong>No." +
                "</strong></td>" +
                "<td><strong>Lexema" +
                "</strong></td>" +
                "<td><strong>Expresion" +
                "</strong></td>" +
                "<td><strong>Aceptado" +
                "</strong></td>" +
                "</tr>";

                for (int i = 0; i < lexemas.Count; i++)
                {
                    Lexema tok = lexemas.ElementAt(i);
                    temp = "";
                    temp = "<tr>" +
                    "<td><strong>" + (i + 1).ToString() +
                    "</strong></td>" +
                    "<td>" + tok.lexema +
                    "</td>" +
                    "<td>" + tok.nombreExpresion +
                    "</td>" +
                    "<td>" + tok.aceptado +
                    "</td>" +
                    "</tr>";
                    tokens += temp;
                }

                cont2 = "</table>" +
                "</body>" +
                "</html>";

                File.WriteAllText("Tokens_" + contadorLEX + ".html", cont1 + tokens + cont2);
                System.Diagnostics.Process.Start("Tokens_" + contadorLEX++ + ".html");
            
        }

        private void tokensXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String cont1;
            String cont2;
            String tokens = "";
            String temp;
            cont1 =
            "<ListaTokens>";

            foreach (Lexema lex in lexemas)
            {
                if (lex.aceptado == true)
                {
                    temp = "<Token>" +
                    "\t<Nombre>" + lex.nombreExpresion + "</Nombre>" +
                    "\t<Valor>" + lex.lexema + "</Valor>" +
                    "\t<Fila>" + lex.fila + "</Fila>" +
                    "\t<Columna>" + lex.col + "</Columna>" +
                    "</Token>";
                    tokens += temp;
                }
            }

            cont2 = "</ListaTokens>";

            File.WriteAllText("tokens_XML_" + contadorXML + ".xml", cont1 + tokens + cont2);
            System.Diagnostics.Process.Start("tokens_XML_" + contadorXML++ + ".xml");
        }

        private void erroresXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String cont1;
            String cont2;
            String tokens = "";
            String temp;
            cont1 =
            "<ListaErrores>";

            foreach (Lexema lex in lexemas)
            {
                if (lex.aceptado == false)
                {
                    temp = "<Error>" +
                    "\t<Valor>" + lex.lexema + "</Valor>" +
                    "\t<Fila>" + lex.fila + "</Fila>" +
                    "\t<Columna>" + lex.col + "</Columna>" +
                    "</Error>";
                    tokens += temp;
                }
            }

            cont2 = "</ListaErrores>";

            File.WriteAllText("Errores_XML_" + contadorXML2 + ".xml", cont1 + tokens + cont2);
            System.Diagnostics.Process.Start("Errores_XML_" + contadorXML2++ + ".xml");
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            pictureBox1.Image = Image.FromFile(treeView1.SelectedNode.Text + ".png");
        }

        private void guardarComo()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "archivo er|*.er";
            saveFile.Title = "Guardar archivo";
            saveFile.FileName = tabControl1.SelectedTab.Text;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = (FileStream)saveFile.OpenFile();
                fs.Close();
                string path = saveFile.FileName;
                guardar(path);
                tabControl1.SelectedTab.Text = Path.GetFileName(path);
                rutas.Add(new Ruta(path, Path.GetFileName(path)));
            }

        }
    }
}
