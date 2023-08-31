namespace Sistema_de_control
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.comprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.articulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasDelDiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasPorFechasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.stockDeArticulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iniciarCajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresoTotalACajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sistemaDeControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desarrolladorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comprasToolStripMenuItem,
            this.ventasToolStripMenuItem,
            this.datosToolStripMenuItem,
            this.informesToolStripMenuItem,
            this.cajaToolStripMenuItem,
            this.loginToolStripMenuItem,
            this.acercaDelToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(807, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // comprasToolStripMenuItem
            // 
            this.comprasToolStripMenuItem.Image = global::Sistema_de_control.Properties.Resources.Add_To_Basket;
            this.comprasToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.comprasToolStripMenuItem.Name = "comprasToolStripMenuItem";
            this.comprasToolStripMenuItem.Size = new System.Drawing.Size(91, 28);
            this.comprasToolStripMenuItem.Text = "Compras";
            this.comprasToolStripMenuItem.Click += new System.EventHandler(this.comprasToolStripMenuItem_Click);
            // 
            // ventasToolStripMenuItem
            // 
            this.ventasToolStripMenuItem.Image = global::Sistema_de_control.Properties.Resources.Shopping_Full;
            this.ventasToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            this.ventasToolStripMenuItem.Size = new System.Drawing.Size(78, 28);
            this.ventasToolStripMenuItem.Text = "Ventas";
            this.ventasToolStripMenuItem.Click += new System.EventHandler(this.ventasToolStripMenuItem_Click);
            // 
            // datosToolStripMenuItem
            // 
            this.datosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.articulosToolStripMenuItem,
            this.toolStripMenuItem1,
            this.clientesToolStripMenuItem,
            this.proveedoresToolStripMenuItem});
            this.datosToolStripMenuItem.Image = global::Sistema_de_control.Properties.Resources.Books;
            this.datosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.datosToolStripMenuItem.Name = "datosToolStripMenuItem";
            this.datosToolStripMenuItem.Size = new System.Drawing.Size(73, 28);
            this.datosToolStripMenuItem.Text = "Datos";
            // 
            // articulosToolStripMenuItem
            // 
            this.articulosToolStripMenuItem.Image = global::Sistema_de_control.Properties.Resources.Control_Panel_2;
            this.articulosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.articulosToolStripMenuItem.Name = "articulosToolStripMenuItem";
            this.articulosToolStripMenuItem.Size = new System.Drawing.Size(160, 30);
            this.articulosToolStripMenuItem.Text = "Articulos";
            this.articulosToolStripMenuItem.Click += new System.EventHandler(this.articulosToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(157, 6);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Image = global::Sistema_de_control.Properties.Resources.Vista_Users;
            this.clientesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(160, 30);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // proveedoresToolStripMenuItem
            // 
            this.proveedoresToolStripMenuItem.Image = global::Sistema_de_control.Properties.Resources.Vista_icons_09;
            this.proveedoresToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            this.proveedoresToolStripMenuItem.Size = new System.Drawing.Size(160, 30);
            this.proveedoresToolStripMenuItem.Text = "Proveedores";
            this.proveedoresToolStripMenuItem.Click += new System.EventHandler(this.proveedoresToolStripMenuItem_Click);
            // 
            // informesToolStripMenuItem
            // 
            this.informesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ventasDelDiaToolStripMenuItem,
            this.ventasPorFechasToolStripMenuItem,
            this.toolStripMenuItem2,
            this.stockDeArticulosToolStripMenuItem});
            this.informesToolStripMenuItem.Image = global::Sistema_de_control.Properties.Resources.Chart;
            this.informesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.informesToolStripMenuItem.Name = "informesToolStripMenuItem";
            this.informesToolStripMenuItem.Size = new System.Drawing.Size(90, 28);
            this.informesToolStripMenuItem.Text = "Informes";
            // 
            // ventasDelDiaToolStripMenuItem
            // 
            this.ventasDelDiaToolStripMenuItem.Image = global::Sistema_de_control.Properties.Resources.Disk_Spaces;
            this.ventasDelDiaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ventasDelDiaToolStripMenuItem.Name = "ventasDelDiaToolStripMenuItem";
            this.ventasDelDiaToolStripMenuItem.Size = new System.Drawing.Size(175, 30);
            this.ventasDelDiaToolStripMenuItem.Text = "Ventas del dia";
            this.ventasDelDiaToolStripMenuItem.Click += new System.EventHandler(this.ventasDelDiaToolStripMenuItem_Click);
            // 
            // ventasPorFechasToolStripMenuItem
            // 
            this.ventasPorFechasToolStripMenuItem.Image = global::Sistema_de_control.Properties.Resources.Diagram;
            this.ventasPorFechasToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ventasPorFechasToolStripMenuItem.Name = "ventasPorFechasToolStripMenuItem";
            this.ventasPorFechasToolStripMenuItem.Size = new System.Drawing.Size(175, 30);
            this.ventasPorFechasToolStripMenuItem.Text = "Ventas por fechas";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(172, 6);
            // 
            // stockDeArticulosToolStripMenuItem
            // 
            this.stockDeArticulosToolStripMenuItem.Image = global::Sistema_de_control.Properties.Resources.Control_Panel_2;
            this.stockDeArticulosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.stockDeArticulosToolStripMenuItem.Name = "stockDeArticulosToolStripMenuItem";
            this.stockDeArticulosToolStripMenuItem.Size = new System.Drawing.Size(175, 30);
            this.stockDeArticulosToolStripMenuItem.Text = "Stock de articulos";
            // 
            // cajaToolStripMenuItem
            // 
            this.cajaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iniciarCajaToolStripMenuItem,
            this.ingresoTotalACajaToolStripMenuItem});
            this.cajaToolStripMenuItem.Image = global::Sistema_de_control.Properties.Resources.sign_dolar_24;
            this.cajaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cajaToolStripMenuItem.Name = "cajaToolStripMenuItem";
            this.cajaToolStripMenuItem.Size = new System.Drawing.Size(66, 28);
            this.cajaToolStripMenuItem.Text = "Caja";
            // 
            // iniciarCajaToolStripMenuItem
            // 
            this.iniciarCajaToolStripMenuItem.Image = global::Sistema_de_control.Properties.Resources.money;
            this.iniciarCajaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.iniciarCajaToolStripMenuItem.Name = "iniciarCajaToolStripMenuItem";
            this.iniciarCajaToolStripMenuItem.Size = new System.Drawing.Size(181, 30);
            this.iniciarCajaToolStripMenuItem.Text = "Iniciar caja";
            // 
            // ingresoTotalACajaToolStripMenuItem
            // 
            this.ingresoTotalACajaToolStripMenuItem.Image = global::Sistema_de_control.Properties.Resources.reward_24;
            this.ingresoTotalACajaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ingresoTotalACajaToolStripMenuItem.Name = "ingresoTotalACajaToolStripMenuItem";
            this.ingresoTotalACajaToolStripMenuItem.Size = new System.Drawing.Size(181, 30);
            this.ingresoTotalACajaToolStripMenuItem.Text = "Ingreso total a caja";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Image = global::Sistema_de_control.Properties.Resources.Vista_icons_08;
            this.loginToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(73, 28);
            this.loginToolStripMenuItem.Text = "Login";
            // 
            // acercaDelToolStripMenuItem
            // 
            this.acercaDelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sistemaDeControlToolStripMenuItem,
            this.desarrolladorToolStripMenuItem});
            this.acercaDelToolStripMenuItem.Image = global::Sistema_de_control.Properties.Resources.Info_2;
            this.acercaDelToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.acercaDelToolStripMenuItem.Name = "acercaDelToolStripMenuItem";
            this.acercaDelToolStripMenuItem.Size = new System.Drawing.Size(107, 28);
            this.acercaDelToolStripMenuItem.Text = "Acerca del...";
            // 
            // sistemaDeControlToolStripMenuItem
            // 
            this.sistemaDeControlToolStripMenuItem.Image = global::Sistema_de_control.Properties.Resources.Home_Page_1;
            this.sistemaDeControlToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.sistemaDeControlToolStripMenuItem.Name = "sistemaDeControlToolStripMenuItem";
            this.sistemaDeControlToolStripMenuItem.Size = new System.Drawing.Size(180, 30);
            this.sistemaDeControlToolStripMenuItem.Text = "Sistema de control";
            // 
            // desarrolladorToolStripMenuItem
            // 
            this.desarrolladorToolStripMenuItem.Image = global::Sistema_de_control.Properties.Resources.Developer;
            this.desarrolladorToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.desarrolladorToolStripMenuItem.Name = "desarrolladorToolStripMenuItem";
            this.desarrolladorToolStripMenuItem.Size = new System.Drawing.Size(180, 30);
            this.desarrolladorToolStripMenuItem.Text = "Desarrollador";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Image = global::Sistema_de_control.Properties.Resources.Log_Off;
            this.salirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(65, 28);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Sistema_de_control.Properties.Resources.fondo145;
            this.ClientSize = new System.Drawing.Size(807, 444);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de control empresarial";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem comprasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem datosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem articulosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasDelDiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasPorFechasToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem stockDeArticulosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iniciarCajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingresoTotalACajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sistemaDeControlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem desarrolladorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
    }
}

