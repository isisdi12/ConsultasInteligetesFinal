using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Data;
using System.Windows.Forms;

namespace CapaDatos
{
    public class sentencias
    {
        int eliminado = 0;
        int disponible = 1;
        public OdbcDataAdapter consultarQuery(string iIdQuery)
        {

            conexion cn = new conexion();
            cn.Conectar();
            string sConsulta = "SELECT * FROM consulta WHERE NombreConsulta = '" + iIdQuery + "' AND disponible = 1";
            OdbcDataAdapter data = new OdbcDataAdapter(sConsulta, cn.Conectar());
            return data;
        }

        public OdbcDataAdapter consultarQuery1()
        {

            conexion cn = new conexion();
            cn.Conectar();
            string sConsulta = "SELECT * FROM consulta WHERE disponible = 1";
            OdbcDataAdapter data = new OdbcDataAdapter(sConsulta, cn.Conectar());
            return data;
        }

        public OdbcDataAdapter ConsultarTablas()
        {
            conexion con = new conexion();
            con.Conectar();
            string sTablas = "SHOW TABLES ";
            OdbcDataAdapter dat = new OdbcDataAdapter(sTablas, con.Conectar());
            return dat;
        }

        public OdbcDataAdapter ConsultarCampos(string tabla)
        {
            conexion cnc = new conexion();
            cnc.Conectar();
            string sCampos = "DESCRIBE " + tabla;
            OdbcDataAdapter dt = new OdbcDataAdapter(sCampos, cnc.Conectar());
            return dt;
        }

        public OdbcDataAdapter Insertarentxt(string iIdQuery)
        {
            conexion cncc = new conexion();
            cncc.Conectar();
            string srelleno = "SELECT Cadena  FROM consulta WHERE NombreConsulta  = '" + iIdQuery+ "' AND disponible = 1";
            OdbcDataAdapter data = new OdbcDataAdapter(srelleno, cncc.Conectar());
            return data;
        }

        public OdbcDataAdapter Insertarentxt1(string iIdQuery)
        {
            conexion cnccc = new conexion();
            cnccc.Conectar();
            string srelleno1 = "SELECT NombreConsulta  FROM consulta WHERE NombreConsulta = '" + iIdQuery+ "' AND disponible = 1";
            OdbcDataAdapter data = new OdbcDataAdapter(srelleno1, cnccc.Conectar());
            return data;
        }

       

        public OdbcCommand InsertarSentencia(string query, string nombre, string usuario)
        {
            conexion conexion = new conexion();
            OdbcCommand command = new OdbcCommand();
            command.CommandText = "SELECT COUNT(*)+1 AS id FROM consulta";
            command.Connection = conexion.Conectar();

            OdbcDataAdapter mySqlDataAdapter = new OdbcDataAdapter(command);
            DataTable dataTable = new DataTable();
            mySqlDataAdapter.Fill(dataTable);

            int iConteo = 0;

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                iConteo = Convert.ToInt32(row["id"]);
            }

            command.CommandText = "INSERT INTO consulta " +
             "VALUES (" + iConteo +
             ",'" + query + "','" + nombre + "','" + usuario + "','"+disponible+"')";

            return command;
        }

        public OdbcCommand EditarSentencia(string query, string nombre, string usuario)
        {
            conexion conexion = new conexion();
            OdbcCommand command = new OdbcCommand();

            //ACTUALIZA
            
            command.Connection = conexion.Conectar();
            command.CommandText = "UPDATE consulta SET Cadena='" + query + "', NombreConsulta='" + nombre + "', Usuario='" + usuario + "' WHERE NombreConsulta='" + nombre + "'";
            OdbcDataAdapter mySqlDataAdapter = new OdbcDataAdapter(command);
            DataTable dataTable = new DataTable();
            mySqlDataAdapter.Fill(dataTable);
            return command;
        }

        public OdbcCommand EliminarSentencia(string nombreconsulta)
        {
            conexion conexion = new conexion();
            OdbcCommand command = new OdbcCommand();

            //ACTUALIZA DISPONIBILIDAD 
            
            command.Connection = conexion.Conectar();
            command.CommandText = "UPDATE consulta SET disponible='"+eliminado+"' WHERE NombreConsulta='" + nombreconsulta + "'";
            OdbcDataAdapter mySqlDataAdapter = new OdbcDataAdapter(command);
            DataTable dataTable = new DataTable();
            mySqlDataAdapter.Fill(dataTable);

            MessageBox.Show("eliminado");
            return command;
        }


        public OdbcDataAdapter ObtenerConsultas()
        {
            conexion conexion = new conexion();
            OdbcCommand command = new OdbcCommand();
            command.CommandText = "SELECT idConsulta,Cadena,NombreConsulta FROM consulta WHERE disponible = 1";
            command.Connection = conexion.Conectar();

            OdbcDataAdapter odbcDataAdapter = new OdbcDataAdapter(command);

            return odbcDataAdapter;
        }



        public OdbcDataAdapter EjecutarCadena(string cadena)
        {
            conexion conexion = new conexion();
            OdbcCommand command = new OdbcCommand();

            command.CommandText = cadena;
            command.Connection = conexion.Conectar();
            command.CommandType = CommandType.Text;
            MessageBox.Show("HOLA7");
            OdbcDataAdapter odbcDataAdapter = new OdbcDataAdapter(command);

            return odbcDataAdapter;
        }

    }
}
