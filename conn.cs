using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Funcion_Excel
{
    public class conn
    {


        public string serverCN { get; set; }
        public string DataBase { get; set; }

        public string userCN { get; set; }

        public string contraseniaCN { get; set; }
        public string DataBaseOBJ { get; set; }
        public int insertados = 0;
        public static bool tipo = false;



        public static List<string> Conectar(string server, string user = "root", string contrasenia = "")
        {

            List<string> data = new List<string>();

            string[] basesSys = { "master", "model", "msdb", "tempdb" };
            DataTable coleccion = new DataTable();
            string sCnn = $@"Server={server};database=master;User Id={user};Password={contrasenia};";
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
                MessageBox.Show(ex.Message.ToString());
                return data;

            }
            return data;
        }
    }
}
