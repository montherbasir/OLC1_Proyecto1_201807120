namespace _OLC1_Proyecto1_201807120
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.f1 = new System.Windows.Forms.RichTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaPestañaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarArchivoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarArchivoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarArchivoComoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tokensHtmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erroresHtmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tokensXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erroresXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lexemasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(514, 630);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(506, 604);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Pestaña 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.AcceptsTab = true;
            this.richTextBox1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(506, 604);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(532, 49);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(231, 315);
            this.treeView1.TabIndex = 3;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // f1
            // 
            this.f1.AcceptsTab = true;
            this.f1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f1.Location = new System.Drawing.Point(532, 493);
            this.f1.Name = "f1";
            this.f1.Size = new System.Drawing.Size(765, 164);
            this.f1.TabIndex = 5;
            this.f1.Text = "";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(532, 452);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(231, 35);
            this.button3.TabIndex = 8;
            this.button3.Text = "Borrar Expresiones y conjuntos";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(532, 370);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(231, 35);
            this.button1.TabIndex = 9;
            this.button1.Text = "Cargar expresoines";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(532, 411);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(231, 35);
            this.button2.TabIndex = 10;
            this.button2.Text = "Analizar lexemas";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.ayudaToolStripMenuItem,
            this.reportesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1319, 24);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaPestañaToolStripMenuItem,
            this.cargarArchivoToolStripMenuItem1,
            this.guardarArchivoToolStripMenuItem1,
            this.guardarArchivoComoToolStripMenuItem1,
            this.salirToolStripMenuItem1});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // nuevaPestañaToolStripMenuItem
            // 
            this.nuevaPestañaToolStripMenuItem.Name = "nuevaPestañaToolStripMenuItem";
            this.nuevaPestañaToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.nuevaPestañaToolStripMenuItem.Text = "Nueva Pestaña";
            this.nuevaPestañaToolStripMenuItem.Click += new System.EventHandler(this.nuevaPestañaToolStripMenuItem_Click);
            // 
            // cargarArchivoToolStripMenuItem1
            // 
            this.cargarArchivoToolStripMenuItem1.Name = "cargarArchivoToolStripMenuItem1";
            this.cargarArchivoToolStripMenuItem1.Size = new System.Drawing.Size(196, 22);
            this.cargarArchivoToolStripMenuItem1.Text = "Cargar Archivo";
            this.cargarArchivoToolStripMenuItem1.Click += new System.EventHandler(this.cargarArchivoToolStripMenuItem1_Click);
            // 
            // guardarArchivoToolStripMenuItem1
            // 
            this.guardarArchivoToolStripMenuItem1.Name = "guardarArchivoToolStripMenuItem1";
            this.guardarArchivoToolStripMenuItem1.Size = new System.Drawing.Size(196, 22);
            this.guardarArchivoToolStripMenuItem1.Text = "Guardar Archivo";
            this.guardarArchivoToolStripMenuItem1.Click += new System.EventHandler(this.guardarArchivoToolStripMenuItem1_Click);
            // 
            // guardarArchivoComoToolStripMenuItem1
            // 
            this.guardarArchivoComoToolStripMenuItem1.Name = "guardarArchivoComoToolStripMenuItem1";
            this.guardarArchivoComoToolStripMenuItem1.Size = new System.Drawing.Size(196, 22);
            this.guardarArchivoComoToolStripMenuItem1.Text = "Guardar Archivo Como";
            this.guardarArchivoComoToolStripMenuItem1.Click += new System.EventHandler(this.guardarArchivoComoToolStripMenuItem1_Click);
            // 
            // salirToolStripMenuItem1
            // 
            this.salirToolStripMenuItem1.Name = "salirToolStripMenuItem1";
            this.salirToolStripMenuItem1.Size = new System.Drawing.Size(196, 22);
            this.salirToolStripMenuItem1.Text = "Salir";
            this.salirToolStripMenuItem1.Click += new System.EventHandler(this.salirToolStripMenuItem1_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeToolStripMenuItem1});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // acercaDeToolStripMenuItem1
            // 
            this.acercaDeToolStripMenuItem1.Name = "acercaDeToolStripMenuItem1";
            this.acercaDeToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.acercaDeToolStripMenuItem1.Text = "Acerca de";
            this.acercaDeToolStripMenuItem1.Click += new System.EventHandler(this.acercaDeToolStripMenuItem1_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tokensHtmlToolStripMenuItem,
            this.erroresHtmlToolStripMenuItem,
            this.tokensXMLToolStripMenuItem,
            this.erroresXMLToolStripMenuItem,
            this.lexemasToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // tokensHtmlToolStripMenuItem
            // 
            this.tokensHtmlToolStripMenuItem.Name = "tokensHtmlToolStripMenuItem";
            this.tokensHtmlToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.tokensHtmlToolStripMenuItem.Text = "Tokens HTML";
            this.tokensHtmlToolStripMenuItem.Click += new System.EventHandler(this.tokensHtmlToolStripMenuItem_Click);
            // 
            // erroresHtmlToolStripMenuItem
            // 
            this.erroresHtmlToolStripMenuItem.Name = "erroresHtmlToolStripMenuItem";
            this.erroresHtmlToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.erroresHtmlToolStripMenuItem.Text = "Errores HTML";
            this.erroresHtmlToolStripMenuItem.Click += new System.EventHandler(this.erroresHtmlToolStripMenuItem_Click);
            // 
            // tokensXMLToolStripMenuItem
            // 
            this.tokensXMLToolStripMenuItem.Name = "tokensXMLToolStripMenuItem";
            this.tokensXMLToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.tokensXMLToolStripMenuItem.Text = "Tokens XML";
            this.tokensXMLToolStripMenuItem.Click += new System.EventHandler(this.tokensXMLToolStripMenuItem_Click);
            // 
            // erroresXMLToolStripMenuItem
            // 
            this.erroresXMLToolStripMenuItem.Name = "erroresXMLToolStripMenuItem";
            this.erroresXMLToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.erroresXMLToolStripMenuItem.Text = "Errores XML";
            this.erroresXMLToolStripMenuItem.Click += new System.EventHandler(this.erroresXMLToolStripMenuItem_Click);
            // 
            // lexemasToolStripMenuItem
            // 
            this.lexemasToolStripMenuItem.Name = "lexemasToolStripMenuItem";
            this.lexemasToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.lexemasToolStripMenuItem.Text = "Lexemas";
            this.lexemasToolStripMenuItem.Click += new System.EventHandler(this.lexemasToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(768, 49);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(540, 439);
            this.panel1.TabIndex = 20;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(714, 534);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1319, 669);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.f1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Metodo de Thompson";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.RichTextBox f1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaPestañaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarArchivoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem guardarArchivoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem guardarArchivoComoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tokensHtmlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erroresHtmlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tokensXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erroresXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lexemasToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

