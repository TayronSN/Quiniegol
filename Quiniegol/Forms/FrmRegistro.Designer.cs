namespace Quiniegol.Forms
{
    partial class FrmRegistro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegistro));
            Titulo1Rgst = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtIdEmpleado = new TextBox();
            txtNombre = new TextBox();
            txtCorreo = new TextBox();
            txtApellido = new TextBox();
            cmbDepartamento = new ComboBox();
            txtPassword = new TextBox();
            txtConfirmarPassword = new TextBox();
            btnRegistrar = new Button();
            SuspendLayout();
            // 
            // Titulo1Rgst
            // 
            Titulo1Rgst.AutoSize = true;
            Titulo1Rgst.Font = new Font("Segoe UI Semibold", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Titulo1Rgst.Location = new Point(258, 48);
            Titulo1Rgst.Name = "Titulo1Rgst";
            Titulo1Rgst.Size = new Size(396, 50);
            Titulo1Rgst.TabIndex = 0;
            Titulo1Rgst.Text = "Vamos a registrarnos!!";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(181, 171);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 1;
            label1.Text = "ID Empleado";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(181, 208);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 2;
            label2.Text = "Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(181, 246);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 3;
            label3.Text = "Apellido";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(181, 285);
            label4.Name = "label4";
            label4.Size = new Size(83, 15);
            label4.TabIndex = 4;
            label4.Text = "Departamento";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(181, 323);
            label5.Name = "label5";
            label5.Size = new Size(43, 15);
            label5.TabIndex = 5;
            label5.Text = "Correo";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(181, 364);
            label6.Name = "label6";
            label6.Size = new Size(67, 15);
            label6.TabIndex = 6;
            label6.Text = "Contraseña";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(181, 400);
            label7.Name = "label7";
            label7.Size = new Size(122, 15);
            label7.TabIndex = 7;
            label7.Text = "Confirmar contraseña";
            // 
            // txtIdEmpleado
            // 
            txtIdEmpleado.Location = new Point(309, 163);
            txtIdEmpleado.Name = "txtIdEmpleado";
            txtIdEmpleado.Size = new Size(315, 23);
            txtIdEmpleado.TabIndex = 9;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(309, 200);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(315, 23);
            txtNombre.TabIndex = 10;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(309, 315);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(315, 23);
            txtCorreo.TabIndex = 11;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(309, 243);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(315, 23);
            txtApellido.TabIndex = 12;
            // 
            // cmbDepartamento
            // 
            cmbDepartamento.FormattingEnabled = true;
            cmbDepartamento.Items.AddRange(new object[] { "Finanzas", "Recursos Humanos", "Tecnología", "Facilities", "Seguridad", "Call Center" });
            cmbDepartamento.Location = new Point(309, 277);
            cmbDepartamento.Name = "cmbDepartamento";
            cmbDepartamento.Size = new Size(315, 23);
            cmbDepartamento.TabIndex = 13;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(309, 356);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(315, 23);
            txtPassword.TabIndex = 14;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtConfirmarPassword
            // 
            txtConfirmarPassword.Location = new Point(309, 392);
            txtConfirmarPassword.Name = "txtConfirmarPassword";
            txtConfirmarPassword.Size = new Size(315, 23);
            txtConfirmarPassword.TabIndex = 15;
            txtConfirmarPassword.UseSystemPasswordChar = true;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(366, 469);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(214, 57);
            btnRegistrar.TabIndex = 16;
            btnRegistrar.Text = "Registrarse!!";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // FrmRegistro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(930, 627);
            Controls.Add(btnRegistrar);
            Controls.Add(txtConfirmarPassword);
            Controls.Add(txtPassword);
            Controls.Add(cmbDepartamento);
            Controls.Add(txtApellido);
            Controls.Add(txtCorreo);
            Controls.Add(txtNombre);
            Controls.Add(txtIdEmpleado);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Titulo1Rgst);
            Name = "FrmRegistro";
            Text = "FrmRegistro";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Titulo1Rgst;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtIdEmpleado;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtCorreo;
        private ComboBox cmbDepartamento;
        private TextBox txtPassword;
        private TextBox txtConfirmarPassword;
        private Button btnRegistrar;
    }
}