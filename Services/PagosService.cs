using System;
using System.Collections.Generic;
using System.Data;
using marcatel_api.Models;
using marcatel_api.DataContext;
using System.Collections;
using System.Data.SqlClient;
using apiSegurosCelestial.Models;


namespace apiSegurosCelestial.Services
{
    public class PagosService
    {
        private  string connection;
        public PagosService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public string InsertarAbonoPoliza(InsertPagoModel abono)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            int folio = 0;
            string mensaje = "";
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@IdPoliza", SqlDbType = SqlDbType.VarChar, Value = abono.IdPoliza });
                parametros.Add(new SqlParameter { ParameterName = "@Monto", SqlDbType = SqlDbType.VarChar, Value = abono.Monto });
                parametros.Add(new SqlParameter { ParameterName = "@MetodoPago", SqlDbType = SqlDbType.VarChar, Value = abono.MetodoPago  });
                parametros.Add(new SqlParameter { ParameterName = "@Referencia", SqlDbType = SqlDbType.VarChar, Value = abono.Referencia  });
                parametros.Add(new SqlParameter { ParameterName = "@UsuarioRegistro", SqlDbType = SqlDbType.VarChar, Value = abono.IdUsuario });

                DataSet ds = dac.Fill("InsertarAbonoPoliza", parametros);
                if (ds.Tables.Count > 0)
                {
                    
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        mensaje = dr["mensaje"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                
            }
            return mensaje;

        }

        public List<GetAbonosModel>GetPolizas(int id_poliza)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetAbonosModel>();
            parametros.Add(new SqlParameter { ParameterName = "@IdPoliza", SqlDbType = SqlDbType.VarChar, Value = id_poliza });
            try
            {
                DataSet ds = dac.Fill("ConsultarAbonosPoliza", parametros);
                if(ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetAbonosModel
                        {
                            IdAbono = int.Parse(dr["IdAbono"].ToString()),
                            MetodoPago = dr["MetodoPago"].ToString(),
                            Referencia = dr["Referencia"].ToString(),
                            Fecha = dr["FechaAbono"].ToString(),
                            Monto = decimal.Parse(dr["Monto"].ToString()),
                            IdPoliza = int.Parse(dr["IdPoliza"].ToString())


                        });
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return lista;
        }

    }
}
