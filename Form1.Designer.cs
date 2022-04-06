
namespace Funcion_Excel
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lbBaseDatos = new DevExpress.XtraEditors.LabelControl();
            this.lbTabla = new DevExpress.XtraEditors.LabelControl();
            this.cbxBaseDatos = new System.Windows.Forms.ComboBox();
            this.cmbxTabla = new System.Windows.Forms.ComboBox();
            this.btnEjecutar = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.excelDataSource1 = new DevExpress.DataAccess.Excel.ExcelDataSource();
            this.spreadsheetControl1 = new DevExpress.XtraSpreadsheet.SpreadsheetControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtHost = new DevExpress.XtraEditors.TextEdit();
            this.btnConectar = new DevExpress.XtraEditors.SimpleButton();
            this.lbUser = new DevExpress.XtraEditors.LabelControl();
            this.lbPas = new DevExpress.XtraEditors.LabelControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtUser = new DevExpress.XtraEditors.TextEdit();
            this.txtPass = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHost.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbBaseDatos
            // 
            this.lbBaseDatos.Location = new System.Drawing.Point(25, 21);
            this.lbBaseDatos.Name = "lbBaseDatos";
            this.lbBaseDatos.Size = new System.Drawing.Size(68, 13);
            this.lbBaseDatos.TabIndex = 1;
            this.lbBaseDatos.Text = "Base de datos";
            // 
            // lbTabla
            // 
            this.lbTabla.Location = new System.Drawing.Point(25, 55);
            this.lbTabla.Name = "lbTabla";
            this.lbTabla.Size = new System.Drawing.Size(26, 13);
            this.lbTabla.TabIndex = 2;
            this.lbTabla.Text = "Tabla";
            // 
            // cbxBaseDatos
            // 
            this.cbxBaseDatos.FormattingEnabled = true;
            this.cbxBaseDatos.Location = new System.Drawing.Point(109, 18);
            this.cbxBaseDatos.Name = "cbxBaseDatos";
            this.cbxBaseDatos.Size = new System.Drawing.Size(121, 21);
            this.cbxBaseDatos.TabIndex = 3;
            this.cbxBaseDatos.TextChanged += new System.EventHandler(this.cbxBaseDatos_TextChanged);
            // 
            // cmbxTabla
            // 
            this.cmbxTabla.FormattingEnabled = true;
            this.cmbxTabla.Location = new System.Drawing.Point(109, 52);
            this.cmbxTabla.Name = "cmbxTabla";
            this.cmbxTabla.Size = new System.Drawing.Size(121, 21);
            this.cmbxTabla.TabIndex = 4;
            this.cmbxTabla.TextChanged += new System.EventHandler(this.cmbxTabla_TextChanged);
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnEjecutar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEjecutar.ImageOptions.Image")));
            this.btnEjecutar.Location = new System.Drawing.Point(25, 93);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(41, 39);
            this.btnEjecutar.TabIndex = 5;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(81, 89);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(42, 47);
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // excelDataSource1
            // 
            this.excelDataSource1.Name = "excelDataSource1";
            // 
            // spreadsheetControl1
            // 
            this.spreadsheetControl1.Location = new System.Drawing.Point(34, 249);
            this.spreadsheetControl1.Name = "spreadsheetControl1";
            this.spreadsheetControl1.Options.Import.Csv.Encoding = ((System.Text.Encoding)(resources.GetObject("spreadsheetControl1.Options.Import.Csv.Encoding")));
            this.spreadsheetControl1.Options.Import.Txt.Encoding = ((System.Text.Encoding)(resources.GetObject("spreadsheetControl1.Options.Import.Txt.Encoding")));
            this.spreadsheetControl1.Size = new System.Drawing.Size(719, 200);
            this.spreadsheetControl1.TabIndex = 9;
            this.spreadsheetControl1.Text = "spreadsheetControl1";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(340, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(22, 13);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "Host";
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(384, 19);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(205, 20);
            this.txtHost.TabIndex = 11;
            // 
            // btnConectar
            // 
            this.btnConectar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnConectar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnConectar.ImageOptions.Image")));
            this.btnConectar.Location = new System.Drawing.Point(606, 2);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(36, 52);
            this.btnConectar.TabIndex = 12;
            this.btnConectar.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // lbUser
            // 
            this.lbUser.Location = new System.Drawing.Point(336, 55);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(26, 13);
            this.lbUser.TabIndex = 13;
            this.lbUser.Text = "User:";
            // 
            // lbPas
            // 
            this.lbPas.Location = new System.Drawing.Point(471, 55);
            this.lbPas.Name = "lbPas";
            this.lbPas.Size = new System.Drawing.Size(26, 13);
            this.lbPas.TabIndex = 14;
            this.lbPas.Text = "Pass:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(384, 52);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(81, 20);
            this.txtUser.TabIndex = 16;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(503, 52);
            this.txtPass.Name = "txtPass";
            this.txtPass.Properties.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(67, 20);
            this.txtPass.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lbPas);
            this.Controls.Add(this.lbUser);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.spreadsheetControl1);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btnEjecutar);
            this.Controls.Add(this.cmbxTabla);
            this.Controls.Add(this.cbxBaseDatos);
            this.Controls.Add(this.lbTabla);
            this.Controls.Add(this.lbBaseDatos);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.txtHost.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl lbBaseDatos;
        private DevExpress.XtraEditors.LabelControl lbTabla;
        private System.Windows.Forms.ComboBox cbxBaseDatos;
        private System.Windows.Forms.ComboBox cmbxTabla;
        private DevExpress.XtraEditors.SimpleButton btnEjecutar;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.DataAccess.Excel.ExcelDataSource excelDataSource1;
        private DevExpress.XtraSpreadsheet.SpreadsheetControl spreadsheetControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtHost;
        private DevExpress.XtraEditors.SimpleButton btnConectar;
        private DevExpress.XtraEditors.LabelControl lbUser;
        private DevExpress.XtraEditors.LabelControl lbPas;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private DevExpress.XtraEditors.TextEdit txtUser;
        private DevExpress.XtraEditors.TextEdit txtPass;
    }
}

