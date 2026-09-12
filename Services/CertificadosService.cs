using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using apiSegurosCelestial.Models;
using iText.Forms;
using iText.Forms.Fields;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Properties;
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
                parametros.Add(new SqlParameter { ParameterName = "@pTipo", SqlDbType = SqlDbType.Int, Value = certificado.TipoCertificado });
                parametros.Add(new SqlParameter { ParameterName = "@pDireccionCliente", SqlDbType = SqlDbType.VarChar, Value = certificado.DireccionCliente });
                parametros.Add(new SqlParameter { ParameterName = "@pTelefonoCliente", SqlDbType = SqlDbType.VarChar, Value = certificado.TelefonoCliente });

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

        public int InsertServicioFunerario(InsertServicioFunerarioModel servicio)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            int idServicio = 0;

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pResponsableNombre", SqlDbType = SqlDbType.NVarChar, Value = (object)servicio.ResponsableNombre ?? DBNull.Value });
                parametros.Add(new SqlParameter { ParameterName = "@pResponsableParentesco", SqlDbType = SqlDbType.NVarChar, Value = (object)servicio.ResponsableParentesco ?? DBNull.Value });
                parametros.Add(new SqlParameter { ParameterName = "@pResponsableTelefono", SqlDbType = SqlDbType.VarChar, Value = (object)servicio.ResponsableTelefono ?? DBNull.Value });
                parametros.Add(new SqlParameter { ParameterName = "@pResponsableCorreo", SqlDbType = SqlDbType.VarChar, Value = (object)servicio.ResponsableCorreo ?? DBNull.Value });
                parametros.Add(new SqlParameter { ParameterName = "@pResponsableDomicilio", SqlDbType = SqlDbType.NVarChar, Value = (object)servicio.ResponsableDomicilio ?? DBNull.Value });
                parametros.Add(new SqlParameter { ParameterName = "@pResponsableColonia", SqlDbType = SqlDbType.NVarChar, Value = (object)servicio.ResponsableColonia ?? DBNull.Value });
                parametros.Add(new SqlParameter { ParameterName = "@pResponsableCiudad", SqlDbType = SqlDbType.NVarChar, Value = (object)servicio.ResponsableCiudad ?? DBNull.Value });
                parametros.Add(new SqlParameter { ParameterName = "@pResponsableCP", SqlDbType = SqlDbType.VarChar, Value = (object)servicio.ResponsableCP ?? DBNull.Value });
                parametros.Add(new SqlParameter { ParameterName = "@pResponsableTipoIdentificacion", SqlDbType = SqlDbType.VarChar, Value = (object)servicio.ResponsableTipoIdentificacion ?? DBNull.Value });
                parametros.Add(new SqlParameter { ParameterName = "@pResponsableOtraIdentificacion", SqlDbType = SqlDbType.NVarChar, Value = (object)servicio.ResponsableOtraIdentificacion ?? DBNull.Value });
                parametros.Add(new SqlParameter { ParameterName = "@pResponsableNumeroIdentificacion", SqlDbType = SqlDbType.VarChar, Value = (object)servicio.ResponsableNumeroIdentificacion ?? DBNull.Value });

                parametros.Add(new SqlParameter { ParameterName = "@pFallecidoNombre", SqlDbType = SqlDbType.NVarChar, Value = (object)servicio.FallecidoNombre ?? DBNull.Value });
                parametros.Add(new SqlParameter { ParameterName = "@pFallecidoEdad", SqlDbType = SqlDbType.Int, Value = servicio.FallecidoEdad.HasValue ? (object)servicio.FallecidoEdad.Value : DBNull.Value });
                parametros.Add(new SqlParameter { ParameterName = "@pFallecidoFechaNacimiento", SqlDbType = SqlDbType.Date, Value = servicio.FallecidoFechaNacimiento.HasValue ? (object)servicio.FallecidoFechaNacimiento.Value : DBNull.Value });
                parametros.Add(new SqlParameter { ParameterName = "@pFallecidoFechaDefuncion", SqlDbType = SqlDbType.Date, Value = servicio.FallecidoFechaDefuncion.HasValue ? (object)servicio.FallecidoFechaDefuncion.Value : DBNull.Value });
                parametros.Add(new SqlParameter { ParameterName = "@pFallecidoLugarTipo", SqlDbType = SqlDbType.VarChar, Value = (object)servicio.FallecidoLugarTipo ?? DBNull.Value });
                parametros.Add(new SqlParameter { ParameterName = "@pFallecidoLugarOtro", SqlDbType = SqlDbType.NVarChar, Value = (object)servicio.FallecidoLugarOtro ?? DBNull.Value });
                parametros.Add(new SqlParameter { ParameterName = "@pFallecidoHospitalLugar", SqlDbType = SqlDbType.NVarChar, Value = (object)servicio.FallecidoHospitalLugar ?? DBNull.Value });
                parametros.Add(new SqlParameter { ParameterName = "@pFallecidoCiudad", SqlDbType = SqlDbType.NVarChar, Value = (object)servicio.FallecidoCiudad ?? DBNull.Value });

                parametros.Add(new SqlParameter { ParameterName = "@pTrasladoLocal", SqlDbType = SqlDbType.Bit, Value = servicio.TrasladoLocal });
                parametros.Add(new SqlParameter { ParameterName = "@pTrasladoForaneo", SqlDbType = SqlDbType.Bit, Value = servicio.TrasladoForaneo });
                parametros.Add(new SqlParameter { ParameterName = "@pPreparacionEstetica", SqlDbType = SqlDbType.Bit, Value = servicio.PreparacionEstetica });
                parametros.Add(new SqlParameter { ParameterName = "@pEmbalsamado", SqlDbType = SqlDbType.Bit, Value = servicio.Embalsamado });
                parametros.Add(new SqlParameter { ParameterName = "@pAtaud", SqlDbType = SqlDbType.Bit, Value = servicio.Ataud });
                parametros.Add(new SqlParameter { ParameterName = "@pSalaVelacion", SqlDbType = SqlDbType.Bit, Value = servicio.SalaVelacion });
                parametros.Add(new SqlParameter { ParameterName = "@pCremacion", SqlDbType = SqlDbType.Bit, Value = servicio.Cremacion });
                parametros.Add(new SqlParameter { ParameterName = "@pInhumacion", SqlDbType = SqlDbType.Bit, Value = servicio.Inhumacion });
                parametros.Add(new SqlParameter { ParameterName = "@pCarroza", SqlDbType = SqlDbType.Bit, Value = servicio.Carroza });
                parametros.Add(new SqlParameter { ParameterName = "@pGestionTramites", SqlDbType = SqlDbType.Bit, Value = servicio.GestionTramites });
                parametros.Add(new SqlParameter { ParameterName = "@pCafeteria", SqlDbType = SqlDbType.Bit, Value = servicio.Cafeteria });
                parametros.Add(new SqlParameter { ParameterName = "@pServicioOtro", SqlDbType = SqlDbType.Bit, Value = servicio.ServicioOtro });
                parametros.Add(new SqlParameter { ParameterName = "@pServicioOtroDescripcion", SqlDbType = SqlDbType.NVarChar, Value = (object)servicio.ServicioOtroDescripcion ?? DBNull.Value });

                parametros.Add(new SqlParameter { ParameterName = "@pLugarTraslado", SqlDbType = SqlDbType.NVarChar, Value = (object)servicio.LugarTraslado ?? DBNull.Value });
                parametros.Add(new SqlParameter { ParameterName = "@pDestinoFinal", SqlDbType = SqlDbType.NVarChar, Value = (object)servicio.DestinoFinal ?? DBNull.Value });
                parametros.Add(new SqlParameter { ParameterName = "@pFechaServicio", SqlDbType = SqlDbType.Date, Value = servicio.FechaServicio.HasValue ? (object)servicio.FechaServicio.Value : DBNull.Value });
                parametros.Add(new SqlParameter { ParameterName = "@pHoraServicio", SqlDbType = SqlDbType.Time, Value = servicio.HoraServicio.HasValue ? (object)servicio.HoraServicio.Value : DBNull.Value });
                parametros.Add(new SqlParameter { ParameterName = "@pTipoServicio", SqlDbType = SqlDbType.VarChar, Value = (object)servicio.TipoServicio ?? DBNull.Value });
                parametros.Add(new SqlParameter { ParameterName = "@pCapillaSala", SqlDbType = SqlDbType.NVarChar, Value = (object)servicio.CapillaSala ?? DBNull.Value });
                parametros.Add(new SqlParameter { ParameterName = "@pTiempoEstimado", SqlDbType = SqlDbType.NVarChar, Value = (object)servicio.TiempoEstimado ?? DBNull.Value });

                parametros.Add(new SqlParameter { ParameterName = "@pCostoTotal", SqlDbType = SqlDbType.Decimal, Value = servicio.CostoTotal });
                parametros.Add(new SqlParameter { ParameterName = "@pAnticipo", SqlDbType = SqlDbType.Decimal, Value = servicio.Anticipo });
                parametros.Add(new SqlParameter { ParameterName = "@pFormaPago", SqlDbType = SqlDbType.VarChar, Value = (object)servicio.FormaPago ?? DBNull.Value });
                parametros.Add(new SqlParameter { ParameterName = "@pObservaciones", SqlDbType = SqlDbType.NVarChar, Value = (object)servicio.Observaciones ?? DBNull.Value });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = SqlDbType.Int, Value = servicio.Usuario.HasValue ? (object)servicio.Usuario.Value : DBNull.Value });

                DataSet ds = dac.Fill("FUN_ServiciosFunerarios_Insert", parametros);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        idServicio = int.Parse(dr["Id"].ToString());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return idServicio;
        }

        public List<ServicioFunerarioModel> GetServicioFunerarioById(int id)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<ServicioFunerarioModel>();

            parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = id });

            try
            {
                DataSet ds = dac.Fill("FUN_ServiciosFunerarios_GetById", parametros);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new ServicioFunerarioModel
                        {
                            Id = SafeInt(dr["Id"]),
                            ResponsableNombre = SafeString(dr["ResponsableNombre"]),
                            ResponsableParentesco = SafeString(dr["ResponsableParentesco"]),
                            ResponsableTelefono = SafeString(dr["ResponsableTelefono"]),
                            ResponsableCorreo = SafeString(dr["ResponsableCorreo"]),
                            ResponsableDomicilio = SafeString(dr["ResponsableDomicilio"]),
                            ResponsableColonia = SafeString(dr["ResponsableColonia"]),
                            ResponsableCiudad = SafeString(dr["ResponsableCiudad"]),
                            ResponsableCP = SafeString(dr["ResponsableCP"]),
                            ResponsableTipoIdentificacion = SafeString(dr["ResponsableTipoIdentificacion"]),
                            ResponsableOtraIdentificacion = SafeString(dr["ResponsableOtraIdentificacion"]),
                            ResponsableNumeroIdentificacion = SafeString(dr["ResponsableNumeroIdentificacion"]),

                            FallecidoNombre = SafeString(dr["FallecidoNombre"]),
                            FallecidoEdad = SafeNullableInt(dr["FallecidoEdad"]),
                            FallecidoFechaNacimiento = SafeNullableDate(dr["FallecidoFechaNacimiento"]),
                            FallecidoFechaDefuncion = SafeNullableDate(dr["FallecidoFechaDefuncion"]),
                            FallecidoLugarTipo = SafeString(dr["FallecidoLugarTipo"]),
                            FallecidoLugarOtro = SafeString(dr["FallecidoLugarOtro"]),
                            FallecidoHospitalLugar = SafeString(dr["FallecidoHospitalLugar"]),
                            FallecidoCiudad = SafeString(dr["FallecidoCiudad"]),

                            TrasladoLocal = SafeBool(dr["TrasladoLocal"]),
                            TrasladoForaneo = SafeBool(dr["TrasladoForaneo"]),
                            PreparacionEstetica = SafeBool(dr["PreparacionEstetica"]),
                            Embalsamado = SafeBool(dr["Embalsamado"]),
                            Ataud = SafeBool(dr["Ataud"]),
                            SalaVelacion = SafeBool(dr["SalaVelacion"]),
                            Cremacion = SafeBool(dr["Cremacion"]),
                            Inhumacion = SafeBool(dr["Inhumacion"]),
                            Carroza = SafeBool(dr["Carroza"]),
                            GestionTramites = SafeBool(dr["GestionTramites"]),
                            Cafeteria = SafeBool(dr["Cafeteria"]),
                            ServicioOtro = SafeBool(dr["ServicioOtro"]),
                            ServicioOtroDescripcion = SafeString(dr["ServicioOtroDescripcion"]),

                            LugarTraslado = SafeString(dr["LugarTraslado"]),
                            DestinoFinal = SafeString(dr["DestinoFinal"]),
                            FechaServicio = SafeNullableDate(dr["FechaServicio"]),
                            HoraServicio = SafeNullableTime(dr["HoraServicio"]),
                            TipoServicio = SafeString(dr["TipoServicio"]),
                            CapillaSala = SafeString(dr["CapillaSala"]),
                            TiempoEstimado = SafeString(dr["TiempoEstimado"]),

                            CostoTotal = SafeDecimal(dr["CostoTotal"]),
                            Anticipo = SafeDecimal(dr["Anticipo"]),
                            Saldo = SafeDecimal(dr["Saldo"]),
                            FormaPago = SafeString(dr["FormaPago"]),
                            Observaciones = SafeString(dr["Observaciones"]),

                            FechaRegistro = SafeString(dr["FechaRegistro"]),
                            UsuarioRegistro = SafeNullableInt(dr["UsuarioRegistro"]),
                            FechaModificacion = SafeString(dr["FechaModificacion"]),
                            UsuarioModificacion = SafeNullableInt(dr["UsuarioModificacion"]),
                            Estatus = SafeInt(dr["Estatus"]),
                            FechaFormato = SafeString(dr["fecha_servicio_format"])
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
                            FechaActualizacion = dr["FechaActualizacion"].ToString(),
                            DescripcionTipo = dr["TipoCertificado"].ToString(),
                            TotalAbonado = decimal.Parse(dr["TotalAbonado"].ToString()),
                            SaldoPendiente = decimal.Parse(dr["Restante"].ToString()),
                            AbonoVencido = int.Parse(dr["AbonoVencido"].ToString()),
                            FechaUltimoAbono = dr["FechaBaseVencimiento"].ToString(),
                            DireccionCliente = dr["DireccionCliente"].ToString(),
                            TelefonoCliente = dr["TelefonoCliente"].ToString(),

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
                            FechaActualizacion = dr["FechaActualizacion"].ToString(),
                            VendedorNombre = dr["nombre"].ToString(),
                            DireccionCliente = dr["DireccionCliente"].ToString(),
                            TelefonoCliente = dr["TelefonoCliente"].ToString()
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

        public int DeleteCertificadoById(int id)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);

            parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = id });

            try
            {
                dac.ExecuteNonQuery("Certificados_DeleteById", parametros);
            }
            catch (Exception)
            {
                throw;
            }

            return id;
        }

        public CertificadoUpdateResponse UpdateCertificado(UpdateCertificadoModel certificado)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var response = new CertificadoUpdateResponse();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = certificado.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pFolio", SqlDbType = SqlDbType.Int, Value = certificado.Folio });
                parametros.Add(new SqlParameter { ParameterName = "@pIdVendedor", SqlDbType = SqlDbType.Int, Value = certificado.IdVendedor });
                parametros.Add(new SqlParameter { ParameterName = "@pNombreCliente", SqlDbType = SqlDbType.VarChar, Value = certificado.NombreCliente });
                parametros.Add(new SqlParameter { ParameterName = "@pValorPaquete", SqlDbType = SqlDbType.Decimal, Value = certificado.ValorPaquete });
                parametros.Add(new SqlParameter { ParameterName = "@pPagoInicial", SqlDbType = SqlDbType.Decimal, Value = certificado.PagoInicial });
                parametros.Add(new SqlParameter { ParameterName = "@pMontoMensualidad", SqlDbType = SqlDbType.Decimal, Value = certificado.MontoMensualidad });
                parametros.Add(new SqlParameter { ParameterName = "@pEstatus", SqlDbType = SqlDbType.Int, Value = certificado.Estatus });
                parametros.Add(new SqlParameter { ParameterName = "@pDireccion", SqlDbType = SqlDbType.VarChar, Value = certificado.DireccionCliente });
                parametros.Add(new SqlParameter { ParameterName = "@pTelefono", SqlDbType = SqlDbType.VarChar, Value = certificado.TelefonoCliente });

                DataSet ds = dac.Fill("Certificados_Update", parametros);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        response.Mensaje = dr["mensaje"].ToString();
                        response.IdCertificado = int.Parse(dr["id_certificado"].ToString());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return response;
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

        public List<CertificadoAbonoDetalleModel> GetAbonoCertificadoById(int id)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<CertificadoAbonoDetalleModel>();

            parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = id });

            try
            {
                DataSet ds = dac.Fill("GetAbonoCertificadoById", parametros);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new CertificadoAbonoDetalleModel
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            IdCertificado = int.Parse(dr["IdCertificado"].ToString()),
                            FolioCertificado = int.Parse(dr["FolioCertificado"].ToString()),
                            NombreCliente = dr["NombreCliente"].ToString(),
                            ValorPaquete = decimal.Parse(dr["ValorPaquete"].ToString()),
                            PagoInicial = decimal.Parse(dr["PagoInicial"].ToString()),
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
                            FechaActualizacion = dr["FechaActualizacion"].ToString(),
                            TotalAbonado = decimal.Parse(dr["TotalAbonado"].ToString()),
                            RestanteCertificado = decimal.Parse(dr["RestanteCertificado"].ToString())
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

        public List<CertificadoAbonoReporteModel> GetReporteAbonos(string fechaInicial, string fechaFinal)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<CertificadoAbonoReporteModel>();

            parametros.Add(new SqlParameter { ParameterName = "@pFechaInicial", SqlDbType = SqlDbType.VarChar, Value = fechaInicial });
            parametros.Add(new SqlParameter { ParameterName = "@pFechaFinal", SqlDbType = SqlDbType.VarChar, Value = fechaFinal });

            try
            {
                DataSet ds = dac.Fill("CertificadosAbonos_GetReporte", parametros);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new CertificadoAbonoReporteModel
                        {
                            IdAbono = int.Parse(dr["IdAbono"].ToString()),
                            IdCertificado = int.Parse(dr["IdCertificado"].ToString()),
                            FolioCertificado = int.Parse(dr["FolioCertificado"].ToString()),
                            FolioAbono = int.Parse(dr["FolioAbono"].ToString()),
                            FechaAbono = dr["FechaAbono"].ToString(),
                            NombreCliente = dr["NombreCliente"].ToString(),
                            IdVendedor = int.Parse(dr["IdVendedor"].ToString()),
                            ValorPaquete = decimal.Parse(dr["ValorPaquete"].ToString()),
                            PagoInicial = decimal.Parse(dr["PagoInicial"].ToString()),
                            MontoAbono = decimal.Parse(dr["MontoAbono"].ToString()),
                            FormaPago = int.Parse(dr["FormaPago"].ToString()),
                            FormaPagoDescripcion = dr["FormaPagoDescripcion"].ToString(),
                            Referencia = dr["Referencia"].ToString(),
                            Observaciones = dr["Observaciones"].ToString(),
                            IdUsuario = string.IsNullOrWhiteSpace(dr["IdUsuario"].ToString()) ? null : (int?)int.Parse(dr["IdUsuario"].ToString()),
                            TipoCertificado = int.Parse(dr["TipoCertificado"].ToString()),
                            TipoCertificadoDescripcion = dr["TipoCertificadoDescripcion"].ToString(),
                            EstatusAbono = int.Parse(dr["EstatusAbono"].ToString()),
                            EstatusAbonoDescripcion = dr["EstatusAbonoDescripcion"].ToString(),
                            TotalAbonadoCertificado = decimal.Parse(dr["TotalAbonadoCertificado"].ToString()),
                            RestanteCertificado = decimal.Parse(dr["RestanteCertificado"].ToString())
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

        public List<CertificadoCarteraVencidaModel> GetCarteraVencida()
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<CertificadoCarteraVencidaModel>();

            try
            {
                DataSet ds = dac.Fill("Certificados_GetCarteraVencida");
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new CertificadoCarteraVencidaModel
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            Folio = int.Parse(dr["Folio"].ToString()),
                            NombreCliente = dr["NombreCliente"].ToString(),
                            FechaRegistro = dr["FechaRegistro"].ToString(),
                            PagoInicial = decimal.Parse(dr["PagoInicial"].ToString()),
                            MontoMensualidad = decimal.Parse(dr["MontoMensualidad"].ToString()),
                            TotalAbonos = decimal.Parse(dr["TotalAbonos"].ToString()),
                            TotalPagado = decimal.Parse(dr["TotalPagado"].ToString()),
                            FechaUltimoAbono = dr["FechaUltimoAbono"].ToString(),
                            CantidadMovimientosAbono = int.Parse(dr["CantidadMovimientosAbono"].ToString()),
                            MensualidadesEsperadas = int.Parse(dr["MensualidadesEsperadas"].ToString()),
                            MensualidadesCubiertas = int.Parse(dr["MensualidadesCubiertas"].ToString()),
                            AbonoParcialMensualidad = decimal.Parse(dr["AbonoParcialMensualidad"].ToString()),
                            ImporteEsperado = decimal.Parse(dr["ImporteEsperado"].ToString()),
                            MontoVencido = decimal.Parse(dr["MontoVencido"].ToString()),
                            MensualidadesVencidas = int.Parse(dr["MensualidadesVencidas"].ToString()),
                            FechaPrimerVencimientoPendiente = dr["FechaPrimerVencimientoPendiente"].ToString(),
                            DiasVencidos = int.Parse(dr["DiasVencidos"].ToString()),
                            PendienteMensualidadMasAntigua = decimal.Parse(dr["PendienteMensualidadMasAntigua"].ToString())
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

        public byte[] GenerarCertificadoPdf(int idCertificado)
        {
            var certificados = GetCertificadoById(idCertificado);
            if (certificados.Count == 0)
            {
                throw new Exception("No se encontró el certificado solicitado.");
            }

            var certificado = certificados[0];
            var estadoCuenta = GetEstadoCuentaCertificado(idCertificado);
            var estado = estadoCuenta.Count > 0 ? estadoCuenta[0] : null;

            string rutaPlantilla = Path.Combine(Directory.GetCurrentDirectory(), "Certificado_Capillas_del_Bosque.pdf");
            if (!File.Exists(rutaPlantilla))
            {
                throw new Exception("No se encontró la plantilla del certificado.");
            }

            using var outputStream = new MemoryStream();
            using var reader = new PdfReader(rutaPlantilla);
            using var writer = new PdfWriter(outputStream);
            using var pdfDocument = new PdfDocument(reader, writer);

            bool informacionInsertada = false;
            var acroForm = PdfAcroForm.GetAcroForm(pdfDocument, false);
            if (acroForm != null)
            {
                var fields = acroForm.GetAllFormFields();
                if (fields != null && fields.Count > 0)
                {
                    informacionInsertada = true;

                    SetFirstExistingField(fields, certificado.Folio.ToString(), "folio", "nofolio", "numerofolio");
                    SetFirstExistingField(fields, certificado.NombreCliente, "nombrecliente", "cliente", "nombre");
                    SetFirstExistingField(fields, certificado.IdVendedor.ToString(), "idvendedor", "vendedor");
                    SetFirstExistingField(fields, FormatCurrency(certificado.ValorPaquete), "valorpaquete", "totalpaquete", "paquete");
                    SetFirstExistingField(fields, FormatCurrency(certificado.PagoInicial), "pagoinicial", "enganche");
                    SetFirstExistingField(fields, FormatCurrency(certificado.MontoMensualidad), "montomensualidad", "mensualidad");
                    SetFirstExistingField(fields, estado != null ? FormatCurrency(estado.TotalAbonado) : "0.00", "totalabonado", "abonado");
                    SetFirstExistingField(fields, estado != null ? FormatCurrency(estado.SaldoPendiente) : "0.00", "saldopendiente", "saldo");
                    SetFirstExistingField(fields, estado != null ? estado.EstatusDescripcion : certificado.Estatus.ToString(), "estatus", "estatusdescripcion");
                    SetFirstExistingField(fields, certificado.FechaRegistro, "fecharegistro", "fecha");
                    SetFirstExistingField(fields, certificado.FechaActualizacion, "fechaactualizacion");

                    acroForm.FlattenFields();
                }
            }

            if (!informacionInsertada)
            {
                var page = pdfDocument.GetFirstPage();
                var canvas = new Canvas(new PdfCanvas(page), page.GetPageSize());
                var font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                canvas.SetFont(font).SetFontSize(11);
                canvas.ShowTextAligned(" " + certificado.Folio, 260, 545, TextAlignment.LEFT);
                canvas.ShowTextAligned(" " + certificado.NombreCliente, 130, 430, TextAlignment.LEFT);
                canvas.ShowTextAligned(" " + certificado.VendedorNombre, 130, 380, TextAlignment.LEFT);
                canvas.ShowTextAligned(" " + FormatCurrency(certificado.ValorPaquete), 150, 270, TextAlignment.LEFT);
                canvas.ShowTextAligned(" " + FormatCurrency(certificado.PagoInicial), 310, 270, TextAlignment.LEFT);
                canvas.ShowTextAligned(" " + FormatCurrency(certificado.MontoMensualidad), 480, 270, TextAlignment.LEFT);
                canvas.ShowTextAligned(" " + certificado.FechaRegistro, 110, 155, TextAlignment.LEFT);
                canvas.ShowTextAligned("INDEFINIDO " , 250, 155, TextAlignment.LEFT);
                canvas.Close();
            }

            pdfDocument.Close();
            return outputStream.ToArray();
        }

        public byte[] GenerarCertificadoInmediatoPdf(int idServicio)
        {
            var servicios = GetServicioFunerarioById(idServicio);
            if (servicios.Count == 0)
            {
                throw new Exception("No se encontró el servicio funerario solicitado.");
            }

            var servicio = servicios[0];

            string rutaPlantilla = Path.Combine(Directory.GetCurrentDirectory(), "Formato_Servicio_Uso_Inmediato_Capillas_del_Bosque.pdf");
            if (!File.Exists(rutaPlantilla))
            {
                throw new Exception("No se encontró la plantilla del certificado inmediato.");
            }

            using var outputStream = new MemoryStream();
            using var reader = new PdfReader(rutaPlantilla);
            using var writer = new PdfWriter(outputStream);
            using var pdfDocument = new PdfDocument(reader, writer);

            bool informacionInsertada = false;
            var acroForm = PdfAcroForm.GetAcroForm(pdfDocument, false);
            if (acroForm != null)
            {
                var fields = acroForm.GetAllFormFields();
                if (fields != null && fields.Count > 0)
                {
                    informacionInsertada = true;

                    SetFirstExistingField(fields, servicio.Id.ToString(), "id", "folio", "numero");

                    SetFirstExistingField(fields, servicio.ResponsableNombre, "responsablenombre", "nombre_responsable", "responsable");
                    SetFirstExistingField(fields, servicio.ResponsableParentesco, "responsableparentesco", "parentesco");
                    SetFirstExistingField(fields, servicio.ResponsableTelefono, "responsabletelefono", "telefono_responsable", "telefono");
                    SetFirstExistingField(fields, servicio.ResponsableCorreo, "responsablecorreo", "correo_responsable", "correo");
                    SetFirstExistingField(fields, servicio.ResponsableDomicilio, "responsabledomicilio", "domicilio_responsable", "domicilio");
                    SetFirstExistingField(fields, servicio.ResponsableColonia, "responsablecolonia", "colonia");
                    SetFirstExistingField(fields, servicio.ResponsableCiudad, "responsableciudad", "ciudad_responsable", "ciudad");
                    SetFirstExistingField(fields, servicio.ResponsableCP, "responsablecp", "cp_responsable", "cp");
                    SetFirstExistingField(fields, servicio.ResponsableTipoIdentificacion, "responsabletipoidentificacion", "tipoidentificacion");
                    SetFirstExistingField(fields, servicio.ResponsableOtraIdentificacion, "responsableotraidentificacion", "otraidentificacion");
                    SetFirstExistingField(fields, servicio.ResponsableNumeroIdentificacion, "responsablenumeroidentificacion", "numeroidentificacion");

                    SetFirstExistingField(fields, servicio.FallecidoNombre, "fallecidonombre", "nombre_fallecido");
                    SetFirstExistingField(fields, servicio.FallecidoEdad.HasValue ? servicio.FallecidoEdad.Value.ToString() : string.Empty, "fallecidoedad", "edad");
                    SetFirstExistingField(fields, FormatDate(servicio.FallecidoFechaNacimiento), "fallecidofechanacimiento", "fecha_nacimiento");
                    SetFirstExistingField(fields, FormatDate(servicio.FallecidoFechaDefuncion), "fallecidofechadefuncion", "fecha_defuncion");
                    SetFirstExistingField(fields, servicio.FallecidoLugarTipo, "fallecidolugartipo", "lugar_tipo");
                    SetFirstExistingField(fields, servicio.FallecidoLugarOtro, "fallecidolugarotro", "lugar_otro");
                    SetFirstExistingField(fields, servicio.FallecidoHospitalLugar, "fallecidohospitalluguar", "hospital_lugar", "hospital");
                    SetFirstExistingField(fields, servicio.FallecidoCiudad, "fallecidociudad", "ciudad_fallecido");

                    SetFirstExistingField(fields, servicio.TrasladoLocal ? "X" : string.Empty, "trasladolocal");
                    SetFirstExistingField(fields, servicio.TrasladoForaneo ? "X" : string.Empty, "trasladoforaneo");
                    SetFirstExistingField(fields, servicio.PreparacionEstetica ? "X" : string.Empty, "preparacionestetica");
                    SetFirstExistingField(fields, servicio.Embalsamado ? "X" : string.Empty, "embalsamado");
                    SetFirstExistingField(fields, servicio.Ataud ? "X" : string.Empty, "ataud");
                    SetFirstExistingField(fields, servicio.SalaVelacion ? "X" : string.Empty, "salavelacion");
                    SetFirstExistingField(fields, servicio.Cremacion ? "X" : string.Empty, "cremacion");
                    SetFirstExistingField(fields, servicio.Inhumacion ? "X" : string.Empty, "inhumacion");
                    SetFirstExistingField(fields, servicio.Carroza ? "X" : string.Empty, "carroza");
                    SetFirstExistingField(fields, servicio.GestionTramites ? "X" : string.Empty, "gestiontramites");
                    SetFirstExistingField(fields, servicio.Cafeteria ? "X" : string.Empty, "cafeteria");
                    SetFirstExistingField(fields, servicio.ServicioOtro ? "X" : string.Empty, "serviciootro");
                    SetFirstExistingField(fields, servicio.ServicioOtroDescripcion, "serviciootrodescripcion", "otroserviciodescripcion");

                    SetFirstExistingField(fields, servicio.LugarTraslado, "lugartraslado");
                    SetFirstExistingField(fields, servicio.DestinoFinal, "destinofinal");
                    SetFirstExistingField(fields, FormatDate(servicio.FechaServicio), "fechaservicio");
                    SetFirstExistingField(fields, FormatTime(servicio.HoraServicio), "horaservicio");
                    SetFirstExistingField(fields, servicio.TipoServicio, "tiposervicio");
                    SetFirstExistingField(fields, servicio.CapillaSala, "capillasala");
                    SetFirstExistingField(fields, servicio.TiempoEstimado, "tiempoestimado");

                    SetFirstExistingField(fields, FormatCurrency(servicio.CostoTotal), "costototal");
                    SetFirstExistingField(fields, FormatCurrency(servicio.Anticipo), "anticipo");
                    SetFirstExistingField(fields, FormatCurrency(servicio.Saldo), "saldo");
                    SetFirstExistingField(fields, servicio.FormaPago, "formapago");

                    SetFirstExistingField(fields, servicio.Observaciones, "observaciones");
                    SetFirstExistingField(fields, servicio.FechaRegistro, "fecharegistro", "fecha_registro");

                    acroForm.FlattenFields();
                }
            }

            if (!informacionInsertada)
            {
                var page = pdfDocument.GetFirstPage();
                var canvas = new Canvas(new PdfCanvas(page), page.GetPageSize());
                var font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                canvas.SetFont(font).SetFontSize(20);
                canvas.ShowTextAligned(servicio.Id.ToString(), 850, 1370, TextAlignment.LEFT);
                var fechaActual = DateTime.Now.ToString("dd/MM/yyyy");
                var partesFechaActual = fechaActual.Split('/');
                var fechaActualDia = partesFechaActual.Length > 0 ? partesFechaActual[0] : string.Empty;
                var fechaActualMes = partesFechaActual.Length > 1 ? partesFechaActual[1] : string.Empty;
                var fechaActualAnio = partesFechaActual.Length > 2 ? partesFechaActual[2] : string.Empty;

                canvas.ShowTextAligned(fechaActualDia, 790, 1330, TextAlignment.LEFT);// FECHA ACTUAL DIA
                canvas.ShowTextAligned(fechaActualMes, 860, 1330, TextAlignment.LEFT);// FECHA ACTUAL MES
                canvas.ShowTextAligned(fechaActualAnio, 930, 1330, TextAlignment.LEFT);// FECHA ACTUAL ANIO
                canvas.ShowTextAligned(DateTime.Now.ToString("HH:mm"), 850, 1290, TextAlignment.LEFT);//HORA ACTUAL
                canvas.ShowTextAligned( (servicio.ResponsableNombre ?? string.Empty), 200, 1220, TextAlignment.LEFT);
                canvas.ShowTextAligned( (servicio.ResponsableTelefono ?? string.Empty), 200, 1170, TextAlignment.LEFT);
                canvas.ShowTextAligned( (servicio.ResponsableParentesco ?? string.Empty), 850, 1210, TextAlignment.LEFT);
                canvas.ShowTextAligned( (servicio.ResponsableCorreo ?? string.Empty), 650, 1170, TextAlignment.LEFT);
                canvas.ShowTextAligned( (servicio.ResponsableDomicilio ?? string.Empty), 300, 1130, TextAlignment.LEFT);
                canvas.ShowTextAligned( (servicio.ResponsableColonia ?? string.Empty), 200, 1090, TextAlignment.LEFT);
                canvas.ShowTextAligned(servicio.ResponsableTipoIdentificacion == "INE" ? "X" : string.Empty, 265, 1045, TextAlignment.LEFT);// este representa INE
                canvas.ShowTextAligned(servicio.ResponsableTipoIdentificacion == "PASAPORTE" ? "X" : string.Empty, 355, 1045, TextAlignment.LEFT);// este representa PASAPORTE
                canvas.ShowTextAligned(servicio.ResponsableTipoIdentificacion == "OTRO" ? "X" : string.Empty, 485, 1045, TextAlignment.LEFT);// este representa OTRO
                canvas.ShowTextAligned( (servicio.ResponsableCiudad ?? string.Empty), 500, 1090, TextAlignment.LEFT);
                canvas.ShowTextAligned( (servicio.ResponsableCP ?? string.Empty), 800, 1090, TextAlignment.LEFT);
                canvas.ShowTextAligned( (servicio.ResponsableNumeroIdentificacion ?? string.Empty), 800, 1050, TextAlignment.LEFT);



                canvas.ShowTextAligned((servicio.FallecidoNombre ?? string.Empty), 200, 930, TextAlignment.LEFT);
                canvas.ShowTextAligned((servicio.FallecidoEdad.ToString() ?? string.Empty), 870, 930, TextAlignment.LEFT);
                canvas.ShowTextAligned((servicio.FallecidoFechaNacimiento.ToString() ?? string.Empty), 215, 885, TextAlignment.LEFT);
                canvas.ShowTextAligned((servicio.FallecidoFechaDefuncion.ToString() ?? string.Empty), 700, 890, TextAlignment.LEFT);
                canvas.ShowTextAligned((servicio.FallecidoHospitalLugar ?? string.Empty), 200, 800, TextAlignment.LEFT);
                canvas.ShowTextAligned((servicio.FallecidoCiudad ?? string.Empty), 800, 800, TextAlignment.LEFT);
                var fallecidoLugarTipo = (servicio.FallecidoLugarTipo ?? string.Empty).Trim().ToUpperInvariant();
                canvas.ShowTextAligned(fallecidoLugarTipo == "HOSPITAL" ? "X" : string.Empty, 270, 835, TextAlignment.LEFT);// este representa HOSPITAL
                canvas.ShowTextAligned(fallecidoLugarTipo == "DOMICILIO" ? "X" : string.Empty, 400, 835, TextAlignment.LEFT);// este representa DOMICILIO
                canvas.ShowTextAligned(fallecidoLugarTipo == "VIA PUBLICA" ? "X" : string.Empty, 535, 835, TextAlignment.LEFT);// este representa VIA PUBLICA


                canvas.ShowTextAligned(servicio.TrasladoLocal ? "X" : string.Empty, 55, 685, TextAlignment.LEFT);// este representa TRASLADO LOCAL
                canvas.ShowTextAligned(servicio.TrasladoForaneo ? "X" : string.Empty, 55, 655, TextAlignment.LEFT);// este representa TRASLADO FORANEO
                canvas.ShowTextAligned(servicio.PreparacionEstetica ? "X" : string.Empty, 55, 620, TextAlignment.LEFT);// este representa PREPARACION ESTETICA
                canvas.ShowTextAligned(servicio.Embalsamado ? "X" : string.Empty, 55, 590, TextAlignment.LEFT);// este representa EMBALSAMADO
                canvas.ShowTextAligned(servicio.Ataud ? "X" : string.Empty, 385, 685, TextAlignment.LEFT);// este representa ATAUD
                canvas.ShowTextAligned(servicio.SalaVelacion ? "X" : string.Empty, 385, 655, TextAlignment.LEFT);// este representa SALA DE VELACION
                canvas.ShowTextAligned(servicio.Cremacion ? "X" : string.Empty, 385, 620, TextAlignment.LEFT);// este representa CREMACION
                canvas.ShowTextAligned(servicio.Inhumacion ? "X" : string.Empty, 385, 590, TextAlignment.LEFT);// este representa INHUMACION
                canvas.ShowTextAligned(servicio.Carroza ? "X" : string.Empty, 685, 685, TextAlignment.LEFT);// este representa CARROZA
                canvas.ShowTextAligned(servicio.GestionTramites ? "X" : string.Empty, 685, 655, TextAlignment.LEFT);// este representa GESTION DE TRAMITES
                canvas.ShowTextAligned(servicio.Cafeteria ? "X" : string.Empty, 685, 620, TextAlignment.LEFT);// este representa CAFETERIA
                canvas.ShowTextAligned(servicio.ServicioOtro ? "X" : string.Empty, 685, 590, TextAlignment.LEFT);// este representa OTROS 

                canvas.ShowTextAligned((servicio.LugarTraslado ?? string.Empty), 200, 480, TextAlignment.LEFT);
                canvas.ShowTextAligned((servicio.DestinoFinal ?? string.Empty), 200, 445, TextAlignment.LEFT);
                canvas.ShowTextAligned((servicio.CapillaSala ?? string.Empty), 700, 430, TextAlignment.LEFT);
                canvas.ShowTextAligned((servicio.TiempoEstimado ?? string.Empty), 850, 390, TextAlignment.LEFT);

                canvas.ShowTextAligned(servicio.TipoServicio == "INMEDIATO" ? "X" : string.Empty, 615, 490, TextAlignment.LEFT);// este representa SERVICIO INMEDIATO
                canvas.ShowTextAligned(servicio.TipoServicio == "PROGRAMADO" ? "X" : string.Empty, 795, 490, TextAlignment.LEFT);// este representa SERVICIO PROGRAMADO
                var fechaFormato = servicio.FechaFormato ?? string.Empty;
                var partesFecha = fechaFormato.Split('/');
                var fechaDia = partesFecha.Length > 0 ? partesFecha[0] : string.Empty;
                var fechaMes = partesFecha.Length > 1 ? partesFecha[1] : string.Empty;
                var fechaAnio = partesFecha.Length > 2 ? partesFecha[2] : string.Empty;

                canvas.ShowTextAligned(fechaDia, 200, 400, TextAlignment.LEFT);
                canvas.ShowTextAligned(fechaMes, 250, 400, TextAlignment.LEFT);
                canvas.ShowTextAligned(fechaAnio, 300, 400, TextAlignment.LEFT);
                canvas.ShowTextAligned((servicio.HoraServicio.ToString() ?? string.Empty), 475, 400, TextAlignment.LEFT);






                canvas.ShowTextAligned(FormatCurrency(servicio.CostoTotal), 160, 300, TextAlignment.LEFT);
                canvas.ShowTextAligned(servicio.FormaPago == "EFECTIVO" ? "X" : string.Empty, 330, 300, TextAlignment.LEFT);//EFECTIVO
                canvas.ShowTextAligned(servicio.FormaPago == "TRANSFERENCIA" ? "X" : string.Empty, 330, 275, TextAlignment.LEFT);//TRANSFERENCIA
                canvas.ShowTextAligned(servicio.FormaPago == "TARJETA" ? "X" : string.Empty, 330, 255, TextAlignment.LEFT);//TARJETA
                canvas.ShowTextAligned(servicio.FormaPago == "CREDITO" ? "X" : string.Empty, 330, 230, TextAlignment.LEFT);//CREDITO
                canvas.ShowTextAligned((servicio.Observaciones ?? string.Empty), 550, 300, TextAlignment.LEFT);
                
                canvas.ShowTextAligned( FormatCurrency(servicio.Anticipo), 160, 270, TextAlignment.LEFT);
                canvas.ShowTextAligned(FormatCurrency(servicio.Saldo), 160, 240, TextAlignment.LEFT);
                canvas.Close();
            }

            pdfDocument.Close();
            return outputStream.ToArray();
        }

        private static string FormatCurrency(decimal amount)
        {
            return amount.ToString("N2");
        }

        private static string FormatDate(DateTime? date)
        {
            return date.HasValue ? date.Value.ToString("yyyy-MM-dd") : string.Empty;
        }

        private static string FormatTime(TimeSpan? time)
        {
            return time.HasValue ? time.Value.ToString(@"hh\:mm\:ss") : string.Empty;
        }

        private static void SetFirstExistingField(IDictionary<string, PdfFormField> fields, string value, params string[] aliases)
        {
            foreach (var alias in aliases)
            {
                var targetField = fields.FirstOrDefault(x => NormalizeFieldName(x.Key) == NormalizeFieldName(alias));
                if (!string.IsNullOrWhiteSpace(targetField.Key))
                {
                    targetField.Value.SetValue(value ?? string.Empty);
                    return;
                }
            }
        }

        private static string NormalizeFieldName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return string.Empty;
            }

            return name
                .Trim()
                .Replace("_", string.Empty)
                .Replace("-", string.Empty)
                .Replace(" ", string.Empty)
                .ToLowerInvariant();
        }

        private static string SafeString(object value)
        {
            return value == null || value == DBNull.Value ? string.Empty : value.ToString();
        }

        private static int SafeInt(object value)
        {
            if (value == null || value == DBNull.Value)
            {
                return 0;
            }

            if (value is int intValue)
            {
                return intValue;
            }

            return int.TryParse(value.ToString(), out var parsed) ? parsed : 0;
        }

        private static int? SafeNullableInt(object value)
        {
            if (value == null || value == DBNull.Value)
            {
                return null;
            }

            if (value is int intValue)
            {
                return intValue;
            }

            var raw = value.ToString();
            if (string.IsNullOrWhiteSpace(raw))
            {
                return null;
            }

            return int.TryParse(raw, out var parsed) ? parsed : null;
        }

        private static decimal SafeDecimal(object value)
        {
            if (value == null || value == DBNull.Value)
            {
                return 0m;
            }

            if (value is decimal decimalValue)
            {
                return decimalValue;
            }

            var raw = value.ToString();
            if (string.IsNullOrWhiteSpace(raw))
            {
                return 0m;
            }

            raw = raw.Trim();
            if (raw.StartsWith(".", StringComparison.Ordinal))
            {
                raw = "0" + raw;
            }

            if (decimal.TryParse(raw, NumberStyles.Any, CultureInfo.InvariantCulture, out var parsedInvariant))
            {
                return parsedInvariant;
            }

            if (decimal.TryParse(raw, NumberStyles.Any, CultureInfo.CurrentCulture, out var parsedCurrent))
            {
                return parsedCurrent;
            }

            return 0m;
        }

        private static DateTime? SafeNullableDate(object value)
        {
            if (value == null || value == DBNull.Value)
            {
                return null;
            }

            if (value is DateTime dateValue)
            {
                return dateValue;
            }

            var raw = value.ToString();
            if (string.IsNullOrWhiteSpace(raw))
            {
                return null;
            }

            return DateTime.TryParse(raw, out var parsed) ? parsed : null;
        }

        private static TimeSpan? SafeNullableTime(object value)
        {
            if (value == null || value == DBNull.Value)
            {
                return null;
            }

            if (value is TimeSpan timeValue)
            {
                return timeValue;
            }

            var raw = value.ToString();
            if (string.IsNullOrWhiteSpace(raw))
            {
                return null;
            }

            return TimeSpan.TryParse(raw, out var parsed) ? parsed : null;
        }

        private static bool SafeBool(object value)
        {
            if (value == null || value == DBNull.Value)
            {
                return false;
            }

            if (value is bool boolValue)
            {
                return boolValue;
            }

            var raw = value.ToString();
            if (string.IsNullOrWhiteSpace(raw))
            {
                return false;
            }

            if (bool.TryParse(raw, out var parsedBool))
            {
                return parsedBool;
            }

            if (int.TryParse(raw, out var parsedInt))
            {
                return parsedInt != 0;
            }

            return false;
        }
    }
}