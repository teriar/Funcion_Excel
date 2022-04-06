using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Spreadsheet;
using DevExpress.XtraEditors;
using DevExpress.Spreadsheet.Export;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;
using System.IO;

using System.Windows.Forms;
using System.Configuration;
using System.Globalization;
using System.Drawing;

using System.Collections;
using System.IO.Compression;
using DevExpress.LookAndFeel;

namespace Funcion_Excel
{
 public    class FileExcel
    {
       public FileExcel()
        {
            //CONSTRUCTOR...
        }

        //ABRIR EXCEL Y LEER SU DATA
        //DEVUELVE UN DATATABLE
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

        //ABRIR EXCEL Y LEER SU DATA
        //DEVUELVE UN DATATABLE
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
                    foreach (DataColumn columna in data.Columns)
                    {
                        columna.DataType = typeof(string);
                        columna.ColumnName = columna.ColumnName.Trim().ToLower();

                        //RUT EMPRESA
                        if (columna.ColumnName == "rut" || columna.ColumnName == "rutemp")
                            columna.ColumnName = "rutempresa";

                        //CÓDIGO DE ACTIVIDAD
                        if (columna.ColumnName == "codactividad")
                            columna.ColumnName = "codigoactividad";

                        //RUT REPRESENTANTE
                        if (columna.ColumnName == "rutrep")
                            columna.ColumnName = "rutrepresentante";

                        //CÓDIGO DE TELÉFONO DE PAÍS
                        if (columna.ColumnName == "codpais" || columna.ColumnName == "cdpais")
                            columna.ColumnName = "codigofonopais";

                        //CÓDIGO DE TELÉFONO DE CIUDAD
                        if (columna.ColumnName == "codciudad" || columna.ColumnName == "cdarea")
                            columna.ColumnName = "codigofonociudad";

                        //NÚMERO DE TELÉFONO
                        if (columna.ColumnName == "telefono")
                            columna.ColumnName = "fono";

                        //EMAIL
                        if (columna.ColumnName == "emailemp")
                            columna.ColumnName = "email";

                        //NOMBRE REPRESENTANTE LEGAL
                        if (columna.ColumnName == "nombrerep")
                            columna.ColumnName = "nombrerepresentante";
                    }

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
    }
}
