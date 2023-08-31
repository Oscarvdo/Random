using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sistema_de_control
{
    public partial class frmCompras : Form
    {
        public frmCompras()
        {
            InitializeComponent();
        }

        Generales dg = new Generales();
        dsGeneralTableAdapters.ComprasTableAdapter rCompra = new dsGeneralTableAdapters.ComprasTableAdapter();
        dsGeneralTableAdapters.DetalleCompraTableAdapter rDetalle = new dsGeneralTableAdapters.DetalleCompraTableAdapter();
        decimal sSub, sIgv, sTotal;

        private void Calcular()
        {
            sTotal = 0;
            foreach (DataGridViewRow fila in dgvLista.Rows)
            {
                sTotal += decimal.Parse(fila.Cells[4].Value.ToString());
            }
            if (cboDoc.Text == "Factura")
            { sIgv = sTotal * 0.19M; sSub = sTotal - sIgv; }
            else
            { sIgv = 0; sSub = 0; }

            txtSub.Text = sSub.ToString("#,#.00");
            txtIGV.Text = sIgv.ToString("#,#.00");
            txtTotal.Text = sTotal.ToString("#,#.00");
        }

        private void frmCompras_Load(object sender, EventArgs e)
        {
            try
            {
                this.productosTableAdapter.Fill(this.dsGeneral.Productos);
                this.proveedoresTableAdapter.Fill(this.dsGeneral.Proveedores);
                // Seleccionamos el primer elemento del ComboBox que corresponde a Tipo de documento
                cboDoc.SelectedIndex = 0;
                // Asigna la fecha actual (de la PC) a la caja de texto Fecha
                txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error temporal"); }
        }

        private void frmCompras_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.opCompra = false;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            productosBindingSource.Filter = "Descripcion like '" + txtBuscar.Text + "%'";
        }

        private void dgvProductos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Si existe al menos un registro
            if (dgvProductos.Rows.Count > 0)
            {
                // Obtnemos el valor del preciocompra y la mostramos en txtPrecioCompra
                txtPrecioCompra.Text = dgvProductos.CurrentRow.Cells[2].Value.ToString();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtPrecioCompra.Text.Trim().Length == 0)
            {
                MessageBox.Show("¡Especifique el precio de compra!", "No ingreso el precio de compra");
                return;
            }
            if (txtCantidad.Text.Trim().Length == 0)
            {
                MessageBox.Show("¡Especifique la cantidad del producto!", "No ingreso la cantidad del producto");
                return;
            }
            try
            {
                if (dgvProductos.Rows.Count > 0)
                {
                    foreach (DataGridViewRow fila in dgvLista.Rows)
                    {
                        if (int.Parse(fila.Cells[5].Value.ToString()) == int.Parse(dgvProductos.CurrentRow.Cells[5].Value.ToString()))
                        {
                            MessageBox.Show("¡El producto ya esta en lista, debe quitarlo" + "\n" +
                                "para volver a agregarlo con otra cantidad!", "Duplicado!");
                            return;
                        }
                    }
                    // Creamos una nueva fila con los campos que contiene el datatable listaCompra
                    DataRow f = dsGeneral.ListaCompra.NewRow();
                    // Codigo
                    f[0] = int.Parse(dgvProductos.CurrentRow.Cells[5].Value.ToString());
                    // Descripcion
                    f[1] = dgvProductos.CurrentRow.Cells[0].Value.ToString();
                    // Marca
                    f[2] = dgvProductos.CurrentRow.Cells[1].Value.ToString();
                    // Precio de compra
                    f[3] = decimal.Parse(txtPrecioCompra.Text);
                    // Cantidad
                    f[4] = int.Parse(txtCantidad.Text);
                    // Importe
                    f[5] = decimal.Parse(f[3].ToString()) * int.Parse(f[4].ToString());
                    dsGeneral.ListaCompra.Rows.Add(f);
                    txtBuscar.ResetText(); txtBuscar.Focus();
                    txtPrecioCompra.ResetText();
                    txtCantidad.Text = "1";
                    Calcular();
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error temporal"); }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvLista.Rows.Count > 0)
            {
                // Eliminamos el producto seleccionado de la lista
                dsGeneral.ListaCompra[dgvLista.CurrentRow.Index].Delete();
                // Volvemos a calcular, reseteamos y asigna el foco a txtBuscar
                Calcular(); txtBuscar.ResetText(); txtBuscar.Focus();
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtNumero.Text.Trim().Length == 0)
            {
                MessageBox.Show("Defina el Nro. del documento", "Registro de compras", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNumero.Clear(); txtNumero.Focus(); return;
            }
            if (dgvLista.Rows.Count == 0)
            {
                MessageBox.Show("Agrege al menos un producto para realizar la compra", "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                // Registramos en la tabla compras            
                rCompra.Insert(int.Parse(cboProveedor.SelectedValue.ToString()), cboDoc.Text, txtNumero.Text,
                    DateTime.Parse(txtFecha.Text), float.Parse(txtSub.Text),
                    float.Parse(txtIGV.Text), float.Parse(txtTotal.Text));
                // Obtener el maximo idcompra
                int codCompra = int.Parse(rCompra.MaxIDCompra().ToString());
                // Recorremos la lista de productos a comprar
                foreach (DataGridViewRow fila in dgvLista.Rows)
                {
                    // Comenzamos a registrar en la tabla Detalles Compra
                    rDetalle.Insert(codCompra, int.Parse(fila.Cells[5].Value.ToString()), float.Parse(fila.Cells[2].Value.ToString()),
                        int.Parse(fila.Cells[3].Value.ToString()), float.Parse(fila.Cells[4].Value.ToString()));
                    // Obtenemos el stock del producto y sumamos la cantidad comprada
                    int stock = int.Parse(productosTableAdapter.MaxStock(int.Parse(fila.Cells[5].Value.ToString())).ToString()) + int.Parse(int.Parse(fila.Cells[3].Value.ToString()).ToString());
                    // Actualizamos el campo stock
                    productosTableAdapter.ActualizaStock(stock, int.Parse(fila.Cells[5].Value.ToString()));
                    // Verificamos si esta marcado actualizar los precios de venta
                    if (chkPrecioCompra.Checked)
                    {
                        productosTableAdapter.ActualizaPrecios(float.Parse(fila.Cells[2].Value.ToString()),
                            float.Parse(fila.Cells[2].Value.ToString()) + (float.Parse(fila.Cells[2].Value.ToString()) * float.Parse(txtGanancia.Text) / 100), int.Parse(fila.Cells[5].Value.ToString()));
                    }
                }
                // Volvemos a cargar los productos
                dsGeneral.Productos.Clear();
                productosTableAdapter.Fill(dsGeneral.Productos);
                // Limpiamos la compra
                dsGeneral.ListaCompra.Clear();
                txtSub.Text = "0"; txtIGV.Text = "0";
                txtTotal.Text = "0"; txtNumero.Clear();
                // Asigna la fecha actual (de la PC) a la caja de texto Fecha
                txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
                MessageBox.Show("¡La compra se realizo con éxito!", "Compra realizada",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error temporal"); }
        }

        private void cboDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calcular();
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            dg.soloNumero(e);
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            dg.soloNumero(e);
        }

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            dg.moneda(e);
        }
    }
}
