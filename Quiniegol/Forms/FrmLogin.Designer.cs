namespace Quiniegol.Forms
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            Titulo1Lgn = new Label();
            Titulo2Lgn = new Label();
            TituloIdEmpleadoLgn = new Label();
            this.txtIdEmpleado = new TextBox();
            TituloPassLgn = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnRegistro = new Button();
            SuspendLayout();
            // 
            // Titulo1Lgn
            // 
            Titulo1Lgn.AutoSize = true;
            Titulo1Lgn.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Titulo1Lgn.Location = new Point(103, 31);
            Titulo1Lgn.Name = "Titulo1Lgn";
            Titulo1Lgn.Size = new Size(660, 50);
            Titulo1Lgn.TabIndex = 0;
            Titulo1Lgn.Text = "Bienvenido a la Quinela Mundialista!";
            // 
            // Titulo2Lgn
            // 
            Titulo2Lgn.AutoSize = true;
            Titulo2Lgn.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Titulo2Lgn.Location = new Point(238, 102);
            Titulo2Lgn.Name = "Titulo2Lgn";
            Titulo2Lgn.Size = new Size(315, 37);
            Titulo2Lgn.TabIndex = 1;
            Titulo2Lgn.Text = "Vamos a iniciar sesion!!";
            // 
            // TituloIdEmpleadoLgn
            // 
            TituloIdEmpleadoLgn.AutoSize = true;
            TituloIdEmpleadoLgn.Font = new Font("Arial", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            TituloIdEmpleadoLgn.Location = new Point(132, 232);
            TituloIdEmpleadoLgn.Name = "TituloIdEmpleadoLgn";
            TituloIdEmpleadoLgn.Size = new Size(109, 18);
            TituloIdEmpleadoLgn.TabIndex = 2;
            TituloIdEmpleadoLgn.Text = "ID Empleado:";
            // 
            // txtIdEmpleado
            // 
            this.txtIdEmpleado.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtIdEmpleado.Location = new Point(265, 224);
            this.txtIdEmpleado.Name = "txtIdEmpleado";
            this.txtIdEmpleado.Size = new Size(272, 26);
            this.txtIdEmpleado.TabIndex = 3;
            // 
            // TituloPassLgn
            // 
            TituloPassLgn.AutoSize = true;
            TituloPassLgn.Font = new Font("Arial", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            TituloPassLgn.Location = new Point(139, 293);
            TituloPassLgn.Name = "TituloPassLgn";
            TituloPassLgn.Size = new Size(102, 18);
            TituloPassLgn.TabIndex = 4;
            TituloPassLgn.Text = "Contraseña:";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(267, 290);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(268, 26);
            txtPassword.TabIndex = 5;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Arial Narrow", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(138, 357);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(224, 55);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Iniciar Sesion";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnRegistro
            // 
            btnRegistro.Font = new Font("Arial Narrow", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegistro.Location = new Point(445, 354);
            btnRegistro.Name = "btnRegistro";
            btnRegistro.Size = new Size(219, 58);
            btnRegistro.TabIndex = 7;
            btnRegistro.Text = "Registrarse";
            btnRegistro.UseVisualStyleBackColor = true;
            btnRegistro.Click += btnRegistro_Click;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRegistro);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(TituloPassLgn);
            Controls.Add(this.txtIdEmpleado);
            Controls.Add(TituloIdEmpleadoLgn);
            Controls.Add(Titulo2Lgn);
            Controls.Add(Titulo1Lgn);
            Name = "FrmLogin";
            Text = "FrmLogin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Titulo1Lgn;
        private Label Titulo2Lgn;
        private Label TituloIdEmpleadoLgn;
        private TextBox txtIdEmpleado;
        private Label TituloPassLgn;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnRegistro;
    }
}