using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using apiSegurosCelestial.Models;
using marcatel_api.DataContext;
using marcatel_api.Models;

namespace apiSegurosCelestial.Services
{
    public class CertificadosService
    {
        private string connection;

        public CertificadosService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public int InsertCertificado(InsertCertificadoModel certificado)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);

            int idCertificado = 0;
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pFolio", SqlDbType = SqlDbType.Int, Value = certificado.Folio });
                parametros.Add(new SqlParameter { ParameterName = "@pIdVendedor", SqlDbType = SqlDbType.Int, Value = certificado.IdVendedor });
                parametros.Add(new SqlParameter { ParameterName = "@pNombreCliente", SqlDbType = SqlDbType.VarChar, Value = certificado.NombreCliente });
                parametros.Add(new SqlParameter { ParameterName = "@pValorPaquete", SqlDbType = SqlDbType.Decimal, Value = certificado.ValorPaquete });
                parametros.Add(new SqlParameter { ParameterName = "@pPagoInicial", SqlDbType = SqlDbType.Decimal, Value = certificado.PagoInicial });
                parametros.Add(new SqlParameter { ParameterName = "@pMontoMensualidad", SqlDbType = SqlDbType.Decimal, Value = certificado.MontoMensualidad });
                parametros.Add(new SqlParameter { ParameterName = "@pEstatus", SqlDbType = SqlDbType.Int, Value = certificado.Estatus });

                DataSet ds = dac.Fill("Certificados_Insert", parametros);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        idCertificado = int.Parse(dr["id_certificado"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return idCertificado;
        }

        public List<CertificadoModel> GetAllCertificados()
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<CertificadoModel>();
            try
            {
                DataSet ds = dac.Fill("Certificados_GetAll");
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new CertificadoModel
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            Folio = int.Parse(dr["Folio"].ToString()),
                            IdVendedor = int.Parse(dr["IdVendedor"].ToString()),
                            NombreCliente = dr["NombreCliente"].ToString(),
                            ValorPaquete = decimal.Parse(dr["ValorPaquete"].ToString()),
                            PagoInicial = decimal.Parse(dr["PagoInicial"].ToString()),
                            MontoMensualidad = decimal.Parse(dr["MontoMensualidad"].ToString()),
                            FechaRegistro = dr["FechaRegistro"].ToString(),
                            Estatus = int.Parse(dr["Estatus"].ToString()),
                            FechaActualizacion = dr["FechaActualizacion"].ToString()
                        });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return lista;
        }
    }
}