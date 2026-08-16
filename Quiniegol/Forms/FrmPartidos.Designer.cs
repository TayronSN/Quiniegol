namespace Quiniegol.Forms
{
    partial class FrmPartidos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPartidos));
            cmbEquipoLocal = new ComboBox();
            cmbEquipoVisitante = new ComboBox();
            cmbFase = new ComboBox();
            txtEstado = new TextBox();
            btnGuardar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            dgvPartidos = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            cmbResultado = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvPartidos).BeginInit();
            SuspendLayout();
            // 
            // cmbEquipoLocal
            // 
            cmbEquipoLocal.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEquipoLocal.FormattingEnabled = true;
            cmbEquipoLocal.Location = new Point(302, 18);
            cmbEquipoLocal.Name = "cmbEquipoLocal";
            cmbEquipoLocal.Size = new Size(210, 23);
            cmbEquipoLocal.TabIndex = 0;
            // 
            // cmbEquipoVisitante
            // 
            cmbEquipoVisitante.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEquipoVisitante.FormattingEnabled = true;
            cmbEquipoVisitante.Location = new Point(302, 59);
            cmbEquipoVisitante.Name = "cmbEquipoVisitante";
            cmbEquipoVisitante.Size = new Size(210, 23);
            cmbEquipoVisitante.TabIndex = 1;
            // 
            // cmbFase
            // 
            cmbFase.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFase.FormattingEnabled = true;
            cmbFase.Location = new Point(302, 102);
            cmbFase.Name = "cmbFase";
            cmbFase.Size = new Size(210, 23);
            cmbFase.TabIndex = 2;
            // 
            // txtEstado
            // 
            txtEstado.Location = new Point(302, 148);
            txtEstado.Name = "txtEstado";
            txtEstado.ReadOnly = true;
            txtEstado.Size = new Size(210, 23);
            txtEstado.TabIndex = 3;
            txtEstado.Text = "Abierto";
            txtEstado.TextAlign = HorizontalAlignment.Center;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(621, 50);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(147, 23);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(621, 90);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(147, 23);
            btnActualizar.TabIndex = 5;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(621, 134);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(147, 23);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dgvPartidos
            // 
            dgvPartidos.AllowUserToAddRows = false;
            dgvPartidos.AllowUserToDeleteRows = false;
            dgvPartidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPartidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPartidos.Location = new Point(49, 226);
            dgvPartidos.MultiSelect = false;
            dgvPartidos.Name = "dgvPartidos";
            dgvPartidos.ReadOnly = true;
            dgvPartidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPartidos.Size = new Size(695, 205);
            dgvPartidos.TabIndex = 8;
            dgvPartidos.CellClick += dgvPartidos_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(125, 18);
            label1.Name = "label1";
            label1.Size = new Size(102, 21);
            label1.TabIndex = 9;
            label1.Text = "Equipo Local ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(125, 61);
            label2.Name = "label2";
            label2.Size = new Size(126, 21);
            label2.TabIndex = 10;
            label2.Text = "Equipo Visitante ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(125, 104);
            label3.Name = "label3";
            label3.Size = new Size(40, 21);
            label3.TabIndex = 11;
            label3.Text = "Fase";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(127, 150);
            label4.Name = "label4";
            label4.Size = new Size(56, 21);
            label4.TabIndex = 12;
            label4.Text = "Estado";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(129, 186);
            label5.Name = "label5";
            label5.Size = new Size(79, 21);
            label5.TabIndex = 13;
            label5.Text = "Resultado";
            // 
            // cmbResultado
            // 
            cmbResultado.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbResultado.FormattingEnabled = true;
            cmbResultado.Items.AddRange(new object[] { "Local", "Empate", "Visitante" });
            cmbResultado.Location = new Point(305, 186);
            cmbResultado.Name = "cmbResultado";
            cmbResultado.Size = new Size(207, 29);
            cmbResultado.TabIndex = 14;
            // 
            // FrmPartidos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(cmbResultado);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvPartidos);
            Controls.Add(btnEliminar);
            Controls.Add(btnActualizar);
            Controls.Add(btnGuardar);
            Controls.Add(txtEstado);
            Controls.Add(cmbFase);
            Controls.Add(cmbEquipoVisitante);
            Controls.Add(cmbEquipoLocal);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmPartidos";
            Text = "FrmPartidos";
            Load += FrmPartidos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPartidos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbEquipoLocal;
        private ComboBox cmbEquipoVisitante;
        private ComboBox cmbFase;
        private TextBox txtEstado;
        private Button btnGuardar;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private DataGridView dgvPartidos;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox cmbResultado;
    }
}