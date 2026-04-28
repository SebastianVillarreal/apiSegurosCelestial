using System;
using System.Collections.Generic;
using System.Data;
using marcatel_api.Models;
using marcatel_api.DataContext;
using System.Collections;
using System.Data.SqlClient;
using apiSegurosCelestial.Models;
using marcatel_api.Utilities;

namespace apiSegurosCelestial.Services
{
    public class ReportesService
    {
        private  string connection;
        public ReportesService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public List<ReporteAbonosModel> GetReporteAbonos(ReporteAbonosRequest reporteAbonosRequest)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<ReporteAbonosModel>();
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@FechaInicio", SqlDbType = SqlDbType.VarChar, Value = reporteAbonosRequest.FechaInicio });
                parametros.Add(new SqlParameter { ParameterName = "@FechaFin", SqlDbType = SqlDbType.VarChar, Value = reporteAbonosRequest.FechaFin });
                DataSet ds = dac.Fill("GetReporteAbonos", parametros);
                if(ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new ReporteAbonosModel
                        {
                            Folio = int.Parse(dr["Folio"].ToString()),
                            Nombre = dr["Nombre"].ToString(),
                            Monto = decimal.Parse(dr["Monto"].ToString()),
                            FechaAbono = dr["FechaAbono"].ToString(),
                            MetodoPago = dr["MetodoPago"].ToString(),
                            Referencia = dr["Referencia"].ToString()
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
