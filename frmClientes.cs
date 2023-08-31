using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sistema_de_control
{
    public partial class frmClientes : Form
    {
        public frmClientes()
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
            nombreTextBox.ReadOnly = x;
            direccionTextBox.ReadOnly = x;
            rucDNITextBox.ReadOnly = x;
            telefonoTextBox.ReadOnly = x;
        }
        //===================================================================================//

        private void frmClientes_Load(object sender, EventArgs e)
        {
            try
            {
                this.clientesTableAdapter.Fill(this.dsGeneral.Clientes);
                // Visualizamos la cantidad total de clientes
                txtConta.Text = clientesBindingSource.Count.ToString() + " Clientes";
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error temporal"); }
        }

        private void frmClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.opCli = false;
            // Limpiamos los enlaces a datos de los controles (Necesario al usar el skin)
            nombreTextBox.DataBindings.Clear();
            direccionTextBox.DataBindings.Clear();
            rucDNITextBox.DataBindings.Clear();
            telefonoTextBox.DataBindings.Clear();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            // Si la caja de texto es de solo lectura, entonces continuar...
            if (nombreTextBox.ReadOnly)
            {
                estado(false); // Cambia el estado a escritura/lectura
                // Agregamos una nueva fila vacia
                clientesBindingSource.AddNew();
                // La caja de texto nombre recibe el foco
                nombreTextBox.Focus();
                // Cambia el valor a 1 (indica que vamos a Registrar nuevo cliente)
                bandera = 1;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Si la caja de texto nombre esta en modo lectura, abandonar el procedimiento
            if (nombreTextBox.ReadOnly) return;
            try
            {
                // Si es uno, entonces registrar un nuevo cliente
                if (bandera == 1)
                {
                    // Procedemos a registrar los datos
                    clientesTableAdapter.RegistrarCliente(nombreTextBox.Text.Trim(), direccionTextBox.Text.Trim(),
                        rucDNITextBox.Text.Trim(), telefonoTextBox.Text.Trim());
                    // Cambiamos el estado a solo lectura
                    estado(true);
                    // Volvemos a su valor original
                    bandera = 0;
                    dsGeneral.Clientes.Clear(); // Limpiamos la tabla clientes
                    clientesTableAdapter.Fill(dsGeneral.Clientes); // Volvemos a cargar los datos
                    // Visualizamos la cantidad total de clientes
                    txtConta.Text = clientesBindingSource.Count.ToString() + " Clientes";
                    clientesBindingSource.MoveLast(); // Visualizamos el ultimo registro
                    // Visualizamos eun mensaje indicando que se ha registrado un nuevo cliente
                    MessageBox.Show("El nuevo cliente fue registrado", "Registrado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (bandera == 2) // Si es dos, entonces actualizar datos existentes
                {
                    // Capturamos el codigo del cliente actual
                    int codCli = int.Parse(dsGeneral.Clientes[clientesBindingSource.Position].idCliente.ToString());
                    // Procedemos a actualizar los datos
                    clientesTableAdapter.ActualizarCliente(nombreTextBox.Text.Trim(), direccionTextBox.Text.Trim(),
                        rucDNITextBox.Text.Trim(), telefonoTextBox.Text.Trim(), codCli);
                    // Cambiamos el estado a solo lectura
                    estado(true);
                    // Volvemos a su valor original
                    bandera = 0;
                    dsGeneral.Clientes.Clear(); // Limpiamos la tabla clientes
                    clientesTableAdapter.Fill(dsGeneral.Clientes); // Volvemos a cargar los datos
                    // Visualizamos eun mensaje indicando que se ha registrado un nuevo cliente
                    MessageBox.Show("Los datos del cliente fue actualizado", "Actualizado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error temporal"); }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            // Si la caja de texto es de solo lectura, entonces continuar...
            if (nombreTextBox.ReadOnly)
            {
                // Capturamos el codigo del cliente actual
                int codCli = int.Parse(dsGeneral.Clientes[clientesBindingSource.Position].idCliente.ToString());
                // Si es el cliente eventual, entonces visualizar mensaje y abandonar procedimiento
                if (codCli == 1)
                {
                    MessageBox.Show("El cliente eventual no puede ser modificado...", "Accion no permitida!",
                MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return; // Abandonamos el procedimiento
                }
                estado(false); // Cambia el estado a escritura/lectura
                bandera = 2; // Cambia el valor de la variable a 2 (indica que vamos a actualizar datos)
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Si la caja de texto nombre esta en modo escritura, abandonar el procedimiento
            if (!nombreTextBox.ReadOnly) return;
            // Obtenemos el codigo del cliente que estamos visualizando
            int cod = int.Parse(dsGeneral.Clientes[clientesBindingSource.Position].idCliente.ToString());
            // Si el codigo del cliente es el 1, quiere decir que es el cliente eventual
            if (cod == 1)
            {
                MessageBox.Show("El cliente eventual no puede ser eliminado...", "Accion no permitida!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; // Abandonamos el procedimiento
            }
            // Preguntamos si desea eliminar al cliente, si la respuesta es si, entonces continuar
            if (MessageBox.Show("Desea eliminar al cliente?", "Eliminar", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // Hacemos uso del P.A. EliminarCliente pasandole el codigo del cliente
                    clientesTableAdapter.EliminarCliente(cod);
                    // Limpiamos la tabla clientes
                    dsGeneral.Clientes.Clear();
                    // Volvemos a cargar los datos de la tabla clientes
                    this.clientesTableAdapter.Fill(this.dsGeneral.Clientes);
                    // Visualizamos la cantidad total de clientes
                    txtConta.Text = clientesBindingSource.Count.ToString() + " Clientes";
                    // Muestra un mensaje indicando que fue eliminado el cliente
                    MessageBox.Show("El cliente fue eliminado", "Hecho!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, "Error temporal"); }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Si la caja de texto esta en modo escritura/lectura, entonces continuar...
            if (!nombreTextBox.ReadOnly)
            {
                estado(true); // Cambia el estado a solo lectura
                bandera = 0; // Restaura el valor de la variable
                clientesBindingSource.CancelEdit();
                clientesBindingSource.ResumeBinding();
            }
        }

        private void rucDNITextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            dg.soloNumero(e); // Hacemos uso del metodo soloNumero
        }

        private void telefonoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            dg.soloNumero(e); // Hacemos uso del metodo soloNumero
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            clientesBindingSource.MoveFirst();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            clientesBindingSource.MovePrevious();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            clientesBindingSource.MoveNext();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            clientesBindingSource.MoveLast();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            // Filtramos los datos por medio del nombre del cliente
            clientesBindingSource.Filter = "Nombre like '" + txtBuscar.Text + "%'";
        }
    }
}
