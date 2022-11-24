namespace Laberinto_Inteligente
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
            this.label1 = new System.Windows.Forms.Label();
            this.BT_CrearLaberinto = new System.Windows.Forms.Button();
            this.BT_DibujarLAberinto = new System.Windows.Forms.Button();
            this.TB_LaberintoTabla = new System.Windows.Forms.TextBox();
            this.BT_BuscarCamino = new System.Windows.Forms.Button();
            this.BT_Jugador = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(38)))), ((int)(((byte)(49)))));
            this.label1.Location = new System.Drawing.Point(704, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 28);
            this.label1.TabIndex = 7;
            this.label1.Text = "LABERINTO INTELIGENTE";
            // 
            // BT_CrearLaberinto
            // 
            this.BT_CrearLaberinto.Location = new System.Drawing.Point(1051, 96);
            this.BT_CrearLaberinto.Name = "BT_CrearLaberinto";
            this.BT_CrearLaberinto.Size = new System.Drawing.Size(134, 23);
            this.BT_CrearLaberinto.TabIndex = 6;
            this.BT_CrearLaberinto.Text = "Crear Laberinto";
            this.BT_CrearLaberinto.UseVisualStyleBackColor = true;
            this.BT_CrearLaberinto.Click += new System.EventHandler(this.BT_CrearLaberinto_Click);
            // 
            // BT_DibujarLAberinto
            // 
            this.BT_DibujarLAberinto.Location = new System.Drawing.Point(1051, 136);
            this.BT_DibujarLAberinto.Name = "BT_DibujarLAberinto";
            this.BT_DibujarLAberinto.Size = new System.Drawing.Size(134, 23);
            this.BT_DibujarLAberinto.TabIndex = 5;
            this.BT_DibujarLAberinto.Text = "Dibujar Laberinto";
            this.BT_DibujarLAberinto.UseVisualStyleBackColor = true;
            this.BT_DibujarLAberinto.Click += new System.EventHandler(this.BT_DibujarLAberinto_Click);
            // 
            // TB_LaberintoTabla
            // 
            this.TB_LaberintoTabla.Enabled = false;
            this.TB_LaberintoTabla.Location = new System.Drawing.Point(648, 75);
            this.TB_LaberintoTabla.Multiline = true;
            this.TB_LaberintoTabla.Name = "TB_LaberintoTabla";
            this.TB_LaberintoTabla.Size = new System.Drawing.Size(386, 554);
            this.TB_LaberintoTabla.TabIndex = 4;
            // 
            // BT_BuscarCamino
            // 
            this.BT_BuscarCamino.Location = new System.Drawing.Point(1051, 174);
            this.BT_BuscarCamino.Name = "BT_BuscarCamino";
            this.BT_BuscarCamino.Size = new System.Drawing.Size(134, 23);
            this.BT_BuscarCamino.TabIndex = 8;
            this.BT_BuscarCamino.Text = "Correr IA";
            this.BT_BuscarCamino.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.BT_BuscarCamino.UseVisualStyleBackColor = true;
            this.BT_BuscarCamino.Click += new System.EventHandler(this.EncontrarCamino);
            // 
            // BT_Jugador
            // 
            this.BT_Jugador.Location = new System.Drawing.Point(1051, 213);
            this.BT_Jugador.Name = "BT_Jugador";
            this.BT_Jugador.Size = new System.Drawing.Size(134, 23);
            this.BT_Jugador.TabIndex = 14;
            this.BT_Jugador.Text = "Iniciar Jugador";
            this.BT_Jugador.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.BT_Jugador.UseVisualStyleBackColor = true;
            this.BT_Jugador.Click += new System.EventHandler(this.BT_Jugador_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1176, 629);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(12, 20);
            this.textBox1.TabIndex = 15;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 661);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.BT_Jugador);
            this.Controls.Add(this.BT_BuscarCamino);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BT_CrearLaberinto);
            this.Controls.Add(this.BT_DibujarLAberinto);
            this.Controls.Add(this.TB_LaberintoTabla);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BT_CrearLaberinto;
        private System.Windows.Forms.Button BT_DibujarLAberinto;
        private System.Windows.Forms.TextBox TB_LaberintoTabla;
        private System.Windows.Forms.Button BT_BuscarCamino;
        private System.Windows.Forms.Button BT_Jugador;
        private System.Windows.Forms.TextBox textBox1;
    }
}

