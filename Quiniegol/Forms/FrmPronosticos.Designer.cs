namespace Quiniegol.Forms
{
    partial class FrmPronosticos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPronosticos));
            lblPartido = new Label();
            cmbPartidos = new ComboBox();
            picEquipoLocal = new PictureBox();
            picEquipoVisitante = new PictureBox();
            lblEquipoLocal = new Label();
            lblEquipoVisitante = new Label();
            label1 = new Label();
            grpResultado = new GroupBox();
            rdbVisitante = new RadioButton();
            rdbEmpate = new RadioButton();
            rdbLocal = new RadioButton();
            btnGuardar = new Button();
            dgvPronosticos = new DataGridView();
            Partido = new DataGridViewTextBoxColumn();
            Pronostico = new DataGridViewTextBoxColumn();
            Estado = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)picEquipoLocal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picEquipoVisitante).BeginInit();
            grpResultado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPronosticos).BeginInit();
            SuspendLayout();
            // 
            // lblPartido
            // 
            lblPartido.AutoSize = true;
            lblPartido.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPartido.Location = new Point(139, 60);
            lblPartido.Name = "lblPartido";
            lblPartido.Size = new Size(59, 21);
            lblPartido.TabIndex = 0;
            lblPartido.Text = "Partido";
            // 
            // cmbPartidos
            // 
            cmbPartidos.FormattingEnabled = true;
            cmbPartidos.Location = new Point(139, 96);
            cmbPartidos.Name = "cmbPartidos";
            cmbPartidos.Size = new Size(250, 23);
            cmbPartidos.TabIndex = 1;
            cmbPartidos.SelectedIndexChanged += cmbPartidos_SelectedIndexChanged;
            // 
            // picEquipoLocal
            // 
            picEquipoLocal.Location = new Point(140, 148);
            picEquipoLocal.Name = "picEquipoLocal";
            picEquipoLocal.Size = new Size(105, 67);
            picEquipoLocal.SizeMode = PictureBoxSizeMode.StretchImage;
            picEquipoLocal.TabIndex = 2;
            picEquipoLocal.TabStop = false;
            // 
            // picEquipoVisitante
            // 
            picEquipoVisitante.Location = new Point(283, 148);
            picEquipoVisitante.Name = "picEquipoVisitante";
            picEquipoVisitante.Size = new Size(106, 67);
            picEquipoVisitante.SizeMode = PictureBoxSizeMode.StretchImage;
            picEquipoVisitante.TabIndex = 3;
            picEquipoVisitante.TabStop = false;
            // 
            // lblEquipoLocal
            // 
            lblEquipoLocal.AutoSize = true;
            lblEquipoLocal.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEquipoLocal.Location = new Point(142, 227);
            lblEquipoLocal.Name = "lblEquipoLocal";
            lblEquipoLocal.Size = new Size(98, 21);
            lblEquipoLocal.TabIndex = 4;
            lblEquipoLocal.Text = "Equipo Local";
            // 
            // lblEquipoVisitante
            // 
            lblEquipoVisitante.AutoSize = true;
            lblEquipoVisitante.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEquipoVisitante.Location = new Point(276, 227);
            lblEquipoVisitante.Name = "lblEquipoVisitante";
            lblEquipoVisitante.Size = new Size(122, 21);
            lblEquipoVisitante.TabIndex = 5;
            lblEquipoVisitante.Text = "Equipo Visitante";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(250, 176);
            label1.Name = "label1";
            label1.Size = new Size(27, 15);
            label1.TabIndex = 6;
            label1.Text = "VRS";
            // 
            // grpResultado
            // 
            grpResultado.Controls.Add(rdbVisitante);
            grpResultado.Controls.Add(rdbEmpate);
            grpResultado.Controls.Add(rdbLocal);
            grpResultado.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpResultado.Location = new Point(169, 267);
            grpResultado.Name = "grpResultado";
            grpResultado.Size = new Size(185, 122);
            grpResultado.TabIndex = 7;
            grpResultado.TabStop = false;
            grpResultado.Text = "Resultado";
            // 
            // rdbVisitante
            // 
            rdbVisitante.AutoSize = true;
            rdbVisitante.Location = new Point(19, 76);
            rdbVisitante.Name = "rdbVisitante";
            rdbVisitante.Size = new Size(128, 25);
            rdbVisitante.TabIndex = 2;
            rdbVisitante.TabStop = true;
            rdbVisitante.Text = "Gana Visitante";
            rdbVisitante.UseVisualStyleBackColor = true;
            // 
            // rdbEmpate
            // 
            rdbEmpate.AutoSize = true;
            rdbEmpate.Location = new Point(19, 51);
            rdbEmpate.Name = "rdbEmpate";
            rdbEmpate.Size = new Size(80, 25);
            rdbEmpate.TabIndex = 1;
            rdbEmpate.TabStop = true;
            rdbEmpate.Text = "Empate";
            rdbEmpate.UseVisualStyleBackColor = true;
            // 
            // rdbLocal
            // 
            rdbLocal.AutoSize = true;
            rdbLocal.Location = new Point(19, 26);
            rdbLocal.Name = "rdbLocal";
            rdbLocal.Size = new Size(104, 25);
            rdbLocal.TabIndex = 0;
            rdbLocal.TabStop = true;
            rdbLocal.Text = "Gana Local";
            rdbLocal.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardar.Location = new Point(209, 431);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(119, 42);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // dgvPronosticos
            // 
            dgvPronosticos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPronosticos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvPronosticos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPronosticos.Columns.AddRange(new DataGridViewColumn[] { Partido, Pronostico, Estado });
            dgvPronosticos.Location = new Point(467, 96);
            dgvPronosticos.Name = "dgvPronosticos";
            dgvPronosticos.Size = new Size(396, 293);
            dgvPronosticos.TabIndex = 10;
            // 
            // Partido
            // 
            Partido.HeaderText = "Partido";
            Partido.Name = "Partido";
            // 
            // Pronostico
            // 
            Pronostico.HeaderText = "Pronostico";
            Pronostico.Name = "Pronostico";
            // 
            // Estado
            // 
            Estado.HeaderText = "Estado";
            Estado.Name = "Estado";
            // 
            // FrmPronosticos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(930, 550);
            Controls.Add(dgvPronosticos);
            Controls.Add(btnGuardar);
            Controls.Add(grpResultado);
            Controls.Add(label1);
            Controls.Add(lblEquipoVisitante);
            Controls.Add(lblEquipoLocal);
            Controls.Add(picEquipoVisitante);
            Controls.Add(picEquipoLocal);
            Controls.Add(cmbPartidos);
            Controls.Add(lblPartido);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmPronosticos";
            Text = "FrmPronosticos";
            Load += FrmPronosticos_Load;
            ((System.ComponentModel.ISupportInitialize)picEquipoLocal).EndInit();
            ((System.ComponentModel.ISupportInitialize)picEquipoVisitante).EndInit();
            grpResultado.ResumeLayout(false);
            grpResultado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPronosticos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPartido;
        private ComboBox cmbPartidos;
        private PictureBox picEquipoLocal;
        private PictureBox picEquipoVisitante;
        private Label lblEquipoLocal;
        private Label lblEquipoVisitante;
        private Label label1;
        private GroupBox grpResultado;
        private RadioButton rdbVisitante;
        private RadioButton rdbEmpate;
        private RadioButton rdbLocal;
        private Button btnGuardar;
        private DataGridView dgvPronosticos;
        private DataGridViewTextBoxColumn Partido;
        private DataGridViewTextBoxColumn Pronostico;
        private DataGridViewTextBoxColumn Estado;
    }
}