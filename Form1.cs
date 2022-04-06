
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Spreadsheet;
using DevExpress.Spreadsheet.Export;
using DevExpress.XtraEditors.Repository;
using Funcion_Excel;
using Funcion_Excel.Properties;



namespace Funcion_Excel
{
    public partial class Form1 : Form
    {
        FileExcel funciones = new FileExcel();
       string server;
       string  pass;
        string user;
        string bd;
        List<string> columnas = new List<string>();
       
         
      
        public Form1()
        { 
          
            InitializeComponent();

        }
        string PathFile = string.Empty;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;

            PathFile = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                  
                    PathFile = openFileDialog.FileName;
                    spreadsheetControl1.LoadDocument(PathFile, DocumentFormat.Xlsx);

                   
                }


            }


        }




        public static DataTable ReadExcelDev(string PathFile)
        {
            DataTable data = new DataTable();

            //CREAMOS LIBRO            
            Workbook Libro = new Workbook();

            //PREGUNTAMOS SI EL ARCHIVO EXISTE
            if (File.Exists(PathFile))
            {
                //CARGAMOS DOCUMENTO
                try
                {
                    string extension = Path.GetExtension(PathFile);

                    if (Path.GetExtension(PathFile).Equals(".xls"))
                        Libro.LoadDocument(PathFile, DocumentFormat.Xls);
                    else if (Path.GetExtension(PathFile).Equals(".xlsx"))
                        Libro.LoadDocument(PathFile, DocumentFormat.Xlsx);

                    //OBTENEMOS LA HOJA DESDE ARCHIVO
                    Worksheet Hoja = Libro.Worksheets[0];

                    //TableCollection tablas = Hoja.Tables;
                    //if (tablas == null || tablas.Count == 0)
                    //  return null;

                    //OBTENEMOS EL RANGO USADO DE LA HOJA
                    //Range rango = Hoja.Tables[0].Range;
                    Range rango = Hoja.GetUsedRange();


                    //LLAMAMOS AL METODO CREATE DATA TABLE
                    //SI EL SEGUNDO PARAMETRO ES TRUE DECIMOS QUE USAREMOS LA PRIMERA FILA COMO LAS COLUMNAS DEL DATATABLE
                    data = Hoja.CreateDataTable(rango, true);

                    foreach (DataColumn columna in data.Columns)
                    {
                        //SI EXISTEN LAS COLUMNAS QUE SE DEBEN INGRESAR

                        if (columna.ColumnName.Trim().ToLower() == "rut")
                            columna.DataType = typeof(string);

                        if (columna.ColumnName.Trim().ToLower() == "periodo")
                            columna.DataType = typeof(string);
                    }

                    DataTableExporter exporter = Hoja.CreateDataTableExporter(rango, data, true);

                    //ExcelConverter converter = new ExcelConverter();
                    //converter.EmptyCellValue = "N/A";
                    //exporter.Options.ConvertEmptyCells = true;
                    //exporter.Options.DefaultCellValueToColumnTypeConverter.SkipErrorValues = true;

                    exporter.CellValueConversionError += Exporter_CellValueConversionError;

                    //exporter.Options.DefaultCellValueToColumnTypeConverter.SkipErrorValues = false;
                    exporter.Export();
                    Libro.Dispose();


                    //QUITAMOS ESPACIOS EN LOS NOMBRES DE LAS COLUMNAS
                    foreach (DataColumn column in data.Columns)
                    {
                        column.ColumnName = QuitarEspacios(column.ColumnName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return null;
                }
            }

            return data;
        }

        public static DataTable ReadExcelEmpresa(string PathFile)
        {
            DataTable data = new DataTable();

            //CREAMOS LIBRO            
            Workbook Libro = new Workbook();

            //PREGUNTAMOS SI EL ARCHIVO EXISTE
            if (File.Exists(PathFile))
            {
                //CARGAMOS DOCUMENTO
                try
                {
                    string extension = Path.GetExtension(PathFile);

                    if (Path.GetExtension(PathFile).Equals(".xls"))
                        Libro.LoadDocument(PathFile, DocumentFormat.Xls);
                    else if (Path.GetExtension(PathFile).Equals(".xlsx"))
                        Libro.LoadDocument(PathFile, DocumentFormat.Xlsx);

                    //OBTENEMOS LA HOJA DESDE ARCHIVO
                    Worksheet Hoja = Libro.Worksheets[0];

                    //OBTENEMOS EL RANGO USADO DE LA HOJA
                    Range rango = Hoja.GetUsedRange();


                    //LLAMAMOS AL METODO CREATE DATA TABLE
                    //SI EL SEGUNDO PARAMETRO ES TRUE DECIMOS QUE USAREMOS LA PRIMERA FILA COMO LAS COLUMNAS DEL DATATABLE
                    data = Hoja.CreateDataTable(rango, true);

                    //QUITAMOS ESPACIOS EN LOS NOMBRES DE LAS COLUMNAS
                    //DAMOS FORMATO CORRECTO SI ES QUE VIENEN CON NOMBRE DE SQLITE O RMEUNERACIONES
                    //foreach (DataColumn columna in data.Columns)
                    //{
                    //    columna.DataType = typeof(string);
                    //    columna.ColumnName = columna.ColumnName.Trim().ToLower();

                    //    //RUT EMPRESA
                    //    if (columna.ColumnName == "rut" || columna.ColumnName == "rutemp")
                    //        columna.ColumnName = "rutempresa";

                    //    //CÓDIGO DE ACTIVIDAD
                    //    if (columna.ColumnName == "codactividad")
                    //        columna.ColumnName = "codigoactividad";

                    //    //RUT REPRESENTANTE
                    //    if (columna.ColumnName == "rutrep")
                    //        columna.ColumnName = "rutrepresentante";

                    //    //CÓDIGO DE TELÉFONO DE PAÍS
                    //    if (columna.ColumnName == "codpais" || columna.ColumnName == "cdpais")
                    //        columna.ColumnName = "codigofonopais";

                    //    //CÓDIGO DE TELÉFONO DE CIUDAD
                    //    if (columna.ColumnName == "codciudad" || columna.ColumnName == "cdarea")
                    //        columna.ColumnName = "codigofonociudad";

                    //    //NÚMERO DE TELÉFONO
                    //    if (columna.ColumnName == "telefono")
                    //        columna.ColumnName = "fono";

                    //    //EMAIL
                    //    if (columna.ColumnName == "emailemp")
                    //        columna.ColumnName = "email";

                    //    //NOMBRE REPRESENTANTE LEGAL
                    //    if (columna.ColumnName == "nombrerep")
                    //        columna.ColumnName = "nombrerepresentante";
                    //}

                    //EXPORTADOR
                    DataTableExporter exporter = Hoja.CreateDataTableExporter(rango, data, true);
                    exporter.CellValueConversionError += Exporter_CellValueConversionError;
                    exporter.Export();
                    Libro.Dispose();

                    //APLICAMOS FORMATO ESPECÍFICO A LAS CELDAS Y REMOVEMOS CARACTERES ESPECIALES
                    foreach (DataRow fila in data.Rows)
                    {
                        foreach (DataColumn columna in data.Columns)
                        {
                            fila[columna] = fila[columna].ToString().ToUpper().Trim();
                            fila[columna] = fila[columna].ToString().Replace("+", "");
                            fila[columna] = fila[columna].ToString().Replace(".", "");
                            fila[columna] = fila[columna].ToString().Replace("-", "");

                            //SE AGREGA UN 0 AL RUT EN CASO DE FALTAR
                            if (columna.ColumnName == "rutempresa" || columna.ColumnName == "rutrepresentante")
                                if (fila[columna] != null)
                                    if (fila[columna].ToString() != "" && fila[columna].ToString().Length == 8)
                                        fila[columna] = "0" + fila[columna].ToString();

                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return null;
                }
            }

            return data;
        }

        private static void Exporter_CellValueConversionError(object sender, CellValueConversionErrorEventArgs e)
        {
            e.Action = DataTableExporterAction.Continue;
        }
        //QUITAR ESPACIOS EN CADENA 
        private static string QuitarEspacios(string cadena)
        {
            string cad = "";

            if (cadena.Length > 0)
            {
                for (int i = 0; i < cadena.Length; i++)
                {
                    if (cadena[i].ToString() != " ")
                        cad = cad + cadena[i];
                }
            }

            return cad;
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            //traemos el excel transformado en datatable
          DataTable excel =  ReadExcelEmpresa(PathFile);
            //desde este punto comenzara a comparar antes de insertar
            //validar si el excel corresponde a la base de datos y tabla objetivo
            List<string> columnasEncontradas = new List<string>();

          for(int i =0; i< excel.Columns.Count; i++)
            {
                string sss = excel.Columns[i].ToString();
                //comparar nombre de tablas con las del excel
                foreach (string nombre in columnas)
                {
                  if(sss == nombre)
                    {
                        columnasEncontradas.Add(nombre);
                    }  
                }

            }

            if (columnasEncontradas.Count == 0)
            {
                MessageBox.Show("No se han econtrado iguales entre el archivo excel y los párametros de la tabla. ");
                return;
            }




        }

        

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            //asignacion de valores globales
            server = txtHost.Text;
            user = txtUser.Text;
            pass = txtPass.Text;
                  

                List<string> data = new List<string>();

                string[] basesSys = { "master", "model", "msdb", "tempdb" };
                DataTable coleccion = new DataTable();
                string sCnn = $@"Server={txtHost.Text};database=master;User Id={user};Password={pass};";
                string bases = "SELECT name FROM sysdatabases";
                try
                {
                    SqlDataAdapter BDs = new SqlDataAdapter(bases, sCnn);
                    BDs.Fill(coleccion);
                    for (int i = 0; i < coleccion.Rows.Count; i++)
                    {
                        string s = coleccion.Rows[i]["name"].ToString();
                        if (Array.IndexOf(basesSys, s) > -1)
                        {

                        }
                        else
                        {
                            data.Add(coleccion.Rows[i]["name"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("La solicitud arrojo el siguiente error :" + ex.Message.ToString());
                return;  

                }
            data = data.OrderBy(o => o).ToList();
            cbxBaseDatos.DataSource = data;
            txtPass.Enabled = false;
            txtHost.Enabled = false;
            txtUser.Enabled = false;
                
            
        }

       

        private void cbxBaseDatos_TextChanged(object sender, EventArgs e)
        {
             bd = cbxBaseDatos.Text;
            cmbxTabla.DataSource = null;
            DataTable tablas = new DataTable();
            List<string> listadoTablas = new List<string>();
            string query = "SELECT CAST(table_name as varchar)  FROM INFORMATION_SCHEMA.TABLES";
            SqlDataAdapter consulta = new SqlDataAdapter(query, generaconexion());
            consulta.Fill(tablas);
            foreach(DataRow tabla in tablas.Rows)
            {
                listadoTablas.Add(tabla[0].ToString());
            }
            cmbxTabla.DataSource = listadoTablas;
          
        }
           
     
        private string generaconexion()
        {
            string conexionTiempoReal = $@"Server={server};database={bd};User Id={user};Password={pass};";
            return conexionTiempoReal;
        }

        private void cmbxTabla_TextChanged(object sender, EventArgs e)
        {
            DataTable columnasdatatable = new DataTable();
            columnas.Clear();
            string queryColumnas = $"SELECT name FROM syscolumns WHERE id=OBJECT_ID('{cmbxTabla.Text}')  ORDER BY colorder";
            SqlDataAdapter consultaColumnas = new SqlDataAdapter(queryColumnas, generaconexion());
            consultaColumnas.Fill(columnasdatatable);
            foreach (DataRow columna in columnasdatatable.Rows)
            {
                columnas.Add(columna[0].ToString());
            }
        }
    }

}
