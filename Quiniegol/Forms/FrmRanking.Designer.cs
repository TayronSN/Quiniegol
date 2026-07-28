namespace Quiniegol.Forms
{
    partial class FrmRanking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRanking));
            dgvRanking = new DataGridView();
            Posición = new DataGridViewTextBoxColumn();
            Empleado = new DataGridViewTextBoxColumn();
            Puntos = new DataGridViewTextBoxColumn();
            btnDescargarRanking = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRanking).BeginInit();
            SuspendLayout();
            // 
            // dgvRanking
            // 
            dgvRanking.AllowUserToAddRows = false;
            dgvRanking.AllowUserToDeleteRows = false;
            dgvRanking.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRanking.BackgroundColor = SystemColors.Menu;
            dgvRanking.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRanking.Columns.AddRange(new DataGridViewColumn[] { Posición, Empleado, Puntos });
            dgvRanking.Location = new Point(349, 12);
            dgvRanking.MultiSelect = false;
            dgvRanking.Name = "dgvRanking";
            dgvRanking.ReadOnly = true;
            dgvRanking.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRanking.Size = new Size(376, 451);
            dgvRanking.TabIndex = 0;
            // 
            // Posición
            // 
            Posición.HeaderText = "Posición";
            Posición.Name = "Posición";
            Posición.ReadOnly = true;
            // 
            // Empleado
            // 
            Empleado.HeaderText = "Empleado";
            Empleado.Name = "Empleado";
            Empleado.ReadOnly = true;
            // 
            // Puntos
            // 
            Puntos.HeaderText = "Puntos";
            Puntos.Name = "Puntos";
            Puntos.ReadOnly = true;
            // 
            // btnDescargarRanking
            // 
            btnDescargarRanking.Location = new Point(40, 207);
            btnDescargarRanking.Name = "btnDescargarRanking";
            btnDescargarRanking.Size = new Size(138, 50);
            btnDescargarRanking.TabIndex = 1;
            btnDescargarRanking.Text = "Descargar Ranking";
            btnDescargarRanking.UseVisualStyleBackColor = true;
            btnDescargarRanking.Click += btnDescargarRanking_Click;
            // 
            // FrmRanking
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(768, 494);
            Controls.Add(btnDescargarRanking);
            Controls.Add(dgvRanking);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmRanking";
            Text = "FrmRanking";
            Load += FrmRanking_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRanking).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvRanking;
        private DataGridViewTextBoxColumn Posición;
        private DataGridViewTextBoxColumn Empleado;
        private DataGridViewTextBoxColumn Puntos;
        private Button btnDescargarRanking;
    }
}