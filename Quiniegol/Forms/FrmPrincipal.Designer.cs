namespace Quiniegol.Forms
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            label1 = new Label();
            label2 = new Label();
            btnUsuarios = new Button();
            btnPartidos = new Button();
            btnPronosticos = new Button();
            btnRanking = new Button();
            btnReportes = new Button();
            btnCerrarSesion = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(156, 9);
            label1.Name = "label1";
            label1.Size = new Size(577, 65);
            label1.TabIndex = 0;
            label1.Text = "Bienvenido a Quiniegol";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(320, 74);
            label2.Name = "label2";
            label2.Size = new Size(246, 45);
            label2.TabIndex = 1;
            label2.Text = "Menu Principal";
            // 
            // btnUsuarios
            // 
            btnUsuarios.Location = new Point(458, 181);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(99, 23);
            btnUsuarios.TabIndex = 2;
            btnUsuarios.Text = "Usuarios";
            btnUsuarios.UseVisualStyleBackColor = true;
            // 
            // btnPartidos
            // 
            btnPartidos.Location = new Point(502, 226);
            btnPartidos.Name = "btnPartidos";
            btnPartidos.Size = new Size(105, 23);
            btnPartidos.TabIndex = 3;
            btnPartidos.Text = "Partidos";
            btnPartidos.UseVisualStyleBackColor = true;
            btnPartidos.Click += btnPartidos_Click;
            // 
            // btnPronosticos
            // 
            btnPronosticos.Location = new Point(528, 275);
            btnPronosticos.Name = "btnPronosticos";
            btnPronosticos.Size = new Size(103, 23);
            btnPronosticos.TabIndex = 4;
            btnPronosticos.Text = "Pronosticos";
            btnPronosticos.UseVisualStyleBackColor = true;
            btnPronosticos.Click += btnPronosticos_Click;
            // 
            // btnRanking
            // 
            btnRanking.Location = new Point(548, 322);
            btnRanking.Name = "btnRanking";
            btnRanking.Size = new Size(108, 23);
            btnRanking.TabIndex = 5;
            btnRanking.Text = "Ranking";
            btnRanking.UseVisualStyleBackColor = true;
            btnRanking.Click += btnRanking_Click;
            // 
            // btnReportes
            // 
            btnReportes.Location = new Point(566, 371);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(104, 23);
            btnReportes.TabIndex = 6;
            btnReportes.Text = "Reportes";
            btnReportes.UseVisualStyleBackColor = true;
            btnReportes.Click += btnReportes_Click;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Location = new Point(590, 422);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(110, 23);
            btnCerrarSesion.TabIndex = 7;
            btnCerrarSesion.Text = "Cerrar sesion";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(860, 494);
            Controls.Add(btnCerrarSesion);
            Controls.Add(btnReportes);
            Controls.Add(btnRanking);
            Controls.Add(btnPronosticos);
            Controls.Add(btnPartidos);
            Controls.Add(btnUsuarios);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmPrincipal";
            Load += FrmPrincipal_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button btnUsuarios;
        private Button btnPartidos;
        private Button btnPronosticos;
        private Button btnRanking;
        private Button btnReportes;
        private Button btnCerrarSesion;
    }
}