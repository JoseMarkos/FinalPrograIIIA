namespace FinalApp.apps.Templates
{
    partial class Dashboard
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
            this.comboRegistros = new System.Windows.Forms.ComboBox();
            this.comboReportes = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboRegistros
            // 
            this.comboRegistros.FormattingEnabled = true;
            this.comboRegistros.Location = new System.Drawing.Point(12, 12);
            this.comboRegistros.Name = "comboRegistros";
            this.comboRegistros.Size = new System.Drawing.Size(121, 23);
            this.comboRegistros.TabIndex = 0;
            this.comboRegistros.Text = "Registros";
            this.comboRegistros.SelectedIndexChanged += new System.EventHandler(this.ComboRegistros_SelectedIndexChanged);
            // 
            // comboReportes
            // 
            this.comboReportes.FormattingEnabled = true;
            this.comboReportes.Location = new System.Drawing.Point(163, 12);
            this.comboReportes.Name = "comboReportes";
            this.comboReportes.Size = new System.Drawing.Size(162, 23);
            this.comboReportes.TabIndex = 1;
            this.comboReportes.Text = "Reportes";
            this.comboReportes.SelectedIndexChanged += new System.EventHandler(this.ComboReportes_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 92);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 236);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.Text = "dataGridView1";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboReportes);
            this.Controls.Add(this.comboRegistros);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Exit);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboRegistros;
        private System.Windows.Forms.ComboBox comboReportes;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}