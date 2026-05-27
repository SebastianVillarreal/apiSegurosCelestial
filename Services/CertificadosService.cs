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

        public List<CertificadoModel> GetCertificadoById(int id)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<CertificadoModel>();

            parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = id });

            try
            {
                DataSet ds = dac.Fill("Certificados_GetById", parametros);
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

        public CertificadoAbonoInsertResponse InsertCertificadoAbono(InsertCertificadoAbonoModel abono)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var response = new CertificadoAbonoInsertResponse();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pIdCertificado", SqlDbType = SqlDbType.Int, Value = abono.IdCertificado });
                parametros.Add(new SqlParameter { ParameterName = "@pMonto", SqlDbType = SqlDbType.Decimal, Value = abono.Monto });
                parametros.Add(new SqlParameter { ParameterName = "@pFormaPago", SqlDbType = SqlDbType.Int, Value = abono.FormaPago });
                parametros.Add(new SqlParameter
                {
                    ParameterName = "@pReferencia",
                    SqlDbType = SqlDbType.VarChar,
                    Value = string.IsNullOrWhiteSpace(abono.Referencia) ? DBNull.Value : (object)abono.Referencia
                });
                parametros.Add(new SqlParameter
                {
                    ParameterName = "@pObservaciones",
                    SqlDbType = SqlDbType.VarChar,
                    Value = string.IsNullOrWhiteSpace(abono.Observaciones) ? DBNull.Value : (object)abono.Observaciones
                });
                parametros.Add(new SqlParameter
                {
                    ParameterName = "@pIdUsuario",
                    SqlDbType = SqlDbType.Int,
                    Value = abono.IdUsuario.HasValue ? (object)abono.IdUsuario.Value : DBNull.Value
                });

                DataSet ds = dac.Fill("CertificadosAbonos_Insert", parametros);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        response.Mensaje = dr["mensaje"].ToString();
                        response.IdAbono = int.Parse(dr["id_abono"].ToString());
                        response.IdCertificado = int.Parse(dr["id_certificado"].ToString());
                        response.FolioAbono = int.Parse(dr["folio_abono"].ToString());
                        response.SaldoAnterior = decimal.Parse(dr["saldo_anterior"].ToString());
                        response.MontoAbono = decimal.Parse(dr["monto_abono"].ToString());
                        response.SaldoActual = decimal.Parse(dr["saldo_actual"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }

            return response;
        }

        public List<CertificadoAbonoModel> GetCertificadoAbonosByCertificado(int idCertificado)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<CertificadoAbonoModel>();

            parametros.Add(new SqlParameter { ParameterName = "@pIdCertificado", SqlDbType = SqlDbType.Int, Value = idCertificado });

            try
            {
                DataSet ds = dac.Fill("CertificadosAbonos_GetByCertificado", parametros);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new CertificadoAbonoModel
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            IdCertificado = int.Parse(dr["IdCertificado"].ToString()),
                            FolioAbono = int.Parse(dr["FolioAbono"].ToString()),
                            FechaAbono = dr["FechaAbono"].ToString(),
                            Monto = decimal.Parse(dr["Monto"].ToString()),
                            FormaPago = int.Parse(dr["FormaPago"].ToString()),
                            FormaPagoDescripcion = dr["FormaPagoDescripcion"].ToString(),
                            Referencia = dr["Referencia"].ToString(),
                            Observaciones = dr["Observaciones"].ToString(),
                            IdUsuario = string.IsNullOrWhiteSpace(dr["IdUsuario"].ToString()) ? null : (int?)int.Parse(dr["IdUsuario"].ToString()),
                            Estatus = int.Parse(dr["Estatus"].ToString()),
                            FechaRegistro = dr["FechaRegistro"].ToString(),
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

        public List<CertificadoEstadoCuentaModel> GetEstadoCuentaCertificado(int idCertificado)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<CertificadoEstadoCuentaModel>();

            parametros.Add(new SqlParameter { ParameterName = "@pIdCertificado", SqlDbType = SqlDbType.Int, Value = idCertificado });

            try
            {
                DataSet ds = dac.Fill("Certificados_GetEstadoCuenta", parametros);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new CertificadoEstadoCuentaModel
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            Folio = int.Parse(dr["Folio"].ToString()),
                            NombreCliente = dr["NombreCliente"].ToString(),
                            IdVendedor = int.Parse(dr["IdVendedor"].ToString()),
                            ValorPaquete = decimal.Parse(dr["ValorPaquete"].ToString()),
                            PagoInicial = decimal.Parse(dr["PagoInicial"].ToString()),
                            TotalAbonado = decimal.Parse(dr["TotalAbonado"].ToString()),
                            SaldoPendiente = decimal.Parse(dr["SaldoPendiente"].ToString()),
                            MontoMensualidad = decimal.Parse(dr["MontoMensualidad"].ToString()),
                            Estatus = int.Parse(dr["Estatus"].ToString()),
                            EstatusDescripcion = dr["EstatusDescripcion"].ToString(),
                            FechaRegistro = dr["FechaRegistro"].ToString(),
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