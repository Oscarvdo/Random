using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sistema_de_control
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Variables booleanas estaticas (por defecto su valor es false)
        internal static bool opCli, opProv, opProd, opCompra, opVenta, opLogin;

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Creamos la instancia del formulario y pasamos el valor de 3 (3 segundos)
            frmSplash f1 = new frmSplash(3);
            f1.ShowDialog(this); // Visualizamos el splash perteneciente a este formulario
            f1.Dispose(); // Limpia todos los recursos utilizados
            this.WindowState = FormWindowState.Maximized; // Maximiza el formulario
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Si la varible opCli es false, entonces seguir...
            if (!opCli)
            {
                // Cambiamos su valor a true, eso quiere decir que ya existe una instancia del formulario frmCliente
                opCli = true;
                // Creamos una instancia del formulario frmCliente
                frmClientes fcli = new frmClientes();
                fcli.MdiParent = this;
                fcli.Show();
            }
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!opProv)
            {
                opProv = true;
                frmProveedores fprov = new frmProveedores();
                fprov.MdiParent = this;
                fprov.Show();
            }
        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!opProd)
            {
                opProd = true;
                frmProductos fprod = new frmProductos();
                fprod.MdiParent = this;
                fprod.Show();
            }
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!opCompra)
            {
                opCompra = true;
                frmCompras fcom = new frmCompras();
                fcom.MdiParent = this;
                fcom.Show();
            }
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!opVenta)
            {
                opVenta = true;
                fVentas fvt = new fVentas();
                fvt.MdiParent = this;
                fvt.Show();
            }
        }

        private void ventasDelDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
