using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sistema_de_control
{
    public partial class frmProductos : Form
    {
        public frmProductos()
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
            descripcionTextBox.ReadOnly = x;
            marcaTextBox.ReadOnly = x;
            precioCompraTextBox.ReadOnly = x;
            precioVentaTextBox.ReadOnly = x;
            stockTextBox.ReadOnly = x;
        }
        //===================================================================================//

        private void frmProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.opProd = false;
            descripcionTextBox.DataBindings.Clear();
            marcaTextBox.DataBindings.Clear();
            precioCompraTextBox.DataBindings.Clear();
            precioVentaTextBox.DataBindings.Clear();
            stockTextBox.DataBindings.Clear();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            try
            {
                this.productosTableAdapter.Fill(this.dsGeneral.Productos);
                // Visualizamos la cantidad total de productos
                txtConta.Text = productosBindingSource.Count.ToString() + " Productos";
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error temporal"); }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            productosBindingSource.Filter = "Descripcion like '" + txtBuscar.Text + "%'";
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            productosBindingSource.MoveFirst();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            productosBindingSource.MovePrevious();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            productosBindingSource.MoveNext();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            productosBindingSource.MoveLast();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (descripcionTextBox.ReadOnly)
            {
                estado(false); // Cambia el estado a escritura/lectura
                // Agregamos una nueva fila vacia
                productosBindingSource.AddNew();
                descripcionTextBox.Focus();
                bandera = 1;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Si la caja de texto esta en modo lectura, abandonar el procedimiento
            if (descripcionTextBox.ReadOnly) return;
            try
            {
                // Si es uno, entonces registrar un nuevo cliente
                if (bandera == 1)
                {
                    // Procedemos a registrar los datos
                    productosTableAdapter.RegistrarProducto(descripcionTextBox.Text.Trim(), marcaTextBox.Text.Trim(),
                        float.Parse(precioCompraTextBox.Text.Trim()), float.Parse(precioVentaTextBox.Text.Trim()),
                        int.Parse(stockTextBox.Text.Trim()));
                    // Cambiamos el estado a solo lectura
                    estado(true);
                    // Volvemos a su valor original
                    bandera = 0;
                    dsGeneral.Productos.Clear(); // Limpiamos la tabla Productos
                    productosTableAdapter.Fill(dsGeneral.Productos); // Volvemos a cargar los datos
                    // Visualizamos la cantidad total de productos
                    txtConta.Text = productosBindingSource.Count.ToString() + " Productos";
                    productosBindingSource.MoveLast(); // Visualizamos el ultimo registro
                    // Visualizamos un mensaje de conformidad
                    MessageBox.Show("El nuevo producto fue registrado", "Registrado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (bandera == 2) // Si es dos, entonces actualizar datos existentes
                {
                    // Capturamos el codigo del producto actual
                    int codProd = int.Parse(dsGeneral.Productos[productosBindingSource.Position].idProducto.ToString());
                    // Procedemos a actualizar los datos
                    productosTableAdapter.ActualizarProducto(descripcionTextBox.Text.Trim(), marcaTextBox.Text.Trim(),
                        float.Parse(precioCompraTextBox.Text.Trim()), float.Parse(precioVentaTextBox.Text.Trim()),
                        int.Parse(stockTextBox.Text.Trim()), codProd);
                    // Cambiamos el estado a solo lectura
                    estado(true);
                    // Volvemos a su valor original
                    bandera = 0;
                    dsGeneral.Productos.Clear(); // Limpiamos la tabla Productos
                    productosTableAdapter.Fill(dsGeneral.Productos); // Volvemos a cargar los datos
                    // Visualizamos un mensaje de conformidad
                    MessageBox.Show("Los datos del producto fueron actualizados", "Actualizado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error temporal"); }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (descripcionTextBox.ReadOnly)
            {
                estado(false); // Cambia el estado a escritura/lectura
                bandera = 2; // Cambia el valor de la variable a 2 (indica que vamos a actualizar datos)
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Si la caja de texto descripcionTextBox esta en modo escritura, abandonar el procedimiento
            if (!descripcionTextBox.ReadOnly) return;
            // Preguntamos si desea eliminar el producto, si la respuesta es si, entonces continuar
            if (MessageBox.Show("Desea eliminar el producto?", "Eliminar", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // Obtenemos el codigo del producto que estamos visualizando
                    int cod = int.Parse(dsGeneral.Productos[productosBindingSource.Position].idProducto.ToString());
                    // Hacemos uso del P.A. EliminarProducto pasandole el codigo del Productos
                    productosTableAdapter.EliminarProducto(cod);
                    // Limpiamos la tabla
                    dsGeneral.Proveedores.Clear();
                    // Volvemos a cargar los datos de la tabla Productos
                    productosTableAdapter.Fill(this.dsGeneral.Productos);
                    // Visualizamos la cantidad total de productos
                    txtConta.Text = productosBindingSource.Count.ToString() + " Productos";
                    // Muestra un mensaje indicando que fue eliminado el Productos
                    MessageBox.Show("El producto fue eliminado", "Hecho!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, "Error temporal"); }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Si la caja de texto esta en modo escritura/lectura, entonces continuar...
            if (!descripcionTextBox.ReadOnly)
            {
                estado(true); // Cambia el estado a solo lectura
                bandera = 0; // Restaura el valor de la variable
                productosBindingSource.CancelEdit();
                productosBindingSource.ResumeBinding();
            }
        }

        private void precioCompraTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            dg.moneda(e);
        }

        private void precioVentaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            dg.moneda(e);
        }

        private void stockTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            dg.soloNumero(e);
        }
    }
}
