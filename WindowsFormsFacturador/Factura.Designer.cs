namespace WindowsFormsFacturador
{
    partial class Factura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Factura));
            this.lblNumeroFactura = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.txtNumeroFactura = new System.Windows.Forms.TextBox();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.txtValorTotal = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mNuevo = new System.Windows.Forms.ToolStripMenuItem();
            this.mGuardar = new System.Windows.Forms.ToolStripMenuItem();
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.btnAdicionarProducto = new System.Windows.Forms.Button();
            this.dgvListarProductos = new System.Windows.Forms.DataGridView();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNumeroFactura
            // 
            this.lblNumeroFactura.AutoSize = true;
            this.lblNumeroFactura.Location = new System.Drawing.Point(38, 42);
            this.lblNumeroFactura.Name = "lblNumeroFactura";
            this.lblNumeroFactura.Size = new System.Drawing.Size(83, 13);
            this.lblNumeroFactura.TabIndex = 0;
            this.lblNumeroFactura.Text = "Número Factura";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(38, 84);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 1;
            this.lblCliente.Text = "Cliente";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(38, 126);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(40, 13);
            this.lblEstado.TabIndex = 2;
            this.lblEstado.Text = "Estado";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(411, 42);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(43, 13);
            this.lblUsuario.TabIndex = 3;
            this.lblUsuario.Text = "Usuario";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(411, 84);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(37, 13);
            this.lblFecha.TabIndex = 4;
            this.lblFecha.Text = "Fecha";
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.Location = new System.Drawing.Point(411, 126);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(55, 13);
            this.lblValorTotal.TabIndex = 5;
            this.lblValorTotal.Text = "ValorTotal";
            // 
            // txtNumeroFactura
            // 
            this.txtNumeroFactura.Enabled = false;
            this.txtNumeroFactura.Location = new System.Drawing.Point(146, 38);
            this.txtNumeroFactura.Name = "txtNumeroFactura";
            this.txtNumeroFactura.Size = new System.Drawing.Size(121, 20);
            this.txtNumeroFactura.TabIndex = 6;
            // 
            // txtEstado
            // 
            this.txtEstado.Enabled = false;
            this.txtEstado.Location = new System.Drawing.Point(146, 122);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(121, 20);
            this.txtEstado.TabIndex = 8;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Location = new System.Drawing.Point(483, 38);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtUsuario.TabIndex = 9;
            // 
            // txtFecha
            // 
            this.txtFecha.Enabled = false;
            this.txtFecha.Location = new System.Drawing.Point(483, 80);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(100, 20);
            this.txtFecha.TabIndex = 10;
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.Enabled = false;
            this.txtValorTotal.Location = new System.Drawing.Point(483, 122);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.Size = new System.Drawing.Size(100, 20);
            this.txtValorTotal.TabIndex = 11;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mNuevo,
            this.mGuardar});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(692, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mNuevo
            // 
            this.mNuevo.Name = "mNuevo";
            this.mNuevo.Size = new System.Drawing.Size(54, 20);
            this.mNuevo.Text = "Nuevo";
            this.mNuevo.Click += new System.EventHandler(this.mNuevo_Click);
            // 
            // mGuardar
            // 
            this.mGuardar.Name = "mGuardar";
            this.mGuardar.Size = new System.Drawing.Size(61, 20);
            this.mGuardar.Text = "Guardar";
            this.mGuardar.Click += new System.EventHandler(this.mGuardar_Click);
            // 
            // cbCliente
            // 
            this.cbCliente.Enabled = false;
            this.cbCliente.FormattingEnabled = true;
            this.cbCliente.Location = new System.Drawing.Point(146, 80);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(121, 21);
            this.cbCliente.TabIndex = 14;
            // 
            // btnAdicionarProducto
            // 
            this.btnAdicionarProducto.Enabled = false;
            this.btnAdicionarProducto.Location = new System.Drawing.Point(41, 165);
            this.btnAdicionarProducto.Name = "btnAdicionarProducto";
            this.btnAdicionarProducto.Size = new System.Drawing.Size(124, 23);
            this.btnAdicionarProducto.TabIndex = 15;
            this.btnAdicionarProducto.Text = "Adicionar Producto";
            this.btnAdicionarProducto.UseVisualStyleBackColor = true;
            this.btnAdicionarProducto.Click += new System.EventHandler(this.btnAdicionarProducto_Click);
            // 
            // dgvListarProductos
            // 
            this.dgvListarProductos.AllowUserToAddRows = false;
            this.dgvListarProductos.AllowUserToDeleteRows = false;
            this.dgvListarProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListarProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Producto,
            this.Cantidad,
            this.Valor});
            this.dgvListarProductos.Enabled = false;
            this.dgvListarProductos.Location = new System.Drawing.Point(41, 211);
            this.dgvListarProductos.Name = "dgvListarProductos";
            this.dgvListarProductos.ReadOnly = true;
            this.dgvListarProductos.Size = new System.Drawing.Size(514, 150);
            this.dgvListarProductos.TabIndex = 16;
            // 
            // Producto
            // 
            this.Producto.DataPropertyName = "NombreProducto";
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "Valor";
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            // 
            // Factura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 450);
            this.Controls.Add(this.dgvListarProductos);
            this.Controls.Add(this.btnAdicionarProducto);
            this.Controls.Add(this.cbCliente);
            this.Controls.Add(this.txtValorTotal);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.txtNumeroFactura);
            this.Controls.Add(this.lblValorTotal);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblNumeroFactura);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Factura";
            this.Text = "Factura";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumeroFactura;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.TextBox txtNumeroFactura;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.TextBox txtValorTotal;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mNuevo;
        private System.Windows.Forms.ToolStripMenuItem mGuardar;
        private System.Windows.Forms.ComboBox cbCliente;
        private System.Windows.Forms.Button btnAdicionarProducto;
        private System.Windows.Forms.DataGridView dgvListarProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
    }
}