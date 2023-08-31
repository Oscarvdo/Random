using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sistema_de_control
{
    public partial class frmSplash : Form
    {
        public frmSplash(int segundos) // El constructor recibira un valor numerico
        {
            InitializeComponent();
            timer1.Interval = segundos * 1000;	// pasamos de segundos a milisegundos
            if (!timer1.Enabled)
                timer1.Enabled = true;	// Activamos el Timer si no esta Enabled (activado)
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop(); // Detenemos el timer.
            this.Close(); // Si se ha terminado cerramos.
        }
    }
}
