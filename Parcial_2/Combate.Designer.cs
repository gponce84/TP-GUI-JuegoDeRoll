namespace Parcial_2
{
    partial class Combate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BoxJugador = new System.Windows.Forms.PictureBox();
            this.BoxEnemigo = new System.Windows.Forms.PictureBox();
            this.timerCmbt = new System.Windows.Forms.Timer(this.components);
            this.btn_Atacar = new System.Windows.Forms.Button();
            this.box_Acciones = new System.Windows.Forms.GroupBox();
            this.btn_Mana = new System.Windows.Forms.Button();
            this.btn_Escapar = new System.Windows.Forms.Button();
            this.btn_Pocion = new System.Windows.Forms.Button();
            this.btn_Defender = new System.Windows.Forms.Button();
            this.btn_AtEspecial = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BoxJugador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoxEnemigo)).BeginInit();
            this.box_Acciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // BoxJugador
            // 
            this.BoxJugador.BackColor = System.Drawing.Color.Transparent;
            this.BoxJugador.Location = new System.Drawing.Point(355, 231);
            this.BoxJugador.Name = "BoxJugador";
            this.BoxJugador.Size = new System.Drawing.Size(310, 280);
            this.BoxJugador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.BoxJugador.TabIndex = 0;
            this.BoxJugador.TabStop = false;
            // 
            // BoxEnemigo
            // 
            this.BoxEnemigo.BackColor = System.Drawing.Color.Transparent;
            this.BoxEnemigo.Location = new System.Drawing.Point(132, 231);
            this.BoxEnemigo.Name = "BoxEnemigo";
            this.BoxEnemigo.Size = new System.Drawing.Size(100, 106);
            this.BoxEnemigo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.BoxEnemigo.TabIndex = 1;
            this.BoxEnemigo.TabStop = false;
            this.BoxEnemigo.Click += new System.EventHandler(this.BoxEnemigo_Click);
            // 
            // timerCmbt
            // 
            this.timerCmbt.Interval = 200;
            this.timerCmbt.Tick += new System.EventHandler(this.timerCmbt_Tick);
            // 
            // btn_Atacar
            // 
            this.btn_Atacar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Atacar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(56)))), ((int)(((byte)(1)))));
            this.btn_Atacar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_Atacar.FlatAppearance.BorderSize = 10;
            this.btn_Atacar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_Atacar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SaddleBrown;
            this.btn_Atacar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Atacar.ForeColor = System.Drawing.Color.BurlyWood;
            this.btn_Atacar.Location = new System.Drawing.Point(8, 20);
            this.btn_Atacar.Name = "btn_Atacar";
            this.btn_Atacar.Size = new System.Drawing.Size(86, 29);
            this.btn_Atacar.TabIndex = 2;
            this.btn_Atacar.TabStop = false;
            this.btn_Atacar.Text = "Atacar";
            this.btn_Atacar.UseVisualStyleBackColor = false;
            this.btn_Atacar.Click += new System.EventHandler(this.btn_atacar_Click);
            // 
            // box_Acciones
            // 
            this.box_Acciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.box_Acciones.BackgroundImage = global::Parcial_2.Properties.Resources.fondomap;
            this.box_Acciones.Controls.Add(this.btn_Mana);
            this.box_Acciones.Controls.Add(this.btn_Escapar);
            this.box_Acciones.Controls.Add(this.btn_Pocion);
            this.box_Acciones.Controls.Add(this.btn_Defender);
            this.box_Acciones.Controls.Add(this.btn_AtEspecial);
            this.box_Acciones.Controls.Add(this.btn_Atacar);
            this.box_Acciones.Font = new System.Drawing.Font("Poor Richard", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box_Acciones.ForeColor = System.Drawing.Color.BurlyWood;
            this.box_Acciones.Location = new System.Drawing.Point(646, 288);
            this.box_Acciones.Name = "box_Acciones";
            this.box_Acciones.Size = new System.Drawing.Size(100, 235);
            this.box_Acciones.TabIndex = 3;
            this.box_Acciones.TabStop = false;
            this.box_Acciones.Text = "ACCIONES";
            // 
            // btn_Mana
            // 
            this.btn_Mana.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Mana.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(56)))), ((int)(((byte)(1)))));
            this.btn_Mana.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_Mana.FlatAppearance.BorderSize = 10;
            this.btn_Mana.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_Mana.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SaddleBrown;
            this.btn_Mana.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Mana.ForeColor = System.Drawing.Color.BurlyWood;
            this.btn_Mana.Location = new System.Drawing.Point(8, 160);
            this.btn_Mana.Name = "btn_Mana";
            this.btn_Mana.Size = new System.Drawing.Size(86, 29);
            this.btn_Mana.TabIndex = 7;
            this.btn_Mana.TabStop = false;
            this.btn_Mana.Text = "Rec. Mana";
            this.btn_Mana.UseVisualStyleBackColor = false;
            this.btn_Mana.Click += new System.EventHandler(this.btn_Mana_Click);
            // 
            // btn_Escapar
            // 
            this.btn_Escapar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Escapar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(56)))), ((int)(((byte)(1)))));
            this.btn_Escapar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_Escapar.FlatAppearance.BorderSize = 10;
            this.btn_Escapar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_Escapar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SaddleBrown;
            this.btn_Escapar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Escapar.ForeColor = System.Drawing.Color.BurlyWood;
            this.btn_Escapar.Location = new System.Drawing.Point(8, 195);
            this.btn_Escapar.Name = "btn_Escapar";
            this.btn_Escapar.Size = new System.Drawing.Size(86, 29);
            this.btn_Escapar.TabIndex = 6;
            this.btn_Escapar.TabStop = false;
            this.btn_Escapar.Text = "Escapar";
            this.btn_Escapar.UseVisualStyleBackColor = false;
            this.btn_Escapar.Click += new System.EventHandler(this.btn_Escapar_Click);
            // 
            // btn_Pocion
            // 
            this.btn_Pocion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Pocion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(56)))), ((int)(((byte)(1)))));
            this.btn_Pocion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_Pocion.FlatAppearance.BorderSize = 10;
            this.btn_Pocion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_Pocion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SaddleBrown;
            this.btn_Pocion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Pocion.ForeColor = System.Drawing.Color.BurlyWood;
            this.btn_Pocion.Location = new System.Drawing.Point(8, 125);
            this.btn_Pocion.Name = "btn_Pocion";
            this.btn_Pocion.Size = new System.Drawing.Size(86, 29);
            this.btn_Pocion.TabIndex = 5;
            this.btn_Pocion.TabStop = false;
            this.btn_Pocion.Text = "Rec. Salud";
            this.btn_Pocion.UseVisualStyleBackColor = false;
            this.btn_Pocion.Click += new System.EventHandler(this.btn_Pocion_Click);
            // 
            // btn_Defender
            // 
            this.btn_Defender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Defender.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(56)))), ((int)(((byte)(1)))));
            this.btn_Defender.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_Defender.FlatAppearance.BorderSize = 10;
            this.btn_Defender.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_Defender.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SaddleBrown;
            this.btn_Defender.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Defender.ForeColor = System.Drawing.Color.BurlyWood;
            this.btn_Defender.Location = new System.Drawing.Point(8, 90);
            this.btn_Defender.Name = "btn_Defender";
            this.btn_Defender.Size = new System.Drawing.Size(86, 29);
            this.btn_Defender.TabIndex = 4;
            this.btn_Defender.TabStop = false;
            this.btn_Defender.Text = "Defender";
            this.btn_Defender.UseVisualStyleBackColor = false;
            this.btn_Defender.Click += new System.EventHandler(this.btn_Defender_Click);
            // 
            // btn_AtEspecial
            // 
            this.btn_AtEspecial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_AtEspecial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(56)))), ((int)(((byte)(1)))));
            this.btn_AtEspecial.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_AtEspecial.FlatAppearance.BorderSize = 10;
            this.btn_AtEspecial.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_AtEspecial.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SaddleBrown;
            this.btn_AtEspecial.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_AtEspecial.ForeColor = System.Drawing.Color.BurlyWood;
            this.btn_AtEspecial.Location = new System.Drawing.Point(8, 55);
            this.btn_AtEspecial.Name = "btn_AtEspecial";
            this.btn_AtEspecial.Size = new System.Drawing.Size(86, 29);
            this.btn_AtEspecial.TabIndex = 3;
            this.btn_AtEspecial.TabStop = false;
            this.btn_AtEspecial.Text = "At. Especial";
            this.btn_AtEspecial.UseVisualStyleBackColor = false;
            this.btn_AtEspecial.Click += new System.EventHandler(this.btn_AtEspecial_Click);
            // 
            // Combate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::Parcial_2.Properties.Resources.fondo_combate;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(744, 521);
            this.ControlBox = false;
            this.Controls.Add(this.box_Acciones);
            this.Controls.Add(this.BoxEnemigo);
            this.Controls.Add(this.BoxJugador);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(100, 100);
            this.MaximizeBox = false;
            this.Name = "Combate";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Combate";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Combate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BoxJugador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoxEnemigo)).EndInit();
            this.box_Acciones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox BoxJugador;
        private System.Windows.Forms.PictureBox BoxEnemigo;
        private System.Windows.Forms.Timer timerCmbt;
        private System.Windows.Forms.Button btn_Atacar;
        private System.Windows.Forms.GroupBox box_Acciones;
        private System.Windows.Forms.Button btn_Escapar;
        private System.Windows.Forms.Button btn_Pocion;
        private System.Windows.Forms.Button btn_Defender;
        private System.Windows.Forms.Button btn_AtEspecial;
        private System.Windows.Forms.Button btn_Mana;
    }
}