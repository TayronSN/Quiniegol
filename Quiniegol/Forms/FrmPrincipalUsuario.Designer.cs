namespace Quiniegol.Forms
{
    partial class FrmPrincipalUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipalUsuario));
            label2 = new Label();
            label1 = new Label();
            btnPronosticos = new Button();
            btnRanking = new Button();
            btnCerrarSesion = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(278, 97);
            label2.Name = "label2";
            label2.Size = new Size(246, 45);
            label2.TabIndex = 3;
            label2.Text = "Menu Principal";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(114, 32);
            label1.Name = "label1";
            label1.Size = new Size(577, 65);
            label1.TabIndex = 2;
            label1.Text = "Bienvenido a Quiniegol";
            // 
            // btnPronosticos
            // 
            btnPronosticos.Location = new Point(58, 185);
            btnPronosticos.Name = "btnPronosticos";
            btnPronosticos.Size = new Size(169, 76);
            btnPronosticos.TabIndex = 4;
            btnPronosticos.Text = "Pronósticos";
            btnPronosticos.UseVisualStyleBackColor = true;
            btnPronosticos.Click += btnPronosticos_Click;
            // 
            // btnRanking
            // 
            btnRanking.Location = new Point(297, 185);
            btnRanking.Name = "btnRanking";
            btnRanking.Size = new Size(169, 76);
            btnRanking.TabIndex = 5;
            btnRanking.Text = "Ranking";
            btnRanking.UseVisualStyleBackColor = true;
            btnRanking.Click += btnRanking_Click;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Location = new Point(538, 185);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(169, 79);
            btnCerrarSesion.TabIndex = 6;
            btnCerrarSesion.Text = "Cerrar sesión";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // FrmPrincipalUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 450);
            Controls.Add(btnCerrarSesion);
            Controls.Add(btnRanking);
            Controls.Add(btnPronosticos);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmPrincipalUsuario";
            Text = "FrmPrincipalUsuario";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label label1;
        private Button btnPronosticos;
        private Button btnRanking;
        private Button btnCerrarSesion;
    }
}