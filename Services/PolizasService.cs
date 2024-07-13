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
    public class PolizasService
    {
        private  string connection;
        public PolizasService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }


        public List<InvAreaModel>GetAreasInv()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<InvAreaModel>();
            try
            {
                DataSet ds = dac.Fill("sp_get_areas", parametros);
                if(ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new InvAreaModel
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            Nombre = dr["Nombre"].ToString(),

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

        public int InsertPoliza(InsertPolizaModel poliza, int usuario)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            int folio = 0;
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@Consecutivo", SqlDbType = SqlDbType.VarChar, Value = poliza.Consecutivo });
                parametros.Add(new SqlParameter { ParameterName = "@Nombre", SqlDbType = SqlDbType.VarChar, Value = poliza.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@Direccion", SqlDbType = SqlDbType.VarChar, Value = poliza.DireccionParticular  });
                parametros.Add(new SqlParameter { ParameterName = "@Telefono", SqlDbType = SqlDbType.VarChar, Value = poliza.Telefono  });
                parametros.Add(new SqlParameter { ParameterName = "@Colonia", SqlDbType = SqlDbType.VarChar, Value = poliza.Colonia });
                parametros.Add(new SqlParameter { ParameterName = "@Poblacion", SqlDbType = SqlDbType.VarChar, Value = poliza.Poblacion  });
                parametros.Add(new SqlParameter { ParameterName = "@DomicilioCobro", SqlDbType = SqlDbType.VarChar, Value = poliza.DomicilioCobro });
                parametros.Add(new SqlParameter { ParameterName = "@Empresa", SqlDbType = SqlDbType.VarChar, Value = poliza.Empresa });
                parametros.Add(new SqlParameter { ParameterName = "@TelefonoEmpresa", SqlDbType = SqlDbType.VarChar, Value = poliza.TelEmpresa });
                parametros.Add(new SqlParameter { ParameterName = "@CalleEmpresa", SqlDbType = SqlDbType.VarChar, Value = poliza.CalleEmpresa  });
                parametros.Add(new SqlParameter { ParameterName = "@Vendedor", SqlDbType = SqlDbType.VarChar, Value = poliza.Vendedor });
                parametros.Add(new SqlParameter { ParameterName = "@Promotor", SqlDbType = SqlDbType.VarChar, Value = poliza.Promotor });
                parametros.Add(new SqlParameter { ParameterName = "@Usuario", SqlDbType = SqlDbType.VarChar, Value = usuario });
                DataSet ds = dac.Fill("InsertPoliza", parametros);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        folio = int.Parse(dr["Id"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                
            }
            return folio;

        }
    }
}
