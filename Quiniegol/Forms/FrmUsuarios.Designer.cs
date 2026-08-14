namespace Quiniegol.Forms
{
    partial class FrmUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUsuarios));
            label1 = new Label();
            dgvUsuarios = new DataGridView();
            colIdEmpleado = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colApellido = new DataGridViewTextBoxColumn();
            colDepartamento = new DataGridViewTextBoxColumn();
            colCorreo = new DataGridViewTextBoxColumn();
            colContrasena = new DataGridViewTextBoxColumn();
            colRol = new DataGridViewTextBoxColumn();
            btnActualizar = new Button();
            btnEliminar = new Button();
            btnDescargarUsuarios = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(253, 22);
            label1.Name = "label1";
            label1.Size = new Size(241, 32);
            label1.TabIndex = 0;
            label1.Text = "Usuarios Registrados";
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Columns.AddRange(new DataGridViewColumn[] { colIdEmpleado, colNombre, colApellido, colDepartamento, colCorreo, colContrasena, colRol });
            dgvUsuarios.Location = new Point(12, 57);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.Size = new Size(776, 311);
            dgvUsuarios.TabIndex = 1;
            // 
            // colIdEmpleado
            // 
            colIdEmpleado.HeaderText = "ID Empleado";
            colIdEmpleado.Name = "colIdEmpleado";
            // 
            // colNombre
            // 
            colNombre.HeaderText = "Nombre";
            colNombre.Name = "colNombre";
            // 
            // colApellido
            // 
            colApellido.HeaderText = "Apellido";
            colApellido.Name = "colApellido";
            // 
            // colDepartamento
            // 
            colDepartamento.HeaderText = "Departamento";
            colDepartamento.Name = "colDepartamento";
            // 
            // colCorreo
            // 
            colCorreo.HeaderText = "Correo";
            colCorreo.Name = "colCorreo";
            // 
            // colContrasena
            // 
            colContrasena.HeaderText = "Contraseña";
            colContrasena.Name = "colContrasena";
            // 
            // colRol
            // 
            colRol.HeaderText = "Rol";
            colRol.Name = "colRol";
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(62, 388);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(108, 40);
            btnActualizar.TabIndex = 2;
            btnActualizar.Text = "Actualizar Lista";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(640, 388);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(109, 40);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar Usuario";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnDescargarUsuarios
            // 
            btnDescargarUsuarios.Location = new Point(365, 388);
            btnDescargarUsuarios.Name = "btnDescargarUsuarios";
            btnDescargarUsuarios.Size = new Size(108, 40);
            btnDescargarUsuarios.TabIndex = 4;
            btnDescargarUsuarios.Text = "Descargar Usuarios";
            btnDescargarUsuarios.UseVisualStyleBackColor = true;
            btnDescargarUsuarios.Click += btnDescargarUsuarios_Click;
            // 
            // FrmUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDescargarUsuarios);
            Controls.Add(btnEliminar);
            Controls.Add(btnActualizar);
            Controls.Add(dgvUsuarios);
            Controls.Add(label1);
            Name = "FrmUsuarios";
            Text = "FrmUsuarios";
            Load += FrmUsuarios_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvUsuarios;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnDescargarUsuarios;
        private DataGridViewTextBoxColumn colIdEmpleado;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colApellido;
        private DataGridViewTextBoxColumn colDepartamento;
        private DataGridViewTextBoxColumn colCorreo;
        private DataGridViewTextBoxColumn colContrasena;
        private DataGridViewTextBoxColumn colRol;
    }
}