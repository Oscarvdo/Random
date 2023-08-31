using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sistema_de_control
{
    public partial class frmProveedores : Form
    {
        public frmProveedores()
        {
            InitializeComponent();
        }

        //===================================================================================//
        // Creamos una instancia de la clase Generales
        Generales dg = new Generales();
        // Declaramos una variable estatica de nombre bandera
        private static byte bandera = 0;
        // Creamos el metodo estado, que servira para cambiar el estado de las cajas de textos
        void estado(bool x)
        {
            razonSocialTextBox.ReadOnly = x;
            direccionTextBox.ReadOnly = x;
            rucTextBox.ReadOnly = x;
            telefonoTextBox.ReadOnly = x;
        }
        //===================================================================================//

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            try
            {
                // Visualizamos el cursor ocupado
                this.Cursor = miCursor.Crear("Busy.ani");
                // Visualizamos los datos de los proveedores
                this.proveedoresTableAdapter.Fill(this.dsGeneral.Proveedores);
                // Cuando la operacion termine, visualizamos el cursor por defecto
                this.Cursor = Cursors.Default;
                // Visualizamos la cantidad total de proveedores
                txtConta.Text = proveedoresBindingSource.Count.ToString() + " Proveedores";
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error temporal"); }
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            proveedoresBindingSource.MoveFirst();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            proveedoresBindingSource.MovePrevious();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            proveedoresBindingSource.MoveNext();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            proveedoresBindingSource.MoveLast();
        }

        private void frmProveedores_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.opProv = false;
            razonSocialTextBox.DataBindings.Clear();
            direccionTextBox.DataBindings.Clear();
            rucTextBox.DataBindings.Clear();
            telefonoTextBox.DataBindings.Clear();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            proveedoresBindingSource.Filter = "RazonSocial like '" + txtBuscar.Text + "%'";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (razonSocialTextBox.ReadOnly)
            {
                estado(false); // Cambia el estado a escritura/lectura
                // Agregamos una nueva fila vacia
                proveedoresBindingSource.AddNew();
                razonSocialTextBox.Focus();
                bandera = 1;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Si la caja de texto razonSocialTextBox esta en modo lectura, abandonar el procedimiento
            if (razonSocialTextBox.ReadOnly) return;
            try
            {
                // Si es uno, entonces registrar un nuevo cliente
                if (bandera == 1)
                {
                    // Procedemos a registrar los datos
                    proveedoresTableAdapter.RegistrarProveedor(razonSocialTextBox.Text.Trim(), direccionTextBox.Text.Trim(),
                        rucTextBox.Text.Trim(), telefonoTextBox.Text.Trim());
                    // Cambiamos el estado a solo lectura
                    estado(true);
                    // Volvemos a su valor original
                    bandera = 0;
                    dsGeneral.Proveedores.Clear(); // Limpiamos la tabla Proveedores
                    proveedoresTableAdapter.Fill(dsGeneral.Proveedores); // Volvemos a cargar los datos
                    // Visualizamos la cantidad total de proveedores
                    txtConta.Text = proveedoresBindingSource.Count.ToString() + " Proveedores";
                    proveedoresBindingSource.MoveLast(); // Visualizamos el ultimo registro
                    // Visualizamos eun mensaje indicando que se ha registrado un nuevo cliente
                    MessageBox.Show("El nuevo proveedor fue registrado", "Registrado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (bandera == 2) // Si es dos, entonces actualizar datos existentes
                {
                    // Capturamos el codigo del cliente actual
                    int codProv = int.Parse(dsGeneral.Proveedores[proveedoresBindingSource.Position].idProveedor.ToString());
                    // Procedemos a actualizar los datos
                    proveedoresTableAdapter.ActualizarProveedor(razonSocialTextBox.Text.Trim(), direccionTextBox.Text.Trim(),
                        rucTextBox.Text.Trim(), telefonoTextBox.Text.Trim(), codProv);
                    // Cambiamos el estado a solo lectura
                    estado(true);
                    // Volvemos a su valor original
                    bandera = 0;
                    dsGeneral.Proveedores.Clear(); // Limpiamos la tabla Proveedores
                    proveedoresTableAdapter.Fill(dsGeneral.Proveedores); // Volvemos a cargar los datos
                    // Visualizamos eun mensaje indicando que se ha registrado un nuevo cliente
                    MessageBox.Show("Los datos del proveedor fueron actualizados", "Actualizado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error temporal"); }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (razonSocialTextBox.ReadOnly)
            {
                estado(false); // Cambia el estado a escritura/lectura
                bandera = 2; // Cambia el valor de la variable a 2 (indica que vamos a actualizar datos)
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Si la caja de texto nombre esta en modo escritura, abandonar el procedimiento
            if (!razonSocialTextBox.ReadOnly) return;
            // Preguntamos si desea eliminar al cliente, si la respuesta es si, entonces continuar
            if (MessageBox.Show("Desea eliminar al proveedor?", "Eliminar", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // Obtenemos el codigo del proveedor que estamos visualizando
                    int cod = int.Parse(dsGeneral.Proveedores[proveedoresBindingSource.Position].idProveedor.ToString());
                    // Hacemos uso del P.A. EliminarProveedor pasandole el codigo del cliente
                    proveedoresTableAdapter.EliminarProveedor(cod);
                    // Limpiamos la tabla
                    dsGeneral.Proveedores.Clear();
                    // Volvemos a cargar los datos de la tabla Proveedores
                    proveedoresTableAdapter.Fill(this.dsGeneral.Proveedores);
                    // Visualizamos la cantidad total de proveedores
                    txtConta.Text = proveedoresBindingSource.Count.ToString() + " Proveedores";
                    // Muestra un mensaje indicando que fue eliminado el Proveedor
                    MessageBox.Show("El proveedor fue eliminado", "Hecho!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, "Error temporal"); }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Si la caja de texto esta en modo escritura/lectura, entonces continuar...
            if (!razonSocialTextBox.ReadOnly)
            {
                estado(true); // Cambia el estado a solo lectura
                bandera = 0; // Restaura el valor de la variable
                proveedoresBindingSource.CancelEdit();
                proveedoresBindingSource.ResumeBinding();
            }
        }

        private void rucTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            dg.soloNumero(e);
        }

        private void telefonoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            dg.soloNumero(e);
        }
    }
}
