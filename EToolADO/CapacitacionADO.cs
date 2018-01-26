using EToolBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EToolADO
{
    public class CapacitacionADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        public List<CapacitacionBE> ListarCapacitacionO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<CapacitacionBE> lCapacitacionBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ListarCapacitacion_Act", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lCapacitacionBE = new List<CapacitacionBE>();
                int posLegajo = drd.GetOrdinal("Legajo");
                int posIdEtto = drd.GetOrdinal("IdEtto");
                int posFecha = drd.GetOrdinal("Fecha");
                int posNota = drd.GetOrdinal("Nota");
                int posCertificado = drd.GetOrdinal("Certificado");
                int posIdExamen = drd.GetOrdinal("IdExamen");
                int posId = drd.GetOrdinal("Id");
                int posExamen = drd.GetOrdinal("Examen");
                CapacitacionBE obeElementoClaveBE = null;
                while (drd.Read())
                {
                    obeElementoClaveBE = new CapacitacionBE();
                    obeElementoClaveBE.Legajo = drd.GetInt32(posLegajo);
                    obeElementoClaveBE.IdEtto = drd.GetString(posIdEtto);
                    obeElementoClaveBE.Fecha = drd.GetDateTime(posFecha);
                    obeElementoClaveBE.Nota = drd.GetInt32(posNota);
                    obeElementoClaveBE.Certificado = drd.GetBoolean(posCertificado);
                    obeElementoClaveBE.IdExamen = drd.GetInt32(posIdExamen);
                    obeElementoClaveBE.Id = drd.GetInt32(posId);
                    obeElementoClaveBE.Examen = drd.GetString(posExamen);
                    lCapacitacionBE.Add(obeElementoClaveBE);
                }
                drd.Close();
            }
            con.Close();
            return (lCapacitacionBE);
        }

        public CapacitacionBE TraerCapacitacion(int Id)
        {
            CapacitacionBE _CapacitacionBE = new CapacitacionBE();
            DataSet dts = new DataSet();
            SqlDataReader dtr = default(SqlDataReader);
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TraerCapacitacionById";
                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));
                cmd.Parameters["@Id"].Value = Id;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    var _with1 = _CapacitacionBE;
                    _with1.Legajo = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Legajo")));
                    _with1.IdEtto = dtr.GetValue(dtr.GetOrdinal("IdEtto")).ToString();
                    _with1.Fecha = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("Fecha")));
                    _with1.Nota = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Nota")));
                    _with1.Certificado = Convert.ToBoolean(dtr.GetValue(dtr.GetOrdinal("Certificado")));
                    _with1.IdExamen = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("IdExamen")));
                    _with1.Id = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Id")));
                    _with1.Examen = dtr.GetValue(dtr.GetOrdinal("Examen")).ToString();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return _CapacitacionBE;
        }
       
        public int InsertarCapacitacion(CapacitacionBE _CapacitacionBE)
        {
            int IdElementoClave = -1;
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertarCapacitacion";
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter par1;
                par1 = cmd.Parameters.Add("@Legajo", SqlDbType.Int);
                par1.Direction = ParameterDirection.Input;
                par1.Value = _CapacitacionBE.Legajo;
                par1 = cmd.Parameters.Add("@IdEtto", SqlDbType.NVarChar, 30);
                par1.Direction = ParameterDirection.Input;
                par1.Value = _CapacitacionBE.IdEtto;
                par1 = cmd.Parameters.Add("@Fecha", SqlDbType.DateTime);
                par1.Direction = ParameterDirection.Input;
                par1.Value = _CapacitacionBE.Fecha;
                par1 = cmd.Parameters.Add("@Nota", SqlDbType.Int);
                par1.Direction = ParameterDirection.Input;
                par1.Value = _CapacitacionBE.Nota;
                par1 = cmd.Parameters.Add("@Certificado", SqlDbType.Bit);
                par1.Direction = ParameterDirection.Input;
                par1.Value = _CapacitacionBE.Certificado;
                par1 = cmd.Parameters.Add("@IdExamen", SqlDbType.Int);
                par1.Direction = ParameterDirection.Input;
                par1.Value = _CapacitacionBE.IdExamen;
                par1 = cmd.Parameters.Add("@Examen", SqlDbType.VarChar, 500);
                par1.Direction = ParameterDirection.Input;
                par1.Value = _CapacitacionBE.Examen;
                SqlParameter par4 = cmd.Parameters.Add("@@identity", SqlDbType.Int);
                par4.Direction = ParameterDirection.ReturnValue;
                cnx.Open();
                int n = cmd.ExecuteNonQuery();
                if (n > 0) IdElementoClave = (int)par4.Value;
            }
            catch (SqlException x)
            {                
                IdElementoClave = -1;
                throw;
            }
            catch (Exception x)
            {
                IdElementoClave = -1;
                throw;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return (IdElementoClave);
        }
        public bool ActualizarCapacitacion(CapacitacionBE _CapacitacionBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarCapacitacion";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add("@Legajo", SqlDbType.Int);
                par1.Direction = ParameterDirection.Input;
                par1.Value = _CapacitacionBE.Legajo;
                par1 = cmd.Parameters.Add("@IdEtto", SqlDbType.NVarChar, 30);
                par1.Direction = ParameterDirection.Input;
                par1.Value = _CapacitacionBE.IdEtto;
                par1 = cmd.Parameters.Add("@Fecha", SqlDbType.DateTime);
                par1.Direction = ParameterDirection.Input;
                par1.Value = _CapacitacionBE.Fecha;
                par1 = cmd.Parameters.Add("@Nota", SqlDbType.Int);
                par1.Direction = ParameterDirection.Input;
                par1.Value = _CapacitacionBE.Nota;
                par1 = cmd.Parameters.Add("@Certificado", SqlDbType.Bit);
                par1.Direction = ParameterDirection.Input;
                par1.Value = _CapacitacionBE.Certificado;
                par1 = cmd.Parameters.Add("@IdExamen", SqlDbType.Int);
                par1.Direction = ParameterDirection.Input;
                par1.Value = _CapacitacionBE.IdExamen;
                par1 = cmd.Parameters.Add("@Id", SqlDbType.Int);
                par1.Direction = ParameterDirection.Input;
                par1.Value = _CapacitacionBE.Id;
                par1 = cmd.Parameters.Add("@Examen", SqlDbType.VarChar, 500);
                par1.Direction = ParameterDirection.Input;
                par1.Value = _CapacitacionBE.Examen;
                cnx.Open();
                cmd.ExecuteNonQuery();
                _vcod = true;

            }
            catch (SqlException x)
            {
                _vcod = false;
            }
            catch (Exception x)
            {
                _vcod = false;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }

            return _vcod;
        }
        public bool EliminarCapacitacion(int Id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_EliminarCapacitacion";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Id"].Value = Id;
                cnx.Open();
                cmd.ExecuteNonQuery();
                _vcod = true;

            }
            catch (SqlException x)
            {
                _vcod = false;
            }
            catch (Exception x)
            {
                _vcod = false;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }

            return _vcod;
        }
        public DataTable ListarCapacitacionFind(string Nombres, string IdEtto, DateTime FechaIni, DateTime FechaFin)
        {
            DataSet dts = new DataSet();
            SqlParameter par1;
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarCapacitacionesFind";
                par1 = cmd.Parameters.Add(new SqlParameter("@Nombres", SqlDbType.VarChar,100));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Nombres"].Value = Nombres;
                par1 = cmd.Parameters.Add(new SqlParameter("@IdEtto", SqlDbType.VarChar, 10));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@IdEtto"].Value = IdEtto;
                par1 = cmd.Parameters.Add(new SqlParameter("@FechaIni", SqlDbType.DateTime));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@FechaIni"].Value = FechaIni;
                par1 = cmd.Parameters.Add(new SqlParameter("@FechaFin", SqlDbType.DateTime));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@FechaFin"].Value = FechaFin;
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Sistemas");
                dtv = dts.Tables["Sistemas"].DefaultView;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return dts.Tables["Sistemas"];
        }
    }
}
