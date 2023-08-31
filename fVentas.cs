using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared; // Agregar para los parametros del reporte

namespace Sistema_de_control
{
    public partial class fVentas : Form
    {
        public fVentas()
        {
            InitializeComponent();
        }

        // Creamos las instancias que necesitaremos
        Generales dg = new Generales();
        dsGeneralTableAdapters.VentasTableAdapter rVenta = new dsGeneralTableAdapters.VentasTableAdapter();
        dsGeneralTableAdapters.DetalleVentaTableAdapter rDetalleV = new dsGeneralTableAdapters.DetalleVentaTableAdapter();
        decimal sSub, sIgv, sTotal;
        int numDoc;

        // Metodo para obtener el nro de Boleta o Factura, luego genera el siguiente numero
        private void verNroDoc()
        {
            try
            {
                // Si no se ha realizado ventas entonces empezar en el numero 0000001
                if (rVenta.MaxNroDoc(cboTipoDoc.Text.Trim()) == null)
                { txtNroDoc.Text = "0000001"; }
                else
                {
                    // Caso contrario, obtenemos el ultimo numero de la boleta o factura
                    numDoc = int.Parse(rVenta.MaxNroDoc(cboTipoDoc.Text.Trim()).ToString());
                    numDoc += 1; // Obtenemos el siguiente numero de boleta o factuta
                    // Visualizamos el numero numero de boleta o factura, si el numero no llega a 7 digitos
                    // entonces rellenaremos con ceros a la izquierda del numero hasta completar los 7 digitos con la ayuda de PadLeft
                    txtNroDoc.Text = numDoc.ToString().PadLeft(7, '0');
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error temporal"); }
        }

        // Metodo  que calculara el total, subtotal e I.G.V
        private void Calcular()
        {
            sTotal = 0;
            foreach (DataGridViewRow fila in dgvLista.Rows)
            {
                // Sumamos todos los importes
                sTotal += decimal.Parse(fila.Cells[5].Value.ToString());
            }
            if (cboTipoDoc.Text == "Factura")
            { sIgv = sTotal * 0.19M; sSub = sTotal - sIgv; }
            else
            { sIgv = 0; sSub = 0; }
            // Pasamos los valores de las variables a las respectivas cajas de texto previo "formateo"
            txtSub.Text = sSub.ToString("#,#.00");
            txtIGV.Text = sIgv.ToString("#,#.00");
            txtTotal.Text = sTotal.ToString("#,#.00");
        }

        private void fVentas_Load(object sender, EventArgs e)
        {
            try
            {
                this.clientesTableAdapter.Fill(this.dsGeneral.Clientes);
                this.productosTableAdapter.Fill(this.dsGeneral.Productos);
                cboTipoDoc.SelectedIndex = 0;
                cboSerie.SelectedIndex = 0;
                verNroDoc();
                // Asigna la fecha actual (de la PC) a la caja de texto Fecha
                txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error temporal"); }
        }

        private void fVentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.opVenta = false;
        }

        private void dgvProductos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProductos.Rows.Count > 0)
            {
                // Pasamos el precio a la caja de texto txtPrecioVenta, para haccer una posible rebaja...
                txtPrecioVenta.Text = dgvProductos.CurrentRow.Cells[3].Value.ToString();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            productosBindingSource.Filter = "Descripcion like '" + txtBuscar.Text + "%'";
        }

        private void chkActivar_CheckedChanged(object sender, EventArgs e)
        {
            // Si esta marcado, pasar a modo escritura/lectura la caja de texto txtNroDoc para cambiar el numero de boleta o factura
            if (chkActivar.Checked)
            { txtNroDoc.ReadOnly = false; txtNroDoc.Focus(); }
            else
            { txtNroDoc.ReadOnly = true; }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtPrecioVenta.Text.Trim().Length == 0)
            {
                MessageBox.Show("¡Especifique el precio de venta!", "No ingreso el precio de venta",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (txtCantidad.Text.Trim().Length == 0)
            {
                MessageBox.Show("¡Especifique la cantidad del producto!", "No especifico la cantidad del producto",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            try
            {
                if (dgvProductos.Rows.Count > 0)
                {
                    // Verificamos el stock para vender
                    int cStock = int.Parse(dgvProductos.CurrentRow.Cells[4].Value.ToString());
                    if (int.Parse(txtCantidad.Text.Trim()) > cStock)
                    {
                        MessageBox.Show("La cantidad a vender es mayor que el stock", "Imposible vender este producto!");
                        return;
                    }
                    // Verificamos si el producto ya esta en la lista de venta a traves de sus codigos o id
                    foreach (DataGridViewRow fila in dgvLista.Rows)
                    {
                        if (int.Parse(fila.Cells[7].Value.ToString()) == int.Parse(dgvProductos.CurrentRow.Cells[5].Value.ToString()))
                        {
                            MessageBox.Show("¡El producto ya esta en lista, debe quitarlo" + "\n" + "para volver a agregarlo con otra cantidad!", "Duplicado!");
                            return;
                        }
                    }
                    DataRow f = dsGeneral.ListaVenta.NewRow();
                    f[0] = int.Parse(dgvProductos.CurrentRow.Cells[5].Value.ToString()); // Cod
                    f[1] = dgvProductos.CurrentRow.Cells[0].Value.ToString(); // Descripcion
                    f[2] = dgvProductos.CurrentRow.Cells[1].Value.ToString(); // Marca
                    f[3] = decimal.Parse(dgvProductos.CurrentRow.Cells[2].Value.ToString()); // PrecioCompra
                    f[4] = decimal.Parse(txtPrecioVenta.Text); // PrecioVenta
                    f[5] = int.Parse(txtCantidad.Text); // Cantidad
                    f[6] = decimal.Parse(f[4].ToString()) * int.Parse(f[5].ToString()); // Importe
                    f[7] = decimal.Parse(f[6].ToString()) - decimal.Parse(f[3].ToString()) * int.Parse(f[5].ToString()); // Ganancia
                    dsGeneral.ListaVenta.Rows.Add(f);
                    txtBuscar.ResetText(); txtBuscar.Focus();
                    txtPrecioVenta.ResetText();
                    txtCantidad.Text = "1";
                    Calcular();
                    //if (!chkConsumo.Checked)
                    //    Calcular();
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error temporal"); }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvLista.Rows.Count > 0)
            {
                dsGeneral.ListaVenta[dgvLista.CurrentRow.Index].Delete();
                Calcular(); txtBuscar.ResetText(); txtBuscar.Focus();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dsGeneral.ListaVenta.Clear();
            txtSub.Text = "0"; txtIGV.Text = "0";
            txtTotal.Text = "0";
            txtBuscar.ResetText(); txtBuscar.Focus();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                frmVista fVista = new frmVista();
                rptBoleta rpt = new rptBoleta();
                rpt.SetDataSource(this.dsGeneral);

                // Creamos los PARAMETROS con sus respectivos nombres
                ParameterField par1 = new ParameterField();
                par1.ParameterFieldName = "Cliente";
                ParameterField par2 = new ParameterField();
                par2.ParameterFieldName = "Documento";
                ParameterField par3 = new ParameterField();
                par3.ParameterFieldName = "Serie";
                ParameterField par4 = new ParameterField();
                par4.ParameterFieldName = "NroDoc";
                ParameterField par5 = new ParameterField();
                par5.ParameterFieldName = "RUC";

                // Indicamos de donde vamos a extraer los VALORES para los parametros
                ParameterDiscreteValue v1 = new ParameterDiscreteValue();
                v1.Value = this.cboCliente.Text;
                ParameterDiscreteValue v2 = new ParameterDiscreteValue();
                v2.Value = this.cboTipoDoc.Text;
                ParameterDiscreteValue v3 = new ParameterDiscreteValue();
                v3.Value = this.cboSerie.Text;
                ParameterDiscreteValue v4 = new ParameterDiscreteValue();
                v4.Value = this.txtNroDoc.Text;
                ParameterDiscreteValue v5 = new ParameterDiscreteValue();
                v5.Value = "20777777773"; // R.U.C. de nuestra empresa

                // Creamos un conjunto de parametros como objeto
                ParameterFields conjpar = new ParameterFields();

                // Pasamos los VALORES a los PARAMETROS
                par1.CurrentValues.Add(v1);
                conjpar.Add(par1);
                par2.CurrentValues.Add(v2);
                conjpar.Add(par2);
                par3.CurrentValues.Add(v3);
                conjpar.Add(par3);
                par4.CurrentValues.Add(v4);
                conjpar.Add(par4);
                par5.CurrentValues.Add(v5);
                conjpar.Add(par5);

                // Visualizamos el formulario donde saldra el visor del reporte
                fVista.Visor.ParameterFieldInfo = conjpar;
                fVista.Visor.ReportSource = rpt;
                fVista.Show(this);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error en reporte"); }
        }

        private void txtNroDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            dg.soloNumero(e);
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            dg.soloNumero(e);
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            dg.moneda(e);
        }

        private void cboTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            verNroDoc();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtNroDoc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Defina el Nro. del documento", "Registro de compras", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNroDoc.Clear(); txtNroDoc.Focus(); return;
            }
            if (dgvLista.Rows.Count == 0)
            {
                MessageBox.Show("Agrege al menos un producto para realizar la venta", "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                // Registramos en la tabla ventas       
                rVenta.Insert(int.Parse(cboCliente.SelectedValue.ToString()), cboTipoDoc.Text,
                    txtNroDoc.Text, DateTime.Parse(txtFecha.Text), float.Parse(txtTotal.Text));
                // Obtener el maximo idventa
                int codVenta = int.Parse(rVenta.MaxIDVenta().ToString());
                // Recorremos la lista de productos a vender
                foreach (DataGridViewRow fila in dgvLista.Rows)
                {
                    // Comenzamos a registrar en la tabla Detalles Compra
                    rDetalleV.Insert(codVenta, int.Parse(fila.Cells[7].Value.ToString()), float.Parse(fila.Cells[2].Value.ToString()),
                        float.Parse(fila.Cells[3].Value.ToString()), int.Parse(fila.Cells[4].Value.ToString()),
                        float.Parse(fila.Cells[5].Value.ToString()), float.Parse(fila.Cells[6].Value.ToString()));
                    // Obtenemos el stock del producto y restamos la cantidad comprada
                    int stock = int.Parse(productosTableAdapter.MaxStock(int.Parse(fila.Cells[7].Value.ToString())).ToString()) - int.Parse(int.Parse(fila.Cells[4].Value.ToString()).ToString());
                    // Actualizamos el campo stock
                    productosTableAdapter.ActualizaStock(stock, int.Parse(fila.Cells[7].Value.ToString()));
                }
                // Limpiamos y volvemos a cargar los productos
                dsGeneral.Productos.Clear();
                productosTableAdapter.Fill(dsGeneral.Productos);
                // Limpiamos la compra
                dsGeneral.ListaVenta.Clear();
                txtSub.Text = "0"; txtIGV.Text = "0";
                txtTotal.Text = "0";
                txtBuscar.ResetText(); txtBuscar.Focus();
                verNroDoc(); // Generamos el siguiente Nro de Boleta o Factura segun sea el caso
                MessageBox.Show("¡La venta se realizo con éxito!", "Venta realizada",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error temporal"); }
        }
    }
}
