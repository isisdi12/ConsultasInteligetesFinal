using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data.Odbc;
using System.Windows.Forms;
using System.Data;

namespace CapaLogica
{

    
    public class logica
    {
        public DataTable consultaId(string nombreconsulta)
        {
            sentencias sn = new sentencias();
            OdbcDataAdapter datos = sn.consultarQuery(nombreconsulta);
            DataTable dtDatos = new DataTable();
            datos.Fill(dtDatos);
            return dtDatos;
        }

        public DataTable consultaId1()
        {
            sentencias sn = new sentencias();
            OdbcDataAdapter datos = sn.consultarQuery1();
            DataTable dtDatos = new DataTable();
            datos.Fill(dtDatos);
            return dtDatos;
        }

        public void tablas(ComboBox cmb)
        {
            sentencias sen = new sentencias();
            OdbcDataAdapter tablas = sen.ConsultarTablas();
            DataTable datTablas = new DataTable();
            tablas.Fill(datTablas);

            if (datTablas.Rows.Count > 0)
            {
                for (int i = 0; i < datTablas.Rows.Count; i++)
                {
                    DataRow row = datTablas.Rows[i];
                    string tab = row["Tables_in_market"].ToString();
                    cmb.Items.Add(tab);

                }
            }
            
        }

        public void campos(ComboBox box, string tabla)
        {
            sentencias sc = new sentencias();
            OdbcDataAdapter dCampos = sc.ConsultarCampos(tabla);
            DataTable datCampos = new DataTable();
            dCampos.Fill(datCampos);

            if (datCampos.Rows.Count > 0)
            {
                for(int i = 0; i < datCampos.Rows.Count; i++)
                {
                    DataRow rows = datCampos.Rows[i];
                    string cam = rows["Field"].ToString();
                    box.Items.Add(cam);
                }
            }

        }

        public void txt(TextBox box, string tabla)
        {
            sentencias sc = new sentencias();
            OdbcDataAdapter dtextos = sc.Insertarentxt1(tabla);
            DataTable datextos = new DataTable();
            dtextos.Fill(datextos);

            if (datextos.Rows.Count > 0)
            {
                for (int i = 0; i < datextos.Rows.Count; i++)
                {
                    DataRow rows = datextos.Rows[i];
                    string cam = rows["NombreConsulta"].ToString();
                    box.Text = cam;
                }
            }

        }

        public void txt1(TextBox box, string tabla1)
        {
            sentencias sc = new sentencias();
            OdbcDataAdapter dtextos = sc.Insertarentxt(tabla1);
            DataTable datextos = new DataTable();
            dtextos.Fill(datextos);

            if (datextos.Rows.Count > 0)
            {
                for (int i = 0; i < datextos.Rows.Count; i++)
                {
                    DataRow rows = datextos.Rows[i];
                    string cam = rows["Cadena"].ToString();
                    box.Text = cam;
                }
            }
            
        }

        public void InsertarCampos(string query, string nombre, string usuario)
        {
            sentencias sc = new sentencias();
            OdbcCommand command = sc.InsertarSentencia(query, nombre, usuario);
            command.ExecuteNonQuery();
        }

        public void EditarCampos(string query, string nombre, string usuario)
        {
            sentencias sc = new sentencias();
            OdbcCommand command = sc.EditarSentencia(query, nombre, usuario);
            command.ExecuteNonQuery();
        }

        public void EliminarCampos(string nombreconsulta)
        {
            sentencias sc = new sentencias();
            OdbcCommand command = sc.EliminarSentencia(nombreconsulta);
            command.ExecuteNonQuery();
        }


        public void CargarConsultas(ComboBox comboBox, List<int> lista, List<string> consultas)
        {
            sentencias sc = new sentencias();
            OdbcDataAdapter odbcDataAdapter = sc.ObtenerConsultas();

            DataTable dataTable = new DataTable();
            odbcDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow row = dataTable.Rows[i];
                    lista.Add(Convert.ToInt32(row["idConsulta"]));
                    consultas.Add(row["Cadena"].ToString());
                    comboBox.Items.Add(row["NombreConsulta"].ToString());
                }
            }
            
        }

        public void EjecutarConsultas(DataGridView tabla, string cadena)
        {
            try
            {
                sentencias sc = new sentencias();
                OdbcDataAdapter odbcDataAdapter = sc.EjecutarCadena(cadena);
                DataTable dataTable = new DataTable();
                odbcDataAdapter.Fill(dataTable);
                tabla.DataSource = dataTable;
            }
            catch
            {
                MessageBox.Show("Sentencia NO Valida", "Consultas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
