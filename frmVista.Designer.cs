namespace Sistema_de_control
{
    partial class frmVista
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
            this.Visor = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.rptBoleta1 = new Sistema_de_control.rptBoleta();
            this.SuspendLayout();
            // 
            // Visor
            // 
            this.Visor.ActiveViewIndex = 0;
            this.Visor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Visor.DisplayGroupTree = false;
            this.Visor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Visor.Location = new System.Drawing.Point(0, 0);
            this.Visor.Name = "Visor";
            this.Visor.ReportSource = this.rptBoleta1;
            this.Visor.Size = new System.Drawing.Size(871, 452);
            this.Visor.TabIndex = 0;
            // 
            // frmVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 452);
            this.Controls.Add(this.Visor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmVista";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmVista";
            this.ResumeLayout(false);

        }

        #endregion

        private rptBoleta rptBoleta1;
        internal CrystalDecisions.Windows.Forms.CrystalReportViewer Visor;
    }
}